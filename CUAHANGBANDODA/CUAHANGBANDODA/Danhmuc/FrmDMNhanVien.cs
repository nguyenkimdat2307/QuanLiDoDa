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


namespace CUAHANGBANDODA.Danhmuc
{
    public partial class FrmDMNhanVien : Form
    {
        Module.DataAccess dtBase = new Module.DataAccess();
        public FrmDMNhanVien()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            main.Show();
            this.Hide();
        }

        private void FrmDMNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNhanVien.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            dgvNhanVien.DataSource = dtBase.DataReader("select * from tNhanVien");
            dgvNhanVien.BackgroundColor = Color.DodgerBlue;
            dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dgvNhanVien.Columns[2].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[3].HeaderText = "Giới tính ";
            dgvNhanVien.Columns[4].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[5].HeaderText = "Mã quê";
            dgvNhanVien.Columns[6].HeaderText = "Số điện thoại";

            dgvNhanVien.Columns[0].Width = 100;
            dgvNhanVien.Columns[1].Width = 150;
            dgvNhanVien.Columns[2].Width = 100;
            dgvNhanVien.Columns[3].Width = 150;
            dgvNhanVien.Columns[4].Width = 100;
            dgvNhanVien.Columns[5].Width = 100;
            dgvNhanVien.Columns[6].Width = 150;
        }

        
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaNhanVien.Text = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
                txtTenNhanVien.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
                chGioiTinh.Text = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
                txtNgaySinh.Text = dgvNhanVien.CurrentRow.Cells[4].Value.ToString();
                txtMaQue.Text = dgvNhanVien.CurrentRow.Cells[5].Value.ToString();
                txtDienThoai.Text = dgvNhanVien.CurrentRow.Cells[6].Value.ToString();
            }
            catch
            {

            }
        }

        private void ResetValue()
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtMaQue.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtNgaySinh.Text = "";
            chGioiTinh.Checked = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtMaNhanVien.Enabled = true; //cho phép nhập mới
            txtMaNhanVien.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string gt;
            if (txtMaNhanVien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNhanVien.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (txtDienThoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return;
            }
            if (txtNgaySinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgaySinh.Focus();
                return;
            }
            if (chGioiTinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            dtBase.updatedata("update tNhanVien set TenNV = N'" + txtTenNhanVien.Text + "',DiaChi = N'"+txtDiaChi.Text+"',GioiTinh = N'"+gt+"',NgaySinh=N'"+txtNgaySinh.Text+"',MaQue=N'"+txtMaQue.Text+"',SDT=N'"+txtDienThoai.Text+"'where MaNVV= N'" + txtMaNhanVien.Text + "'");
            dgvNhanVien.DataSource = dtBase.DataReader("select * from tNhanVien");
            MessageBox.Show("Bạn đã sửa thành công");
            
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNhanVien.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sqlInsert, maNV,gt;
            
            DataTable dtNhanVien;
            // Kiểm tra nhập dữ liệu
            if (txtMaNhanVien.Text.Trim() == "" || txtTenNhanVien.Text.Trim() == "" || txtDiaChi.Text.Trim() == "" ||txtDienThoai.Text.Trim() == "" || txtNgaySinh.Text == "" || txtMaQue.Text.Trim()=="")
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu");
                return;
            }
            // Kiểm tra trường hợp trùng mã
            maNV = txtMaNhanVien.Text;
            dtNhanVien = dtBase.DataReader("select * from tNhanVien where MaNVV = '" + maNV + "'");
            if (dtNhanVien.Rows.Count > 0)
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại");
                txtMaNhanVien.Focus();
                txtMaNhanVien.Text = "";
                return;
            }
            if (chGioiTinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sqlInsert = "insert into tNhanVien values ('" + maNV + "',N'" + txtTenNhanVien.Text + "',N'"+txtDiaChi.Text+"',N'"+gt+"','"+txtNgaySinh.Text + "',N'"+txtMaQue.Text+"','"+txtDienThoai.Text+"')";
            dtBase.updatedata(sqlInsert);
            // Hiển thị Dữ liệu trên datagridview
            dgvNhanVien.DataSource = dtBase.DataReader("select * from tNhanVien");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa mã nhân viên có mã " + txtMaNhanVien.Text + "Không ?",
               "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtBase.updatedata("delete tNhanVien where MaNVV = '" + txtMaNhanVien.Text + "'");
                dgvNhanVien.DataSource = dtBase.DataReader("select * from tNhanVien");
                ResetValue();
            }

        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            
        }

        private void txtMaNhanVien_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
