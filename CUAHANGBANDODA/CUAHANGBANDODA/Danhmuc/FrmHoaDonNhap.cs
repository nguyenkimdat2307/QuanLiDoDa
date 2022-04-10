using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CUAHANGBANDODA.Module;
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace CUAHANGBANDODA.Danhmuc
{
    public partial class FrmHoaDonNhap : Form
    {
        Module.DataAccess dtbase = new Module.DataAccess();
        public FrmHoaDonNhap()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            main.Show();
            this.Hide();
        }

        private void FrmHoaDonNhap_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnInHoaDon.Enabled = false;
            txtMaHDNhap.ReadOnly = true;
            txtTenNhanVien.ReadOnly = true;
            txtTenNhaCC.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtDienThoai.ReadOnly = true;
            txtTenSanPham.ReadOnly = true;
            txtDonGiaNhap.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtKhuyenMai.Text = "0";
            txtTongTien.Text = "0";
            cboMaNhaCC.DataSource = dtbase.DataReader("SELECT MaNCC FROM tNhaCungCap");
            cboMaNhaCC.DisplayMember = "MaNCC";
            cboMaNhaCC.ValueMember = "MaNCC";
            cboMaNhaCC.SelectedIndex = -1;
            cboMaNhanVien.DataSource = dtbase.DataReader("SELECT MaNVV,TenNV FROM tNhanVien");
            cboMaNhanVien.DisplayMember = "MaNVV";
            cboMaNhanVien.ValueMember = "MaNVV";
            cboMaNhanVien.SelectedIndex = -1;
            cboMaSanPham.DataSource = dtbase.DataReader("SELECT MaSP, TenSP FROM tSanPham");
            cboMaSanPham.DisplayMember = "MaSP";
            cboMaSanPham.ValueMember = "MaSP";
            cboMaSanPham.SelectedIndex = -1;
            if (txtMaHDNhap.Text != "")
            {
                LoadInfoHoaDon();
                btnXoa.Enabled = true;
                btnInHoaDon.Enabled = true;
            }
            LoadDataGridView();
        }
        public void LoadDataGridView()
        {
            dgvHoaDonNhap.DataSource = dtbase.DataReader("select a.MaSP,a.TenSP," +
                "b.SoLuong,b.DonGia,b.KhuyenMai,b.ThanhTien from tSanPham as a,tChiTietHDN as b where a.MaSP = b.MaSP group by a.MaSP,a.TenSP,b.SoLuong,b.DonGia,b.KhuyenMai,b.ThanhTien");
            dgvHoaDonNhap.BackgroundColor = Color.DodgerBlue;
            dgvHoaDonNhap.Columns[0].HeaderText = "Mã sản phẩm";
            dgvHoaDonNhap.Columns[1].HeaderText = "Tên sản phẩm";
            dgvHoaDonNhap.Columns[2].HeaderText = "Số lượng";
            dgvHoaDonNhap.Columns[3].HeaderText = "Đơn giá";
            dgvHoaDonNhap.Columns[4].HeaderText = "Giảm giá %";
            dgvHoaDonNhap.Columns[5].HeaderText = "Thành tiền";
        }
        public void ResetValues()
        {
            txtMaHDNhap.Text = "";
            txtNgayNhap.Text = "";
            cboMaNhanVien.Text = "";
            cboMaNhaCC.Text = "";
            txtTongTien.Text = "0";
            cboMaSanPham.Text = "";
            txtSoLuong.Text = "";
            txtKhuyenMai.Text = "0";
            txtThanhTien.Text = "0";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtTenNhaCC.Text = "";
            txtTenNhanVien.Text = "";
        }
        public void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayNhap FROM tHoaDonNhap WHERE MaHDN = N'" + txtMaHDNhap.Text + "'";
            txtNgayNhap.Text = dtbase.laygiatri(str);
            str = "SELECT MaNVV FROM tHoaDonNhap WHERE MaHDN = N'" + txtMaHDNhap.Text + "'";
            cboMaNhanVien.Text = dtbase.laygiatri(str);
            str = "SELECT MaNCC FROM tHoaDonNHap WHERE MaHDN = N'" + txtMaHDNhap.Text + "'";
            cboMaNhaCC.Text = dtbase.laygiatri(str);
            str = "SELECT Tongtien FROM tHoaDonNhap WHERE MaHDN = N'" + txtMaHDNhap.Text + "'";
            txtTongTien.Text = dtbase.laygiatri(str);

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnInHoaDon.Enabled = false;
            btnThem.Enabled = false;
            ResetValues();
            txtMaHDNhap.Text = dtbase.TaoMa("HDN");
            LoadDataGridView();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            int sl, SLcon, tong, Tongmoi;
            sql = "SELECT MaHDN FROM tHoaDonNhap WHERE MaHDN=N'" + txtMaHDNhap.Text + "'";
            if (!dtbase.ktra(sql))
            {
                if (txtNgayNhap.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNgayNhap.Focus();
                    return;
                }
                if (cboMaNhanVien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaNhanVien.Focus();
                    return;
                }
                if (cboMaNhaCC.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaNhaCC.Focus();
                    return;
                }
                sql = "INSERT INTO tHoaDonNhap(MaHDN, NgayNhap, MaNVV, MaNCC, Tongtien) VALUES (N'" + txtMaHDNhap.Text.Trim() + "','" +
                     txtNgayNhap.Text + "',N'" + cboMaNhanVien.SelectedValue + "',N'" +
                        cboMaNhaCC.SelectedValue + "'," + txtTongTien.Text + ")";
                dtbase.Chaysql(sql);
            }
            // Lưu thông tin của các mặt hàng
            if (cboMaSanPham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaSanPham.Focus();
                return;
            }
            if ((txtSoLuong.Text.Trim().Length == 0) || (txtSoLuong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            if (txtKhuyenMai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKhuyenMai.Focus();
                return;
            }
            sql = "SELECT MaSP FROM tChiTietHDN WHERE MaSP=N'" + cboMaSanPham.SelectedValue + "' AND MaHDN = N'" + txtMaHDNhap.Text.Trim() + "'";
            if (dtbase.ktra(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaSanPham.Text = "";
                txtSoLuong.Text = "";
                txtKhuyenMai.Text = "0";
                txtThanhTien.Text = "0";
                cboMaSanPham.Focus();
                return;
            }
            
            sl = int.Parse(dtbase.laygiatri("SELECT SoLuong FROM tSanPham WHERE MaSP = N'" + cboMaSanPham.SelectedValue + "'"));
           
            sql = "INSERT INTO tChiTietHDN(MaHDN,MaSP,SoLuong,ThanhTien,KhuyenMai,DonGia) VALUES(N'" + txtMaHDNhap.Text.Trim() + "',N'" + cboMaSanPham.SelectedValue + "'," + txtSoLuong.Text + "," + txtThanhTien.Text + "," + txtKhuyenMai.Text + "," + txtDonGiaNhap.Text + ")";
            dtbase.Chaysql(sql);
            LoadDataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng tSanPham
            SLcon = sl + Convert.ToInt32(txtSoLuong.Text);
            sql = "UPDATE tSanPham SET SoLuong =" + SLcon + " WHERE MaSP= N'" + cboMaSanPham.SelectedValue + "'";
            dtbase.Chaysql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn nhập
            tong = int.Parse(dtbase.laygiatri("SELECT Tongtien FROM tHoaDonNhap WHERE MaHDN = N'" + txtMaHDNhap.Text + "'"));
            Tongmoi = tong + int.Parse(txtThanhTien.Text);
            sql = "UPDATE tHoaDonNHap SET Tongtien =" + Tongmoi + " WHERE MaHDN = N'" + txtMaHDNhap.Text + "'";
            dtbase.Chaysql(sql);
            txtTongTien.Text = Tongmoi.ToString();

            cboMaSanPham.Text = "";
            txtSoLuong.Text = "";
            txtKhuyenMai.Text = "0";
            txtThanhTien.Text = "0";
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnInHoaDon.Enabled = true;
        }

        private void cboMaHDNhap_DropDown(object sender, EventArgs e)
        {
            cboMaHDNhap.DataSource = dtbase.DataReader("SELECT MaHDN FROM tHoaDonNhap");
            cboMaHDNhap.DisplayMember = "MaHDN";
            cboMaHDNhap.ValueMember = "MaHDN";
            cboMaHDNhap.SelectedIndex = -1;
        }

        private void cboMaNhanVien_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaNhanVien.Text == "")
                txtTenNhanVien.Text = "";
            str = "Select TenNV from tNhanVien where MaNVV =N'" + cboMaNhanVien.SelectedValue + "'";
            txtTenNhanVien.Text = dtbase.laygiatri(str);
        }

        private void cboMaNhaCC_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaNhaCC.Text == "")
            {
                txtTenNhaCC.Text = "";
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
            }
            str = "Select TenNCC from tNhaCungCap where MaNCC = N'" + cboMaNhaCC.SelectedValue + "'";
            txtTenNhaCC.Text = dtbase.laygiatri(str);
            str = "Select SĐT from tNhaCungCap where MaNCC= N'" + cboMaNhaCC.SelectedValue + "'";
            txtDienThoai.Text = dtbase.laygiatri(str);
            str = "Select DiaChi from tNhaCungCap where MaNCC = N'" + cboMaNhaCC.SelectedValue + "'";
            txtDiaChi.Text = dtbase.laygiatri(str);
           
        }

        private void cboMaSanPham_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaSanPham.Text == "")
            {
                txtTenSanPham.Text = "";
                txtDonGiaNhap.Text = "";
            }
            str = "SELECT TenSP FROM tSanPham WHERE MaSP =N'" + cboMaSanPham.SelectedValue + "'";
            txtTenSanPham.Text = dtbase.laygiatri(str);
            str = "SELECT GiaNhap FROM tSanPham WHERE MaSP =N'" + cboMaSanPham.SelectedValue + "'";
            txtDonGiaNhap.Text = dtbase.laygiatri(str);
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtKhuyenMai.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtKhuyenMai.Text);
            if (txtDonGiaNhap.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaNhap.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void txtKhuyenMai_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtKhuyenMai.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtKhuyenMai.Text);
            if (txtDonGiaNhap.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaNhap.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string str;
            if (cboMaHDNhap.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHDNhap.Focus();
                return;
            }
            txtMaHDNhap.Text = cboMaHDNhap.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            str = "SELECT MaSP FROM tChiTietHDN WHERE MaHDN = N'" + txtMaHDNhap.Text + "'";
            cboMaSanPham.Text = dtbase.laygiatri(str);
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            btnInHoaDon.Enabled = true;
            cboMaHDNhap.SelectedIndex = -1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MaSP,SoLuong FROM tChiTietHDN WHERE MaHDN = N'" + txtMaHDNhap.Text + "'";
                DataTable tblHang = dtbase.LayData(sql);
                for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
                {
                    sl = Convert.ToDouble(dtbase.laygiatri("SELECT SoLuong FROM tSanPham WHERE MaSP = N'" + tblHang.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
                    slcon = sl - slxoa;
                    sql = "UPDATE tSanPham SET SoLuong =" + slcon + " WHERE MaSP= N'" + tblHang.Rows[hang][0].ToString() + "'";
                    dtbase.Chaysql(sql);
                }
                sql = "DELETE tChiTietHDN WHERE MaHDN=N'" + txtMaHDNhap.Text + "'";
                dtbase.Chaysql(sql);
                sql = "DELETE tHoaDonNhap WHERE MaHDN=N'" + txtMaHDNhap.Text + "'";
                dtbase.Chaysql(sql);
                ResetValues();
                LoadDataGridView();
                btnXoa.Enabled = false;
                btnInHoaDon.Enabled = false;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
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
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN NHẬP";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHDN, a.NgayNhap, a.Tongtien, b.TenNCC, b.DiaChi, b.SĐT, c.TenNV FROM tHoaDonNhap AS a, tNhaCungCap AS b, tNhanVien AS c WHERE a.MaHDN = N'" + txtMaHDNhap.Text + "' AND a.MaNCC = b.MaNCC AND a.MaNVV = c.MaNVV";
            tblThongtinHD = dtbase.DataReader(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Nhà cung cấp:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:C9"].MergeCells = true;
            exRange.Range["C9:C9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenSP, a.SoLuong, b.GiaNhap, a.KhuyenMai, a.ThanhTien " +
                  "FROM tChiTietHDN AS a , tSanPham AS b WHERE a.MaHDN = N'" +
                  txtMaHDNhap.Text + "' AND a.MaSP = b.MaSP";
            tblThongtinHang = dtbase.DataReader(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên sản phẩm";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString() + "%";
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            //exRange.Range["A1:F1"].Value = "Bằng chữ: " + dtbase.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên nhập hàng";
            exRange.Range["A4:C4"].MergeCells = true;
            exRange.Range["A4:C4"].Font.Italic = true;
            exRange.Range["A4:C4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A4:C4"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
