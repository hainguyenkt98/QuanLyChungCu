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
    public partial class fQuanLyCanHo : DevExpress.XtraEditors.XtraForm
    {
        bool isThem = false;
        bool isXoa = false;
        bool isSua = false;
        private int rowSelecting = 0;
        private bool isReload = false;
        DataLinqDataContext context;
        DataTable dt;
        public fQuanLyCanHo()
        {
            InitializeComponent();
            context = new DataLinqDataContext(PropertieConst.connectionString);
            LoadData();
        }

        private void LoadData()
        {
            var data = context.layDanhSachCanHoVaChuSoHuu();
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("Mã", typeof(string));
            DataColumn dc1 = new DataColumn("Tầng", typeof(string));
            DataColumn dc2 = new DataColumn("Số người tối đa", typeof(string));
            DataColumn dc3 = new DataColumn("Mã chủ hộ", typeof(string));
            DataColumn dc4 = new DataColumn("Tên chủ hộ", typeof(string));
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);

            foreach (var item in data)
            {
                DataRow row = dt.NewRow();
                row[0] = item.ma.ToString().Trim();
                row[1] = item.tang.ToString().Trim();
                row[2] = item.songuoiotoida.ToString().Trim();
                row[3] = item.machuho.ToString().Trim();
                row[4] = item.ten.ToString().Trim();

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
                        if (PropertieConst.quyen.Trim() == "user")
                        {
                            MessageBox.Show("Bạn không có quyền hạn đề thực hiện việc này !", "Cảnh báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        Them();
                        break;
                    }
                case "Xóa":
                    {
                        if (PropertieConst.quyen.Trim() == "user" || PropertieConst.quyen.Trim() == "manager")
                        {
                            MessageBox.Show("Bạn không có quyền hạn đề thực hiện việc này !", "Cảnh báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (isThem || isSua)
                        {
                            return;
                        }
                        Xoa();
                        break;
                    }
                case "Sửa":
                    {
                        if (PropertieConst.quyen.Trim() == "user")
                        {
                            MessageBox.Show("Bạn không có quyền hạn đề thực hiện việc này !", "Cảnh báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (isThem || isSua)                      
                            return;
                        
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
        private void LoadChuHo()
        {
            cboMaChuHo.Items.Clear();
            cboTenChuHo.Items.Clear();
            var danhSachChuHo = context.layDanhSachNguoiDan();
            foreach (var chuHo in danhSachChuHo)
            {
                cboMaChuHo.Items.Add(chuHo.ma.ToString().Trim());
                cboTenChuHo.Items.Add(chuHo.ten.ToString().Trim());
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
        private void Them()
        {
            txtMa.Enabled = true;
            isThem = true;
            pnControlFor.Enabled = true;
            pnControlPri.Enabled = true;
            LoadChuHo();
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
            }
            catch
            {
                MessageBox.Show("Bạn đang xóa căn hộ đang được sở hữu, xem lại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DeleteRow(int indexRow)
        {
            string maCanHo = gridView1.GetRowCellValue(indexRow, "Mã").ToString().Trim();
            context.xoaCanHo(maCanHo);
        }
        private void Sua()
        {
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    isSua = true;
                    LoadChuHo();
                    LoadTang();

                    rowSelecting = i;
                    txtMa.Text = gridView1.GetRowCellValue(i, "Mã").ToString().Trim();
                    cboTang.Text = gridView1.GetRowCellValue(i, "Tầng").ToString().Trim();
                    cboSoNguoiToiDa.Text = gridView1.GetRowCellValue(i, "Số người tối đa").ToString().Trim();
                    cboMaChuHo.Text = gridView1.GetRowCellValue(i, "Mã chủ hộ").ToString().Trim();
                    cboTenChuHo.Text = gridView1.GetRowCellValue(i, "Tên chủ hộ").ToString().Trim();

                    pnControlFor.Enabled = true;
                    pnControlPri.Enabled = true;

                    return;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (isSua)
                {
                    context.capNhatCanHo(txtMa.Text.Trim(), Convert.ToInt16(cboTang.Text.Trim()), Convert.ToInt16(cboSoNguoiToiDa.Text.Trim()), cboMaChuHo.Text.Trim());
                    isSua = false;
                }
                if (isThem)
                {
                    context.themCanHo(txtMa.Text.Trim(), Convert.ToInt16(cboTang.Text.Trim()), Convert.ToInt16(cboSoNguoiToiDa.Text.Trim()), cboMaChuHo.Text.Trim());
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
            cboTang.Text = "";
            cboTang.Text = "";
            cboTenChuHo.Text = "";
            cboMaChuHo.Text = "";
            cboSoNguoiToiDa.Text = "";
        }

        private void cboMaChuHo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexChange = cboMaChuHo.SelectedIndex;
            cboTenChuHo.SelectedIndex = indexChange;
        }

        private void cboTenChuHo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexChange = cboTenChuHo.SelectedIndex;
            cboMaChuHo.SelectedIndex = indexChange;
        }

        private void cboSoNguoiToiDa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void windowsUIButtonPanel_Click(object sender, EventArgs e)
        {

        }

        private void fQuanLyCanHo_Load(object sender, EventArgs e)
        {

        }
    }
}