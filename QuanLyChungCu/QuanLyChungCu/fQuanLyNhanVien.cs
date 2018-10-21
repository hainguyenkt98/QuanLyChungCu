using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLyChungCu
{
    public partial class fQuanLyNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public fQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "In") gridControl.ShowRibbonPrintPreview();
        }
    }
}