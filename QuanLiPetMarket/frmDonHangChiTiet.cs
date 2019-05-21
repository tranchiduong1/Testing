using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;



namespace QuanLiPetMarket
{
    public partial class frmDonHangChiTiet : Form
    {
        
        DonHangChiTietBUS donhangchitietBUS;
        SanPhamBUS sanphamBUS;
        DonHangBUS donhangBUS;
        public frmDonHangChiTiet()
        {
            InitializeComponent();
            donhangchitietBUS = new DonHangChiTietBUS();
            sanphamBUS = new SanPhamBUS();
            donhangBUS = new DonHangBUS();
        }
        
        private void frmDonHang_Load(object sender, EventArgs e)
        {
            GridHoaDon.DataSource = donhangchitietBUS.GetDHCT();


            cboMaSP.DataSource = sanphamBUS.GetSanPham();
            cboMaSP.DisplayMember = "TenSP";
            cboMaSP.ValueMember = "MaSP";

            

            cboDH.DataSource = donhangBUS.GetDonHang();
            cboDH.DisplayMember = "MaHDBan";
            cboDH.ValueMember = "MaHDBan";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmDonHang xhd = new frmDonHang();
            xhd.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                int thanhtien = (Int32.Parse(txtDonGia.Text) * Int32.Parse(txtSoLuong.Text)) - Int32.Parse(txtGiamGia.Text);
                if(txtDonGia.Text != null && txtSoLuong.Text != null && txtGiamGia != null)
                {
                    txtThanhTien.Text = thanhtien.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Phải nhập đơn giá, số lượng, giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonGia.Focus();
            }
        }
        public void Reset()
        {
           
            
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            txtGiamGia.Text = "";
            txtThanhTien.Text = "";
        
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaHD, MaSP, SL, DG, GG, TT;
                MaHD = cboDH.SelectedValue.ToString() ;
                MaSP = cboMaSP.SelectedValue.ToString();
                SL = txtSoLuong.Text;
                DG = txtDonGia.Text;
                GG = txtGiamGia.Text;
                TT = txtThanhTien.Text;

                DonHangChiTietDTO dhct = new DonHangChiTietDTO(MaHD, MaSP, SL, DG, GG, TT);
     
                int numOfRows = donhangchitietBUS.Add(dhct);
                    
                if (numOfRows > 0)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                GridHoaDon.DataSource = donhangchitietBUS.GetDHCT();
                
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Thêm thất bại, trùng mã hoá đơn và mã sản phẩm\n"+ex.Message , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string MaHD, MaSP, SL, DG, GG, TT;
            MaHD = cboDH.SelectedValue.ToString();
            MaSP = cboMaSP.SelectedValue.ToString();
            SL = txtSoLuong.Text;
            DG = txtDonGia.Text;
            GG = txtGiamGia.Text;
            TT = txtThanhTien.Text;

            DonHangChiTietDTO dhct = new DonHangChiTietDTO(MaHD, MaSP, SL, DG, GG, TT);
            try
            {
                int numOfRows = donhangchitietBUS.Update(dhct);

                if (numOfRows > 0)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("không tìm được đơn hàng để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                GridHoaDon.DataSource = donhangchitietBUS.GetDHCT();
              
            }
            catch
            {
                MessageBox.Show("Phải nhập đủ Mã Hoá Đơn và Mã Loại Sản Phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btTim_Click(object sender, EventArgs e)
        {
            string MaHD = cboDH.SelectedValue.ToString();
            try
            {
                List<DonHangChiTietDTO> list = new DonHangChiTietBUS().GetDHCTWK(MaHD);
                if (list.Count > 0)
                {
                    GridHoaDon.DataSource = list;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đơn hàng chi tiết nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi hệ thống\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            string MaHDBan;
            MaHDBan = cboDH.SelectedValue.ToString();
            DonHangChiTietDTO dhct = new DonHangChiTietDTO(MaHDBan);

            int numOfRows = donhangchitietBUS.Delete(dhct);
            if (numOfRows == 0)
            {
                MessageBox.Show("Không tìm được dữ liệu để xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            else
            {
                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            GridHoaDon.DataSource = donhangchitietBUS.GetDHCT();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reset();
            GridHoaDon.DataSource = donhangchitietBUS.GetDHCT();
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            frmSanPham sp = new frmSanPham();
            if (MessageBox.Show("Bạn muốn đóng?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.BackColor = Color.Black;
            label3.ForeColor = Color.White;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.LightSteelBlue;
            label3.ForeColor = Color.Black;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btXuatHD_Click(object sender, EventArgs e)
        {
            frmXuatHoaDon xhd = new frmXuatHoaDon();
            xhd.ShowDialog();
        }
    }
}
