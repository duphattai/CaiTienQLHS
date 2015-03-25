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
    public class XepLop_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);

        public List<XEPLOP> LayTatCa()
        {
            return DB.XEPLOPs.ToList();
        }
        public ISingleResult<usp_SelectXeplopsByMAHOCSINHResult> TruyVanTheoMaHocSinh(int _MAHS)
        {
            return DB.usp_SelectXeplopsByMAHOCSINH(_MAHS);
        }

        public ISingleResult<usp_SelectXeplopsByMALOPResult> TruyVanTheoMaLop(int _MALOP)
        {
            return DB.usp_SelectXeplopsByMALOP(_MALOP);

        }

        public bool CheckExist(int _MaHS, int _MaLop)
        {
            try
            {
                if (DB.usp_SelectXeplop(_MaHS, _MaLop).Count() > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public void Update(int? _MaHS, int? _MaLop, int? _NewMaHS, int? _NewMaLop)
        {
            DB.usp_UpdateXeplop(_MaHS, _MaLop, _NewMaHS, _NewMaLop);
        }

        public void Delete(int _MaHS, int _MaLop)
        {
            DB.usp_DeleteXeplop(_MaLop, _MaHS);
        }

        public void Insert(int _MaHS, int _MaLop)
        {
            DB.usp_InsertXeplop(_MaHS, _MaLop);
        }

        public int TimMaLopTheoMaHS_NamHoc(int _MaHocSinh, string _NamHoc)
        {
            try
            {
                return DB.usp_SelectMALOPByMAHOCSINH_NAMHOC(_MaHocSinh, _NamHoc).First().MALOP;
            }
            catch
            {
                return -1;
            }
        }
    }
}
