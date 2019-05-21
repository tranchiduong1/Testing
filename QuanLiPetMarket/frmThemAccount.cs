using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BUS;

namespace QuanLiPetMarket
{
    public partial class frmThemAccount : Form
    {
        ThemAccountBUS themaccountBUS;
        public frmThemAccount()
        {
            InitializeComponent();
            themaccountBUS = new ThemAccountBUS();
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string TaiKhoan, MatKhau;
                int ID;
                TaiKhoan = txtNewAC.Text;
                MatKhau = txtnewPW.Text;
                ID = int.Parse(txtName.Text);

                ThemAccountDTO them = new ThemAccountDTO(TaiKhoan, MatKhau, ID);

                if (string.IsNullOrEmpty(txtNewAC.Text) || string.IsNullOrEmpty(txtnewPW.Text) || string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string cfpw = txtConfirmPW.Text;
                if (cfpw != txtnewPW.Text)
                {
                    MessageBox.Show("Mật khẩu nhập lại không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int numOfRows = themaccountBUS.Add(them);
                    if (numOfRows > 0)
                    {
                        if (MessageBox.Show("Tạo thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)==DialogResult.OK)
                        {
                            txtNewAC.Text = "";
                            txtnewPW.Text = "";
                            txtConfirmPW.Text = "";
                            txtName.Text = "";
                            txtNewAC.Focus();
                        }
                        
                    }
                }              
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Tài khoản đã có người sử dụng\n"+ ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtNewAC.Text = "";
                txtnewPW.Text = "";
                txtConfirmPW.Text = "";
                txtName.Text = "";
                txtNewAC.Focus();
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txtNewAC.Text = "";
            txtnewPW.Text = "";
            txtConfirmPW.Text = "";
            txtName.Text = "";
            txtNewAC.Focus();
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                this.Close();
        }

        private void txtnewPW_TextChanged(object sender, EventArgs e)
        {
            if (txtnewPW.Text.Length > 8)
            {
                label5.BackColor = Color.Yellow;
                label5.ForeColor = Color.Red;
            }
            else
            {
                Color c = Color.FromArgb(192, 192, 255);
                label5.ForeColor = c;
                label5.BackColor = c;
            }
        }
    }
}
