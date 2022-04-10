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
using System.Security.Cryptography;

namespace CUAHANGBANDODA.Danhmuc
{
    
    public partial class FrmQuenMK : Form
    {

        Module.DataAccess dtbase = new Module.DataAccess();

        public FrmQuenMK()
        {
            InitializeComponent();
        }
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder sb = new StringBuilder();
            char c;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(rand.Next(65, 87)));
                sb.Append(c);
            }
            if (lowerCase)
            {
                return sb.ToString().ToLower();
            }
            return sb.ToString();
        }
        private void FrmQuenMK_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            int nb = rand.Next(1, 500);
            FrmQuenMK p = new FrmQuenMK();
            string s1 = p.RandomString(5, false);
            txtMaXacNhan.Text = s1 + nb.ToString();
            txtTenDangNhap.Text = tendangnhap;
            txtTenDangNhap.Enabled = false;
            txtMatKhauCu.Text = matkhau;
            txtMatKhauCu.Enabled = false;
            txtMatKhauMoi.Focus();
        }
        private string tendangnhap,matkhau;
        public string Username
        {
            get { return tendangnhap; }
            set { tendangnhap= value; }
        }
        public string Password
        {
            get { return matkhau; }
            set { matkhau = value; }
        }

        internal string HashPass(string text)
        {
            MD5 md5 = MD5.Create();
            byte[] temp = Encoding.ASCII.GetBytes(text);
            byte[] hashData = md5.ComputeHash(temp);
            string hashPass = "";
            foreach (var item in hashData)
            {
                hashPass += item.ToString("x2");
            }
            return hashPass;
        }
        private void btnNguon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co muon thoat khong?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtMatKhauMoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            string hassPass = HashPass(txtMatKhauMoi.Text);
            if (txtTenDangNhap.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMatKhauCu.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập Mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMatKhauMoi.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtXacNhan.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập mã xác nhận", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtXacNhan.Text.Trim() != txtMaXacNhan.Text.Trim())
            {
                MessageBox.Show("Bạn nhập mã xác nhận sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenDangNhap.Text.Trim() != tendangnhap.Trim())
            {
                MessageBox.Show("Bạn nhập tên đăng nhập sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMatKhauCu.Text.Trim() != matkhau.Trim())
            {
                MessageBox.Show("Bạn nhập mật khẩu cũ sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMatKhauCu.Text.Trim() == matkhau.Trim() && txtTenDangNhap.Text.Trim() == tendangnhap.Trim() && txtXacNhan.Text.Trim() == txtMaXacNhan.Text.Trim())
            {
                dtbase.updatedata("update tLogin set MatKhau = '" + hassPass + "' where TenDangNhap = '" + txtTenDangNhap.Text + "' ");
                MessageBox.Show("Bạn đã đổi thành công!!");
                txtMatKhauMoi.Text = "";
                txtXacNhan.Text = "";
                txtMatKhauCu.Text = "";
                txtTenDangNhap.Text = "";

            }

        }
    }
}
