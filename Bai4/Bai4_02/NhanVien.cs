using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4_02
{
    internal class NhanVien
    {
        private int ID;
        private string Name;
        private int Luong;

        public NhanVien()
        {
        }

        public NhanVien(int iD, string name, int luong)
        {
            ID1 = iD;
            Name1 = name;
            Luong1 = luong;
        }

        public int ID1 { get => ID; set => ID = value; }
        public string Name1 { get => Name; set => Name = value; }
        public int Luong1 { get => Luong; set => Luong = value; }
    }
}
