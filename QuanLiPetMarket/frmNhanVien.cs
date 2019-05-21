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
    public partial class frmNhanVien : Form
    {
        NhanVienBUS quantriBUS;
        public frmNhanVien()
        {
            InitializeComponent();
            quantriBUS = new NhanVienBUS();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmThemAccount add = new frmThemAccount();
            add.Show();
        }
       
        private void frmQuanTri_Load(object sender, EventArgs e)
        {
            GridNhanVien.DataSource = quantriBUS.GetNhanVien();
        }
        public void Reset()
        {
            txtMaNV.Text = "";
            txtHoNV.Text = "";
            txtTenNV.Text = "";
            txtChucDanh.Text = "";
            txtNgaySinh.Text = "";
            txtStartDate.Text = "";
            txtGioiTinh.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtMaNV.Focus();
        }
        private void btThem_Click(object sender, EventArgs e)
        {
                string MaNhanVien, HoNhanVien, TenNhanVien, ChucDanh, NgaySinh, NgayBatDauLamViec, GioiTinh, DiaChi, SoDienThoai;

                MaNhanVien = txtMaNV.Text;
                HoNhanVien = txtHoNV.Text;
                TenNhanVien = txtTenNV.Text;
                ChucDanh = txtChucDanh.Text;
                NgaySinh = txtNgaySinh.Text;
                NgayBatDauLamViec = txtStartDate.Text;
                GioiTinh = txtGioiTinh.Text;
                DiaChi = txtDiaChi.Text;
                SoDienThoai = txtSDT.Text;

                NhanVienDTO quantri = new NhanVienDTO(MaNhanVien, HoNhanVien, TenNhanVien, ChucDanh, NgaySinh, NgayBatDauLamViec, GioiTinh, DiaChi, SoDienThoai);
            try
            {
                if (string.IsNullOrEmpty(txtMaNV.Text))
                    return;
                int numOfRows = quantriBUS.Add(quantri);
                if (numOfRows > 0)
                {
                    MessageBox.Show("Thêm thành công, yêu cầu tạo tài khoản cho nhân viên mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                GridNhanVien.DataSource = quantriBUS.GetNhanVien();                
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Thêm thất bại, mã nhân viên bị trùng \n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                frmXacNhanXoaNV xn = new frmXacNhanXoaNV();
                  xn.ShowDialog();
                
                    string MaNhanVien;
                    MaNhanVien = txtMaNV.Text;
                    NhanVienDTO quantri = new NhanVienDTO(MaNhanVien);


                    if (string.IsNullOrEmpty(txtMaNV.Text))
                    {
                        return;
                    }

                    int numOfRows = quantriBUS.Delete(quantri);
                    if (numOfRows == 0)
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    GridNhanVien.DataSource = quantriBUS.GetNhanVien();
               
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Lỗi hệ thống\n" + ex.Message);
            }
           
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
            string MaNhanVien, HoNhanVien, TenNhanVien, ChucDanh, NgaySinh, NgayBatDauLamViec, GioiTinh, DiaChi, SoDienThoai;

            MaNhanVien = txtMaNV.Text;
            HoNhanVien = txtHoNV.Text;
            TenNhanVien = txtTenNV.Text;
            ChucDanh = txtChucDanh.Text;
            NgaySinh = txtNgaySinh.Text;
            NgayBatDauLamViec = txtStartDate.Text;
            GioiTinh = txtGioiTinh.Text;
            DiaChi = txtDiaChi.Text;
            SoDienThoai = txtSDT.Text;

            NhanVienDTO quantri = new NhanVienDTO(MaNhanVien, HoNhanVien, TenNhanVien, ChucDanh, NgaySinh, NgayBatDauLamViec, GioiTinh, DiaChi, SoDienThoai);

            try
            {
                int numOfRows = quantriBUS.Update(quantri);
                if (numOfRows > 0)
                {
                    MessageBox.Show("Sửa thành công", "Sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy để sửa", "Sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                GridNhanVien.DataSource = quantriBUS.GetNhanVien();

            }
            catch (SqlException ex)
            {

                MessageBox.Show("Lỗi hệ thống" + ex.Message);
            }
                
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimNV();
        }

        public void TimNV()
        {
            string MaNV = txtMaNV.Text;

            try
            {
                List<NhanVienDTO> list = new NhanVienBUS().GetNhanVienWK(MaNV);
                if (list.Count > 0)
                {
                    GridNhanVien.DataSource = list;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi hệ thống\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    

        private void label11_MouseHover(object sender, EventArgs e)
        {
            label11.BackColor = Color.Black;
            label11.BackColor = Color.White;
        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            label11.BackColor = Color.LightSteelBlue;
            label11.ForeColor = Color.Black;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reset();
            GridNhanVien.DataSource = quantriBUS.GetNhanVien();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmXacNhanXoaNV xc = new frmXacNhanXoaNV();
            xc.ShowDialog();
            frmXemAccountList xem = new frmXemAccountList();
            xem.Show();
        }
    }
}
