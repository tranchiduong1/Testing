using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using DAO;

namespace TestDonHang
{
    
    [TestClass]
    public class TestLoaiSanPham
    {
        private List<LoaiSanPhamDTO> GetLSP;
        private LoaiSanPhamDAO lspDAO;
        private LoaiSanPhamDTO lsp1;
        private LoaiSanPhamDTO lsp2;
        private LoaiSanPhamDTO lsp3;

        [TestInitialize]
        public void SetUp()
        {
            GetLSP = new List<LoaiSanPhamDTO>();
            lspDAO = new LoaiSanPhamDAO();
            lsp1 = new LoaiSanPhamDTO("1TCCM", "Thờ cúng chó mèo");
            lsp2 = new LoaiSanPhamDTO("2PTCM", "Phẫu thuật chó mèo");
            lsp3 = new LoaiSanPhamDTO("3LCM", "Lẩu chó mèo");
        }
        [TestMethod]
        public void testTimLSP()
        {
            List<LoaiSanPhamDTO> kq = lspDAO.GetLoaiSPWK("CSCMM");
            Assert.AreEqual(0, kq.Count);

            kq = lspDAO.GetLoaiSPWK("CSCM");
            Assert.AreEqual(1, kq.Count);
        }
        [TestMethod]
        public void testThemLSP()
        {
            this.lspDAO.Add(this.lsp1);
            Assert.AreEqual(6, lspDAO.GetLoaiSP().Count);
            Assert.AreEqual("1TCCM", lspDAO.GetLoaiSP()[0].MaLoaiSanPham);
            Assert.AreEqual("Thờ cúng chó mèo", lspDAO.GetLoaiSP()[0].TenLoaiSanPham);

            this.lspDAO.Add(this.lsp2);
            Assert.AreEqual(7, lspDAO.GetLoaiSP().Count);
            Assert.AreEqual("2PTCM", lspDAO.GetLoaiSP()[1].MaLoaiSanPham);
            Assert.AreEqual("Phẫu thuật chó mèo", lspDAO.GetLoaiSP()[1].TenLoaiSanPham);
        }


        [TestMethod]
        public void testSuaLSP()
        {
            lsp1 = new LoaiSanPhamDTO("1TCCM", "Thờ cúng chó và mèo");
            lsp2 = new LoaiSanPhamDTO("2PTCM", "Phẫu thuật cho chó và mèo");

            this.lspDAO.Update(this.lsp1);
            Assert.AreEqual("Thờ cúng chó và mèo", lspDAO.GetLoaiSP()[0].TenLoaiSanPham);
            Assert.AreNotEqual("Thờ cúng chó mèo", lspDAO.GetLoaiSP()[0].TenLoaiSanPham);

            this.lspDAO.Update(this.lsp2);
            Assert.AreEqual("Phẫu thuật cho chó và mèo", lspDAO.GetLoaiSP()[1].TenLoaiSanPham);
            Assert.AreNotEqual("Phẫu thuật chó mèo", lspDAO.GetLoaiSP()[1].TenLoaiSanPham);

        }


        [TestMethod]
        public void testXoaLSP()
        {
            Assert.AreEqual(7, lspDAO.GetLoaiSP().Count);

            this.lspDAO.Delete(this.lsp3);
            Assert.AreEqual(7, lspDAO.GetLoaiSP().Count);

            this.lspDAO.Delete(this.lsp1);
            Assert.AreEqual(6, lspDAO.GetLoaiSP().Count);
            this.lspDAO.Delete(this.lsp2);
            Assert.AreEqual(5, lspDAO.GetLoaiSP().Count);
        }
    }
}
