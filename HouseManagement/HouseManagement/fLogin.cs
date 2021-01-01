using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseManagement
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
       
        private void bt_DangNhap_Click(object sender, EventArgs e)
        {
            fNhanVien f = new fNhanVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void bt_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
