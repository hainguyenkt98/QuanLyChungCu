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
    public partial class fQuanLyChucNang : XtraForm
    {
        private fKetNoiDataBase ketNoiDB;
        private fDangNhap dangNhap;
        public fQuanLyChucNang()
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

        private void kếtNốiDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ketNoiDB = new fKetNoiDataBase();
            ketNoiDB.StartPosition = FormStartPosition.CenterParent;
            ketNoiDB.eventConnection += FKetNoiDB_eventConnection;
            ketNoiDB.ShowDialog();
        }
        private void FKetNoiDB_eventConnection()
        {
            MessageBox.Show("Kết nối Database thành công, có thể đăng nhập !", "Thông báo !", MessageBoxButtons.OK);
            PropertieConst.trangThaiKetNoiDB = true;
            this.ketNoiDB.Close();
            đăngNhậpToolStripMenuItem.Enabled = true;

        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dangNhap = new fDangNhap();
            dangNhap.StartPosition = FormStartPosition.CenterParent;
            dangNhap.eventDangNhap += DangNhap_eventDangNhap;
            dangNhap.ShowDialog();
        }

        private void DangNhap_eventDangNhap()
        {
            this.dangNhap.Close();
            đăngNhậpToolStripMenuItem.Enabled = false;
            đăngXuấtToolStripMenuItem.Enabled = true;
            pnNavBar.Enabled = true;
            if(PropertieConst.quyen=="user")
            {
                btnUser.Enabled = false;
                btnUser.Visible = false;
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertieConst.tenTaiKhoan = "";
            PropertieConst.matKhau = "";
            PropertieConst.quyen = "";
        }
    }
}
