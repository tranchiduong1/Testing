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
    public partial class frmSanPham : Form
    {
        SanPhamBUS sanphamBUS;
        LoaiSanPhamBUS loaisanphamBUS;
        public frmSanPham()
        {
            InitializeComponent();
            sanphamBUS = new SanPhamBUS();
            loaisanphamBUS = new LoaiSanPhamBUS();
        }
     
        private void frmSanPham_Load(object sender, EventArgs e)
        {

            GridSP.DataSource = sanphamBUS.GetSanPham();

            cboMaLSP.DataSource = loaisanphamBUS.GetLoaiSP();
            cboMaLSP.DisplayMember = "TenLoaiSanPham";
            cboMaLSP.ValueMember = "MaLoaiSanPham";
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            frmSanPham sp = new frmSanPham();
            if (MessageBox.Show("Bạn muốn đóng?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaSP, TenSP, MaLSP, SLTK, DGN, DGB;
                MaSP = txtMaSP.Text;
                TenSP = txtTenSP.Text;
                MaLSP = cboMaLSP.SelectedValue.ToString();
                SLTK = txtSLTonKho.Text;
                DGN = txtDGNhap.Text;
                DGB = txtDGBan.Text;

                SanPhamDTO sanpham = new SanPhamDTO(MaSP, TenSP, MaLSP, SLTK, DGN, DGB);

                if (string.IsNullOrEmpty(txtMaSP.Text))

                {
                    MessageBox.Show("Vui lòng nhập mã sản phẩm cần thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int numOfRows = sanphamBUS.Add(sanpham);
                if (numOfRows > 0)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                GridSP.DataSource = sanphamBUS.GetSanPham();
                
            }
            catch
            {
                MessageBox.Show("Thêm thất bại, trùng mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
        }
        public void Reset()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";         
            txtSLTonKho.Text = "";
            txtDGBan.Text = "";
            txtDGNhap.Text = "";
            txtMaSP.Focus();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string MaSP;
            MaSP = txtMaSP.Text;
            SanPhamDTO sanpham = new SanPhamDTO(MaSP);

            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng nhập mã SP cần xoá ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int numOfRows = sanphamBUS.Delete(sanpham);
            if (numOfRows == 0)
            {
                MessageBox.Show("Không tìm được dữ liệu để xoá ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            else
            {
                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            GridSP.DataSource = sanphamBUS.GetSanPham();
            
        }

        private void btTimSP_Click(object sender, EventArgs e)
        {
            string MaSP = txtTimSP.Text;

            try
            {
                List<SanPhamDTO> list = new SanPhamBUS().GetSanPhamWK(MaSP);
                if (list.Count > 0)
                {
                    GridSP.DataSource = list;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi hệ thống\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string MaSP, TenSP, MaLSP, DGN, DGB, SLTK;
            MaSP = txtMaSP.Text;
            TenSP = txtTenSP.Text;
            MaLSP = cboMaLSP.SelectedValue.ToString();
            SLTK = txtSLTonKho.Text;
            DGN = txtDGNhap.Text;
            DGB = txtDGBan.Text;
            SanPhamDTO sp = new SanPhamDTO(MaSP, TenSP, MaLSP, SLTK, DGN, DGB);
            try
            {
                int num = sanphamBUS.Update(sp);
                if (num > 0)
                {
                    MessageBox.Show("Sửa thành công", "Sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm để sửa", "Sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                GridSP.DataSource = sanphamBUS.GetSanPham();
            }
            catch(SqlException ex)
            {
                
                MessageBox.Show("Phải nhập Mã SP\n"+ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label9_MouseHover(object sender, EventArgs e)
        {
            label9.BackColor = Color.Black;
            label9.ForeColor = Color.White;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.BackColor = Color.LightSteelBlue;
            label9.ForeColor = Color.Black;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btTimLSP_Click(object sender, EventArgs e)
        {
            string MaLSP = txtTimLSP.Text;

            try
            {
                List<SanPhamDTO> list = new SanPhamBUS().GetLSPWK(MaLSP);
                if (list.Count > 0)
                {
                    GridSP.DataSource = list;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi hệ thống\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btReFr_Click(object sender, EventArgs e)
        {
            Reset();
            GridSP.DataSource = sanphamBUS.GetSanPham();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KiemKe kk = new KiemKe();
            kk.ShowDialog();
        }
    }
}
