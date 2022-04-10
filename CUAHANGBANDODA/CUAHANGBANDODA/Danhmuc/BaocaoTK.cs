using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;


namespace CUAHANGBANDODA.Danhmuc
{
    public partial class BaocaoTK : Form
    {
        Module.DataAccess dtBase = new Module.DataAccess();
        string kn = "Data Source=DESKTOP-8UM34TA\\SQLEXPRESS;Initial Catalog=QLBanDoDa4;Integrated Security=True";
        int TongNhap, TongBan, TongTon, DoanhThu, LoiNhuan, TTNhap;

        private void btnLoad_Click(object sender, EventArgs e)
        {


            TongNhap = int.Parse(dtBase.laygiatri("Select sum(a.SoLuong) from tChiTietHDN as a join tHoaDonNhap as b on a.MaHDN = b.MaHDN where year(b.NgayNhap) = '" + comboBox1.SelectedValue + "' "));
            TongBan = int.Parse(dtBase.laygiatri("Select sum(a.SoLuong) from tChiTietHDB as a join tHoaDonBan as b on a.MaHDB = b.MaHDB where year(b.NgayBan) = '" + comboBox1.SelectedValue + "' "));
            TongTon = TongNhap - TongBan;
            lblHangTon.Text = TongTon.ToString();
            lblTongBan.Text = TongBan.ToString();
            DoanhThu = int.Parse(dtBase.laygiatri("Select sum(a.ThanhTien) from tChiTietHDB as a join tHoaDonBan as b on a.MaHDB = b.MaHDB where year(b.NgayBan) = '" + comboBox1.SelectedValue + "' "));
            lblDoanhThu.Text = DoanhThu.ToString();
            TTNhap = int.Parse(dtBase.laygiatri("Select sum(a.ThanhTien) from tChiTietHDN as a join tHoaDonNhap as b on a.MaHDN = b.MaHDN where year(b.NgayNhap) = '" + comboBox1.SelectedValue + "' "));
            if (LoiNhuan <= 0)
            {
                LoiNhuan = 0;
                lblLoiNhuan.Text = LoiNhuan.ToString();
            }
            else
            {
                LoiNhuan = DoanhThu - TTNhap;
                lblLoiNhuan.Text = LoiNhuan.ToString();
            }
        }
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.DataSource = dtBase.DataReader("SELECT DISTINCT year(NgayBan) as nam  FROM tHoaDonBan");
            comboBox1.DisplayMember = "nam";
            comboBox1.ValueMember = "nam";
            comboBox1.SelectedIndex = -1;
        }

        public BaocaoTK()
        {
            InitializeComponent();
        }

        private void BaocaoTK_Load(object sender, EventArgs e)
        {

           


            //Xuat bieu do tron
            string cl = "SELECT * FROM tChiTietHDB as a join tSanPham as b on  a.MaSP = b.MaSP ";
            SqlConnection con = new SqlConnection(kn);
            SqlCommand cmd = new SqlCommand(cl, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            con.Open();
            chtBDT.DataSource = ds;

            chtBDT.Series["SanPham"].XValueMember = "TenSP";
            chtBDT.Series["SanPham"].YValueMembers = "SoLuong";




            //con.Close();
            //Datagridview
            dgvThongKe.DataSource = dtBase.DataReader("select a.MaSP,a.TenSP," +
               "b.SoLuong,case when a.SoLuong - b.SoLuong <= 0 then 0 else a.SoLuong - b.SoLuong end,b.ThanhTien from tSanPham as a,tChiTietHDB as b " +
               "where a.MaSP = b.MaSP group by a.MaSP,a.TenSP,b.SoLuong,a.SoLuong,b.ThanhTien");
            /*where b.MaHDB = '" + txtMaHDBan.Text + "' and a.MaSP = b.MaSP*/
            dgvThongKe.BackgroundColor = Color.DodgerBlue;
            dgvThongKe.Columns[0].HeaderText = "Mã sản phẩm";
            dgvThongKe.Columns[1].HeaderText = "Tên sản phẩm";
            dgvThongKe.Columns[2].HeaderText = "Số lượng bán";
            dgvThongKe.Columns[3].HeaderText = "Số lượng còn";
            dgvThongKe.Columns[4].HeaderText = "Thành tiền";
            dgvThongKe.Columns[0].Width = 150;
            dgvThongKe.Columns[1].Width = 150;
            dgvThongKe.Columns[2].Width = 150;
            dgvThongKe.Columns[3].Width = 150;
            dgvThongKe.Columns[4].Width = 150;
            

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FrmMain frmmain = new FrmMain();
            frmmain.Show();
            this.Hide();
        }

        private void btnInExcel_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop Marc Jacobs ";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Hoàn Kiếm - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (04)38526419";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "BÁO CÁO THỐNG KÊ";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "select sum(b.SoLuong)-sum(a.SoLuong),sum(a.SoLuong),sum(a.ThanhTien),sum(a.ThanhTien)-sum(b.ThanhTien),d.TenNV from tChiTietHDB as a,tChiTietHDN as b,tHoaDonNhap as c,tNhanVien as d where a.MaSP = b.MaSP and  b.MaHDN = C.MaHDN and d.MaNVV = c.MaNVV group by c.MaNVV,d.TenNV";
            tblThongtinHD = dtBase.DataReader(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Tổng tồn:";
            //exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:C6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Tổng bán:";
           
            exRange.Range["C7:C7"].Value = tblThongtinHD.Rows[0][1].ToString();
            exRange.Range["B8:B8"].Value = "Daonh thu:";
            
            exRange.Range["C8:C8"].Value = tblThongtinHD.Rows[0][2].ToString();
            exRange.Range["B9:B9"].Value = "Lợi nhuận:";
            
            exRange.Range["C9:C9"].Value = tblThongtinHD.Rows[0][3].ToString();
            //Lấy thông tin các mặt hàng
            sql = "select a.MaSP,a.TenSP," +
               "b.SoLuong,a.SoLuong - b.SoLuong,b.ThanhTien from tSanPham as a,tChiTietHDB as b " +
               "where a.MaSP = b.MaSP ";
            tblThongtinHang = dtBase.DataReader(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 18;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Mã sản phẩm";
            exRange.Range["C11:C11"].Value = "Tên sản phẩm";
            exRange.Range["D11:D11"].Value = "Số lượng đã bán";
            exRange.Range["E11:E11"].Value = "Số lượng còn lại";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                }
            }
            
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
           
            DateTime d = DateTime.UtcNow;
            
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên";
            exRange.Range["A4:C4"].MergeCells = true;
            exRange.Range["A4:C4"].Font.Italic = true;
            exRange.Range["A4:C4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A4:C4"].Value = tblThongtinHD.Rows[0][4];
            exSheet.Name = "Hóa đơn bán";
            exApp.Visible = true;
        }
    }
}
