using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject.DAO;
using Settings = ConnectToDatabase.Properties.Settings;

namespace BUS
{
    public class NamHoc_BUS
    {

        QLHSDataContext DB = new QLHSDataContext(Settings.Default.ConnectString);
         
        public List<NAMHOC> LayNamHoc()
        {
            return DB.NAMHOCs.ToList();
        }

        public void XoaNamHoc(NAMHOC namhoc)
        {
            DB.usp_DeleteNamhoc(namhoc.NAMHOC1);
        }

        public void ThemNamHoc(NAMHOC namhoc)
        {
            DB.usp_InsertNamhoc(namhoc.NAMHOC1);
        }
      
    }
}
