using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Xml;
using System.Collections;
using Ol4RentAPI.Model;

namespace OL4RENT.Funciones
{

    public class ManejoRSS
    {

        public List<Novedad> LecturaRSS(string entradaRSS)
        {

            //Get the XML from remote URL
            XmlDocument xml = new XmlDocument();

            //URL currently hardcoded - but you could use a macro param to pass in URL            
            xml.Load(entradaRSS);

            //Select the nodes we want to loop through
            XmlNodeList nodes = xml.SelectNodes("//item");

            List<Novedad> listaNovRSS = new List<Novedad>();
            Novedad nv;
            string title, description;

            //Traverse the entire XML nodes.
            foreach (XmlNode node in nodes)
            {
                //Get the value from the <title> node
                title = node.SelectSingleNode("title").InnerText;

                //Get the value from the <description> node
                description = node.SelectSingleNode("description").InnerText;

                nv = new Novedad();
                nv.Id = 30;
                nv.Titulo = title;
                nv.Contenido = description;

                listaNovRSS.Add(nv);

            }

            return listaNovRSS;
            
        }

    }

}