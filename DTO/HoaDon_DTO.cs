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
        private string tenban;       
        private DateTime ngay;
        
        private int tongtien;

        public int ID { get => id; set => id = value; }
        public string Tenban { get => tenban; set => tenban = value; }
        public DateTime Ngay { get => ngay; set => ngay = value; }
        public int TongTien { get => tongtien; set => tongtien = value; }
        
    }
}
