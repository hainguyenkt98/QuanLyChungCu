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
    public partial class fDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public delegate void HandleEventDangNhap();
        public event HandleEventDangNhap eventDangNhap;
        string taiKhoan = "";
        string matKhau = "";

        public fDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            taiKhoan = txtTaiKhoan.Text.Trim();
            matKhau = txtMatKhau.Text.Trim();
            using (DataLinqDataContext context = new DataLinqDataContext(PropertieConst.connectionString))
            {
                UserLogin us = context.UserLogins.Where(m => m.tendangnhap == taiKhoan && m.matkhau == matKhau).FirstOrDefault();
                if (us != null)
                {
                    MessageBox.Show("Đăng nhập thành công thành công !", "Thông báo !", MessageBoxButtons.OK);
                    PropertieConst.tenTaiKhoan = us.tendangnhap.Trim();
                    PropertieConst.matKhau = us.matkhau.Trim();
                    PropertieConst.quyen = us.quyen.Trim() ;
                    OnEventDangNhap();
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công, vui lòng thử lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void OnEventDangNhap()
        {
            if (eventDangNhap != null)
            {
                eventDangNhap();
            }
        }
    }
}