using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChungCu
{
    public partial class QuanLyChucNang : Form
    {
        public QuanLyChucNang()
        {
            InitializeComponent();
            Form1 f1 = new Form1();
            f1.MdiParent = this;
            this.Controls.Add(f1);
        }
    }
}
