using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class HoaDon_DAO
    {
        static SQLiteConnection conn;

        public static List<HoaDon_DTO> DsHoaDon()
        {
            string chuoiTruyVan = "Select * From HoaDon";
            conn = DataProvider.OpenConnection();
            DataTable dtHoaDon = DataProvider.LayDataTable(chuoiTruyVan, conn);
            if (dtHoaDon.Rows.Count == 0)
                return null;

            List<HoaDon_DTO> danhSachHoaDon = new List<HoaDon_DTO>();
            for (int i = 0; i < dtHoaDon.Rows.Count; i++)
            {
                HoaDon_DTO hoadon = new HoaDon_DTO();
                hoadon.ID = int.Parse(dtHoaDon.Rows[i]["ID"].ToString());
                hoadon.IDBan = int.Parse(dtHoaDon.Rows[i]["ID bàn"].ToString());
                hoadon.TinhTrang = int.Parse(dtHoaDon.Rows[i]["Tình trạng"].ToString());
                hoadon.Ngay = dtHoaDon.Rows[i]["Ngày"].ToString();
                hoadon.TongTien = int.Parse(dtHoaDon.Rows[i]["Tổng Tiền"].ToString());
                danhSachHoaDon.Add(hoadon);
            }
            DataProvider.OpenConnection();
            return danhSachHoaDon;
        }
    }
}
