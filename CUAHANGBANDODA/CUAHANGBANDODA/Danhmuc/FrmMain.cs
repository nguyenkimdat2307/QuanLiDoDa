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
    public partial class FrmMain : Form
    {
        
      
        int PanelWith;
        bool isCollapsed;
        public FrmMain()
        {
            InitializeComponent();
            timerTime.Start();
            PanelWith = paneleft.Width;
            isCollapsed = false;
        }
        
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNguon_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Ban co muon thoat khong?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                Application.Exit();
            }
        }

        private void timerPaneleft_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                
                paneleft.Width = paneleft.Width + 10;
                if (paneleft.Width >= PanelWith)
                {
                    timerPaneleft.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                paneleft.Width = paneleft.Width - 10;
                if (paneleft.Width <= 64)
                {
                    timerPaneleft.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            timerPaneleft.Start();
        }
        private void moveSidePanel(Control btn)
        {
            paneSidle.Top = btn.Top;
            paneSidle.Height = btn.Height;
        }

       
        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt =  DateTime.Now;
            lblTime.Text = dt.ToString("HH:MM:ss");
        }

        private void paneleft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnNhanVien);
            FrmDMNhanVien nv = new FrmDMNhanVien();
            nv.Show();
            this.Hide();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnKhachHang);
            FrmDMKhachHang KH = new FrmDMKhachHang();
            KH.Show();
            this.Hide();
            
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnNhaCungCap);
            FrmNhaCungCap NCC = new FrmNhaCungCap();
            NCC.Show();
            this.Hide();
            
        }

        private void btnHoaDonNhap_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHoaDonNhap);
            FrmHoaDonNhap HDN = new FrmHoaDonNhap();
            HDN.Show();
            this.Hide();
          
        }

        private void btnHoaDonBan_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHoaDonBan);
            FrmHoaDonBan HDB = new FrmHoaDonBan();
            HDB.Show();
            this.Hide();
           
        }

        private void btnTimKiemHD_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnTimKiemHD);
            FrmTimKiemHoaDon TKHD = new FrmTimKiemHoaDon();
            TKHD.Show();
            this.Hide();
            
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnBaoCao);
            BaocaoTK baocao = new BaocaoTK();
            baocao.Show();
            this.Hide();
        }

        private void btnChatLieu_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnChatLieu);
            FrmDMChatLieu CL = new FrmDMChatLieu();
            CL.Show();
            this.Hide();
           
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSanPham);
            FrmDMSanPham SP = new FrmDMSanPham();
            SP.Show();
            this.Hide();
            
        }

        private static string username;
        public  string Username
        {
            get { return username; }
            set { username = value; }
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
          
            lblXinChao.Text = "Xin chào : " + username;
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }
    }
}
