using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagement.DAO
{
    public class NhaDAO
    {
        private static NhaDAO instance;

        public static NhaDAO Instance
        {
            get { if (instance == null) instance = new NhaDAO(); return NhaDAO.instance; }
            private set { NhaDAO.instance = value; }  
        }
        private NhaDAO() { }
    }
}
