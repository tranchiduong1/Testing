using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using DAO;
using BUS;

namespace TestNhanVien
{

    [TestClass]
    public class TestNhanVien
    {
        private List<NhanVienDTO> GetNhanVien;
        private NhanVienDAO nhanvienDAO;
        private NhanVienDTO nv1;
        private NhanVienDTO nv2;
        private NhanVienDTO nv3;
        private NhanVienDTO nv4;
        private NhanVienDTO nv5;
        private NhanVienDTO nv6;
        private NhanVienDTO nv7;

        [TestInitialize]
        public void Setup()
        {
            this.GetNhanVien = new List<NhanVienDTO>();          
            this.nhanvienDAO = new NhanVienDAO();
            this.nv1 = new NhanVienDTO("1651010010", "Lữ", "Bố", "Giám đốc", "01/03/2015", "02/02/1999", "Nam", "123", "321");
            this.nv2 = new NhanVienDTO("1651010011", "Điêu", "Thuyền", "Kế toán", "01/03/2015", "02/02/1999", "Nữ", "13212", "32213121");
            this.nv3 = new NhanVienDTO("1651010012", "Viên", "Thiệu", "Quản lí kho", "01/03/2015", "02/02/1999", "Nam", "1253453", "32121323");
            this.nv4 = new NhanVienDTO("1651010013", "Viên", "Thuật", "Quản lí", "01/03/2015", "02/02/1999", "Nam", "134523", "321123");
            this.nv5 = new NhanVienDTO("1651010014", "Mã", "Siêu", "Bảo vệ", "01/03/2015", "02/02/1999", "Nam", "112323", "324321");
            this.nv6 = new NhanVienDTO("1651010015", "Tây", "Thi", "Lao Công", "01/03/2015", "02/02/1999", "Nữ", "112323", "324321");
            this.nv7 = new NhanVienDTO("1651010016", "Hoa", "Đà", "Y tế", "01/03/2015", "02/02/1999", "Nữ", "112323", "324321");
        }

        [TestMethod]
        public void testThemNhanVien()
        {

            this.nhanvienDAO.Add(this.nv1);
            Assert.AreEqual(5, nhanvienDAO.GetNhanVien().Count);
            Assert.AreEqual("1651010010", nhanvienDAO.GetNhanVien()[0].MaNhanVien);
            Assert.AreEqual("Lữ", nhanvienDAO.GetNhanVien()[0].HoNhanVien);
            Assert.AreEqual("Bố", nhanvienDAO.GetNhanVien()[0].TenNhanVien);

            this.nhanvienDAO.Add(this.nv2);
            Assert.AreEqual(6, nhanvienDAO.GetNhanVien().Count);
            Assert.AreEqual("1651010011", nhanvienDAO.GetNhanVien()[1].MaNhanVien);
            Assert.AreEqual("Điêu", nhanvienDAO.GetNhanVien()[1].HoNhanVien);
            Assert.AreEqual("Thuyền", nhanvienDAO.GetNhanVien()[1].TenNhanVien);

            this.nhanvienDAO.Add(this.nv3);
            Assert.AreEqual(7, nhanvienDAO.GetNhanVien().Count);
            Assert.AreEqual("1651010012", nhanvienDAO.GetNhanVien()[2].MaNhanVien);
            Assert.AreEqual("Viên", nhanvienDAO.GetNhanVien()[2].HoNhanVien);
            Assert.AreEqual("Thiệu", nhanvienDAO.GetNhanVien()[2].TenNhanVien);

            this.nhanvienDAO.Add(this.nv4);
            Assert.AreEqual(8, nhanvienDAO.GetNhanVien().Count);
            Assert.AreEqual("1651010013", nhanvienDAO.GetNhanVien()[3].MaNhanVien);
            Assert.AreEqual("Viên", nhanvienDAO.GetNhanVien()[3].HoNhanVien);
            Assert.AreEqual("Thuật", nhanvienDAO.GetNhanVien()[3].TenNhanVien);

            this.nhanvienDAO.Add(this.nv5);
            Assert.AreEqual(9, nhanvienDAO.GetNhanVien().Count);
            Assert.AreEqual("1651010014", nhanvienDAO.GetNhanVien()[4].MaNhanVien);
            Assert.AreEqual("Mã", nhanvienDAO.GetNhanVien()[4].HoNhanVien);
            Assert.AreEqual("Siêu", nhanvienDAO.GetNhanVien()[4].TenNhanVien);

        }


        [TestMethod]
        public void testSuaNhanVien()
        {

            nv1 = new NhanVienDTO("1651010010", "Lữ", "Phụng Tiên", "Giám đốc", "01/03/2015", "02/02/1999", "Nam", "123", "321");
            this.nhanvienDAO.Update(this.nv1);
            Assert.AreEqual("Phụng Tiên", nhanvienDAO.GetNhanVien()[0].TenNhanVien);
            Assert.AreNotEqual("Bố", nhanvienDAO.GetNhanVien()[0].TenNhanVien);
            Assert.IsNotNull(nv1.MaNhanVien);

            this.nv2 = new NhanVienDTO("1651010011", "Điêu", "Thuyền", "Trưởng phòng nhân sự", "02/23/2016", "02/02/1999", "Nữ", "13212", "32213121");
            this.nhanvienDAO.Update(this.nv2);
            Assert.AreEqual("Trưởng phòng nhân sự", nhanvienDAO.GetNhanVien()[1].ChucDanh);
            Assert.AreNotEqual("02/23/2016", nhanvienDAO.GetNhanVien()[1].NgaySinh);
            Assert.AreEqual("23/02/2016 12:00:00 AM", nhanvienDAO.GetNhanVien()[1].NgaySinh);
            Assert.IsNotNull(nv2.MaNhanVien);
        }

        [TestMethod]
        public void testTimNhanVien()
        {
            List<NhanVienDTO> kq = nhanvienDAO.GetNhanVienWK("1651010034");
            Assert.AreEqual(1, kq.Count);

            kq = nhanvienDAO.GetNhanVienWK("1651010030");
            Assert.AreEqual(0, kq.Count);
        }

        [TestMethod]
        public void testXoaNhanVien()
        {
            Assert.AreEqual(9, nhanvienDAO.GetNhanVien().Count);

            this.nhanvienDAO.Delete(this.nv6);
            Assert.AreEqual(9, nhanvienDAO.GetNhanVien().Count);

            this.nhanvienDAO.Delete(this.nv1);
            Assert.AreEqual(8, nhanvienDAO.GetNhanVien().Count);
            this.nhanvienDAO.Delete(this.nv2);
            Assert.AreEqual(7, nhanvienDAO.GetNhanVien().Count);
            this.nhanvienDAO.Delete(this.nv3);
            Assert.AreEqual(6, nhanvienDAO.GetNhanVien().Count);
            this.nhanvienDAO.Delete(this.nv4);
            Assert.AreEqual(5, nhanvienDAO.GetNhanVien().Count);
            this.nhanvienDAO.Delete(this.nv5);
            Assert.AreEqual(4, nhanvienDAO.GetNhanVien().Count);
        }
    }
}
