using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TaiKhoan_DAO
    {
        static SQLiteConnection conn;
        public static List<TaiKhoan_DTO> LoadTaiKhoan()
        {
            string QueryString = "Select [Mã NV] From NhanVien";
            conn = DataProvider.OpenConnection();
            DataTable dt = DataProvider.LayDataTable(QueryString, conn);
            if (dt.Rows.Count == 0)
                return null;

            List<TaiKhoan_DTO> danhSachNhanVien = new List<TaiKhoan_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TaiKhoan_DTO ManhanVien = new TaiKhoan_DTO();

                ManhanVien.Manv = dt.Rows[i]["Mã NV"].ToString();
                danhSachNhanVien.Add(ManhanVien);
            }
            DataProvider.OpenConnection();
            return danhSachNhanVien;
        }
    }
}
