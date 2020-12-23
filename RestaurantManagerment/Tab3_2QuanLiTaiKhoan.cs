using BUS;
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagerment
{
    public partial class Tab3_2QuanLiTaiKhoan : UserControl
    {
        public Tab3_2QuanLiTaiKhoan()
        {
            InitializeComponent();
        }

        private void cbLoaiTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }      
        List<TaiKhoan_DTO> dstaikhoan = new List<TaiKhoan_DTO>();
        private void btnThemTK_Click(object sender, EventArgs e)
        {
            if (txtTenTaiKhoan.Text == "" || txtMatKhau.Text == "" || cbLoaiTaiKhoan.Text == "" || cbMaNhanVien.Text=="" )
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin ...");
                return;
            }           
            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            tk.Manv = cbMaNhanVien.Text;
            tk.Tentk = txtTenTaiKhoan.Text;
            tk.Matkhau = txtMatKhau.Text;
            if (cbLoaiTaiKhoan.Text=="Admin")
                tk.Loaitk = "Admin";
            else
                tk.Loaitk = "Steff";
            if (dstaikhoan != null)
            {
                foreach (TaiKhoan_DTO TK in dstaikhoan)
                {
                    if (tk.Manv == TK.Manv)
                    {
                        MessageBox.Show("Mã nhân viên đã có rồi");
                        return;
                    }
                }
            }

        }
        
        private void cbMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            

        }
       
        private void Tab3_2QuanLiTaiKhoan_Load(object sender, EventArgs e)
        {
            SQLiteConnection conn = DataProvider.OpenConnection();
            try
            {
                cbMaNhanVien.Items.Clear();

                string query = "Select MaNV From NhanVien";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.CommandText = query;


                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbMaNhanVien.Items.Add(dr["MaNV"].ToString());
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu sql !");
            }

        }
    }
}
