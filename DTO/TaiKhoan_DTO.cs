using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan_DTO
    {
        private string manv;
        private string tentk;
        private string matkhau;
        private string loaitk;

        public string Manv { get => manv; set => manv = value; }
        public string Tentk { get => tentk; set => tentk = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public string Loaitk { get => loaitk; set => loaitk = value; }
    }
}
