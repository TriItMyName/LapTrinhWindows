using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BUS
{
    public class SanPham
    {
        private Model_QLSanPham context;

        public SanPham()
        {
            context = new Model_QLSanPham();
        }

        public List<Sanpham> GetAll()
        {
            return context.Sanphams.ToList();
        }

        public List<Sanpham> GetByLoai(string MaLoai)
        {
            return context.Sanphams.Where(p => p.MaLoai == MaLoai).ToList();
        }

        public Sanpham GetByID(string MaSP)
        {
            return context.Sanphams.FirstOrDefault(p => p.MaSP == MaSP);
        }

        public void Add(Sanpham sp)
        {
            context.Sanphams.Add(sp);
        }

        public void Update(Sanpham sp)
        {
            Sanpham oldSP = context.Sanphams.Find(sp.MaSP);
            if (oldSP != null)
            {
                oldSP.TenSP = sp.TenSP;
                oldSP.Ngaynhap = sp.Ngaynhap;
                oldSP.MaLoai = sp.MaLoai;
            }
        }

        public void Delete(string MaSP)
        {
            Sanpham sp = context.Sanphams.FirstOrDefault(p => p.MaSP == MaSP);
            if (sp != null)
            {
                context.Sanphams.Remove(sp);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
