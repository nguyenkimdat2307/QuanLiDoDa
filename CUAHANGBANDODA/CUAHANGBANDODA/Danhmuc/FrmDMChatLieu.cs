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
   
    public partial class FrmDMChatLieu : Form
    {
        Module.DataAccess dtBase = new Module.DataAccess();
        public FrmDMChatLieu()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            main.Show();
            this.Hide();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtMaChatLieu.Enabled = true; //cho phép nhập mới
            txtMaChatLieu.Focus();
        }

        private void ResetValue()
        {
            txtMaChatLieu.Text = "";
            txtTenChatLieu.Text = "";
        }
        private void FrmDMChatLieu_Load(object sender, EventArgs e)
        {
            txtMaChatLieu.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            dgvChatLieu.DataSource = dtBase.DataReader("select * from tChatLieu");
            dgvChatLieu.BackgroundColor = Color.DodgerBlue;
            dgvChatLieu.Columns[0].HeaderText = "Mã Chất Liệu";
            dgvChatLieu.Columns[1].HeaderText = "Tên Chất Liệu";
        }

       
        private void dgvChatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaChatLieu.Text = dgvChatLieu.CurrentRow.Cells[0].Value.ToString();

                txtTenChatLieu.Text = dgvChatLieu.CurrentRow.Cells[1].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đã chắc chắn sửa đúng ?",
               "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtBase.updatedata("update tChatLieu set TenCL = N'" + txtTenChatLieu.Text + "' where MaCL = '" + txtMaChatLieu.Text + "'");
                dgvChatLieu.DataSource = dtBase.DataReader("select * from tChatLieu");
                MessageBox.Show("Bạn đã sửa thành công");
            }    
               
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sqlInsert, maCL;
            DataTable dtChatLieu;
            // Kiểm tra nhập dữ liệu
            if (txtMaChatLieu.Text.Trim() == "" || txtTenChatLieu.Text.Trim() == "")
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu");
                return;
            }
            // Kiểm tra trường hợp trùng mã
            maCL = txtMaChatLieu.Text;
            dtChatLieu = dtBase.DataReader("select * from tChatLieu where MaCL = '" + maCL + "'");
            if (dtChatLieu.Rows.Count > 0)
            {
                MessageBox.Show("Mã chất liệu này đã tồn tại");
                txtMaChatLieu.Focus();
                txtMaChatLieu.Text = "";
                return;
            }
            sqlInsert = "insert into tChatLieu values ('" + maCL + "',N'" + txtTenChatLieu.Text + "')";
            dtBase.updatedata(sqlInsert);
            // Hiển thị Dữ liệu trên datagridview
            dgvChatLieu.DataSource = dtBase.DataReader("select * from tChatLieu");
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaChatLieu.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa chất liệu có mã " + txtMaChatLieu.Text + "Không ?",
               "Lựa chọn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dtBase.updatedata("delete tChatLieu where MaCL = '" + txtMaChatLieu.Text + "'");
                dgvChatLieu.DataSource = dtBase.DataReader("select * from tChatLieu");
                txtMaChatLieu.Text = "";
                txtTenChatLieu.Text = "";
            }    
               
        }

        private void dgvChatLieu_Click(object sender, EventArgs e)
        {
            
        }

        private void txtMaChatLieu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
