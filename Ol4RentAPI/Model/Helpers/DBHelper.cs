using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ol4RentAPI.Model.Helpers
{
    public class DBHelper
    {
        public const string CONN_DEFAULT = "DefaultConnection";

        public static string Connection
        {
            get
            {
                return CONN_DEFAULT;
            }
        }
    }
}