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
        private bool loadLai = false;
        private int rowSelecting = 0;
        public fQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "In") gridControl.ShowRibbonPrintPreview();
        }

        private void gridControl_Click(object sender, EventArgs e)
        {
            
        }

        private void fQuanLyNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void windowsUIButtonPanel_Click(object sender, EventArgs e)
        {

        }
    }
}