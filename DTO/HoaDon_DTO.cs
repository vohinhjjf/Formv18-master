using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon_DTO
    {
        private int id;
        private int idban;
        private int tinhtrang;
        private string ngay;
        private int tongtien;

        public int ID { get => id; set => id = value; }
        public int IDBan { get => idban; set => idban = value; }
        public int TinhTrang { get => tinhtrang; set => tinhtrang = value; }
        public string Ngay { get => ngay; set => ngay = value; }
        public int TongTien { get => tongtien; set => tongtien = value; }
    }
}
