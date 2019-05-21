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
    public partial class frmLoaiSanPham : Form
    {
        LoaiSanPhamBUS loaisanphamBUS;
        public frmLoaiSanPham()
        {
            InitializeComponent();
            loaisanphamBUS = new LoaiSanPhamBUS();
        }

        
        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            GridLoaiSP.DataSource = loaisanphamBUS.GetLoaiSP();
        }
        public void Reset()
        {
            txtMaloai.Text = "";
            txtTenloai.Text = "";
            txtMaloai.Focus();
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaLSP, TenLSP;
                MaLSP = txtMaloai.Text;
                TenLSP = txtTenloai.Text;

                LoaiSanPhamDTO lsp = new LoaiSanPhamDTO(MaLSP, TenLSP);

                if (string.IsNullOrEmpty(txtMaloai.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã loại sản phẩm cần thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                int numOfRows = loaisanphamBUS.Add(lsp);
                if (numOfRows > 0)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                GridLoaiSP.DataSource = loaisanphamBUS.GetLoaiSP(); 
               
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Thêm thất bại, mã loại bị trùng\n"+ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string MaLSP;
            MaLSP = txtMaloai.Text;
            LoaiSanPhamDTO lsp = new LoaiSanPhamDTO(MaLSP);

            if (string.IsNullOrEmpty(txtMaloai.Text))
            {
                MessageBox.Show("Vui lòng nhập mã LSP cần xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            int numOfRows = loaisanphamBUS.Delete(lsp);
            if (numOfRows == 0)
            {
                MessageBox.Show("Không tìm được để xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            GridLoaiSP.DataSource = loaisanphamBUS.GetLoaiSP();
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string maloai, tenloai;
            maloai = txtMaloai.Text;
            tenloai = txtTenloai.Text;

            LoaiSanPhamDTO lsp = new LoaiSanPhamDTO(maloai, tenloai);
            try
            {
                int num = loaisanphamBUS.Update(lsp);
                if (num > 0)
                {
                    MessageBox.Show("Sửa thành công", "Sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridLoaiSP.DataSource = loaisanphamBUS.GetLoaiSP();
                }
                else
                {
                    MessageBox.Show("Không tìm được để sửa", "Sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi hệ thống\n" + ex.Message, "Sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MaLSP = txtTimLSP.Text;

            try
            {
                List<LoaiSanPhamDTO> list = new LoaiSanPhamBUS().GetLoaiSPWK(MaLSP);
                if (list.Count > 0)
                {
                    GridLoaiSP.DataSource = list;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy loại sản phẩm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi hệ thống\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.BackColor = Color.Black;
            label5.ForeColor = Color.White;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = Color.LightSteelBlue;
            label5.ForeColor = Color.Black;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
            GridLoaiSP.DataSource = loaisanphamBUS.GetLoaiSP();
        }
    }
}
