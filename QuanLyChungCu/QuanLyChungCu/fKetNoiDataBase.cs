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
    public partial class fKetNoiDataBase : DevExpress.XtraEditors.XtraForm
    {
        public delegate void HandleEventConnetion();
        public event HandleEventConnetion eventConnection;
        public fKetNoiDataBase()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=" + txtIP.Text.Trim() + ";Initial Catalog=" + txtTenDB.Text.Trim() + ";User ID=" + txtTaiKhoanDB.Text.Trim() + ";Password=" + txtMatKhauDB.Text.Trim() + "";
            DataLinqDataContext context = new DataLinqDataContext(connectionString);

            try
            {
                CanHo ch = context.CanHos.FirstOrDefault();
                PropertieConst.connectionString = connectionString;
                OnEventConnection();
            }
            catch
            {
                MessageBox.Show("Thông tin kết nối tới cơ sở dữ liệu không chính xác !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void OnEventConnection()
        {
            if (eventConnection != null)
            {
                eventConnection();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}