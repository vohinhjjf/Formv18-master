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
        List<int> ID = new List<int>();
        DataGridViewRow drvTK;
        private void cbLoaiTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        List<TaiKhoan_DTO> dstaikhoan; 
        private void LoadTaiKhoan()
        {

            ID.Clear();
            dstaikhoan = TaiKhoan_BUS.LoadTK();
            if (dstaikhoan != null)
            {
                foreach (TaiKhoan_DTO tk in dstaikhoan)
                {
                    ID.Add(int.Parse(tk.Manv.Substring(3)));
                }
            }
            dtgrvDanhTaiKhoan.DataSource = dstaikhoan;
            
            if (dstaikhoan == null)
                return;

            dtgrvDanhTaiKhoan.Columns["TenTK"].HeaderText = "Tài Khoản";
            dtgrvDanhTaiKhoan.Columns["MatKhau"].HeaderText = "Mật Khẩu";
            dtgrvDanhTaiKhoan.Columns["MaNV"].HeaderText = "Mã NV";
            dtgrvDanhTaiKhoan.Columns["LoaiTK"].HeaderText = "Loại Tài Khoản";
            for (int i = 0; i < 3; i++) dtgrvDanhTaiKhoan.AutoResizeColumn(i);

        }
        //Button Thêm
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
            if (TaiKhoan_BUS.ThemTaiKhoan(tk))
            {
                LoadTaiKhoan();
                MessageBox.Show("Thêm thành công");
                return;
            }
            MessageBox.Show("Thêm thất bại");
        }
        //Button Xóa
        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            if (drvTK == null)
            {
                MessageBox.Show("Chọn nhân viên muốn xóa");
                return;
            }

            TaiKhoan_DTO taikhoan = new TaiKhoan_DTO();
            taikhoan.Manv = cbMaNhanVien.Text;
            if (taikhoan.Manv == "0001")
            {
                MessageBox.Show("Không thể xóa admin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (dstaikhoan == null)
                    dtgrvDanhTaiKhoan.DataSource = null;
                if (TaiKhoan_BUS.XoaTaiKhoan(taikhoan))
                {
                    drvTK = null;
                    txtTenTaiKhoan.Text = "";
                    txtMatKhau.Text = "";
                    cbLoaiTaiKhoan.Text = "";
                    cbMaNhanVien.Text = "";                  
                    MessageBox.Show("Xóa thành công");
                    LoadTaiKhoan();
                    return;
                }
                MessageBox.Show("Xóa thất bại");
            }
        }
        //Button sửa
        private void btnSuaTK_Click(object sender, EventArgs e)
        {
            if (drvTK == null)
            {
                MessageBox.Show("Chọn tài khoản muốn cập nhật");
                return;
            }

            TaiKhoan_DTO taikhoan = new TaiKhoan_DTO();
            taikhoan.Tentk = txtTenTaiKhoan.Text;
            taikhoan.Matkhau = txtMatKhau.Text;
            taikhoan.Manv = cbMaNhanVien.Text;
            taikhoan.Loaitk = cbLoaiTaiKhoan.Text;

            
            if (dstaikhoan != null)
            {
                foreach (TaiKhoan_DTO TK in dstaikhoan)
                {
                    if (TaiKhoan_BUS.SuaTaiKhoan(taikhoan) )
                    {
                        if (taikhoan.Manv == TK.Manv)
                        {
                            LoadTaiKhoan();
                            MessageBox.Show("Mã nhân viên đã có rồi ! Sửa thất bại !");
                            return;
                        }
                        else
                        {
                            drvTK = null;
                            txtTenTaiKhoan.Text = "";
                            txtMatKhau.Text = "";
                            cbMaNhanVien.Text = "";
                            cbLoaiTaiKhoan.Text = "";
                            LoadTaiKhoan();
                            MessageBox.Show("Sửa thành công");
                            return;
                        }    
                        
                    }
                    
                }
            }
            
        }
        // sự kiện click vào 1 dòng
        private void dtgrvDanhTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                drvTK = dtgrvDanhTaiKhoan.SelectedRows[0];
            }
            catch (Exception)
            {
                return;
            }
            if (drvTK.Cells["MaNV"].Value.ToString() != "0001")
            {
                txtTenTaiKhoan.Text = drvTK.Cells["TenTK"].Value.ToString();
                txtMatKhau.Text = drvTK.Cells["MatKhau"].Value.ToString();                               
                cbMaNhanVien.Text = drvTK.Cells["MaNV"].Value.ToString();
                cbLoaiTaiKhoan.Text = drvTK.Cells["LoaiTK"].Value.ToString();
                
            }
        }
        public void DSLoaiTK()
        {
            cbLoaiTaiKhoan.Items.Add("Admin");
            cbLoaiTaiKhoan.Items.Add("Steff");
        }
        public void DSMANV()
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
        private void cbMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            

        }
       
        private void Tab3_2QuanLiTaiKhoan_Load(object sender, EventArgs e)
        {
            DSMANV();
            DSLoaiTK();
            LoadTaiKhoan();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
