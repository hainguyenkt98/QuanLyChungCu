using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChungCu
{
    class cboDVItem
    {
        private string maDV;
        private string tenDV;
        private string chiphiDV;

        public string MaDV { get => maDV; set => maDV = value; }
        public string TenDV { get => tenDV; set => tenDV = value; }
        public string ChiphiDV { get => chiphiDV; set => chiphiDV = value; }
        public override string ToString()
        {
            return maDV.ToString().Trim();
        }
    }
}
