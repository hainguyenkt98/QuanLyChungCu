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
    public partial class fTraCuuPhiSinhHoat : DevExpress.XtraEditors.XtraForm
    {
        DataLinqDataContext context;
        DataTable dt;
        public fTraCuuPhiSinhHoat()
        {
            InitializeComponent();
            context = new DataLinqDataContext(PropertieConst.connectionString);
            LoadData();
        }
        public void LoadData()
        {
            var data = context.tracuuChiPhiDichVuCanHo();
            DataTable dt = new DataTable();
            DataColumn dc0 = new DataColumn("Mã căn hộ", typeof(string));
            DataColumn dc1 = new DataColumn("Tầng", typeof(string));
            DataColumn dc2 = new DataColumn("Chủ hộ", typeof(string));
            DataColumn dc3 = new DataColumn("Số điện thoại chủ hộ", typeof(string));
            DataColumn dc4 = new DataColumn("Tổng chi phí dịch vụ hằng tháng", typeof(string));
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
                row[2] = item.ten.ToString().Trim();
                row[3] = item.sodienthoai.ToString().Trim();
                row[4] = item.tongchiphi.ToString().Trim();
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
                case "Tải lại":
                    {
                        LoadData();
                        break;
                    }
            }
        }
    }
}