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
    public class Khoi_BUS
    {
        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);


        public ISingleResult<usp_SelectKhoisAllResult> LayDanhSachKhoi()
        {
            return DB.usp_SelectKhoisAll();
        }
        
    }
}
