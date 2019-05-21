using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using DAO;

namespace TestDonHang
{

    [TestClass]
    public class TestDonHangChiTiet
    {
        private DonHangChiTietDAO dhctDAO;
        private DonHangChiTietDTO hdct1;
        private DonHangChiTietDTO hdct2;
        private DonHangChiTietDTO hdct3;
        private DonHangChiTietDTO hdct4;

        [TestInitialize]
        public void SetUp()
        {
            dhctDAO = new DonHangChiTietDAO();
            hdct1 = new DonHangChiTietDTO("HD001", "CSCM01", "2", "5000","0", "10000");
            hdct2 = new DonHangChiTietDTO("HD002", "DDCM01", "1", "30000", "0", "30000");
            hdct3 = new DonHangChiTietDTO("HD003", "DPCM01", "2", "5000", "2000", "8000");
            hdct4 = new DonHangChiTietDTO("HD004", "PKCM01", "2", "150000", "30000", "270000");
        }
        [TestMethod]
        public void testTimDHCT()
        {
            List<DonHangChiTietDTO> kq = dhctDAO.GetDHCTWK("HD00");
            Assert.AreEqual(0, kq.Count);

            kq = dhctDAO.GetDHCTWK("HD02");
            Assert.AreEqual(1, kq.Count);
        }

        [TestMethod]
        public void testThemHDCT()
        {
            this.dhctDAO.Add(this.hdct1);
            Assert.AreEqual(6, dhctDAO.GetDHCT().Count);
            Assert.AreEqual("HD001", dhctDAO.GetDHCT()[0].MaHDBan);
            Assert.AreEqual("CSCM01", dhctDAO.GetDHCT()[0].MaSanPham);

            this.dhctDAO.Add(this.hdct2);
            Assert.AreEqual(7, dhctDAO.GetDHCT().Count);
            Assert.AreEqual("HD002", dhctDAO.GetDHCT()[1].MaHDBan);
            Assert.AreEqual("DDCM01", dhctDAO.GetDHCT()[1].MaSanPham);

            this.dhctDAO.Add(this.hdct3);
            Assert.AreEqual(8, dhctDAO.GetDHCT().Count);
            Assert.AreEqual("HD003", dhctDAO.GetDHCT()[2].MaHDBan);
            Assert.AreEqual("DPCM01", dhctDAO.GetDHCT()[2].MaSanPham);
        }

        [TestMethod]
        public void testSuaDHCT()
        {
            hdct1 = new DonHangChiTietDTO("HD001", "CSCM01", "5", "5000", "0", "25000");
            hdct2 = new DonHangChiTietDTO("HD002", "DDCM01", "1", "30000", "3000", "27000");
            hdct3 = new DonHangChiTietDTO("HD003", "DPCM01", "2", "5000", "0", "10000");

            this.dhctDAO.Update(this.hdct1);
            Assert.AreEqual("5", dhctDAO.GetDHCT()[0].SoLuong);
            Assert.AreEqual("25000", dhctDAO.GetDHCT()[0].ThanhTien);
            Assert.AreNotEqual("2", dhctDAO.GetDHCT()[0].SoLuong);
            Assert.AreNotEqual("10000", dhctDAO.GetDHCT()[0].ThanhTien);

            this.dhctDAO.Update(this.hdct2);
            Assert.AreEqual("3000", dhctDAO.GetDHCT()[1].GiamGia);
            Assert.AreEqual("27000", dhctDAO.GetDHCT()[1].ThanhTien);
            Assert.AreNotEqual("0", dhctDAO.GetDHCT()[1].GiamGia);
            Assert.AreNotEqual("30000", dhctDAO.GetDHCT()[1].ThanhTien);

            this.dhctDAO.Update(this.hdct3);
            Assert.AreEqual("10000", dhctDAO.GetDHCT()[2].ThanhTien);
            Assert.AreEqual("0", dhctDAO.GetDHCT()[2].GiamGia);
            Assert.AreNotEqual("8000", dhctDAO.GetDHCT()[2].ThanhTien);
            Assert.AreNotEqual("2000", dhctDAO.GetDHCT()[2].GiamGia);
        }

        [TestMethod]
        public void testXoaDHCT()
        {
            Assert.AreEqual(8, dhctDAO.GetDHCT().Count);

            this.dhctDAO.Delete(this.hdct4);
            Assert.AreEqual(8, dhctDAO.GetDHCT().Count);

            this.dhctDAO.Delete(this.hdct1);
            Assert.AreEqual(7, dhctDAO.GetDHCT().Count);
            this.dhctDAO.Delete(this.hdct2);
            Assert.AreEqual(6, dhctDAO.GetDHCT().Count);
            this.dhctDAO.Delete(this.hdct3);
            Assert.AreEqual(5, dhctDAO.GetDHCT().Count);
        }
    }
}
