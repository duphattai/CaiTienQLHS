using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ThongTinLop
    {
        private String _TenLop { get; set; }
        private int _Siso { get; set; }

        public ThongTinLop(String _newTenLop,int _newSiso)
        {
            _TenLop = _newTenLop;
            _Siso = _newSiso;
        }
    }
}
