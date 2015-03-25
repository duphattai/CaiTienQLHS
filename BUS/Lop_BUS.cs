using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Lop_BUS
    {
        String _TenLop { get; set; }
        int _Siso { get; set; }

        public Lop_BUS(String _newTenLop,int _newSiso)
        {
            _TenLop = _newTenLop;
            _Siso = _newSiso;
        }
    }
}
