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

        public static List<HoaDon_DTO> LocDsHoaDon(DateTime checkin , DateTime checkout)
        {
            string QueryString = string.Format("Select HoaDon.ID,BanAn.TenBan,HoaDon.NgayThanhToan,HoaDon.SoTien From BanAn,HoaDon Where HoaDon.IDBan = BanAn.ID AND HoaDon.NgayThanhToan >= '{0}' AND HoaDon.NgayThanhToan <='{1}'",checkin,checkout);
            conn = DataProvider.OpenConnection();
            DataTable dtHoaDon = DataProvider.LayDataTable(QueryString, conn);
            if (dtHoaDon.Rows.Count == 0)
                return null;

            List<HoaDon_DTO> danhSachHoaDon = new List<HoaDon_DTO>();
            for (int i = 0; i < dtHoaDon.Rows.Count; i++)
            {
                HoaDon_DTO hoadon = new HoaDon_DTO();
                hoadon.ID = int.Parse(dtHoaDon.Rows[i]["ID"].ToString());
                hoadon.Tenban = dtHoaDon.Rows[i]["TenBan"].ToString();
                hoadon.Ngay = DateTime.Parse(dtHoaDon.Rows[i]["NgayThanhToan"].ToString());
                hoadon.TongTien = int.Parse(dtHoaDon.Rows[i]["SoTien"].ToString());
                
                danhSachHoaDon.Add(hoadon);


            }
            DataProvider.OpenConnection();
            return danhSachHoaDon;
        }
        public static List<HoaDon_DTO> DsHoaDon()
        {
            string QueryString = "Select HoaDon.ID,BanAn.TenBan,HoaDon.NgayThanhToan,HoaDon.SoTien From BanAn,HoaDon Where HoaDon.IDBan = BanAn.ID ";
            conn = DataProvider.OpenConnection();
            DataTable dtHoaDon = DataProvider.LayDataTable(QueryString, conn);
            if (dtHoaDon.Rows.Count == 0)
                return null;

            List<HoaDon_DTO> danhSachHoaDon = new List<HoaDon_DTO>();
            for (int i = 0; i < dtHoaDon.Rows.Count; i++)
            {
                HoaDon_DTO hoadon = new HoaDon_DTO();
                hoadon.ID = int.Parse(dtHoaDon.Rows[i]["ID"].ToString());
                hoadon.Tenban = dtHoaDon.Rows[i]["TenBan"].ToString();
                hoadon.Ngay = DateTime.Parse(dtHoaDon.Rows[i]["NgayThanhToan"].ToString());
                hoadon.TongTien = int.Parse(dtHoaDon.Rows[i]["SoTien"].ToString());

                danhSachHoaDon.Add(hoadon);


            }
            DataProvider.OpenConnection();
            return danhSachHoaDon;
        }
        public static bool XoaHoaDon(int ID)
        {
            // chuỗi truy vấn xóa thông tin hóa đơn
            string chuoiTruyVan = string.Format("Delete from HoaDon where HoaDon.ID = {0}", ID);
            conn = DataProvider.OpenConnection();
            try
            {
                DataProvider.ThucThiTruyVanNonQuery(chuoiTruyVan, conn);
                DataProvider.CloseConnection(conn);
                return true;
            }
            catch (Exception)
            {
                DataProvider.CloseConnection(conn);
                return false;
            }
        }
    }
}
