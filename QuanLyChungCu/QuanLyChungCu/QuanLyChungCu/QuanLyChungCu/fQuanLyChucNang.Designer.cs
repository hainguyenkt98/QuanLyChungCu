namespace QuanLyChungCu
{
    partial class fQuanLyChucNang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fQuanLyChucNang));
            this.menuFunction = new System.Windows.Forms.MenuStrip();
            this.quảnTrịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thônTinPhầnMềmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.pnNavBar = new DevExpress.XtraEditors.PanelControl();
            this.btnCanHo_DichVu = new DevExpress.XtraEditors.SimpleButton();
            this.btnDangXuat = new DevExpress.XtraEditors.SimpleButton();
            this.btnUser = new DevExpress.XtraEditors.SimpleButton();
            this.btnCanHo = new DevExpress.XtraEditors.SimpleButton();
            this.btnNhanVien = new DevExpress.XtraEditors.SimpleButton();
            this.btnNguoiDan = new DevExpress.XtraEditors.SimpleButton();
            this.menuFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnNavBar)).BeginInit();
            this.pnNavBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuFunction
            // 
            this.menuFunction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(236)))), ((int)(((byte)(120)))));
            this.menuFunction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnTrịToolStripMenuItem,
            this.thônTinPhầnMềmToolStripMenuItem});
            this.menuFunction.Location = new System.Drawing.Point(0, 0);
            this.menuFunction.Name = "menuFunction";
            this.menuFunction.Size = new System.Drawing.Size(984, 24);
            this.menuFunction.TabIndex = 0;
            this.menuFunction.Text = "menuStrip2";
            // 
            // quảnTrịToolStripMenuItem
            // 
            this.quảnTrịToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(236)))), ((int)(((byte)(120)))));
            this.quảnTrịToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngNhậpToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.quảnTrịToolStripMenuItem.Name = "quảnTrịToolStripMenuItem";
            this.quảnTrịToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.quảnTrịToolStripMenuItem.Text = "Chức năng";
            // 
            // đăngNhậpToolStripMenuItem
            // 
            this.đăngNhậpToolStripMenuItem.Name = "đăngNhậpToolStripMenuItem";
            this.đăngNhậpToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.đăngNhậpToolStripMenuItem.Text = "Đăng nhập";
            this.đăngNhậpToolStripMenuItem.Click += new System.EventHandler(this.đăngNhậpToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Enabled = false;
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            // 
            // thônTinPhầnMềmToolStripMenuItem
            // 
            this.thônTinPhầnMềmToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(236)))), ((int)(((byte)(120)))));
            this.thônTinPhầnMềmToolStripMenuItem.Name = "thônTinPhầnMềmToolStripMenuItem";
            this.thônTinPhầnMềmToolStripMenuItem.Size = new System.Drawing.Size(132, 20);
            this.thônTinPhầnMềmToolStripMenuItem.Text = "Thông tin phần mềm";
            // 
            // xtraTabbedMdiManager
            // 
            this.xtraTabbedMdiManager.MdiParent = this;
            // 
            // pnNavBar
            // 
            this.pnNavBar.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(236)))), ((int)(((byte)(120)))));
            this.pnNavBar.Appearance.BackColor2 = System.Drawing.Color.PowderBlue;
            this.pnNavBar.Appearance.Options.UseBackColor = true;
            this.pnNavBar.Controls.Add(this.btnCanHo_DichVu);
            this.pnNavBar.Controls.Add(this.btnDangXuat);
            this.pnNavBar.Controls.Add(this.btnUser);
            this.pnNavBar.Controls.Add(this.btnCanHo);
            this.pnNavBar.Controls.Add(this.btnNhanVien);
            this.pnNavBar.Controls.Add(this.btnNguoiDan);
            this.pnNavBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnNavBar.Enabled = false;
            this.pnNavBar.Location = new System.Drawing.Point(0, 24);
            this.pnNavBar.Name = "pnNavBar";
            this.pnNavBar.Size = new System.Drawing.Size(984, 64);
            this.pnNavBar.TabIndex = 1;
            // 
            // btnCanHo_DichVu
            // 
            this.btnCanHo_DichVu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCanHo_DichVu.ImageOptions.Image")));
            this.btnCanHo_DichVu.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCanHo_DichVu.Location = new System.Drawing.Point(302, 3);
            this.btnCanHo_DichVu.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCanHo_DichVu.Name = "btnCanHo_DichVu";
            this.btnCanHo_DichVu.Size = new System.Drawing.Size(60, 60);
            this.btnCanHo_DichVu.TabIndex = 7;
            this.btnCanHo_DichVu.Click += new System.EventHandler(this.btnCanHo_DichVu_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.ImageOptions.Image")));
            this.btnDangXuat.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDangXuat.Location = new System.Drawing.Point(510, 3);
            this.btnDangXuat.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(60, 60);
            this.btnDangXuat.TabIndex = 6;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnUser
            // 
            this.btnUser.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnUser.Appearance.BackColor2 = System.Drawing.Color.Red;
            this.btnUser.Appearance.Options.UseBackColor = true;
            this.btnUser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUser.ImageOptions.Image")));
            this.btnUser.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnUser.Location = new System.Drawing.Point(406, 3);
            this.btnUser.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(60, 60);
            this.btnUser.TabIndex = 3;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnCanHo
            // 
            this.btnCanHo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCanHo.ImageOptions.Image")));
            this.btnCanHo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCanHo.Location = new System.Drawing.Point(200, 3);
            this.btnCanHo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCanHo.Name = "btnCanHo";
            this.btnCanHo.Size = new System.Drawing.Size(60, 60);
            this.btnCanHo.TabIndex = 2;
            this.btnCanHo.Click += new System.EventHandler(this.btnCanHo_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNhanVien.ImageOptions.Image")));
            this.btnNhanVien.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnNhanVien.Location = new System.Drawing.Point(0, 3);
            this.btnNhanVien.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(60, 60);
            this.btnNhanVien.TabIndex = 1;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnNguoiDan
            // 
            this.btnNguoiDan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNguoiDan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNguoiDan.ImageOptions.Image")));
            this.btnNguoiDan.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnNguoiDan.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.btnNguoiDan.Location = new System.Drawing.Point(101, 3);
            this.btnNguoiDan.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnNguoiDan.Name = "btnNguoiDan";
            this.btnNguoiDan.Size = new System.Drawing.Size(60, 60);
            this.btnNguoiDan.TabIndex = 0;
            this.btnNguoiDan.Click += new System.EventHandler(this.btnNguoiDan_Click);
            // 
            // fQuanLyChucNang
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(226)))), ((int)(((byte)(233)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.pnNavBar);
            this.Controls.Add(this.menuFunction);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "fQuanLyChucNang";
            this.Text = "Menu chính";
            this.menuFunction.ResumeLayout(false);
            this.menuFunction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnNavBar)).EndInit();
            this.pnNavBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuFunction;
        private System.Windows.Forms.ToolStripMenuItem quảnTrịToolStripMenuItem;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private DevExpress.XtraEditors.PanelControl pnNavBar;
        private DevExpress.XtraEditors.SimpleButton btnNguoiDan;
        private DevExpress.XtraEditors.SimpleButton btnUser;
        private DevExpress.XtraEditors.SimpleButton btnCanHo;
        private DevExpress.XtraEditors.SimpleButton btnNhanVien;
        private DevExpress.XtraEditors.SimpleButton btnDangXuat;
        private System.Windows.Forms.ToolStripMenuItem đăngNhậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thônTinPhầnMềmToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton btnCanHo_DichVu;
    }
}