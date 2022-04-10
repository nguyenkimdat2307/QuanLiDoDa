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
    public partial class FrmDangKi : Form
    {
        Module.DataAccess dtbase = new Module.DataAccess();
        public FrmDangKi()
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
        private void FrmDangKi_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            int nb = rand.Next(1, 500);
            FrmDangKi p = new FrmDangKi();
            string s1 = p.RandomString(5, false);
            txtMaXacNhan.Text = s1 + nb.ToString();
            //

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
        private void btnDK_Click(object sender, EventArgs e)
        {
            string hassPass = HashPass(txtPassWord.Text);
            string sqlInsert, tendn;
            DataTable dtLogin;
            // Kiểm tra nhập dữ liệu
            if (txtUserName.Text.Trim() == "" || txtPassWord.Text.Trim() == "" || txtXacNhan.Text.Trim() == "")
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu");
                return;
            }
            if (txtXacNhan.Text.Trim() != txtMaXacNhan.Text.Trim())
            {
                MessageBox.Show("Làm ơn kiểm tra lại mã xác nhận");
            }
            // Kiểm tra trường hợp trùng mã
            tendn = txtUserName.Text;
            dtLogin = dtbase.DataReader("select * from tLogin where TenDangNhap = '" + tendn + "'");
            if (dtLogin.Rows.Count > 0)
            {
                MessageBox.Show("Tên đăng nhập này đã tồn tại này đã tồn tại");
                txtUserName.Focus();
                txtUserName.Text = "";
                txtPassWord.Text = "";
                txtXacNhan.Text = "";

            }
            sqlInsert = "insert into tLogin values ('" + tendn + "',N'" + hassPass + "')";
            dtbase.updatedata(sqlInsert);
            MessageBox.Show("Bạn đã đăng kí thành công");
            txtUserName.Text = "";
            txtPassWord.Text = "";
            txtXacNhan.Text = "";
            txtUserName.Focus();


            Random rand = new Random();
            int nb = rand.Next(1, 500);
            FrmDangKi p = new FrmDangKi();
            string s1 = p.RandomString(5, false);
            txtMaXacNhan.Text = s1 + nb.ToString();
        }

        private void btnNguon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co muon thoat khong?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void chkHienPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienPass.Checked)
            {
                txtPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassWord.UseSystemPasswordChar = true;
            }
        }
    }
}
