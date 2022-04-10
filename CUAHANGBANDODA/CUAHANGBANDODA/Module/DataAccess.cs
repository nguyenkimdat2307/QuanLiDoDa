using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CUAHANGBANDODA.Module
{
    class DataAccess
    {
        //B1 Khai bao cuoi ket noi
        string conectionStr = "Data Source=DESKTOP-8UM34TA\\SQLEXPRESS;Initial Catalog=QLBanDoDa4;Integrated Security=True";
        //B2 Mở kết nối
        
        public static SqlConnection sqlconn ;
        void Openconect()
        {
            sqlconn = new SqlConnection(conectionStr);
            if (sqlconn.State != ConnectionState.Open)
                sqlconn.Open();
        }

        void Closeconect()
        {
            if (sqlconn.State != ConnectionState.Closed)
            {
                sqlconn.Close();
                sqlconn.Dispose();
                sqlconn = null;
            }

        }

        public void updatedata(string sql)
        {
            Openconect();

            SqlCommand sqlcomd = new SqlCommand();
            sqlcomd.Connection = sqlconn;
            sqlcomd.CommandText = sql;
            sqlcomd.ExecuteNonQuery();
            Closeconect();
            sqlcomd.Dispose();
        }
        //thuc hien cau select va tra ve mot datatble
        public DataTable DataReader(string sqlselect)
        {
            DataTable dtTable = new DataTable();
            Openconect();
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlselect, sqlconn);
            sqlData.Fill(dtTable);
            Closeconect();
            sqlData.Dispose();
            return dtTable;
        }
            
        public  string laygiatri(string sql)
        {
            sqlconn = new SqlConnection(conectionStr);
            sqlconn.Open();
            string ma = "";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlconn;
            cmd.CommandText = sql;
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            sqlconn.Close();
            return ma;
        }
        public  string TaoMa(string tiento)
        {

            sqlconn = new SqlConnection(conectionStr);
            sqlconn.Open();
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            //Xóa ký tự trắng và PM hoặc AM
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("_{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            sqlconn.Close();
            return key;
        }
        public  string ConvertTimeTo24(string hour)
        {

            sqlconn = new SqlConnection(conectionStr);
            sqlconn.Open();
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            sqlconn.Close();
            return h;
        }
        public  bool ktra(string sql)
        {

            sqlconn = new SqlConnection(conectionStr);
            sqlconn.Open();
            SqlDataAdapter dap = new SqlDataAdapter(sql, sqlconn);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
            sqlconn.Close();
        }
        public  void Chaysql(string sql)
        {

            sqlconn = new SqlConnection(conectionStr);
            sqlconn.Open();
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = sqlconn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
            sqlconn.Close();

        }
       
        public  DataTable LayData(string sql)
        {

            sqlconn = new SqlConnection(conectionStr);
            sqlconn.Open();
            SqlDataAdapter dap = new SqlDataAdapter();
            dap.SelectCommand = new SqlCommand();
            dap.SelectCommand.Connection = DataAccess.sqlconn;
            dap.SelectCommand.CommandText = sql;
            DataTable table = new DataTable();
            dap.Fill(table);
            sqlconn.Close();
            return table;
        }
        


    }
}
