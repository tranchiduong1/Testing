using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using DAO;
using BUS;

namespace TestSuiteCollection
{

    [TestClass]
    public class TestKhachHang
    {
        private List<KhachHangDTO> GetKhachHang;
        private KhachHangDAO khachhangDAO;
        private KhachHangDTO kh1;
        private KhachHangDTO kh2;
        private KhachHangDTO kh3;
        private KhachHangDTO kh4;
        private KhachHangDTO kh5;
        private KhachHangDTO kh6;

        [TestInitialize]
        public void SetUp()
        {
            this.GetKhachHang = new List<KhachHangDTO>();
            this.khachhangDAO = new KhachHangDAO();
            this.kh1 = new KhachHangDTO("1", "Quan", "Vũ", "123 TQC", "123456");
            this.kh2 = new KhachHangDTO("2", "Lưu", "Bị", "321 TQC", "9632587");
            this.kh3 = new KhachHangDTO("3", "Trương", "Phi", "963 TQC", "5469871231");
            this.kh4 = new KhachHangDTO("4", "Gia Cát", "Lượng", "654 TQC ", "321650458");
            this.kh5 = new KhachHangDTO("5", "Hạ Hầu", "Quyên", "854 TQC", "012365478");
            this.kh6 = new KhachHangDTO("6", "Hạ Hầu", "Đôn", "654 TQC", "6549871");
        }
        [TestMethod]
        public void testTimKhachHang()
        {
            List<KhachHangDTO> kq = khachhangDAO.GetKhachHangWK("KH00");
            Assert.AreEqual(0, kq.Count);

            kq = khachhangDAO.GetKhachHangWK("KH01");
            Assert.AreEqual(1, kq.Count);
        }
    
        [TestMethod]
        public void testThemKhachHang()
        {
            this.khachhangDAO.Add(this.kh1);
            Assert.AreEqual(7, khachhangDAO.GetKhachHang().Count);
            Assert.AreEqual("1", khachhangDAO.GetKhachHang()[0].MaKH);
            Assert.AreEqual("Quan", khachhangDAO.GetKhachHang()[0].HoKH);
            Assert.AreEqual("Vũ", khachhangDAO.GetKhachHang()[0].TenKH);
            
            this.khachhangDAO.Add(this.kh2);
            Assert.AreEqual(8, khachhangDAO.GetKhachHang().Count);
            Assert.AreEqual("2", khachhangDAO.GetKhachHang()[1].MaKH);
            Assert.AreEqual("Lưu", khachhangDAO.GetKhachHang()[1].HoKH);
            Assert.AreEqual("Bị", khachhangDAO.GetKhachHang()[1].TenKH);

            this.khachhangDAO.Add(this.kh3);
            Assert.AreEqual(9, khachhangDAO.GetKhachHang().Count);
            Assert.AreEqual("3", khachhangDAO.GetKhachHang()[2].MaKH);
            Assert.AreEqual("Trương", khachhangDAO.GetKhachHang()[2].HoKH);
            Assert.AreEqual("Phi", khachhangDAO.GetKhachHang()[2].TenKH);

            this.khachhangDAO.Add(this.kh4);
            Assert.AreEqual(10, khachhangDAO.GetKhachHang().Count);
            Assert.AreEqual("4", khachhangDAO.GetKhachHang()[3].MaKH);
            Assert.AreEqual("Gia Cát", khachhangDAO.GetKhachHang()[3].HoKH);
            Assert.AreEqual("Lượng", khachhangDAO.GetKhachHang()[3].TenKH);

            this.khachhangDAO.Add(this.kh5);
            Assert.AreEqual(11, khachhangDAO.GetKhachHang().Count);
            Assert.AreEqual("5", khachhangDAO.GetKhachHang()[4].MaKH);
            Assert.AreEqual("Hạ Hầu", khachhangDAO.GetKhachHang()[4].HoKH);
            Assert.AreEqual("Quyên", khachhangDAO.GetKhachHang()[4].TenKH);
        }

        [TestMethod]
        public void testSuaKhachHang()
        {
            this.kh1 = new KhachHangDTO("1", "Vân", "Trường", "123 TQC", "123456");
            this.kh2 = new KhachHangDTO("2", "Huyền", "Đức", "321 TQC", "9632587");

            this.khachhangDAO.Update(this.kh1);
            Assert.AreEqual("Vân", khachhangDAO.GetKhachHang()[0].HoKH);
            Assert.AreNotEqual("Quan", khachhangDAO.GetKhachHang()[0].HoKH);
            Assert.AreEqual("Trường", khachhangDAO.GetKhachHang()[0].TenKH);
            Assert.AreNotEqual("Vũ", khachhangDAO.GetKhachHang()[0].TenKH);

            this.khachhangDAO.Update(this.kh2);
            Assert.AreEqual("Huyền", khachhangDAO.GetKhachHang()[1].HoKH);
            Assert.AreNotEqual("Lưu", khachhangDAO.GetKhachHang()[0].HoKH);
            Assert.AreEqual("Đức", khachhangDAO.GetKhachHang()[1].TenKH);
            Assert.AreNotEqual("Bị", khachhangDAO.GetKhachHang()[0].TenKH);

        }

        [TestMethod]
        public void testXoaKhachHang()
        {
            Assert.AreEqual(11, khachhangDAO.GetKhachHang().Count);

            this.khachhangDAO.Delete(this.kh6);
            Assert.AreEqual(11, khachhangDAO.GetKhachHang().Count);

            this.khachhangDAO.Delete(this.kh1);
            Assert.AreEqual(10, khachhangDAO.GetKhachHang().Count);
            this.khachhangDAO.Delete(this.kh2);
            Assert.AreEqual(9, khachhangDAO.GetKhachHang().Count);
            this.khachhangDAO.Delete(this.kh3);
            Assert.AreEqual(8, khachhangDAO.GetKhachHang().Count);
            this.khachhangDAO.Delete(this.kh4);
            Assert.AreEqual(7, khachhangDAO.GetKhachHang().Count);
            this.khachhangDAO.Delete(this.kh5);
            Assert.AreEqual(6, khachhangDAO.GetKhachHang().Count);

        }
    }





}

