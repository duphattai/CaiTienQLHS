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
    public class HocKy_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);

        public List<HOCKY> LayDanhSachHocKy()
        {
            return DB.HOCKies.ToList();
        }
    }
}
