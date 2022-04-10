using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CUAHANGBANDODA.Danhmuc
{
    public partial class FrmNhaCungCap : Form
    {
        Module.DataAccess dtbase = new Module.DataAccess();
        public FrmNhaCungCap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            main.Show();
            this.Hide();
        }
        private void resetvalue()
        {
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtMaNhaCC.Text = "";
            txtTenNhaCC.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            resetvalue();
            txtMaNhaCC.Enabled = true; //cho phép nhập mới
            txtMaNhaCC.Focus();
        }

        private void FrmNhaCungCap_Load(object sender, EventArgs e)
        {
            dgvNhaCC.DataSource = dtbase.DataReader("select * from tNhaCungCap");
            txtMaNhaCC.Enabled = false;
            dgvNhaCC.BackgroundColor = Color.DodgerBlue;
            dgvNhaCC.Columns[0].HeaderText = "Mã Nhà Cung Cấp";
            dgvNhaCC.Columns[1].HeaderText = "Tên Nhà Cung Cấp";
            dgvNhaCC.Columns[2].HeaderText = "Địa Chỉ";
            dgvNhaCC.Columns[3].HeaderText = "Số Điện thoại";
            dgvNhaCC.Columns[0].Width = 200;
            dgvNhaCC.Columns[1].Width = 200;
            dgvNhaCC.Columns[2].Width = 200;
            dgvNhaCC.Columns[3].Width = 200;
        }

        private void dgvNhaCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaNhaCC.Text = dgvNhaCC.CurrentRow.Cells[0].Value.ToString();
                txtTenNhaCC.Text = dgvNhaCC.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dgvNhaCC.CurrentRow.Cells[2].Value.ToString();
                txtDienThoai.Text = dgvNhaCC.CurrentRow.Cells[3].Value.ToString();
                
            }
            catch
            { }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNhaCC.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNhaCC.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDienThoai.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dtbase.updatedata("update tNhaCungCap set TenNCC = N'" + txtTenNhaCC.Text + "' ,DiaChi = N'" + txtDiaChi.Text + "', SĐT = '" + txtDienThoai.Text + "' where MaNCC = '" + txtMaNhaCC.Text + "'");
            dgvNhaCC.DataSource = dtbase.DataReader("select * from tNhaCungCap");
            MessageBox.Show("Bạn đã sửa thành công");
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            resetvalue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNhaCC.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sqlInsert, maNCC;
            DataTable dtNhaCC;
            // Kiểm tra nhập dữ liệu
            if (txtMaNhaCC.Text.Trim() == "" || txtTenNhaCC.Text.Trim() == "" || txtDienThoai.Text.Trim() == "" || txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu");
                return;
            }
            // Kiểm tra trường hợp trùng mã
            maNCC = txtMaNhaCC.Text;
            dtNhaCC = dtbase.DataReader("select * from tNhaCungCap where MaNCC = '" + maNCC + "'");
            if (dtNhaCC.Rows.Count > 0)
            {
                MessageBox.Show("Mã nhà cung cấp này đã tồn tại");
                txtMaNhaCC.Focus();
                resetvalue();
                return;
            }
            sqlInsert = "insert into tNhaCungCap values ('" + maNCC + "',N'" + txtTenNhaCC.Text + "',N'" + txtDiaChi.Text + "',N'" + txtDienThoai.Text + "')";
            dtbase.updatedata(sqlInsert);
            // Hiển thị Dữ liệu trên datagridview
            dgvNhaCC.DataSource = dtbase.DataReader("select * from tNhaCungCap");
            //
            resetvalue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNhaCC.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNhaCC.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa nhà cung cấp có mã " + txtMaNhaCC.Text + "Không ?",
                "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtbase.updatedata("delete tNhaCungCap where MaNCC = '" + txtMaNhaCC.Text + "'");
                dgvNhaCC.DataSource = dtbase.DataReader("select * from tNhaCungCap");
                resetvalue();
            }
        }
    }
}
