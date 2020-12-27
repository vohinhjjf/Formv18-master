using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Text.RegularExpressions;

namespace RestaurantManagerment
{
    public partial class Tab4_1QuanLiHoaDon : UserControl
    {
        List<int> ID = new List<int>();
        public Tab4_1QuanLiHoaDon()
        {
            InitializeComponent();
            LoadDateTimePickerBill();
        }
        List<HoaDon_DTO> danhsachHD;
        DataGridViewRow dsHoaDon;
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;          
            dtpTuNgay.Value = new DateTime(today.Year, today.Month, 1);
            dtpDenNgay.Value = dtpTuNgay.Value.AddMonths(1).AddDays(-1);       
        }
        public void DsHoaDon()
        {
            ID.Clear();
            danhsachHD = HoaDon_BUS.DSHoaDon();
            if (danhsachHD != null)
            {
                foreach (HoaDon_DTO hd in danhsachHD)
                {
                    ID.Add(hd.ID);

                }
            }
            dgvDanhSachHoaDon.DataSource = danhsachHD;

            if (danhsachHD == null)
                return;
            dgvDanhSachHoaDon.Columns["ID"].HeaderText = "ID";
            dgvDanhSachHoaDon.Columns["Tenban"].HeaderText = "Tên Bàn";
            dgvDanhSachHoaDon.Columns["Ngay"].HeaderText = "Ngày Thanh Toán";
            dgvDanhSachHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";

            dgvDanhSachHoaDon.Columns["ID"].Width = 50;
            dgvDanhSachHoaDon.Columns["Tenban"].Width = 150;
            dgvDanhSachHoaDon.Columns["Ngay"].Width = 250;
            dgvDanhSachHoaDon.Columns["TongTien"].Width = 200;


            this.dgvDanhSachHoaDon.Columns["ID"].HeaderCell.Style.Font = new Font("Arial", 12);
            this.dgvDanhSachHoaDon.Columns["Tenban"].HeaderCell.Style.Font = new Font("Arial", 12);
            this.dgvDanhSachHoaDon.Columns["Ngay"].HeaderCell.Style.Font = new Font("Arial", 12);
            this.dgvDanhSachHoaDon.Columns["TongTien"].HeaderCell.Style.Font = new Font("Arial", 12);
            this.dgvDanhSachHoaDon.DefaultCellStyle.Font = new Font("Arial", 12);
            
        }
        public void LocDsHoaDon(DateTime checkIn, DateTime checkOut)
        {
            ID.Clear();
            danhsachHD = HoaDon_BUS.LocDSHoaDon(checkIn,checkOut);
            if (danhsachHD != null)
            {
                foreach (HoaDon_DTO hd in danhsachHD)
                {
                    ID.Add(hd.ID);
                    
                }
            }
            dgvDanhSachHoaDon.DataSource = danhsachHD;

            if (danhsachHD == null)
                return;
            dgvDanhSachHoaDon.Columns["ID"].HeaderText = "ID";
            dgvDanhSachHoaDon.Columns["Tenban"].HeaderText = "Tên Bàn";           
            dgvDanhSachHoaDon.Columns["Ngay"].HeaderText = "Ngày Thanh Toán";
            dgvDanhSachHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";

            dgvDanhSachHoaDon.Columns["ID"].Width = 50;
            dgvDanhSachHoaDon.Columns["Tenban"].Width = 150;
            dgvDanhSachHoaDon.Columns["Ngay"].Width = 250;
            dgvDanhSachHoaDon.Columns["TongTien"].Width = 200;

            
            this.dgvDanhSachHoaDon.Columns["ID"].HeaderCell.Style.Font = new Font("Arial", 12);
            this.dgvDanhSachHoaDon.Columns["Tenban"].HeaderCell.Style.Font = new Font("Arial", 12);
            this.dgvDanhSachHoaDon.Columns["Ngay"].HeaderCell.Style.Font = new Font("Arial", 12);
            this.dgvDanhSachHoaDon.Columns["TongTien"].HeaderCell.Style.Font = new Font("Arial", 12);
            this.dgvDanhSachHoaDon.DefaultCellStyle.Font = new Font("Arial", 12);
            

        }
        
        private void btnLoc_Click(object sender, EventArgs e)
        {            
            LocDsHoaDon(dtpTuNgay.Value,dtpDenNgay.Value);
        }

        private void dgvDanhSachHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Tab4_1QuanLiHoaDon_Load(object sender, EventArgs e)
        {
            
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            
            DsHoaDon();
        }
        public int indexTable = -1;
        int chiSoCuaLsvHoaDon = -1;
        private void dgvDanhSachHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            chiSoCuaLsvHoaDon = dgvDanhSachHoaDon.CurrentCell.RowIndex;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dsHoaDon == null)
            {
                MessageBox.Show("Chọn hóa đơn muốn xóa");
                return;
            }

            HoaDon_DTO hoaDon = new HoaDon_DTO();
            hoaDon.ID = int.Parse(dsHoaDon.Cells["ID"].Value.ToString());
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (danhsachHD == null)
                    dgvDanhSachHoaDon.DataSource = null;
                if (HoaDon_BUS.XoaHoaDon(hoaDon.ID))
                {
                    
                    MessageBox.Show("Xóa thành công");
                     

                    DsHoaDon(); // sau khi xóa thì load lại hóa đơn 
                    return;
                }
                MessageBox.Show("Xóa thất bại");
            }
            /*if (dgvDanhSachHoaDon.RowCount < 1)
            {
                return;
            }
            if (chiSoCuaLsvHoaDon != -1)
            {
                // xóa món ăn đã chọn dựa vào id hóa đơn và id món ăn
                try
                {
                    // xóa món ăn trong cơ sở dữ liệu dựa vào IDHoaDon và IDMonAN
                    HoaDonOrder_BUS.XoaThongTinHoaDon(HoaDonOrder_BUS.layIDHoaDon(danhsachHD[indexTable].ID));
                }
                catch (Exception)
                {
                    return;
                }

                dgvDanhSachHoaDon.Rows.RemoveAt(chiSoCuaLsvHoaDon); // xóa món ăn trên listview

                LoadHoaDon(dtpTuNgay.Value, dtpDenNgay.Value); // sau khi xóa thì load lại hóa đơn 
            }*/
        }

        private void dgvDanhSachHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                dsHoaDon = dgvDanhSachHoaDon.SelectedRows[0];
            }
            catch (Exception)
            {
                return;
            }
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if(dtpTuNgay.Value>dtpDenNgay.Value)
            {
                MessageBox.Show("Thời gian không hợp lệ!");
                LoadDateTimePickerBill();
            }    
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Thời gian không hợp lệ!");
                LoadDateTimePickerBill();
            }
        }
    }
}
