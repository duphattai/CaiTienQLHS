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
    public class MonHoc_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);

        public List<MONHOC> LayDanhSachMonHoc()
        {
            return DB.MONHOCs.ToList();
        }

        public bool KiemTraMonHoc(String _MonHoc, List<MONHOC> _ListMon)
        {
            foreach (MONHOC mh in _ListMon)
            {
                if (mh.TENMONHOC == _MonHoc)
                {
                    return false;
                }
            }
            return true;
        }

        public void Them(String _MaMon, String _TenMon)
        {
            DB.usp_InsertMonhoc(_MaMon, _TenMon);
        }
        public void Update(String _MaMon, String _TenMon)
        {
            DB.usp_UpdateMonhoc(_MaMon, _TenMon);
        }
        public void Delete(String _MaMon)
        {
            DB.usp_DeleteMonhoc(_MaMon);
        }
    }
}
