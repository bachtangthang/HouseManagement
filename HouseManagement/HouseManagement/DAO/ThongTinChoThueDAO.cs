using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagement.DAO
{
    class ThongTinChoThueDAO
    {
        private static ThongTinChoThueDAO instance;
        public static ThongTinChoThueDAO Instance
        {
            get { if (instance == null) instance = new ThongTinChoThueDAO(); return ThongTinChoThueDAO.instance; }
            private set { ThongTinChoThueDAO.instance = value; }
        }
        private ThongTinChoThueDAO() { }
    }
}
