using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagement.DAO
{
    class HopDongThueDAO
    {
        private static HopDongThueDAO instance;

        public static HopDongThueDAO Instance
        {
            get { if (instance == null) instance = new HopDongThueDAO(); return HopDongThueDAO.instance;  }
            private set { HopDongThueDAO.instance = value; }
        }
        private HopDongThueDAO() { }
    }
}
