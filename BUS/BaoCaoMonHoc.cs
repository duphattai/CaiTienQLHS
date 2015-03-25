using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
   public class BaoCaoMonHoc
    {
       public String _Lop {get;set;}
       public int _Siso { get; set; }
       public int? _SoLuongDat { get; set; }
       public  double _Tile { get; set; }

       public BaoCaoMonHoc(String _newLop,int _newSiso,int? _newSoLuongDat,double _newTile)
        {
            _Lop = _newLop;
            _Siso = _newSiso;
            _SoLuongDat = _newSoLuongDat;
            _Tile = _newTile;
        }


    }
}
