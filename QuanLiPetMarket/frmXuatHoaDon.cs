using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiPetMarket
{
    public partial class frmXuatHoaDon : Form
    {
        public frmXuatHoaDon()
        {
            InitializeComponent();
        }

        private void frmXuatHoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLPetMarketDataSet1.HoaDonChiTiet' table. You can move, or remove it, as needed.
            this.HoaDonChiTietTableAdapter.Fill(this.QLPetMarketDataSet1.HoaDonChiTiet);

            this.reportViewer1.RefreshReport();
        }
    }
}
