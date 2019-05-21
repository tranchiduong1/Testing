using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using DAO;

namespace TestDonHang
{
    
    [TestClass]
    public class TestDonHang
    {
        private DonHangDAO donhangDAO;
        private DonHangDTO dh1;
        private DonHangDTO dh2;
        private DonHangDTO dh3;
        private DonHangDTO dh4;

        [TestInitialize]
        public void setUp()
        {
            donhangDAO = new DonHangDAO();
            this.dh1 = new DonHangDTO("1", "1651010034", "18/11/2018", "KH01");
            this.dh2 = new DonHangDTO("2", "1651010144", "17/11/2018", "KH02");
            this.dh3 = new DonHangDTO("3", "1651010034", "16/11/2018", "KH03");
            this.dh4 = new DonHangDTO("4", "1651010144", "15/11/2018", "KH04");
        }

        [TestMethod]
        public void testTimDHCT()
        {
            List<DonHangDTO> kq = donhangDAO.GetDonHangWK("HD00");
            Assert.AreEqual(0, kq.Count);

            kq = donhangDAO.GetDonHangWK("HD02");
            Assert.AreEqual(1, kq.Count);
        }
        [TestMethod]
        public void testThemDonHang()
        {
            this.donhangDAO.Add(this.dh1);
            Assert.AreEqual(10, donhangDAO.GetDonHang().Count);
            Assert.AreEqual("1", donhangDAO.GetDonHang()[0].MaHDBan);
            Assert.AreEqual("1651010034", donhangDAO.GetDonHang()[0].MaNhanVien);

            this.donhangDAO.Add(this.dh2);
            Assert.AreEqual(11, donhangDAO.GetDonHang().Count);
            Assert.AreEqual("2", donhangDAO.GetDonHang()[1].MaHDBan);
            Assert.AreEqual("1651010144", donhangDAO.GetDonHang()[1].MaNhanVien);

            this.donhangDAO.Add(this.dh3);
            Assert.AreEqual(12, donhangDAO.GetDonHang().Count);
            Assert.AreEqual("3", donhangDAO.GetDonHang()[2].MaHDBan);
            Assert.AreEqual("1651010034", donhangDAO.GetDonHang()[2].MaNhanVien);
        }

        [TestMethod]
        public void testSuaDonHang()
        {
            this.dh1 = new DonHangDTO("1", "1651010144", "18/11/2018", "KH02");
            this.dh2 = new DonHangDTO("2", "1651010034", "14/11/2018", "KH03");
            this.dh3 = new DonHangDTO("3", "1651010144", "16/11/2018", "KH04");

            this.donhangDAO.Update(this.dh1);
            Assert.AreEqual("1651010144", donhangDAO.GetDonHang()[0].MaNhanVien);
            Assert.AreEqual("KH02", donhangDAO.GetDonHang()[0].MaKhachHang);
            Assert.AreNotEqual("1651010034", donhangDAO.GetDonHang()[0].MaNhanVien);
            Assert.AreNotEqual("KH01", donhangDAO.GetDonHang()[0].MaKhachHang);

            this.donhangDAO.Update(this.dh2);
            Assert.AreEqual("1651010034", donhangDAO.GetDonHang()[1].MaNhanVien);
            Assert.AreEqual("KH03",donhangDAO.GetDonHang()[1].MaKhachHang);
            Assert.AreNotEqual("KH02", donhangDAO.GetDonHang()[1].MaKhachHang);
            Assert.AreNotEqual("1651010144", donhangDAO.GetDonHang()[1].MaNhanVien);

            this.donhangDAO.Update(this.dh3);
            Assert.AreEqual("1651010144", donhangDAO.GetDonHang()[2].MaNhanVien);
            Assert.AreEqual("KH04", donhangDAO.GetDonHang()[2].MaKhachHang);
            Assert.AreNotEqual("1651010034", donhangDAO.GetDonHang()[2].MaNhanVien);
            Assert.AreNotEqual("KH03", donhangDAO.GetDonHang()[2].MaKhachHang);
        }

        [TestMethod]
        public void testXoaNhanVien()
        {
            Assert.AreEqual(12, donhangDAO.GetDonHang().Count);

            this.donhangDAO.Delete(this.dh4);
            Assert.AreEqual(12, donhangDAO.GetDonHang().Count);

            this.donhangDAO.Delete(this.dh1);
            Assert.AreEqual(11, donhangDAO.GetDonHang().Count);
            this.donhangDAO.Delete(this.dh2);
            Assert.AreEqual(10, donhangDAO.GetDonHang().Count);
            this.donhangDAO.Delete(this.dh3);
            Assert.AreEqual(9, donhangDAO.GetDonHang().Count);

        }
    }
}
