using DataAccessObject.DAO;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Settings = ConnectToDatabase.Properties.Settings;
namespace BUS
{
    public class GiangDay_BUS
    {
        public QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);
        private QLHSDataContext DBServer = new QLHSDataContext(ConnectionServer.connectionServer);
        public void Them(String MaGiaoVien, int MaKhoi)
        {
            DB.usp_InsertGiangDay(MaGiaoVien, MaKhoi);
            DBServer.usp_InsertGiangDay(MaGiaoVien, MaKhoi);
        }


        public void Delete(String MaGiaoVien)
        {
            DB.usp_DeleteGiangDay(MaGiaoVien);
            DBServer.usp_DeleteGiangDay(MaGiaoVien);
        }

        public void Delete(String MaGiaoVien, int MaLop)
        {
            DB.usp_DeleteGiangDayBy_MaGiaoVien_MaLop(MaGiaoVien, MaLop);
            DBServer.usp_DeleteGiangDayBy_MaGiaoVien_MaLop(MaGiaoVien, MaLop);
        }

        public List<usp_SelectGiangDayResult> LayGiangDayTheoMaGiaoVien(String MaGiaoVien, String NamHoc)
        {
            return DB.usp_SelectGiangDay(MaGiaoVien, NamHoc).ToList();
        }

        public List<usp_SelectGiangDayBy_MaLopResult> LayGiangDayTheoMaLop(int maLop)
        {
            return DB.usp_SelectGiangDayBy_MaLop(maLop).ToList();
        }

        public List<usp_SelectMonHocBy_MaLopResult> LayMonHocTheoMaLop(int MaLop)
        {
            try
            {
                List<usp_SelectMonHocBy_MaLopResult> temp = DB.usp_SelectMonHocBy_MaLop(MaLop).ToList();

                return temp;
            }catch(Exception ex)
            {
                return null;
            }          
        }
    }
}
