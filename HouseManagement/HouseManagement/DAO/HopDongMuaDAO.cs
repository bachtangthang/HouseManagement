using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagement.DAO
{
    class HopDongMuaDAO
    {
        private static HopDongMuaDAO instance;

        public static HopDongMuaDAO Instance
        {
            get { if (instance == null) instance = new HopDongMuaDAO(); return HopDongMuaDAO.instance; }
            private set { HopDongMuaDAO.instance = value; }
        }
        private HopDongMuaDAO() { }
    }
}
