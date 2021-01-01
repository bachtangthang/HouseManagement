using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagement.DTO
{
    class HopDongThueDTO
    {
        private int NhaID;
        private int KhachHangID;
        private int ID;
        private DateTime ngayThue;
        private DateTime ngayHetHan;

        public int NhaID1 { get => NhaID; set => NhaID = value; }
        public int KhachHangID1 { get => KhachHangID; set => KhachHangID = value; }
        public int ID1 { get => ID; set => ID = value; }
        public DateTime NgayThue { get => ngayThue; set => ngayThue = value; }
        public DateTime NgayHetHan { get => ngayHetHan; set => ngayHetHan = value; }
    }
}
