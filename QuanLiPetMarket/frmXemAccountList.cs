using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace QuanLiPetMarket
{
    public partial class frmXemAccountList : Form
    {
        ThemAccountBUS themacBUS;
        public frmXemAccountList()
        {
            InitializeComponent();
            themacBUS = new ThemAccountBUS();
        }

        private void XemAccountList_Load(object sender, EventArgs e)
        {
            gridXemAC.DataSource = themacBUS.GetThemAccount();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmThemAccount them = new frmThemAccount();
            them.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            id = int.Parse(textBox1.Text);

            ThemAccountDTO xoa = new ThemAccountDTO(id);
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                return;
            }

            int numOfRows = themacBUS.Delete(xoa);
            if (numOfRows == 0)
            {
                MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            gridXemAC.DataSource = themacBUS.GetThemAccount();
        }
    }
}
