using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using DAO;

namespace TestSuiteCollection
{

    [TestClass]
    public class TestSanPham
    {
        private SanPhamDAO sanphamDAO;
        private SanPhamDTO sp1;
        private SanPhamDTO sp2;
        private SanPhamDTO sp3;
        private SanPhamDTO sp4;
        private SanPhamDTO sp5;

        [TestInitialize]
        public void SetUp()
        {
            sanphamDAO = new SanPhamDAO();
            this.sp1 = new SanPhamDTO("1", "Sữa tắm mướt lông", "CSCM", "30", "6000", "30000");
            this.sp2 = new SanPhamDTO("2", "Áo tắm", "DDCM", "10", "20000", "80000");
            this.sp3 = new SanPhamDTO("3", "Thuốc an thần", "DPCM", "15", "60000", "180000");
            this.sp4 = new SanPhamDTO("4", "Áo quần Adidas", "PKCM", "30", "150000", "130000");
            this.sp5 = new SanPhamDTO("5", "Ngũ cốc hoàng gia", "TACM", "30", "150000", "450000");
        }

        [TestMethod]
        public void testThemSanPham()
        {
            this.sanphamDAO.Add(this.sp1);
            Assert.AreEqual(16, sanphamDAO.GetSanPham().Count);
            Assert.AreEqual("1", sanphamDAO.GetSanPham()[0].MaSP);
            Assert.AreEqual("CSCM", sanphamDAO.GetSanPham()[0].MaLSP);
            Assert.AreEqual("Sữa tắm mướt lông", sanphamDAO.GetSanPham()[0].TenSP);

            this.sanphamDAO.Add(this.sp2);
            Assert.AreEqual(17, sanphamDAO.GetSanPham().Count);
            Assert.AreEqual("2", sanphamDAO.GetSanPham()[1].MaSP);
            Assert.AreEqual("DDCM", sanphamDAO.GetSanPham()[1].MaLSP);
            Assert.AreEqual("Áo tắm", sanphamDAO.GetSanPham()[1].TenSP);

            this.sanphamDAO.Add(this.sp3);
            Assert.AreEqual(18, sanphamDAO.GetSanPham().Count);
            Assert.AreEqual("3", sanphamDAO.GetSanPham()[2].MaSP);
            Assert.AreEqual("DPCM", sanphamDAO.GetSanPham()[2].MaLSP);
            Assert.AreEqual("Thuốc an thần", sanphamDAO.GetSanPham()[2].TenSP);

            this.sanphamDAO.Add(this.sp4);
            Assert.AreEqual(19, sanphamDAO.GetSanPham().Count);
            Assert.AreEqual("4", sanphamDAO.GetSanPham()[3].MaSP);
            Assert.AreEqual("PKCM", sanphamDAO.GetSanPham()[3].MaLSP);
            Assert.AreEqual("Áo quần Adidas", sanphamDAO.GetSanPham()[3].TenSP);
        }

        [TestMethod]
        public void testSuaSanPham()
        {
            this.sp1 = new SanPhamDTO("1", "Sữa tắm siêu cấp mướt lông", "CSCM", "15", "6000", "30000");
            this.sp2 = new SanPhamDTO("2", "Áo lụa Mông Cổ", "PKCM", "10", "25000", "80000");
            this.sp3 = new SanPhamDTO("3", "Thuốc an thần liều cao", "DPCM", "15", "72000", "200000");

            this.sanphamDAO.Update(this.sp1);
            Assert.AreEqual("Sữa tắm siêu cấp mướt lông", sanphamDAO.GetSanPham()[0].TenSP);
            Assert.AreEqual("15", sanphamDAO.GetSanPham()[0].SLTonKho);
            Assert.AreNotEqual("Sữa tắm mướt lông", sanphamDAO.GetSanPham()[0].TenSP);
            Assert.AreNotEqual("30", sanphamDAO.GetSanPham()[0].SLTonKho);

            this.sanphamDAO.Update(this.sp2);
            Assert.AreEqual("PKCM", sanphamDAO.GetSanPham()[1].MaLSP);
            Assert.AreEqual("25000", sanphamDAO.GetSanPham()[1].DGNhap);
            Assert.AreNotEqual("DDCM", sanphamDAO.GetSanPham()[1].MaLSP);
            Assert.AreNotEqual("20000", sanphamDAO.GetSanPham()[1].DGNhap);

            this.sanphamDAO.Update(this.sp3);
            Assert.AreEqual("Thuốc an thần liều cao", sanphamDAO.GetSanPham()[2].TenSP);
            Assert.AreEqual("72000", sanphamDAO.GetSanPham()[2].DGNhap);
            Assert.AreEqual("200000", sanphamDAO.GetSanPham()[2].DGBan);
            Assert.AreNotEqual("Thuốc an thần", sanphamDAO.GetSanPham()[2].TenSP);
            Assert.AreNotEqual("60000", sanphamDAO.GetSanPham()[2].DGNhap);
            Assert.AreNotEqual("180000", sanphamDAO.GetSanPham()[2].DGBan);
        }

        [TestMethod]
        public void testXoaSanPham()
        {
            Assert.AreEqual(19, sanphamDAO.GetSanPham().Count);

            this.sanphamDAO.Delete(this.sp5);
            Assert.AreEqual(19, sanphamDAO.GetSanPham().Count);
            this.sanphamDAO.Delete(this.sp1);
            Assert.AreEqual(18, sanphamDAO.GetSanPham().Count);
            this.sanphamDAO.Delete(this.sp2);
            Assert.AreEqual(17, sanphamDAO.GetSanPham().Count);
            this.sanphamDAO.Delete(this.sp3);
            Assert.AreEqual(16, sanphamDAO.GetSanPham().Count);
            this.sanphamDAO.Delete(this.sp4);
            Assert.AreEqual(15, sanphamDAO.GetSanPham().Count);
        }

        [TestMethod]
        public void testTimSanPhamTheoMaSanPhamVaMaLoaiSanPham()
        {
            List<SanPhamDTO> kq = sanphamDAO.GetSanPhamWK("CSCM00");
            Assert.AreEqual(0, kq.Count);

            List<SanPhamDTO> kq1 = sanphamDAO.GetLSPWK("CSCM00");
            Assert.AreEqual(0, kq1.Count);

            kq1 = sanphamDAO.GetLSPWK("CSCM");
            Assert.AreEqual(3, kq1.Count);

            kq = sanphamDAO.GetSanPhamWK("CSCM01");
            Assert.AreEqual(1, kq.Count);
        }
    }
}
