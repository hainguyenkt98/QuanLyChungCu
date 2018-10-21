using DevExpress.XtraEditors;
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
    public partial class QuanLyChucNang : XtraForm
    {
        public QuanLyChucNang()
        {
            InitializeComponent();
        }

        private bool CheckExistForm(string name)
        {
            bool check = false;
            if (MdiChildren.Count() > 0)
            {
                foreach (var form in MdiChildren)
                {
                    if (form.Name == name)
                    {
                        check = true;
                        break;
                    }
                }
            }
            return check;
        }
        private void ActiveChildForm(string name)
        {
            foreach (var form in MdiChildren)
            {
                if (form.Name == name)
                {
                    xtraTabbedMdiManager.Pages[form].MdiChild.Activate();
                }
            }
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("fQuanLyNhanVien"))
            {
                fQuanLyNhanVien xf2 = new fQuanLyNhanVien();
                xf2.MdiParent = this;
                xf2.Name = "fQuanLyNhanVien";
                xf2.Show();
            }
            else
            {
                ActiveChildForm("fQuanLyNhanVien");
            }
        }

        private void btnNguoiDan_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("fQuanLyNguoiDan"))
            {
                fQuanLyNguoiDan xf2 = new fQuanLyNguoiDan();
                xf2.MdiParent = this;
                xf2.Name = "fQuanLyNguoiDan";
                xf2.Show();
            }
            else
            {
                ActiveChildForm("fQuanLyNguoiDan");
            }
        }
    }
}
