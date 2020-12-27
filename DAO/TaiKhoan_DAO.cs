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
            string QueryString = "Select * From NGUOIDUNG";
            conn = DataProvider.OpenConnection();
            DataTable dt = DataProvider.LayDataTable(QueryString, conn);
            if (dt.Rows.Count == 0)
                return null;

            List<TaiKhoan_DTO> danhSachTaiKhoan = new List<TaiKhoan_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TaiKhoan_DTO TK = new TaiKhoan_DTO();

                TK.Manv = dt.Rows[i]["MaNV"].ToString();
                TK.Tentk = dt.Rows[i]["TaiKhoan"].ToString();
                TK.Matkhau = dt.Rows[i]["MatKhau"].ToString();
                TK.Loaitk = dt.Rows[i]["LoaiTK"].ToString();
                danhSachTaiKhoan.Add(TK);
            }
            DataProvider.OpenConnection();
            return danhSachTaiKhoan;
        }
        //------------- thêm tài khoản ---------------
        public static bool ThemTaiKhoan(TaiKhoan_DTO taikhoan)
        {
            // chuỗi truy vấn thêm 1 món ăn vào bảng Món Ăn
            string QueryString = $" INSERT INTO NGUOIDUNG (TaiKhoan,MatKhau,MaNV,LoaiTK) "
                + $"VALUES('{taikhoan.Tentk}','{taikhoan.Matkhau}','{taikhoan.Manv}','{taikhoan.Loaitk}'); ";
            conn = DataProvider.OpenConnection();
            try
            {
                DataProvider.ThucThiTruyVanNonQuery(QueryString, conn);
                DataProvider.CloseConnection(conn);
                return true;
            }
            catch (Exception)
            {
                DataProvider.CloseConnection(conn);
                return false;
            }
        }
        //------------------------ sửa tài khoản ---------------------------------
        public static bool SuaTaiKhoan(TaiKhoan_DTO taikhoan)
        {
            // chuỗi truy vấn sửa món ăn
            string QueryString = string.Format("UPDATE NGUOIDUNG set TaiKhoan='{0}', MatKhau='{1}', LoaiTK='{2}' where MaNV='{3}'", taikhoan.Tentk, taikhoan.Matkhau, taikhoan.Loaitk,taikhoan.Manv);
            conn = DataProvider.OpenConnection();
            try
            {
                DataProvider.ThucThiTruyVanNonQuery(QueryString, conn);
                DataProvider.CloseConnection(conn);
                return true;
            }
            catch (Exception)
            {
                DataProvider.CloseConnection(conn);
                return false;
            }
        }

        //---------------- xóa tài khoản người dùng ---------------------------------
        public static bool XoaTaiKhoan(TaiKhoan_DTO taikhoan)
        {
            // chuỗi truy vấn nhân viên
            string QueryString = string.Format("DELETE FROM NGUOIDUNG where MaNV ='{0}'", taikhoan.Manv);
            conn = DataProvider.OpenConnection();
            try
            {
                DataProvider.ThucThiTruyVanNonQuery(QueryString, conn);
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
