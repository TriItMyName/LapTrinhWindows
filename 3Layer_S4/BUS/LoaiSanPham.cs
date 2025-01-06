using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BUS
{
    public class LoaiSanPham
    {
        public List<LoaiSP> GetAll()
        {
            Model_QLSanPham context = new Model_QLSanPham();
            return context.LoaiSPs.ToList();
        }
    }
}
