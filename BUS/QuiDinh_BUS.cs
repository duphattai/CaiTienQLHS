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
    /// <summary>
    /// quản lý việc truy xuất dữ liệu  trên bảng QUIDINH (database) từ ứng dụng
    /// </summary>
    public class QuiDinh_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);
        /// <summary>
        /// lấy danh sách các tham số từ bảng THAMSO
        /// </summary>
        /// <returns>
        /// danh sách các đối tượng chứa(TUOITOITHIEU, TUOITOIDA, SISOTOIDA, DIEMTOITHIEU, DIEMTOIDA, DIEMDATMON, SOLOPTOIDAKHOI10, SOLOPTOIDAKHOI11, SOLOPTOIDAKHOI12)
        /// </returns>
        public List<THAMSO> LayDanhSachThamSo()
        {
            return DB.THAMSOs.ToList();
        }

        /// <summary>
        /// lấy điểm tối thiếu 
        /// </summary>
        /// <returns></returns>
        public int LayDiemToiThieu()
        {
            return (int)DB.THAMSOs.First().DIEMTOITHIEU;
        }

        /// <summary>
        /// lấy điểm tối đa 
        /// </summary>
        /// <returns></returns>
        public int LayDiemToiDa()
        {
            return (int)DB.THAMSOs.First().DIEMTOIDA;
        }

        /// <summary>
        /// lấy điểm đạt môn 
        /// </summary>
        /// <returns></returns>
        public int LayDiemDatMon()
        {
            return (int)DB.THAMSOs.First().DIEMDATMON;
        }

        /// <summary>
        /// lấy sỉ số lớp tối đa
        /// </summary>
        /// <returns></returns>
        public int LaySiSoToiDa()
        {
            return (int)DB.THAMSOs.First().SISOTOIDA;
        }

        /// <summary>
        /// lấy tuổi tối đa
        /// </summary>
        /// <returns></returns>
        public int LayTuoiToiDa()
        {
            return (int)DB.THAMSOs.First().TUOITOIDA;
        }

       /// <summary>
       /// cập nhật lại dữ liệu trên bảng THAMSO
       /// </summary>
       /// <param name="_TuoiToiThieu"></param>
       /// <param name="_TuoiToiDa"></param>
       /// <param name="_DiemDatMon"></param>
       /// <param name="_SiSoToiDa"></param>
       /// <param name="_DiemToiThieu"></param>
       /// <param name="_DiemToiDa"></param>
       /// <param name="_Khoi10"></param>
       /// <param name="_Khoi11"></param>
       /// <param name="_Khoi12"></param>
        public void Update(String _TuoiToiThieu, String _TuoiToiDa, String _DiemDatMon, String _SiSoToiDa, String _DiemToiThieu, String _DiemToiDa,String _Khoi10,String _Khoi11,String _Khoi12)
        {
            DB.usp_UpdateThamSo(int.Parse(_TuoiToiDa), int.Parse(_TuoiToiThieu), int.Parse(_SiSoToiDa), int.Parse(_DiemToiDa),int.Parse(_DiemToiThieu), int.Parse(_DiemDatMon),int.Parse(_Khoi10),int.Parse(_Khoi11),int.Parse(_Khoi12));
        }

        /// <summary>
        /// lấy số lớp tối đa theo khối
        /// </summary>
        /// <param name="_Makhoi"></param>
        /// <returns></returns>
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
