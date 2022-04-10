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
    public partial class FrmDMKhachHang : Form
    {
        Module.DataAccess dtBase = new Module.DataAccess();

        public FrmDMKhachHang()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            main.Show();
            this.Hide();
        }

        private void ResetValues()
        {
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtMaKhach.Text = "";
            txtTenKhach.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaKhach.Enabled = true;
            txtMaKhach.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKhach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhach.Focus();
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
          
            dtBase.updatedata("update tKhachHang set TenKH = N'" + txtTenKhach.Text + "',DiaChi = N'" + txtDiaChi.Text + "',SDT=N'" + txtDienThoai.Text + "'where MaKH= N'" + txtMaKhach.Text + "'");
            dgvKhachHang.DataSource = dtBase.DataReader("select * from tKhachHang");
            MessageBox.Show("Bạn đã sửa thành công");
        }

        private void FrmDMKhachHang_Load(object sender, EventArgs e)
        {
            txtMaKhach.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            dgvKhachHang.DataSource = dtBase.DataReader("select * from tKhachHang");
            dgvKhachHang.BackgroundColor = Color.DodgerBlue;
            dgvKhachHang.Columns[0].HeaderText = "Mã khách hàng";
            dgvKhachHang.Columns[1].HeaderText = "Tên khách hàng";
            dgvKhachHang.Columns[2].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Số điện thoại ";
           
            dgvKhachHang.Columns[0].Width = 100;
            dgvKhachHang.Columns[1].Width = 150;
            dgvKhachHang.Columns[2].Width = 100;
            dgvKhachHang.Columns[3].Width = 150;
            
            
        }
       
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaKhach.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
                txtTenKhach.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
                txtDienThoai.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
              
            }
            catch
            {

            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sqlInsert, maKh;
            DataTable dtKhach;
            // Kiểm tra nhập dữ liệu
            if (txtMaKhach.Text.Trim() == "" || txtTenKhach.Text.Trim() == "" || txtDiaChi.Text.Trim() == "" || txtDienThoai.Text.Trim() == "")
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu");
                return;
            }
            // Kiểm tra trường hợp trùng mã
            maKh = txtMaKhach.Text;
            dtKhach = dtBase.DataReader("select * from tKhachHang where MaKH = '" + maKh + "'");
            if (dtKhach.Rows.Count > 0)
            {
                MessageBox.Show("Mã khách này đã tồn tại");
                txtMaKhach.Focus();
                txtMaKhach.Text = "";
                return;
            }
            sqlInsert = "insert into tKhachHang values ('"+ maKh +"',N'" + txtTenKhach.Text + "',N'" + txtDiaChi.Text + "','" + txtDienThoai.Text + "')";
            dtBase.updatedata(sqlInsert);
            // Hiển thị Dữ liệu trên datagridview
            dgvKhachHang.DataSource = dtBase.DataReader("select * from tKhachHang");
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaKhach.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa mã khách hàng có mã " + txtMaKhach.Text + "Không ?",
               "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtBase.updatedata("delete tKhachHang where MaKH = '" + txtMaKhach.Text + "'");
                dgvKhachHang.DataSource = dtBase.DataReader("select * from tKhachHang");
                ResetValues();
            }
        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            
        }
    }
}
