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
    public partial class fQuanLyDichVuCanHo : DevExpress.XtraEditors.XtraForm
    {
        bool isThem = false;
        bool isXoa = false;
        bool isSua = false;
        private int rowSelecting = 0;
        private bool isReload = false;
        DataLinqDataContext context;
        DataTable dt;
        public fQuanLyDichVuCanHo()
        {
            InitializeComponent();
            context = new DataLinqDataContext(PropertieConst.connectionString);
            LoadData();
        }
        private void LoadData()
        {
            var data = context.layDanhSachCanHoDichVu();
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("Mã căn hộ", typeof(string));
            DataColumn dc1 = new DataColumn("Tầng", typeof(string));
            DataColumn dc2 = new DataColumn("Mã dịch vụ", typeof(string));
            DataColumn dc3 = new DataColumn("Tên dich vụ", typeof(string));
            DataColumn dc4 = new DataColumn("Chi phí/tháng", typeof(string));
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);

            foreach (var item in data)
            {
                DataRow row = dt.NewRow();
                row[0] = item.maCH.ToString().Trim();
                row[1] = item.tang.ToString().Trim();
                row[2] = item.maDV.ToString().Trim();
                row[3] = item.ten.ToString().Trim();
                row[4] = item.chiphi.ToString().Trim();
                dt.Rows.Add(row);
            } 
            
            gridControl.DataSource = dt;
            gridView1.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

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
        private void Them()
        {
            isThem = true;
            pnControlFor.Enabled = true;
            pnControlPri.Enabled = true;
            LoadDichVu();
            //LoadCanHo();
            LoadTang();
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
            string maCanHo = gridView1.GetRowCellValue(indexRow, "Mã căn hộ").ToString().Trim();
            string maDichVu = gridView1.GetRowCellValue(indexRow, "Mã dịch vụ").ToString().Trim();
            context.xoaCanHoDichVu(maCanHo, maDichVu);
        }
        private void Sua()
        {
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    isSua = true;
                    LoadDichVu();
                    //LoadCanHo();
                    LoadTang();

                    rowSelecting = i;
                    cboMaDichVu.Text = gridView1.GetRowCellValue(i, "Mã dịch vụ").ToString().Trim();
                    cboTenDichVu.Text = gridView1.GetRowCellValue(i, "Tên dịch vụ").ToString().Trim();
                    txtChiPhi.Text = gridView1.GetRowCellValue(i, "Chi phí/tháng").ToString().Trim();

                    cboMaCanHo.Text = gridView1.GetRowCellValue(i, "Mã căn hộ").ToString().Trim();
                    cboTang.Text = gridView1.GetRowCellValue(i, "Tầng").ToString().Trim();
                    pnControlFor.Enabled = true;
                    pnControlPri.Enabled = true;

                    return;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isSua)
            {
                string maCanHo = cboMaDichVu.Text.Trim();
                string maDichVu = cboMaCanHo.Text.Trim();
                context.capNhatCanHoDichVu(maCanHo, maDichVu);
            }
            if (isThem)
            {
                string maCanHo = cboMaCanHo.Text.Trim();
                string maDichVu = cboMaDichVu.Text.Trim();
                context.themCanHoDichVu(maCanHo, maDichVu);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            pnControlFor.Enabled = false;
            pnControlPri.Enabled = false;

            isThem = false;
            isSua = false;
            isXoa = false;

            cboMaDichVu.Text = "";
            txtChiPhi.Text = "";
            cboTenDichVu.Text = "";
            cboMaCanHo.Text = "";
            cboTang.Text = "";
        }
        private void LoadCanHo()
        {
            var danhSachCanho = context.layDanhSachCanHo();
            cboMaCanHo.Items.Clear();
            cboTang.Items.Clear();
            foreach (var ch in danhSachCanho)
            {
                cboMaCanHo.Items.Add(ch.ma.ToString().Trim());
            }
        }

        private void LoadTang()
        {
            cboTang.Items.Clear();
            var soTang = context.laySoTang();
            for (int i = 1; i <= Convert.ToInt32(soTang); i++)
            {
                cboTang.Items.Add(i.ToString().Trim());
            }
        }

        private void cboTang_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexChange = cboTang.SelectedIndex;
            var danhSachCanHoTheoTang = context.layDanhSachCanHoTheoTang(Convert.ToInt16(cboTang.Text.Trim()));
            cboMaCanHo.Items.Clear();
            foreach (var ch in danhSachCanHoTheoTang)
            {
                cboMaCanHo.Items.Add(ch.ma.ToString().Trim());
            }
        }
        private void LoadDichVu()
        {
            var danhSachDichVu = context.layDanhSachDichVu();
            foreach (var dv in danhSachDichVu)
            {
                cboDVItem item = new cboDVItem();
                item.MaDV = dv.ma.ToString().Trim();
                item.TenDV = dv.ten.ToString().Trim();
                item.ChiphiDV = dv.chiphi.ToString().Trim();

                cboMaDichVu.Items.Add(item);
                cboTenDichVu.Items.Add(dv.ten.ToString().Trim());
            }

        }

        private void cboMaDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexChange = cboMaDichVu.SelectedIndex;
            cboTenDichVu.SelectedIndex = indexChange;

            txtChiPhi.Text = ((cboDVItem)cboMaDichVu.Items[indexChange]).ChiphiDV;
        }

        private void cboTenDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexChange = cboTenDichVu.SelectedIndex;
            cboMaDichVu.SelectedIndex = indexChange;

            txtChiPhi.Text = ((cboDVItem)cboMaDichVu.Items[indexChange]).ChiphiDV;
        }
    }
}