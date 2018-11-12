using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChungCu
{
    class cboCVitem
    {
        private string maCV;
        private string tenCV;
        private string Luong;

        public string MaCV { get => maCV; set => maCV = value; }
        public string TenCV { get => tenCV; set => tenCV = value; }
        public string LuongCV { get => Luong; set => Luong = value; }
        public override string ToString()
        {
            return maCV.ToString().Trim();
        }
    }
}
