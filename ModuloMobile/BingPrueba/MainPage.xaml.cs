
using System;
using System.Windows.Media;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

using System.Windows.Media.Imaging;
using Newtonsoft.Json;

using System.Text.RegularExpressions;

///using System.web

namespace BingPrueba
{
    public partial class MainPage : PhoneApplicationPage
    {

        // para gps
        GeoCoordinateWatcher watcher; // main location object
        bool trackingOn = false; // switches on w/button push
        Pushpin myPushpin = new Pushpin(); // marks current spot on Map
        // fin para gps

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            //// Registrar la Key del Mapa-Bing
            map1.CredentialsProvider = new ApplicationIdCredentialsProvider("AluRG7JuiEndUdqhTxuKd6FI4ta3LkzHhR-C0476HmT0w19asYmCSvuc9OAv-TIG");
        
            //// Inicializar la pantalla con ejemplo de ubicacion
            /*SharedInformation.myLatitude = -34.91;
            SharedInformation.myLongitude = -56.201;
            SharedInformation.myZoom = 16;
            this.ubicarenmapa(SharedInformation.myLatitude, SharedInformation.myLongitude, SharedInformation.myZoom);*/

            // Para GPS
            //Instatiate watcher, setting its accuracy level and movement threshold.
            watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High); // using high accuracy.
            watcher.MovementThreshold = 10.0f; // meters of change before "PositionChanged" event fires.

