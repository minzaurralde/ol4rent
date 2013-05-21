using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.Facades
{
    public class ServiceFacadeFactory
    {
        private static ServiceFacadeFactory _instance = null;
        private ServiceFacadeFactory() { }
        public static ServiceFacadeFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceFacadeFactory();
                }
                return _instance;
            }
        }

        public ICreadorDatosDummyFacade CreadorDatosDummy
        {
            get
            {
                return new CreadorDatosDummyImpl();
            }
        }

        public IBienFacade BienFacade
        {
            get
            {
                return new BienFacadeImpl();
            }
        }

        public ISitioFacade SitioFacade
        {
            get
            {
                return new SitioFacadeImpl();
            }
        }

        public IAccountFacade AccountFacade
        {
            get
            {
                return new AccountFacadeImpl();
			}
		}
        public INovedadFacade NovedadFacade
        {
            get
            {
                return new NovedadFacadeImpl();
            }
        }

        public IEspecificacionBienFacade EspecificacionBienFacade
        {
            get
            {
                return new EspecificacionBienFacadeImpl();
            }
        }

        public IOrigenDatosFacade OrigenDatosFacade
        {
            get
            {
                return new OrigenDatosFacade();
            }
        }
    }
}
