using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject.DAO;
using Settings = ConnectToDatabase.Properties.Settings;

namespace BUS
{
    public class DanhSachHS_BUS
    {
        public String _HoTen
        {
            get;
            set;
        }
        public String _Lop
        {
            get;
            set;
        }
        public double _TBHK1
        {
            get;
            set;
        }
        public double _TBHK2
        {
            get;
            set;
        }

        public DanhSachHS_BUS(String _newHoTen, String _newLop, double _newTBHK1, double _newTBHK2)
        {
            _HoTen = _newHoTen;
            _Lop = _newLop;
            _TBHK1 = _newTBHK1;
            _TBHK2 = _newTBHK2;
        }

    }
}
