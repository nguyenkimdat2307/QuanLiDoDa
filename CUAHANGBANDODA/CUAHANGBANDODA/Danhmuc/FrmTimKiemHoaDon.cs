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

namespace CUAHANGBANDODA.Danhmuc
{
   
   
    public partial class FrmTimKiemHoaDon : Form
    {
        Module.DataAccess dtBase = new Module.DataAccess();
        DataTable tblHDB;
        public FrmTimKiemHoaDon()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            main.Show();
            this.Hide();
        }

        private void FrmTimKiemHoaDon_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgvTKHoaDon.DataSource = null;
        }
        private void ResetValues()
        {
            txtMaNhanVien.Text = "";
            txtNgayBan.Text = "";
            txtTongTien.Text = "";
            txtMaKhach.Text = "";
            txtMaHDBan.Text = "";
            txtMaHDBan.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaHDBan.Text == "") && (txtNgayBan.Text == "")  &&
               (txtMaNhanVien.Text == "") && (txtMaKhach.Text == "") &&
               (txtTongTien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tHoaDonBan WHERE 1=1";
            if (txtMaHDBan.Text != "")
                sql = sql + " AND MaHDB Like N'%" + txtMaHDBan.Text + "%'";
            if (txtNgayBan.Text != "")
                sql = sql + " AND YYYY(NgayBan) =" + txtNgayBan.Text;
            
            if (txtMaNhanVien.Text != "")
                sql = sql + " AND MaNVV Like N'%" + txtMaNhanVien.Text + "%'";
            if (txtMaKhach.Text != "")
                sql = sql + " AND MaKH Like N'%" + txtMaKhach.Text + "%'";
            if (txtTongTien.Text != "")
                sql = sql + " AND Tongtien <=" + txtTongTien.Text;
            tblHDB = dtBase.LayData(sql);
            if (tblHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTKHoaDon.DataSource = tblHDB;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            dgvTKHoaDon.Columns[0].HeaderText = "Mã HĐB";
            dgvTKHoaDon.Columns[1].HeaderText = "Ngày Bán";
            dgvTKHoaDon.Columns[2].HeaderText = "Mã nhân viên";
            dgvTKHoaDon.Columns[3].HeaderText = "Mã khách";
            dgvTKHoaDon.Columns[4].HeaderText = "Tổng tiền";
            dgvTKHoaDon.Columns[0].Width = 150;
            dgvTKHoaDon.Columns[1].Width = 100;
            dgvTKHoaDon.Columns[2].Width = 80;
            dgvTKHoaDon.Columns[3].Width = 80;
            dgvTKHoaDon.Columns[4].Width = 80;
            dgvTKHoaDon.AllowUserToAddRows = false;
            
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvTKHoaDon.DataSource = null;
        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dgvTKHoaDon_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void dgvTKHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaHDBan.Text = dgvTKHoaDon.CurrentRow.Cells[0].Value.ToString();
                txtMaHDBan.Enabled = false;
                txtNgayBan.Text = dgvTKHoaDon.CurrentRow.Cells[1].Value.ToString();
                txtMaNhanVien.Text = dgvTKHoaDon.CurrentRow.Cells[2].Value.ToString();
                txtMaKhach.Text = dgvTKHoaDon.CurrentRow.Cells[3].Value.ToString();
                txtTongTien.Text = dgvTKHoaDon.CurrentRow.Cells[4].Value.ToString();
            }
            catch { }
        }
    }
}
