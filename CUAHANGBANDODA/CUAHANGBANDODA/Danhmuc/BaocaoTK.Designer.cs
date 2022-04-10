
namespace CUAHANGBANDODA.Danhmuc
{
    partial class BaocaoTK
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaocaoTK));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.chtBDT = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnInExcel = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnLoiNhuan = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lblLoiNhuan = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pnDoanhThu = new System.Windows.Forms.Panel();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pnTongBan = new System.Windows.Forms.Panel();
            this.lblTongBan = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnHangTon = new System.Windows.Forms.Panel();
            this.lblHangTon = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtBDT)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnLoiNhuan.SuspendLayout();
            this.pnDoanhThu.SuspendLayout();
            this.pnTongBan.SuspendLayout();
            this.pnHangTon.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1178, 49);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(435, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Báo Cáo Thống  Kê";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvThongKe);
            this.panel2.Controls.Add(this.chtBDT);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(1178, 615);
            this.panel2.TabIndex = 1;
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongKe.Location = new System.Drawing.Point(10, 110);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.RowHeadersWidth = 62;
            this.dgvThongKe.RowTemplate.Height = 28;
            this.dgvThongKe.Size = new System.Drawing.Size(747, 397);
            this.dgvThongKe.TabIndex = 4;
            // 
            // chtBDT
            // 
            chartArea2.Name = "ChartArea1";
            this.chtBDT.ChartAreas.Add(chartArea2);
            this.chtBDT.Dock = System.Windows.Forms.DockStyle.Right;
            legend2.Name = "Legend1";
            this.chtBDT.Legends.Add(legend2);
            this.chtBDT.Location = new System.Drawing.Point(757, 110);
            this.chtBDT.Name = "chtBDT";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "SanPham";
            this.chtBDT.Series.Add(series2);
            this.chtBDT.Size = new System.Drawing.Size(411, 397);
            this.chtBDT.TabIndex = 3;
            this.chtBDT.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.ForeColor = System.Drawing.Color.DodgerBlue;
            title2.Name = "Title1";
            title2.Text = "Biểu đồ thống kê sản phẩm bán";
            this.chtBDT.Titles.Add(title2);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnInExcel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(10, 507);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1158, 98);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(901, 31);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(224, 49);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnInExcel
            // 
            this.btnInExcel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnInExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInExcel.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInExcel.ForeColor = System.Drawing.Color.White;
            this.btnInExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnInExcel.Image")));
            this.btnInExcel.Location = new System.Drawing.Point(568, 31);
            this.btnInExcel.Name = "btnInExcel";
            this.btnInExcel.Size = new System.Drawing.Size(224, 49);
            this.btnInExcel.TabIndex = 0;
            this.btnInExcel.Text = "InExcel";
            this.btnInExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInExcel.UseVisualStyleBackColor = false;
            this.btnInExcel.Click += new System.EventHandler(this.btnInExcel_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.pnLoiNhuan, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnDoanhThu, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnTongBan, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnHangTon, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1158, 100);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // pnLoiNhuan
            // 
            this.pnLoiNhuan.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnLoiNhuan.Controls.Add(this.label11);
            this.pnLoiNhuan.Controls.Add(this.lblLoiNhuan);
            this.pnLoiNhuan.Controls.Add(this.label13);
            this.pnLoiNhuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnLoiNhuan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnLoiNhuan.Location = new System.Drawing.Point(870, 3);
            this.pnLoiNhuan.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.pnLoiNhuan.Name = "pnLoiNhuan";
            this.pnLoiNhuan.Size = new System.Drawing.Size(278, 87);
            this.pnLoiNhuan.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(-1, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 28);
            this.label11.TabIndex = 2;
            // 
            // lblLoiNhuan
            // 
            this.lblLoiNhuan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoiNhuan.ForeColor = System.Drawing.Color.White;
            this.lblLoiNhuan.Location = new System.Drawing.Point(49, 31);
            this.lblLoiNhuan.Name = "lblLoiNhuan";
            this.lblLoiNhuan.Size = new System.Drawing.Size(229, 30);
            this.lblLoiNhuan.TabIndex = 2;
            this.lblLoiNhuan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 28);
            this.label13.TabIndex = 1;
            this.label13.Text = "Lợi nhuận";
            // 
            // pnDoanhThu
            // 
            this.pnDoanhThu.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnDoanhThu.Controls.Add(this.lblDoanhThu);
            this.pnDoanhThu.Controls.Add(this.label10);
            this.pnDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDoanhThu.Location = new System.Drawing.Point(581, 3);
            this.pnDoanhThu.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.pnDoanhThu.Name = "pnDoanhThu";
            this.pnDoanhThu.Size = new System.Drawing.Size(276, 87);
            this.pnDoanhThu.TabIndex = 2;
            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDoanhThu.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThu.Location = new System.Drawing.Point(47, 31);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(229, 30);
            this.lblDoanhThu.TabIndex = 2;
            this.lblDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 28);
            this.label10.TabIndex = 1;
            this.label10.Text = "Doanh thu";
            // 
            // pnTongBan
            // 
            this.pnTongBan.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnTongBan.Controls.Add(this.lblTongBan);
            this.pnTongBan.Controls.Add(this.label7);
            this.pnTongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTongBan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnTongBan.ForeColor = System.Drawing.Color.Blue;
            this.pnTongBan.Location = new System.Drawing.Point(292, 3);
            this.pnTongBan.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.pnTongBan.Name = "pnTongBan";
            this.pnTongBan.Size = new System.Drawing.Size(276, 87);
            this.pnTongBan.TabIndex = 1;
            // 
            // lblTongBan
            // 
            this.lblTongBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongBan.ForeColor = System.Drawing.Color.White;
            this.lblTongBan.Location = new System.Drawing.Point(47, 31);
            this.lblTongBan.Name = "lblTongBan";
            this.lblTongBan.Size = new System.Drawing.Size(229, 30);
            this.lblTongBan.TabIndex = 2;
            this.lblTongBan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 28);
            this.label7.TabIndex = 1;
            this.label7.Text = "Tổng bán";
            // 
            // pnHangTon
            // 
            this.pnHangTon.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnHangTon.Controls.Add(this.lblHangTon);
            this.pnHangTon.Controls.Add(this.label2);
            this.pnHangTon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnHangTon.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnHangTon.Location = new System.Drawing.Point(3, 3);
            this.pnHangTon.Margin = new System.Windows.Forms.Padding(3, 3, 10, 10);
            this.pnHangTon.Name = "pnHangTon";
            this.pnHangTon.Size = new System.Drawing.Size(276, 87);
            this.pnHangTon.TabIndex = 0;
            // 
            // lblHangTon
            // 
            this.lblHangTon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHangTon.ForeColor = System.Drawing.Color.White;
            this.lblHangTon.Location = new System.Drawing.Point(47, 31);
            this.lblHangTon.Name = "lblHangTon";
            this.lblHangTon.Size = new System.Drawing.Size(229, 30);
            this.lblHangTon.TabIndex = 2;
            this.lblHangTon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hàng tồn";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(23, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(236, 42);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.Location = new System.Drawing.Point(297, 31);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(224, 49);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // BaocaoTK
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1178, 664);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaocaoTK";
            this.Text = "BaocaoTK";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BaocaoTK_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtBDT)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.pnLoiNhuan.ResumeLayout(false);
            this.pnLoiNhuan.PerformLayout();
            this.pnDoanhThu.ResumeLayout(false);
            this.pnDoanhThu.PerformLayout();
            this.pnTongBan.ResumeLayout(false);
            this.pnTongBan.PerformLayout();
            this.pnHangTon.ResumeLayout(false);
            this.pnHangTon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel pnLoiNhuan;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblLoiNhuan;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnDoanhThu;
        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnTongBan;
        private System.Windows.Forms.Label lblTongBan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnHangTon;
        private System.Windows.Forms.Label lblHangTon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtBDT;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnInExcel;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnLoad;
    }
}