            // wire up event handlers
            watcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_statusChanged);
            watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);

            // start up the Location Service on app startup. watcher_StatusChanged
            // will fire when start up of LocServ is complete.
            new Thread(startLocServInBackground).Start();
            statusTextBlock.Text = "Starting Location Service...";

            this.marcarpunto(-34.91, -56.201, "bien 1");
            this.marcarpunto(-34.91, -56.202, "bien 2");

            // Fin para GPS
        }
        void startLocServInBackground()
        {
            watcher.TryStart(true, TimeSpan.FromSeconds(60));
        }
        void watcher_statusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Disabled:
                    // The Location Service is disabled or unsupported.
                    // Check to see if the user has disabled the location service.
                    if (watcher.Permission == GeoPositionPermission.Denied)
                    {
                        // the user has disabled LocServ on their device.
                        statusTextBlock.Text = "You have disabled Location Service.";
                    }
                    else
                    {
                        statusTextBlock.Text = "Location Service is not functioning on this device.";
                    }
                    break;

                case GeoPositionStatus.Initializing:
                    // The location service is initializing.
                    statusTextBlock.Text = "Location Service is retrieving data...";
                    break;

                case GeoPositionStatus.NoData:
                    // The Location Service is working, but it cannot get location data
                    // due to poor signal fidelity (most likely)
                    statusTextBlock.Text = "Location data is not available.";
                    break;

                case GeoPositionStatus.Ready:
                    // The location service is working and is receiving location data.
                    statusTextBlock.Text = "Location data is available.";
                    break;
            }
        }

        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            // update the textblock readouts.
            
            double latitudcapturada = e.Position.Location.Latitude;
            double longitudcapturada = e.Position.Location.Longitude;
            latitudeTextblock.Text = latitudcapturada.ToString("0.0000000000");
            longitudeTextblock.Text = longitudcapturada.ToString("0.0000000000");

            /*speedreadout.Text = e.Position.Location.Speed.ToString("0.0") + " meters per second";
            coursereadout.Text = e.Position.Location.Course.ToString("0.0") + " degrees";
            altitudereadout.Text = e.Position.Location.Altitude.ToString("0.0") + " meters above sea level";*/

            //// Inicializar la pantalla con ejemplo de ubicacion
            /*SharedInformation.myLatitude = -34.91;
            SharedInformation.myLongitude = -56.201;*/
            SharedInformation.myLatitude = latitudcapturada;
            SharedInformation.myLongitude = longitudcapturada;
            SharedInformation.myZoom = 16;

            ///// Invocacion a bienes cercanos
            string ServiceUri = "http://localhost:1616/ServiceMobile.svc/Rest/BienesCercanos/" + latitudcapturada.ToString().Trim() + "/" + longitudcapturada.ToString().Trim();

            WebClient proxy = new WebClient();
            proxy.DownloadStringCompleted +=
                       new DownloadStringCompletedEventHandler(proxy_DownloadStringCompleted);
            proxy.DownloadStringAsync(new Uri(ServiceUri));

            rescerc.Text = "Id: ";

            /*BingMapsDemoV1.ServiceReferenceGf.Service1Client sr = new BingMapsDemoV1.ServiceReferenceGf.Service1Client();
            string sal = "";
                   sr.ObtenerBienesCercanosAsync    
            rescerc.Text = sal;*/

            /*BingMapsDemoV1.ServiceReference1.WebServiceSoapClient cl = new BingMapsDemoV1.ServiceReference1.WebServiceSoapClient();

            BingMapsDemoV1.ServiceReference2.WebServiceSoapClient ws = new BingMapsDemoV1.ServiceReference2.WebServiceSoapClient();
            
            ws.*/

            //BingMapsDemoV1.ServiceReference1.HelloWorldRequest nb = new BingMapsDemoV1.ServiceReference1.HelloWorldRequest();
            ///cl.ImprimeMensajeAsync(

            /*object UsrEstado = null;
            cl.HelloWorldAsync(UsrEstado);
            rescerc.Text = UsrEstado.ToString();*/

            this.ubicarenmapa(SharedInformation.myLatitude, SharedInformation.myLongitude, SharedInformation.myZoom);

            // update the map if the user has asked to be tracked.
            if (trackingOn)
            {
                // center the pushpin and map on the current position
                myPushpin.Location = e.Position.Location;
                map1.Center = e.Position.Location;

                // if this is the first time that myPushPin is being plotted, add it to the object
                // hierarchy!
                if (map1.Children.Contains(myPushpin) == false) { map1.Children.Add(myPushpin); };
            }

        }

        

        private void trackMe_Click(object sender, RoutedEventArgs e)
        {
            if (trackingOn)
            {
                trackMe.Content = "Track Me On Map";
                trackingOn = false;
                /////map1.ZoomLevel = 1.0f; // zoom out to see whole world.
                map1.ZoomLevel = 16;
            }
            else
            {
                trackMe.Content = "Stop Tracking";
                trackingOn = true;
                //// map1.ZoomLevel = 16.0f; // zoom to street level.
                map1.ZoomLevel = 16;
            }
        }

        private void startStop_Click(object sender, RoutedEventArgs e)
        {
            if (startStop.Content.ToString() == "Stop LocServ")
            {
                startStop.Content = "Start LocServ";
                statusTextBlock.Text = "Location Services Stopped...";
                watcher.Stop();
            }
            else if (startStop.Content.ToString() == "Start LocServ")
            {
                startStop.Content = "Stop LocServ";
                statusTextBlock.Text = "Starting Location Services...";
                new Thread(startLocServInBackground).Start(); // StatusChanged will fire when complete.
            }
        }
        // fin para GPS


        private void zoomIn_click(object sender, EventArgs e)
        {
            map1.ZoomLevel++;
        }

        private void zoomOut_click(object sender, EventArgs e)
        {
            map1.ZoomLevel--;
        }

        private void chooseMyPosition_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/ChooseMyPosition.xaml", UriKind.Relative));
        }

        private void Aerial_click(object sender, EventArgs e)
        {
            map1.Mode = new AerialMode(true);
        }

        private void Road_click(object sender, EventArgs e)
        {
            map1.Mode = new RoadMode();
        }

        private void marcarpunto(double latitude, double longitud, string texto)
        {
            ///// Ejemplo ubicar puntos en un mapa 
            Pushpin pin = new Pushpin();
            pin.Location = new GeoCoordinate(latitude, longitud);
            pin.Background = new SolidColorBrush(Colors.Yellow);
            pin.Foreground = new SolidColorBrush(Colors.Black);            
            pin.Content = texto;                     
            this.map1.Children.Add(pin);          
        }

        private void ubicarenmapa(double latitude, double longitud, int zoom)
        {
            Pushpin p = new Pushpin();
            p.Background = new SolidColorBrush(Colors.Yellow);
            p.Foreground = new SolidColorBrush(Colors.Black);
            p.Location = new GeoCoordinate(latitude, longitud);
            p.Content = "Aca se empieza ...";
            map1.Children.Add(p);
            map1.SetView(new GeoCoordinate(latitude, longitud, 200), 9);
            map1.ZoomLevel = zoom;
        }

        private void locateMe_click(object sender, EventArgs e)
        {
            this.ubicarenmapa(SharedInformation.myLatitude, SharedInformation.myLongitude, SharedInformation.myZoom);
        }

        /*private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           
            string ServiceUri = "http://localhost:15657/Service1.svc/Rest/BienesCercanos/34.55/56.8069";
                               
            WebClient proxy = new WebClient();
            proxy.DownloadStringCompleted +=
                       new DownloadStringCompletedEventHandler(proxy_DownloadStringCompleted);
            proxy.DownloadStringAsync(new Uri(ServiceUri));
        }*/

        public class workspace
        {
            public string name { get; set; }
            public string dataStores { get; set; }
            public string coverageStores { get; set; }
            public string wmsStores { get; set; }
            public string otros { get; set; }
        }

        public class objSON
        {
            public workspace workspace { get; set; }
        }

        void proxy_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            /*Stream stream = new MemoryStream(Encoding.Unicode.GetBytes(e.Result));
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(string));
            string result = obj.ReadObject(stream).ToString();      */

            
            ///List<string> list = JsonConvert.DeserializeObject<List<string>>(e.Result);
            ////List<string> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(result);
            /*foreach (string item in list)
            {
                Console.WriteLine(item);
            }*/

            /////var jss = new JavaScriptSerializer();
            ///var dict = jss.Deserialize<Dictionary<string, string>>(result);

            string result = e.Result;
            rescerc.Text = rescerc.Text + result;

            ///[{"Id":2,"Latitud":-35,"Longitud":-56,"TipoDeBien":"Camionetas","Titulo":"Biene 2"},{"Id":1,"Latitud":56,"Longitud":-35,"TipoDeBien":"Camionetas","Titulo":"Toyota"}]
            result = result.Replace("[", "");
            result = result.Replace("]", "");

            double latituda = 0, longituda = 0;
            string tituloa = "";

            //// Recorrida de cada bien
            string[] partes = Regex.Split(result, "},{");
            foreach (string line in partes)
            {
                string lineaactual = line.Replace("{","");
                lineaactual = lineaactual.Replace("}", "");
                lineaactual = lineaactual.Replace("\"", "");

                //// cada campo
                string[] campos = Regex.Split(lineaactual,",");
                foreach (string subcampo in campos)
                {
                    //// los valores
                    string[] atributos = Regex.Split(subcampo, ":");
                    if (atributos[0] == "Latitud")
                        latituda = double.Parse(atributos[1]);
                    if (atributos[0] == "Longitud")
                        longituda = double.Parse(atributos[1]);
                    if (atributos[0] == "Titulo")
                        tituloa = atributos[1];
                }

                    marcarpunto(latituda,longituda,tituloa);

            }


        }

    }
}