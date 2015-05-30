using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject.DAO;
using System.Data.Linq;
using Settings = ConnectToDatabase.Properties.Settings;

namespace BUS
{

    public class BangDiemHocSinh
    {
        public String _Hoten { get; set; }
        public int _MaHocSinh { get; set; }
        
        public double? _Diem15 { get; set; } 
        public double? _Diem1Tiet { get; set; }
        public double? _DiemHK { get; set; }
        public double? _DiemTB { get; set; }

        public int? _MaDiem15 { get; set; }
        public int? _MaDiem1T { get; set; }
        public int? _MaDiemHK { get; set; }

        public BangDiemHocSinh()
        { }

        public BangDiemHocSinh(String _newHoTen,int _newMaHocSinh, int? _newMaDiem15, double? _newDiem15, int? _newMaDiem1Tiet,double? _newDiem1Tiet, int? _newMaDiemHK, double? _newDiemHK,double? _newDiemTB)
        {
            _Hoten = _newHoTen;
            _MaHocSinh = _newMaHocSinh;
            
            _MaDiem15 = _newMaDiem15;
            _Diem15 = _newDiem15;
            _MaDiem1T = _newMaDiem1Tiet;
            _Diem1Tiet = _newDiem1Tiet;
            _MaDiemHK = _newMaDiemHK;
            _DiemHK = _newDiemHK;
            _DiemTB = _newDiemTB;
        }
    }
}
