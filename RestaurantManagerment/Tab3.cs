using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagerment
{
    public partial class Tab3 : UserControl
    {
        public Tab3()
        {
            InitializeComponent();
        }

        private void Tab3_Load(object sender, EventArgs e)
        {
            this.Controls.Add(this.tab3_2QuanLiTaiKhoan1);
            this.Controls.Add(this.Tab3_1QuanLiNhanSu1);
            Tab3_1QuanLiNhanSu1.BringToFront();
        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            Tab3_1QuanLiNhanSu1.BringToFront();
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            tab3_2QuanLiTaiKhoan1.BringToFront();
        }
    }
}
