using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using DataAccessObject.DAO;
using Settings = ConnectToDatabase.Properties.Settings;

namespace BUS
{
    public class QuiDinh_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);

        public List<THAMSO> LayDanhSachThamSo()
        {
            return DB.THAMSOs.ToList();
        }
        public int LayDiemToiThieu()
        {
            return (int)DB.THAMSOs.First().DIEMTOITHIEU;
        }

        public int LayDiemToiDa()
        {
            return (int)DB.THAMSOs.First().DIEMTOIDA;
        }

        public int LayDiemDatMon()
        {
            return (int)DB.THAMSOs.First().DIEMDATMON;
        }

        public int LaySiSoToiDa()
        {
            return (int)DB.THAMSOs.First().SISOTOIDA;
        }

        public int LayTuoiToiDa()
        {
            return (int)DB.THAMSOs.First().TUOITOIDA;
        }

       
        public void Update(String _TuoiToiThieu, String _TuoiToiDa, String _DiemDatMon, String _SiSoToiDa, String _DiemToiThieu, String _DiemToiDa,String _Khoi10,String _Khoi11,String _Khoi12)
        {

            DB.usp_UpdateThamSo(int.Parse(_TuoiToiDa), int.Parse(_TuoiToiThieu), int.Parse(_SiSoToiDa), int.Parse(_DiemToiDa),int.Parse(_DiemToiThieu), int.Parse(_DiemDatMon),int.Parse(_Khoi10),int.Parse(_Khoi11),int.Parse(_Khoi12));
        }
        public int? LayLopToiDaCuaKhoi(String _Makhoi)
        {
            if (_Makhoi == "K10")
                return LayDanhSachThamSo().First().SOLOPTOIDAKHOI10;
            else
            if (_Makhoi == "K11")
                return LayDanhSachThamSo().First().SOLOPTOIDAKHOI11;
            else
            if (_Makhoi == "K12")
                return LayDanhSachThamSo().First().SOLOPTOIDAKHOI12;

            return null;

        }
            
    }
}
