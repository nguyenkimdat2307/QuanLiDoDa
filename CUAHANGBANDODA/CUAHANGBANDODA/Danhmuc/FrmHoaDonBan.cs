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
using CUAHANGBANDODA.Module;

namespace CUAHANGBANDODA.Danhmuc
{
    public partial class FrmHoaDonBan : Form
    {
        Module.DataAccess dtbase = new Module.DataAccess();

        public FrmHoaDonBan()
        {
            InitializeComponent();

        }

        public void btnThoat_Click(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            main.Show();
            this.Hide();
        }

       
        public void FrmHoaDonBan_Load(object sender, EventArgs e)
        {

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnInHoaDon.Enabled = false;
            txtMaHDBan.ReadOnly = true;
            txtTenNhanVien.ReadOnly = true;
            txtTenKhach.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtDienThoai.ReadOnly = true;
            txtTenSanPham.ReadOnly = true;
            txtDonGiaBan.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtKhuyenMai.Text = "0";
            txtTongTien.Text = "0";
            cboMaKhach.DataSource = dtbase.DataReader("SELECT MaKH FROM tKhachHang");
            cboMaKhach.DisplayMember = "MaKH";
            cboMaKhach.ValueMember = "MaKH";
            cboMaKhach.SelectedIndex = -1;
            cboMaNhanVien.DataSource = dtbase.DataReader("SELECT MaNVV,TenNV FROM tNhanVien");
            cboMaNhanVien.DisplayMember = "MaNVV";
            cboMaNhanVien.ValueMember = "MaNVV";
            cboMaNhanVien.SelectedIndex = -1;
            cboMaSanPham.DataSource = dtbase.DataReader("SELECT MaSP, TenSP FROM tSanPham");
            cboMaSanPham.DisplayMember = "MaSP";
            cboMaSanPham.ValueMember = "MaSP";
            cboMaSanPham.SelectedIndex = -1;
            if (txtMaHDBan.Text != "")
            {
                LoadInfoHoaDon();
                btnXoa.Enabled = true;
                btnInHoaDon.Enabled = true;
            }
            LoadDataGridView();
        }
        public void LoadDataGridView()
        {
            dgvHoaDonBan.DataSource = dtbase.DataReader("select a.MaSP,a.TenSP," +
                "b.SoLuong,b.DonGia,b.KhuyenMai,b.ThanhTien from tSanPham as a,tChiTietHDB as b where a.MaSP = b.MaSP group by a.MaSP,a.TenSP,b.SoLuong,b.DonGia,b.KhuyenMai,b.ThanhTien");
            /*where b.MaHDB = '" + txtMaHDBan.Text + "' and a.MaSP = b.MaSP*/
            dgvHoaDonBan.BackgroundColor = Color.DodgerBlue;
            dgvHoaDonBan.Columns[0].HeaderText = "Mã sản phẩm";
            dgvHoaDonBan.Columns[1].HeaderText = "Tên sản phẩm";
            dgvHoaDonBan.Columns[2].HeaderText = "Số lượng";
            dgvHoaDonBan.Columns[3].HeaderText = "Đơn giá";
            dgvHoaDonBan.Columns[4].HeaderText = "Giảm giá %";
            dgvHoaDonBan.Columns[5].HeaderText = "Thành tiền";
        }
        public void ResetValues()
        {
            txtMaHDBan.Text = "";
            txtNgayBan.Text = "";
            cboMaNhanVien.Text = "";
            cboMaKhach.Text = "";
            txtTongTien.Text = "0";
            cboMaSanPham.Text = "";
            txtSoLuong.Text = "";
            txtKhuyenMai.Text = "0";
            txtThanhTien.Text = "0";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtTenKhach.Text = "";
            txtTenNhanVien.Text = "";
        }
        public void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayBan FROM tHoaDonBan WHERE MaHDB = N'" + txtMaHDBan.Text + "'";
            txtNgayBan.Text = dtbase.laygiatri(str);
            str = "SELECT MaNVV FROM tHoaDonBan WHERE MaHDB = N'" + txtMaHDBan.Text + "'";
            cboMaNhanVien.Text = dtbase.laygiatri(str);
            str = "SELECT MaKH FROM tHoaDonBan WHERE MaHDB = N'" + txtMaHDBan.Text + "'";
            cboMaKhach.Text = dtbase.laygiatri(str);
            str = "SELECT Tongtien FROM tHoaDonBan WHERE MaHDB = N'" + txtMaHDBan.Text + "'";
            txtTongTien.Text = dtbase.laygiatri(str);
            
        }

