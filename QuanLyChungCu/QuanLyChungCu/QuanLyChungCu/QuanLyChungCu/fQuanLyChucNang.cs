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


        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ketNoiDB = new fKetNoiDataBase();
            ketNoiDB.eventConnection += KetNoiDB_eventConnection;
            ketNoiDB.StartPosition = FormStartPosition.CenterParent;
            ketNoiDB.ShowDialog();
        }

        private void KetNoiDB_eventConnection()
        {
            MessageBox.Show("Kết nối Database thành công, có thể đăng nhập !", "Thông báo !", MessageBoxButtons.OK);
            PropertieConst.trangThaiKetNoiDB = true;
            pnNavBar.Enabled = true;
            this.ketNoiDB.Close();
            đăngNhậpToolStripMenuItem.Enabled = false;
            đăngXuấtToolStripMenuItem.Enabled = false;
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            đăngXuấtToolStripMenuItem.Enabled = false;
            đăngNhậpToolStripMenuItem.Enabled = true;
            PropertieConst.tenTaiKhoan = "";
            PropertieConst.matKhau = "";
            PropertieConst.quyen = "";
        }

        private void btnCanHo_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("fQuanLyCanHo"))
            {
                fQuanLyCanHo xf2 = new fQuanLyCanHo();
                xf2.MdiParent = this;
                xf2.Name = "fQuanLyCanHo";
                xf2.Show();
            }
            else
            {
                ActiveChildForm("fQuanLyCanHo");
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("fTraCuuPhiSinhHoat"))
            {
                fTraCuuPhiSinhHoat xf2 = new fTraCuuPhiSinhHoat();
                xf2.MdiParent = this;
                xf2.Name = "fTraCuuPhiSinhHoat";
                xf2.Show();
            }
            else
            {
                ActiveChildForm("fTraCuuPhiSinhHoat");
            }
        }

        private void btnCanHo_DichVu_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("fQuanLyDichVuCanHo"))
            {
                fQuanLyDichVuCanHo xf2 = new fQuanLyDichVuCanHo();
                xf2.MdiParent = this;
                xf2.Name = "fQuanLyDichVuCanHo";
                xf2.Show();
            }
            else
            {
                ActiveChildForm("fQuanLyDichVuCanHo");
            }
        }
    }
}
