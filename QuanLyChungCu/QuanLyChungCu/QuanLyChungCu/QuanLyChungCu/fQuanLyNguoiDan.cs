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
    public partial class fQuanLyNguoiDan : DevExpress.XtraEditors.XtraForm
    {
        bool isThem = false;
        bool isXoa = false;
        bool isSua = false;

        private int rowSelecting = 0;
        private bool isReload = false;
        DataLinqDataContext context;
        DataTable dt;
        public fQuanLyNguoiDan()
        {
            InitializeComponent();
            context = new DataLinqDataContext(PropertieConst.connectionString);
            LoadData();
        }
        private void LoadData()
        {
            var data = context.layDanhSachQuanLyNguoiDan();
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("Mã", typeof(string));
            DataColumn dc1 = new DataColumn("Họ và tên", typeof(string));
            DataColumn dc2 = new DataColumn("Giới tính", typeof(string));
            DataColumn dc3 = new DataColumn("Ngày sinh", typeof(string));
            DataColumn dc4 = new DataColumn("Dân tộc", typeof(string));
            DataColumn dc5 = new DataColumn("Tôn giáo", typeof(string));
            DataColumn dc6 = new DataColumn("Nghề nghiệp", typeof(string));
            DataColumn dc7 = new DataColumn("Số điện thoại", typeof(string));
            DataColumn dc8 = new DataColumn("Mã căn hộ", typeof(string));
            DataColumn dc9 = new DataColumn("Tầng", typeof(string));
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);
            dt.Columns.Add(dc8);
            dt.Columns.Add(dc9);
            foreach (var item in data)
            {
                DataRow row = dt.NewRow();
                row[0] = item.ma.ToString().Trim();
                row[1] = item.ten.ToString().Trim();
                row[2] = item.gioitinh.ToString().Trim();
                row[3] = item.ngaysinh.ToString("dd/MM/yyyy").Trim();
                row[4] = item.dantoc.ToString().Trim();
                row[5] = item.tongiao.ToString().Trim();
                row[6] = item.nghenghiep.ToString().Trim();
                row[7] = item.sodienthoai.ToString().Trim();
                row[8] = item.macanho.ToString().Trim();
                row[9] = item.tang.ToString().Trim();
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
            gridView1.Columns[8].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
                        if (isThem || isSua)
                        {
                            return;
                        }
                        Them();
                        break;
                    }
                case "Xóa":
                    {
                        if(isThem || isSua)
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
            }
        }
        private void Them()
        {
            txtMa.Enabled = true;
            isThem = true;
            pnControlFor.Enabled = true;
            pnControlPri.Enabled = true;
            LoadTang();
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
            }catch
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
                    LoadTang();

                    rowSelecting = i;
                    txtMa.Text = gridView1.GetRowCellValue(i, "Mã").ToString();
                    txtHoVaTen.Text = gridView1.GetRowCellValue(i, "Họ và tên").ToString();
                    txtDanToc.Text = gridView1.GetRowCellValue(i, "Dân tộc").ToString();
                    txtNgheNghiep.Text = gridView1.GetRowCellValue(i, "Nghề nghiệp").ToString();
                    txtSoDienThoai.Text = gridView1.GetRowCellValue(i, "Số điện thoại").ToString();
                    txtTonGiao.Text = gridView1.GetRowCellValue(i, "Tôn giáo").ToString();

                    cboGioiTinh.Text = gridView1.GetRowCellValue(i, "Giới tính").ToString();
                    dtNgaySinh.Text = gridView1.GetRowCellValue(i, "Ngày sinh").ToString();


                    cboTang.Text = gridView1.GetRowCellValue(i, "Tầng").ToString();
                    LoadCanHo(Convert.ToInt16(cboTang.Text));

                    pnControlFor.Enabled = true;
                    pnControlPri.Enabled = true;

                    cboCanHo.Text = gridView1.GetRowCellValue(i, "Mã căn hộ").ToString();
                    return;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                //DateTime dt = Convert.ToDateTime(dtNgaySinh.)
                if(isSua)
                {
                    context.capNhatNguoiDan(txtMa.Text.Trim(), txtHoVaTen.Text.Trim(), cboGioiTinh.Text.Trim(), dtNgaySinh.DateTime, txtDanToc.Text.Trim(), txtTonGiao.Text.Trim(), txtNgheNghiep.Text.Trim(), txtSoDienThoai.Text.Trim(), cboCanHo.Text.Trim());
                    isSua = false;
                }
                if(isThem)
                {
                    context.themNguoiDan(txtMa.Text.Trim(), txtHoVaTen.Text.Trim(), cboGioiTinh.Text.Trim(), dtNgaySinh.DateTime, txtDanToc.Text.Trim(), txtTonGiao.Text.Trim(), txtNgheNghiep.Text.Trim(), txtSoDienThoai.Text.Trim(), cboCanHo.Text.Trim());
                    isThem = false;
                    txtMa.Enabled = false;
                }
                LoadData();
                isReload = false;
                btnHuy_Click(null, null);
            }
            catch(Exception ex)
            {
                string s = ex.Message.ToString();
                MessageBox.Show("Thông tin không nhập vào không chính xác !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void DeleteRow(int indexRow)
        {
            string maNguoiDan = gridView1.GetRowCellValue(indexRow, "Mã").ToString().Trim();
            context.xoaNguoiDan(maNguoiDan);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            pnControlFor.Enabled = false;
            pnControlPri.Enabled = false;

            isThem = false;
            isSua = false;
            isXoa = false;

            txtMa.Text = "";
            txtHoVaTen.Text = "";
            txtDanToc.Text = "";
            txtNgheNghiep.Text = "";
            txtSoDienThoai.Text = "";
            txtTonGiao.Text = "";

            cboGioiTinh.Text = "";
            dtNgaySinh.Text = "";
            cboTang.Text = "";
            cboCanHo.Text = "";
        }
        private void LoadTang()
        {
            cboTang.Items.Clear();
            var soTang = context.laySoTang();
            for (int i = 1; i <= (int)soTang; i++)
            {
                cboTang.Items.Add(i.ToString().Trim());
            }
        }
        private void LoadCanHo(int tang)
        {
            cboCanHo.Items.Clear();
            var danhSachCanHoTheoTang = context.layDanhSachCanHoTheoTang(tang);
            foreach (var canHo in danhSachCanHoTheoTang)
            {
                cboCanHo.Items.Add(canHo.ma.ToString().Trim());
            }

        }

        private void cboTang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCanHo(Convert.ToInt16(cboTang.Text));
        }
    }
}