using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BaoCaoTKHK
    {
        public String _Lop { get; set; }
        public int _SiSo { get; set; }
        public int _SoLuongDat { get; set; }
        public double _TiLe { get; set; }

        public BaoCaoTKHK(String _newLop, int _newSiSo, int _newSoLuongDat, double _newTiLe)
        {
            _Lop = _newLop;
            _SiSo = _newSiSo;
            _SoLuongDat = _newSoLuongDat;
            _TiLe = _newTiLe;
        }

    }
}
