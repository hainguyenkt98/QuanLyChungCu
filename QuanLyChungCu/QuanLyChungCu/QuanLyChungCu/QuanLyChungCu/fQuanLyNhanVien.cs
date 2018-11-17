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
        bool isThem = false;
        bool isXoa = false;
        bool isSua = false;
        private bool isReload = false;
        private int rowSelecting = 0;
        DataLinqDataContext context;
        DataTable dt;
        public fQuanLyNhanVien()
        {
            InitializeComponent();
            context = new DataLinqDataContext(PropertieConst.connectionString);
            LoadData();
        }
        private void LoadData()
        {
            var data = context.layDanhSachNhanVien();
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("Mã", typeof(string));
            DataColumn dc1 = new DataColumn("Họ và tên", typeof(string));
            DataColumn dc2 = new DataColumn("Giới tính", typeof(string));
            DataColumn dc3 = new DataColumn("Ngày sinh", typeof(string));
            DataColumn dc4 = new DataColumn("Địa chỉ", typeof(string));
            DataColumn dc5 = new DataColumn("Số điện thoại", typeof(string));
            DataColumn dc6 = new DataColumn("Mã quản lí", typeof(string));
            DataColumn dc7 = new DataColumn("Mã chức vụ", typeof(string));
           
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);
          
            foreach (var item in data)
            {
                DataRow row = dt.NewRow();
                row[0] = item.ma.ToString().Trim();
                row[1] = item.ten.ToString().Trim();
                row[2] = item.gioitinh.ToString().Trim();
                row[3] = item.ngaysinh.ToString("dd/MM/yyyy").Trim();
                row[4] = item.diachi.ToString().Trim();
                row[5] = item.sodienthoai.ToString().Trim();
                row[6] = item.maquanly.ToString().Trim();
                row[7] = item.machucvu.ToString().Trim();
              
                dt.Rows.Add(row);
            }
            gridControl.DataSource = dt;
            gridView1.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[5].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[6].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[7].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
           
        }
        private void Them()
        {
            txtMa.Enabled = true;
            isThem = true;
            pnControlFor.Enabled = true;
            pnControlPri.Enabled = true;
            LoadQL();
            LoadChucVu();


        }
        private void Xoa()
        {
            try
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
            catch
            {

            }

        }
        private void Sua()
        {
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    isSua = true;
                    LoadQL();
                    LoadChucVu();



                    rowSelecting = i;
                    txtMa.Text = gridView1.GetRowCellValue(i, "Mã").ToString();
                    txtTen.Text = gridView1.GetRowCellValue(i, "Họ và tên").ToString();
                    cboGioiTinh.Text = gridView1.GetRowCellValue(i, "Giới tính").ToString();
                    dtNgaySinh.Text = gridView1.GetRowCellValue(i, "Ngày sinh").ToString();
                   txtDiaChi.Text = gridView1.GetRowCellValue(i, "Địa chỉ").ToString();
                    txtSodt.Text = gridView1.GetRowCellValue(i, "Số điện thoại").ToString();

                   cboNguoiQuanLi.Text = gridView1.GetRowCellValue(i, "Mã quản lí").ToString();
                    cboChucVu.Text = gridView1.GetRowCellValue(i, "Mã chức vụ").ToString();

                    pnControlFor.Enabled = true;
                    pnControlPri.Enabled = true;
                     return;
                }
            }
        }
        private void DeleteRow(int indexRow)
        {
            string maNhanVien = gridView1.GetRowCellValue(indexRow, "Mã").ToString().Trim();
            context.xoaNhanVien(maNhanVien);
        }

        private void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
           // if (e.Button.Properties.Caption == "In") gridControl.ShowRibbonPrintPreview();
            switch (e.Button.Properties.Caption)
            {
                case "In":
                    {
                        gridControl.ShowRibbonPrintPreview();
                        break;
                    }
                case "Thêm":
                    {
                        if (isThem || isSua)
                        {
                            return;
                        }
                        Them();
                        break;
                    }
                case "Xóa":
                    {
                        if (isThem || isSua)
                        {
                            return;
                        }
                        Xoa();
                        break;
                    }
                case "Sửa":
                    {
                        if (isThem || isSua)
                        {
                            return;
                        }
                        Sua();
                        break;
                    }
                case "Tải Lại":
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

        private void gridControl_Click(object sender, EventArgs e)
        {
            
        }

        private void fQuanLyNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void windowsUIButtonPanel_Click(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
           
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (isSua)
                {
                    context.capnhapNhanVien(txtMa.Text.Trim(), txtTen.Text.Trim(), cboGioiTinh.Text.Trim(), dtNgaySinh.DateTime, txtDiaChi.Text.Trim(), txtSodt.Text.Trim(), cboNguoiQuanLi.Text.Trim(), cboChucVu.Text.Trim());
                    isSua = false;
                }
                if (isThem)
                {
                    context.themNhanVien(txtMa.Text.Trim(), txtTen.Text.Trim(), cboGioiTinh.Text.Trim(), dtNgaySinh.DateTime, txtDiaChi.Text.Trim(), txtSodt.Text.Trim(), cboNguoiQuanLi.Text.Trim(), cboChucVu.Text.Trim());
                    isThem = false;
                    txtMa.Enabled = false;
                }
                LoadData();
                isReload = false;
                btnHuy_Click(null, null);
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                MessageBox.Show("Thông tin không nhập vào không chính xác !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            pnControlFor.Enabled = false;
            pnControlPri.Enabled = false;

            isThem = false;
            isSua = false;
            isXoa = false;

            txtMa.Text = "";
            txtTen.Text = "";
           cboGioiTinh.Text = "";
            dtNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtSodt.Text = "";
            cboNguoiQuanLi.Text = "";
           cboChucVu.Text = "";
            cboTenChucVu.Text = "";
        }
        private void LoadQL()
        {
            cboNguoiQuanLi.Items.Clear();
            var DSQLNV = context.LayDanhSachMaQuanLiNV();
            foreach (var QL in DSQLNV)
            {
                cboNguoiQuanLi.Items.Add(QL.txt.ToString().Trim());
            }

        }
        private void LoadChucVu()
        {
            cboChucVu.Items.Clear();
            var danhSachCV = context.LayDanhSachChucVu();
            foreach (var cv in danhSachCV)
            {
               cboCVitem item = new cboCVitem();
                item.MaCV = cv.machucvu.ToString().Trim();
                item.TenCV = cv.tenchucvu.ToString().Trim();
                item.TenCV = cv.machucvu.ToString().Trim();

                cboChucVu.Items.Add(item);
                cboTenChucVu.Items.Add(cv.tenchucvu.ToString().Trim());
               

                
            }

        }

        private void cboNguoiQuanLi_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cboChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexChange = cboChucVu.SelectedIndex;
            cboTenChucVu.SelectedIndex = indexChange;
        }

        private void cboMaChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexChange = cboTenChucVu.SelectedIndex;
            cboChucVu.SelectedIndex = indexChange;
        }

        private void windowsUIButtonPanel_Click(object sender, EventArgs e)
        {

        }
    }
}