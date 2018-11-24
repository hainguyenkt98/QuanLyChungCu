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
    public partial class fQuanLyTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        bool isThem = false;
        bool isXoa = false;
        bool isSua = false;
        private bool isReload = false;
        private int rowSelecting = 0;
        DataLinqDataContext context;
        DataTable dt;
        public fQuanLyTaiKhoan()
        {
            InitializeComponent();
            context = new DataLinqDataContext(PropertieConst.connectionString);
            LoadData();
        }

        private void LoadData()
        {
            var data = context.layDanhSachUserLogin();
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("Mã", typeof(string));
            DataColumn dc1 = new DataColumn("Tên đăng nhập", typeof(string));
            DataColumn dc2 = new DataColumn("Mật khẩu", typeof(string));
            DataColumn dc3 = new DataColumn("Quyền", typeof(string));
            DataColumn dc4 = new DataColumn("Mã nhân viên", typeof(string));
            DataColumn dc5 = new DataColumn("Tên nhân viên", typeof(string));

            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);

            foreach (var item in data)
            {
                DataRow row = dt.NewRow();
                row[0] = item.ma.ToString().Trim();
                row[1] = item.tendangnhap.ToString().Trim();
                row[2] = item.matkhau.ToString().Trim();
                row[3] = item.quyen.ToString().Trim();
                row[4] = item.manv.ToString().Trim();
                row[5] = item.ten.ToString().Trim();

                dt.Rows.Add(row);
            }
            gridControl.DataSource = dt;
            gridView1.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[5].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }
        private void Them()
        {
            txtMa.Enabled = true;
            isThem = true;
            pnControlFor.Enabled = true;
            pnControlPri.Enabled = true;

            txtMa.Enabled = true;
            txtTenDangNhap.Enabled = true;
            LoadNhanVien();
        }
        private void Xoa()
        {
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    DeleteRow(i);
                    isReload = true;
                }
            }
            if (isReload)
            {
                LoadData();
                isReload = false;
            }
        }
        private void DeleteRow(int indexRow)
        {
            try
            {
                string ma = gridView1.GetRowCellValue(indexRow, "Mã").ToString().Trim();
                string tendangnhap = gridView1.GetRowCellValue(indexRow, "Tên đăng nhập").ToString().Trim();
                string manv = gridView1.GetRowCellValue(indexRow, "Mã nhân viên").ToString().Trim();
                context.xoaTaiKhoan(ma, tendangnhap, manv);
            }
            catch (Exception ex)
            {
                int a = 0;
            }     
        }
        private void LoadNhanVien()
        {
            var danhSachNhanVien = context.layDanhSachNhanVien();
            foreach (var nv in danhSachNhanVien)
            {
                cboNVitem item = new cboNVitem();
                item.MaNV = nv.ma.ToString().Trim();
                item.TenNV = nv.ten.ToString().Trim();

                cboMaNhanVien.Items.Add(item);
                cboTenNhanVien.Items.Add(nv.ten.ToString().Trim());
            }
        }

        private void cboTenNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexChange = cboTenNhanVien.SelectedIndex;
            cboMaNhanVien.SelectedIndex = indexChange;
        }

        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexChange = cboMaNhanVien.SelectedIndex;
            cboTenNhanVien.SelectedIndex = indexChange;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isSua)
            {
                try
                {
                    string ma = txtMa.Text.Trim();
                    string tendangnhap = txtTenDangNhap.Text.Trim();
                    string matkhau = txtMatKhau.Text.Trim();
                    string quyen = cboQuyen.Text.Trim();
                    string manv = cboMaNhanVien.Text.Trim();
                    context.suaTaiKhoan(ma, tendangnhap, matkhau, quyen, manv);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thông tin nhập vào không hợp lệ !", "Nhắc nhở !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (isThem)
            {
                try
                {
                    string ma = txtMa.Text.Trim();
                    string tendangnhap = txtTenDangNhap.Text.Trim();
                    string matkhau = txtMatKhau.Text.Trim();
                    string quyen = cboQuyen.Text.Trim();
                    string manv = cboMaNhanVien.Text.Trim();
                    context.taoTaiKhoanDangNhap(ma, tendangnhap, matkhau, quyen, manv);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thông tin nhập vào không hợp lệ !", "Nhắc nhở !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            pnControlFor.Enabled = false;
            pnControlPri.Enabled = false;

            isThem = false;
            isSua = false;
            isXoa = false;

            cboTenNhanVien.Text = "";
            cboMaNhanVien.Text = "";
            txtMa.Text = "";
            txtMatKhau.Text = "";
            txtTenDangNhap.Text = "";


        }
        private void Sua()
        {
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    isSua = true;
                    LoadNhanVien();

                    rowSelecting = i;
                    txtMa.Text = gridView1.GetRowCellValue(i, "Mã").ToString().Trim();
                    txtTenDangNhap.Text = gridView1.GetRowCellValue(i, "Tên đăng nhập").ToString().Trim();
                    txtMatKhau.Text = gridView1.GetRowCellValue(i, "Mật khẩu").ToString().Trim();

                    cboQuyen.Text = gridView1.GetRowCellValue(i, "Quyền").ToString().Trim();
                    cboMaNhanVien.Text = gridView1.GetRowCellValue(i, "Mã nhân viên").ToString().Trim();
                    cboTenNhanVien.Text = gridView1.GetRowCellValue(i, "Tên nhân viên").ToString().Trim();

                    pnControlFor.Enabled = true;
                    pnControlPri.Enabled = true;

                    txtMa.Enabled = false;
                    txtTenDangNhap.Enabled = false;

                    return;
                }
            }
        }

        private void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "In":
                    {
                        gridControl.ShowRibbonPrintPreview();
                        break;
                    }
                case "Thêm":
                    {
                        if (PropertieConst.quyen.Trim() == "user")
                            MessageBox.Show("Bạn không có quyền hạn đề thực hiện việc này !", "Cảnh báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning); if (isThem || isSua)
                        {
                            return;
                        }
                        Them();
                        break;
                    }
                case "Xóa":
                    {
                        if (PropertieConst.quyen.Trim() == "user" || PropertieConst.quyen.Trim() == "manager")
                            MessageBox.Show("Bạn không có quyền hạn đề thực hiện việc này !", "Cảnh báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning); if (isThem || isSua)
                        {
                            return;
                        }
                        Xoa();
                        break;
                    }
                case "Sửa":
                    {
                        if (PropertieConst.quyen.Trim() == "user")
                            MessageBox.Show("Bạn không có quyền hạn đề thực hiện việc này !", "Cảnh báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning); if (isThem || isSua)
                        {
                            return;
                        }
                        Sua();
                        break;
                    }
                case "Tải lại":
                    {
                        if (isThem || isSua)
                        {
                            return;
                        }
                        LoadData();
                        break;
                    }
            }
        }
    }
}