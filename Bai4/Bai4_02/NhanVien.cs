using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4_02
{
    internal class NhanVien
    {
        private int Id;
        private string NAME;
        private int LUONG;

        public NhanVien()
        {
        }

        public NhanVien(int iD, string name, int luong)
        {
            Id = iD;
            NAME = name;
            LUONG = luong;
        }

        public int ID
        {
            get => Id;
            set => Id = value;
        }

        public string Name
        {
            get => NAME;
            set => NAME = value;
        }

        public int Luong
        {
            get => LUONG;
            set => LUONG = value;
        }
    }
}
