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
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-8UM34TA\\SQLEXPRESS;Initial Catalog=QLBanDoDa4;Integrated Security=True");
        public Login()
        {
            InitializeComponent();
        }

        private void btnNguon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co muon thoat khong?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string hashPass = HashPass(txtPassWord.Text);
                if (txtUserName.Text == "" || txtPassWord.Text == "")
                {
                    MessageBox.Show("Làm ơn hãy nhập tên đăng nhập và mật khẩu:");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("select * from  tLogin where TenDangNhap=@Name and MatKhau=@Pass",con);
                    cmd.Parameters.Add("@Name", txtUserName.Text);
                    cmd.Parameters.Add("@Pass", hashPass);
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);

                    int count = ds.Tables[0].Rows.Count;
                    if (count == 1)
                    {
                        MessageBox.Show("Bạn đã nhập đúng!!! ");
                        FrmMain frm = new FrmMain();
                        frm.Username = txtUserName.Text;
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Làm ơn hãy kiểm tra lại tên đăng nhập hoặc mật khẩu");
                    }
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            try
            {
                string hashPass = HashPass(txtPassWord.Text);
                if (txtUserName.Text == "" || txtPassWord.Text == "")
                {
                    MessageBox.Show("Hãy nhập tên đăng nhập và mật khẩu để thay đổi mật khẩu:");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("select * from  tLogin where TenDangNhap=@Name and MatKhau=@Pass", con);
                    cmd.Parameters.Add("@Name", txtUserName.Text);
                    cmd.Parameters.Add("@Pass", hashPass);
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);

                    int count = ds.Tables[0].Rows.Count;
                    if(count == 1)
                    {
                        MessageBox.Show("Đã duyệt!!");
                        FrmQuenMK qmk = new FrmQuenMK();
                        qmk.Username = txtUserName.Text;
                        qmk.Password = txtPassWord.Text;
                        qmk.Show();
                    }    
                    else
                    {
                        MessageBox.Show("Làm ơn hãy kiểm tra lại tên đăng nhập hoặc mật khẩu");
                    }    
                    
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkHienPass_CheckedChanged(object sender, EventArgs e)
        {
            if(chkHienPass.Checked)
            {
                txtPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassWord.UseSystemPasswordChar = true;
            }
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            FrmDangKi dk = new FrmDangKi();
            dk.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
