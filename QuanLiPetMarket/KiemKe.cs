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
    public partial class KiemKe : Form
    {
        public KiemKe()
        {
            InitializeComponent();
        }

        private void KiemKe_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLPetMarketDataSet2.SanPham' table. You can move, or remove it, as needed.
            this.SanPhamTableAdapter.Fill(this.QLPetMarketDataSet2.SanPham);

            this.reportViewer1.RefreshReport();
        }
    }
}
