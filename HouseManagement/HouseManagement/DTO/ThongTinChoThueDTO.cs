using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagement.DTO
{
    class ThongTinChoThueDTO
    {
        private int ChuNhaID;
        private int NhaID;
        private DateTime ngayDang;
        private DateTime ngayHetHan;
        private float tienThue;

        public int ChuNhaID1 { get => ChuNhaID; set => ChuNhaID = value; }
        public int NhaID1 { get => NhaID; set => NhaID = value; }
        public DateTime NgayDang { get => ngayDang; set => ngayDang = value; }
        public DateTime NgayHetHan { get => ngayHetHan; set => ngayHetHan = value; }
        public float TienThue { get => tienThue; set => tienThue = value; }
    }
}
