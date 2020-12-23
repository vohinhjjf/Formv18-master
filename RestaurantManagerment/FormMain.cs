using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagerment
{
    public partial class FormMain : Form
    {
        Control c;
        public FormMain()
        {
            InitializeComponent();
            c = tab1QLBanAn1;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }
        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn Có Muốn Thoát Hay Không ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
                Application.Exit();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (c != tab3)
            {
                tab3.BringToFront();
                c = tab3;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (c != tab1QLBanAn1)
            {
                tab1QLBanAn1.BringToFront();
                c = tab1QLBanAn1;
            }
        }

        private void QLTD_Click(object sender, EventArgs e)
        {
            if (c != tab2QLThucDon1)
            {
                tab2QLThucDon1.BringToFront();
                c = tab2QLThucDon1;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.Location = new System.Drawing.Point(gunaShadowPanel1.Width, gunaGradient2Panel2.Height);
            panel1.Size = new System.Drawing.Size(this.Width - gunaShadowPanel1.Width, this.Height - gunaGradient2Panel2.Height);
            tab1QLBanAn1.Location = new Point(0, 0);
            tab1QLBanAn1.Size = new System.Drawing.Size(this.Width - gunaShadowPanel1.Width, this.Height - gunaGradient2Panel2.Height);
            tab2QLThucDon1.Location = new Point(0, 0);
            tab2QLThucDon1.Size = panel1.Size;
            tab3.Location = new Point(0, 0);
            tab3.Size = panel1.Size;
            tab4.Location= new Point(0, 0);
            tab4.Size = panel1.Size;
            LoadInPanel();
        }
        private void LoadInPanel ()
        {
            panel1.Controls.Add(tab1QLBanAn1);
            panel1.Controls.Add(tab2QLThucDon1);
            panel1.Controls.Add(tab3);
            panel1.Controls.Add(tab4);
        }

        private void QLHD_Click(object sender, EventArgs e)
        {
            if (c != tab4)
            {
                tab4.BringToFront();
                c = tab4;
            }
        }
    }
}
