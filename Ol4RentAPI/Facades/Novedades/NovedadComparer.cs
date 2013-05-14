using Ol4RentAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.Facades.Novedades
{
    internal class NovedadComparer: IComparer<NovedadDTO>
    {
        public int Compare(NovedadDTO x, NovedadDTO y)
        {
            if (x.Fecha > y.Fecha)
            {
                return 1;
            }
            else if (x.Fecha == y.Fecha)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
