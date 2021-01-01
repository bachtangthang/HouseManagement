using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagement.DTO
{
    class NhaDTO
    {
        private int iD;
        private int soLuongPhong;
        private int soLuotXem;
        private bool tinhTrang;
        private string duong;
        private string khuVuc;
        private string quan;
        private string thanhPho;
        private int loaiNha;
        private int chiNhanhID;

        public int ID { get => iD; set => iD = value; }
        public int SoLuongPhong { get => soLuongPhong; set => soLuongPhong = value; }
        public int SoLuotXem { get => soLuotXem; set => soLuotXem = value; }
        public bool TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public string Duong { get => duong; set => duong = value; }
        public string KhuVuc { get => khuVuc; set => khuVuc = value; }
        public string Quan { get => quan; set => quan = value; }
        public string ThanhPho { get => thanhPho; set => thanhPho = value; }
        public int LoaiNha { get => loaiNha; set => loaiNha = value; }
        public int ChiNhanhID { get => chiNhanhID; set => chiNhanhID = value; } 

    }
}
