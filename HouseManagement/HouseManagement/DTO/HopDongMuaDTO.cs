using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagement.DTO
{
    class HopDongMuaDTO
    {
        private DateTime ngayMua;
        private int KhachHangID;
        private int NhaID;
        private int ID;

        public int KhachHangID1 { get => KhachHangID; set => KhachHangID = value; }
        public int NhaID1 { get => NhaID; set => NhaID = value; }
        public int ID1 { get => ID; set => ID = value; }
        public DateTime NgayMua { get => ngayMua; set => ngayMua = value; }
    }
}
