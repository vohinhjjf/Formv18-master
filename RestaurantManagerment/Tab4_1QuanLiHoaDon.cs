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

namespace RestaurantManagerment
{
    public partial class Tab4_1QuanLiHoaDon : UserControl
    {
        List<int> ID = new List<int>();
        public Tab4_1QuanLiHoaDon()
        {
            InitializeComponent();
        }
        List<HoaDon_DTO> danhsachHD;
        public void LoadHoaDon()
        {
            danhsachHD = HoaDon_BUS.DSHoaDon();

            dgvDanhSachHoaDon.DataSource = danhsachHD;

            if (danhsachHD == null)
                return;

            for (int i = 0; i < 7; i++) dgvDanhSachHoaDon.AutoResizeColumn(i);
        }
        
        private void btnLoc_Click(object sender, EventArgs e)
        {
            
                LoadHoaDon();
            
            
        }

        private void dgvDanhSachHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Tab4_1QuanLiHoaDon_Load(object sender, EventArgs e)
        {
            this.Controls.Add(this.dgvDanhSachHoaDon);
        }
        
    }
}
