using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChungCu
{
    class cboNVitem
    {
        private string maNV;
        private string tenNV;

        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }

        public override string ToString()
        {
            return MaNV.ToString().Trim();
        }
    }
}
