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
    public class TestThemAccountChoNhanVien
    {
        private List<ThemAccountDTO> GetThemAccount; 
        private ThemAccountDAO themacDAO;
        private ThemAccountDTO ac1;
        private ThemAccountDTO ac2;
        private ThemAccountDTO ac3;

        [TestInitialize]
        public void SetUp()
        {
            this.GetThemAccount = new List<ThemAccountDTO>();
            this.themacDAO = new ThemAccountDAO();
            this.ac1 = new ThemAccountDTO("1651010010", "vana1234", 1651010090);
            this.ac2 = new ThemAccountDTO("1651010011", "thib1234", 1651010091);
            this.ac3 = new ThemAccountDTO("1651010012", "vanc1234", 1651010012);
        }

        [TestMethod]
        public void testThemAccountNV()
        {
            this.themacDAO.Add(this.ac1);
            Assert.AreEqual(3, themacDAO.GetThemAccount().Count);
            Assert.AreEqual("1651010010", themacDAO.GetThemAccount()[0].taiKhoan);
            Assert.AreEqual("vana1234", themacDAO.GetThemAccount()[0].matKhau);

            this.themacDAO.Add(this.ac2);
            Assert.AreEqual(4, themacDAO.GetThemAccount().Count);
            Assert.AreEqual("1651010011", themacDAO.GetThemAccount()[1].taiKhoan);
            Assert.AreEqual("thib1234", themacDAO.GetThemAccount()[1].matKhau);
        }

        [TestMethod]
        public void testXoaAccountNV()
        {
            Assert.AreEqual(4, themacDAO.GetThemAccount().Count);

            this.themacDAO.Delete(this.ac3);
            Assert.AreEqual(4, themacDAO.GetThemAccount().Count);

            this.themacDAO.Delete(this.ac1);
            Assert.AreEqual(3, themacDAO.GetThemAccount().Count);
            this.themacDAO.Delete(this.ac2);
            Assert.AreEqual(2, themacDAO.GetThemAccount().Count);
        }
    }
}
