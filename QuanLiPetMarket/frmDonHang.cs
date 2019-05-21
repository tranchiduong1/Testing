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
    public partial class frmDonHang : Form
    {
        DonHangBUS donhangBUS;
        NhanVienBUS quantriBUS;
        KhachHangBUS khachhangBUS;
        public frmDonHang()
        {
            InitializeComponent();
            donhangBUS = new DonHangBUS();
            quantriBUS = new NhanVienBUS();
            khachhangBUS = new KhachHangBUS();
        }
        
        public void Reset()
        {
            txtMaHD.Text = "";            
            txtNgayBan.Text = "";
           
        }
        private void btHuy_Click(object sender, EventArgs e)
        {
            string MaHDBan;
            MaHDBan = txtMaHD.Text;
            DonHangDTO donhang = new DonHangDTO(MaHDBan);
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hoá đơn cần xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int numOfRows = donhangBUS.Delete(donhang);
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
            GridXemHD.DataSource = donhangBUS.GetDonHang();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {

                //if (string.IsNullOrEmpty(txtNgayBan.Text))
                //{
                //    txtNgayBan.Text = DateTime.Now.ToString();
                //}

                string MaHD, MaNV, NB, MaKH;
                MaHD = txtMaHD.Text;
                MaNV = cboMaNV.SelectedValue.ToString();
                NB = txtNgayBan.Text;
                MaKH = cboKH.SelectedValue.ToString();

                DonHangDTO donhang = new DonHangDTO(MaHD, MaNV, NB, MaKH);

                if (string.IsNullOrEmpty(txtMaHD.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã đơn hàng cần thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }

                int numOfRows = donhangBUS.Add(donhang);
                if (numOfRows > 0)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }

                GridXemHD.DataSource = donhangBUS.GetDonHang();
                
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Thêm thất bại, trùng mã hoá đơn\n" + ex.Message , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmXemHoaDon_Load(object sender, EventArgs e)
        {
            GridXemHD.DataSource = donhangBUS.GetDonHang();

            cboMaNV.DataSource = quantriBUS.GetNhanVien();
            cboMaNV.DisplayMember = "TenNhanVien";
            cboMaNV.ValueMember = "MaNhanVien";

            cboKH.DataSource = khachhangBUS.GetKhachHang();
            cboKH.DisplayMember = "MaKH";
            cboKH.ValueMember = "MaKH";

        }

        private void btDong_Click(object sender, EventArgs e)
        {
            frmSanPham sp = new frmSanPham();
            if (MessageBox.Show("Bạn muốn đóng?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {

            string MaHD, MaNV, MaKH, NB;
                MaHD = txtMaHD.Text;
                MaNV = cboMaNV.SelectedValue.ToString();
                NB = txtNgayBan.Text;
                MaKH = cboKH.SelectedValue.ToString();

                DonHangDTO donhang = new DonHangDTO(MaHD, MaNV, NB, MaKH);
            try
            {
                int num = donhangBUS.Update(donhang);
                if (num > 0)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Không tìm được đơn hàng để sửa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                }
                GridXemHD.DataSource = donhangBUS.GetDonHang();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Lỗi hệ thống\n" + ex.Message, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            string MaHD = txtMaHD.Text;

            try
            {
                List<DonHangDTO> list = new DonHangBUS().GetDonHangWK(MaHD);
                if (list.Count > 0)
                {
                    GridXemHD.DataSource = list;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đơn hàng nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi hệ thống\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            label6.BackColor = Color.Black;
            label6.ForeColor = Color.White;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.BackColor = Color.LightSteelBlue;
            label6.ForeColor = Color.Black;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btReFr_Click(object sender, EventArgs e)
        {
            Reset();
            GridXemHD.DataSource = donhangBUS.GetDonHang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDonHangChiTiet dhct = new frmDonHangChiTiet();
            dhct.Show();
        }
    }
}