        public void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnInHoaDon.Enabled = false;
            btnThem.Enabled = false;
            ResetValues();
            txtMaHDBan.Text = dtbase.TaoMa("HDB");
            LoadDataGridView();
        }

        public void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            int sl, SLcon, tong, Tongmoi;
            sql = "SELECT MaHDB FROM tHoaDonBan WHERE MaHDB=N'" + txtMaHDBan.Text + "'";
            if (!dtbase.ktra(sql))
            {
                if (txtNgayBan.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNgayBan.Focus();
                    return;
                }
                if (cboMaNhanVien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaNhanVien.Focus();
                    return;
                }
                if (cboMaKhach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaKhach.Focus();
                    return;
                }
                sql = "INSERT INTO tHoaDonBan(MaHDB, NgayBan, MaNVV, MaKH, Tongtien) VALUES (N'" + txtMaHDBan.Text.Trim() + "','" +
                     txtNgayBan.Text + "',N'" + cboMaNhanVien.SelectedValue + "',N'" +
                        cboMaKhach.SelectedValue + "'," + txtTongTien.Text + ")";
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
            sql = "SELECT MaSP FROM tChiTietHDB WHERE MaSP=N'" + cboMaSanPham.SelectedValue + "' AND MaHDB = N'" + txtMaHDBan.Text.Trim() + "'";
            if (dtbase.ktra(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaSanPham.Text = "";
                txtSoLuong.Text = "";
                txtKhuyenMai.Text = "0";
                txtThanhTien.Text = "0";
                cboMaSanPham.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = int.Parse(dtbase.laygiatri("SELECT SoLuong FROM tSanPham WHERE MaSP = N'" + cboMaSanPham.SelectedValue + "'"));
            if (int.Parse(txtSoLuong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            sql = "INSERT INTO tChiTietHDB(MaHDB,MaSP,SoLuong,ThanhTien,KhuyenMai,DonGia) VALUES(N'" + txtMaHDBan.Text.Trim() + "',N'" + cboMaSanPham.SelectedValue + "'," + txtSoLuong.Text + "," + txtThanhTien.Text + "," + txtKhuyenMai.Text + "," + txtDonGiaBan.Text + ")";
            dtbase.Chaysql(sql);
            LoadDataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToInt32(txtSoLuong.Text);
            sql = "UPDATE tSanPham SET SoLuong =" + SLcon + " WHERE MaSP= N'" + cboMaSanPham.SelectedValue + "'";
            dtbase.Chaysql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = int.Parse(dtbase.laygiatri("SELECT Tongtien FROM tHoaDonBan WHERE MaHDB = N'" + txtMaHDBan.Text + "'"));
            Tongmoi = tong + int.Parse(txtThanhTien.Text);
            sql = "UPDATE tHoaDonBan SET Tongtien =" + Tongmoi + " WHERE MaHDB = N'" + txtMaHDBan.Text + "'";
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

        public void cboMaHDBan_DropDown(object sender, EventArgs e)
        {

            cboMaHDBan.DataSource = dtbase.DataReader("SELECT MaHDB FROM tChiTietHDB");
            cboMaHDBan.DisplayMember = "MaHDB";
            cboMaHDBan.ValueMember = "MaHDB";
            cboMaHDBan.SelectedIndex = -1;
        }

        public void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void cboMaKhach_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        public void cboMaSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void cboMaNhanVien_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaNhanVien.Text == "")
                txtTenNhanVien.Text = "";
            str = "Select TenNV from tNhanVien where MaNVV =N'" + cboMaNhanVien.SelectedValue + "'";
            txtTenNhanVien.Text = dtbase.laygiatri(str);
        }

        public void cboMaKhach_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaKhach.Text == "")
            {
                txtTenKhach.Text = "";
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
            }
            str = "Select TenKH from tKhachHang where MaKH = N'" + cboMaKhach.SelectedValue + "'";
            txtTenKhach.Text = dtbase.laygiatri(str);
            str = "Select DiaChi from tKhachHang where MaKH = N'" + cboMaKhach.SelectedValue + "'";
            txtDiaChi.Text = dtbase.laygiatri(str);
            str = "Select SDT from tKhachHang where MaKH= N'" + cboMaKhach.SelectedValue + "'";
            txtDienThoai.Text = dtbase.laygiatri(str);
        }

        public void cboMaSanPham_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaSanPham.Text == "")
            {
                txtTenSanPham.Text = "";
                txtDonGiaBan.Text = "";
            }
            str = "SELECT TenSP FROM tSanPham WHERE MaSP =N'" + cboMaSanPham.SelectedValue + "'";
            txtTenSanPham.Text = dtbase.laygiatri(str);
            str = "SELECT GiaBan FROM tSanPham WHERE MaSP =N'" + cboMaSanPham.SelectedValue + "'";
            txtDonGiaBan.Text = dtbase.laygiatri(str);
        }

        public void txtSoLuong_TextChanged(object sender, EventArgs e)
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
            if (txtDonGiaBan.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaBan.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        public void txtKhuyenMai_TextChanged(object sender, EventArgs e)
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
            if (txtDonGiaBan.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaBan.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        public void btnTimKiem_Click(object sender, EventArgs e)
        {
            string str;
            if (cboMaHDBan.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHDBan.Focus();
                return;
            }
            txtMaHDBan.Text = cboMaHDBan.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            str = "SELECT MaSP FROM tChiTietHDB WHERE MaHDB = N'" + txtMaHDBan.Text + "'";
            cboMaSanPham.Text = dtbase.laygiatri(str);
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            btnInHoaDon.Enabled = true;
            cboMaHDBan.SelectedIndex = -1;
        }

        public void btnXoa_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MaSP,SoLuong FROM tChiTietHDB WHERE MaHDB = N'" + txtMaHDBan.Text + "'";
                DataTable tblHang = dtbase.LayData(sql);
                for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
                {
                    sl = Convert.ToDouble(dtbase.laygiatri("SELECT SoLuong FROM tSanPham WHERE MaSP = N'" + tblHang.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
                    slcon = sl + slxoa;
                    sql = "UPDATE tSanPham SET SoLuong =" + slcon + " WHERE MaSP= N'" + tblHang.Rows[hang][0].ToString() + "'";
                    dtbase.Chaysql(sql);
                }
                sql = "DELETE tChiTietHDB WHERE MaHDB=N'" + txtMaHDBan.Text + "'";
                dtbase.Chaysql(sql);
                sql = "DELETE tHoaDonBan WHERE MaHDB=N'" + txtMaHDBan.Text + "'";
                dtbase.Chaysql(sql);
                ResetValues();
                LoadDataGridView();
                btnXoa.Enabled = false;
                btnInHoaDon.Enabled = false;
            }
        }

        public void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
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
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHDB, a.NgayBan, a.Tongtien, b.TenKH, b.DiaChi, b.SDT, c.TenNV FROM tHoaDonBan AS a, tKhachHang AS b, tNhanVien AS c WHERE a.MaHDB = N'" + txtMaHDBan.Text + "' AND a.MaKH = b.MaKH AND a.MaNVV = c.MaNVV";
            tblThongtinHD = dtbase.DataReader(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:C9"].MergeCells = true;
            exRange.Range["C9:C9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenSP, a.SoLuong, b.GiaBan, a.KhuyenMai, a.ThanhTien " +
                  "FROM tChiTietHDB AS a , tSanPham AS b WHERE a.MaHDB = N'" +
                  txtMaHDBan.Text + "' AND a.MaSP = b.MaSP";
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
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A4:C4"].MergeCells = true;
            exRange.Range["A4:C4"].Font.Italic = true;
            exRange.Range["A4:C4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A4:C4"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn bán";
            exApp.Visible = true;
        }
    }
}
