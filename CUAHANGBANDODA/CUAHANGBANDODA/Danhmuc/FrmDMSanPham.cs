
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CUAHANGBANDODA.Danhmuc
{
    public partial class FrmDMSanPham : Form
    {
        Module.DataAccess dtBase = new Module.DataAccess();
        string imagename;
        public FrmDMSanPham()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            main.Show();
            this.Hide();
        }

        private void FrmDMSanPham_Load(object sender, EventArgs e)
        {
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            cboMaChatLieu.DataSource = dtBase.DataReader("select MaCL,TenCL from tChatLieu");
            cboMaChatLieu.DisplayMember = "MaCL";
            cboMaChatLieu.ValueMember = "MaCL";
            cboMaChatLieu.Text = "";

            cboMaLoai.DataSource = dtBase.DataReader("select MaLoai,TenLoai from tLoai");
            cboMaLoai.DisplayMember = "MaLoai";
            cboMaLoai.ValueMember = "MaLoai";
            cboMaLoai.Text = "";

            cboMaNuoc.DataSource = dtBase.DataReader("select MaNuoc,TenNuoc from tNuocSX");
            cboMaNuoc.DisplayMember = "MaNuoc";
            cboMaNuoc.ValueMember = "MaNuoc";
            cboMaNuoc.Text = "";

            cboMaMau.DataSource = dtBase.DataReader("select MaMau,TenMau from tMauSac");
            cboMaMau.DisplayMember = "MaMau";
            cboMaMau.ValueMember = "MaMau";
            cboMaMau.SelectedIndex = -1;
            //Tải hàng lên datagridview
            dgvSanPham.DataSource = dtBase.DataReader("select MaSP,TenSP,MaLoai,MaNuoc,MaCL,GiaNhap,GiaBan," +
                "SoLuong,MaMau,HinhAnh,GhiChu from tSanPham");
            dgvSanPham.BackgroundColor = Color.DodgerBlue;
            dgvSanPham.Columns[0].HeaderText = "Mã sản phẩm";
            dgvSanPham.Columns[1].HeaderText = "Tên sản phẩm";
            dgvSanPham.Columns[2].HeaderText = "Loại";
            dgvSanPham.Columns[3].HeaderText = "Nước sản xuất";
            dgvSanPham.Columns[4].HeaderText = "Chất liệu";
            dgvSanPham.Columns[5].HeaderText = "Giá nhập";
            dgvSanPham.Columns[6].HeaderText = "Giá bán";
            dgvSanPham.Columns[7].HeaderText = "Số lượng";
            dgvSanPham.Columns[8].HeaderText = "Màu";
            dgvSanPham.Columns[9].HeaderText = "Hình ảnh";
            dgvSanPham.Columns[10].HeaderText = "Ghi chú";
        }
        private void ResetValues()
        {
            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            cboMaChatLieu.Text = "";
            cboMaLoai.Text = "";
            cboMaNuoc.Text = "";
            cboMaMau.Text = "";
            txtSoLuong.Text = "0";
            txtDonGiaNhap.Text = "0";
            txtDonGiaBan.Text = "0";
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtghichu.Text = "";
            picAnh.Image = null;
        }
        private void dgvSanPham_Click(object sender, EventArgs e)
        {


        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaSanPham.Enabled = true;
            txtMaSanPham.Focus();
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtDonGiaBan.Enabled = true;
            cboMaChatLieu.Enabled = true;
            cboMaLoai.Enabled = true;
            cboMaNuoc.Enabled = true;
            cboMaMau.Enabled = true;
            txtghichu.Enabled = true;
            picAnh.Enabled = true;
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaSanPham.Text = dgvSanPham.CurrentRow.Cells[0].Value.ToString();
                txtTenSanPham.Text = dgvSanPham.CurrentRow.Cells[1].Value.ToString();
                cboMaLoai.Text = "";
                cboMaLoai.SelectedText = dgvSanPham.CurrentRow.Cells[2].Value.ToString();
                cboMaNuoc.Text = "";
                cboMaNuoc.SelectedText = dgvSanPham.CurrentRow.Cells[3].Value.ToString();
                cboMaChatLieu.Text = "";
                cboMaChatLieu.SelectedText = dgvSanPham.CurrentRow.Cells[4].Value.ToString();

                txtDonGiaNhap.Text = dgvSanPham.CurrentRow.Cells[5].Value.ToString();
                txtDonGiaBan.Text = dgvSanPham.CurrentRow.Cells[6].Value.ToString();
                txtSoLuong.Text = dgvSanPham.CurrentRow.Cells[7].Value.ToString();
                cboMaMau.Text = "";
                cboMaMau.SelectedText = dgvSanPham.CurrentRow.Cells[8].Value.ToString();
                imagename = dgvSanPham.CurrentRow.Cells[9].Value.ToString();

                if (imagename == "")
                    picAnh.Image = null;
                else
                    picAnh.Image = Image.FromFile(Application.StartupPath.ToString() + "\\Image\\SanPham\\" + imagename);
                txtghichu.Text = dgvSanPham.CurrentRow.Cells[10].Value.ToString();
            }
            catch (Exception) { }

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string[] pathanh;
            OpenFileDialog dlgopen = new OpenFileDialog();
            dlgopen.Filter = "JEPG Imanges|*.jpg|All Files|*.*";
            dlgopen.InitialDirectory = Application.StartupPath.ToString() + "\\Image\\SanPham\\";
            if (dlgopen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgopen.FileName);
                pathanh = dlgopen.FileName.Split('\\');
                imagename = pathanh[pathanh.Length - 1];
                MessageBox.Show(imagename);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaSanPham.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maSP, sqlInsert;
            DataTable dtSanPham;
            if (txtMaSanPham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSanPham.Focus();
                return;
            }
            if (txtTenSanPham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSanPham.Focus();
                return;
            }
            if (cboMaChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaChatLieu.Focus();
                return;
            }
            if (txtghichu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ghi chú cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtghichu.Focus();
                return;
            }
            if (txtDonGiaNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá nhập chú cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonGiaNhap.Focus();
                return;
            }
            if (txtDonGiaBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá bán chú cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonGiaBan.Focus();
                return;
            }
            if (cboMaMau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã màu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaMau.Focus();
                return;
            }
            if (cboMaLoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaLoai.Focus();
                return;
            }
            if (cboMaNuoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNuoc.Focus();
                return;
            }
            maSP = txtMaSanPham.Text;
            dtSanPham = dtBase.DataReader("select * from tSanPham where MaSP = '" + maSP + "'");
            if (dtSanPham.Rows.Count > 0)
            {
                MessageBox.Show("Mã sản phẩm này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSanPham.Focus();
                return;
            }
            sqlInsert = "insert into tSanPham values ('" + maSP + "',N'" + txtTenSanPham.Text + "',N'" + cboMaLoai.Text + "',N'" + cboMaNuoc.Text + "',N'" + cboMaChatLieu.Text + "','" + txtDonGiaNhap.Text + "','" + txtDonGiaBan.Text + "','" + txtSoLuong.Text + "',N'" + cboMaMau.Text + "','" + imagename + "',N'" + txtghichu.Text + "')";
            dtBase.updatedata(sqlInsert);
            //
            dgvSanPham.DataSource = dtBase.DataReader("select * from tSanPham");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSanPham.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtBase.updatedata("delete tSanPham where MaSP = '" + txtMaSanPham.Text + "'");
                dgvSanPham.DataSource = dtBase.DataReader("select * from tSanPham");
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaSanPham.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSanPham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSanPham.Focus();
                return;
            }
            if (txtDonGiaBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaBan.Focus();
                return;
            }
            if (txtDonGiaNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaNhap.Focus();
                return;
            }
            if (txtghichu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ghi chú", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtghichu.Focus();
                return;
            }
            if (cboMaChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaChatLieu.Focus();
                return;
            }
            if (cboMaMau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã màu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaMau.Focus();
                return;
            }
            if (cboMaLoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaLoai.Focus();
                return;
            }
            if (cboMaNuoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNuoc.Focus();
                return;
            }
            dtBase.updatedata("update tSanPham set TenSP = N'" + txtTenSanPham.Text + "', MaLoai= N'" + cboMaLoai.Text + "',MaNuoc=N'" + cboMaNuoc.Text + "',MaCL = N'"+cboMaChatLieu.Text+"',GiaNhap = '"+txtDonGiaNhap.Text+"',GiaBan = N'"+txtDonGiaBan.Text+"',SoLuong = N'"+txtSoLuong.Text+"',MaMau = N'"+cboMaMau.Text+"',HinhAnh = '"+imagename+"',GhiChu = N'"+txtghichu.Text+"' where MaSP= N'" + txtMaSanPham.Text + "'");
            dgvSanPham.DataSource = dtBase.DataReader("select * from tSanPham");
            MessageBox.Show("Bạn đã sửa thành công");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            DataTable dtSanPhaml;
            if ((txtMaSanPham.Text == "") && (txtTenSanPham.Text == "") && (cboMaChatLieu.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from tSanPham WHERE 1=1";
            if (txtMaSanPham.Text != "")
                sql += " AND MaSP LIKE N'%" + txtMaSanPham.Text + "%'";
            if (txtTenSanPham.Text != "")
                sql += " AND TenSP LIKE N'%" + txtTenSanPham.Text + "%'";
            if (cboMaChatLieu.Text != "")
                sql += " AND MaCL LIKE N'%" + cboMaChatLieu.SelectedValue + "%'";
            dtSanPhaml = dtBase.DataReader(sql);
            if (dtSanPhaml.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else 
                MessageBox.Show("Có " + dtSanPhaml.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvSanPham.DataSource = dtSanPhaml;
            ResetValues();
        }
    }
}
