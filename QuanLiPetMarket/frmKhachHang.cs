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
    public partial class frmKhachHang : Form
    {
        KhachHangBUS khachhangBUS;
        public frmKhachHang()
        {
            InitializeComponent();
            khachhangBUS = new KhachHangBUS();
        }        
        public void Reset()
        {
            txtMaKH.Text = "";
            txtHoKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtMaKH.Focus();
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaKH, HoKH, TenKH, DiaChi, SDT;
                MaKH = txtMaKH.Text;
                HoKH = txtHoKH.Text;
                TenKH = txtTenKH.Text;
                DiaChi = txtDiaChi.Text;
                SDT = txtDienThoai.Text;

                KhachHangDTO khachhangDTO = new KhachHangDTO(MaKH, HoKH, TenKH, DiaChi, SDT);

                if (string.IsNullOrEmpty(txtMaKH.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                int numOfRows = khachhangBUS.Add(khachhangDTO);
                if (numOfRows > 0)
                {
                    MessageBox.Show("Thêm thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Reset();
                }
                GridKH.DataSource = khachhangBUS.GetKhachHang();
              
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Thêm thất bại, mã khách hàng đã có người sử dụng\n" +ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
            }
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            GridKH.DataSource = khachhangBUS.GetKhachHang();

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string MaKH;
            MaKH = txtMaKH.Text;
            KhachHangDTO kh = new KhachHangDTO(MaKH);

            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng nhập mã KH cần xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int numOfRows = khachhangBUS.Delete(kh);
            if (numOfRows == 0)
            {
                MessageBox.Show("Không tìm được KH để xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            GridKH.DataSource = khachhangBUS.GetKhachHang();

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
            string MaKH, HoKH, TenKH, DiaChi, SDT;
            MaKH = txtMaKH.Text;
            HoKH = txtHoKH.Text;
            TenKH = txtTenKH.Text;
            DiaChi = txtDiaChi.Text;
            SDT = txtDienThoai.Text;

            KhachHangDTO khachhangDTO = new KhachHangDTO(MaKH, HoKH, TenKH, DiaChi, SDT);

            try
            {
                int numOfRows = khachhangBUS.Update(khachhangDTO);
                if (numOfRows > 0)
                {
                    MessageBox.Show("Sửa thành công", " Sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridKH.DataSource = khachhangBUS.GetKhachHang();
                }
                else
                {
                    MessageBox.Show("không tìm được khách hàng để sửa", " Sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Lỗi hệ thống" + ex.Message, " Sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btTimKH_Click(object sender, EventArgs e)
        {
            string MaKH = txtTimKH.Text;

            try
            {
                List<KhachHangDTO> list = new KhachHangBUS().GetKhachHangWK(MaKH);               
                if (list.Count > 0)
                {
                    GridKH.DataSource = list;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi hệ thống\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
            GridKH.DataSource = khachhangBUS.GetKhachHang();
        }
    }
}
