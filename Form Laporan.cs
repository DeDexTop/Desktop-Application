using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lks_Desktop_2022
{
    public partial class Form_Laporan : Form
    {
        public static string url = @"Data Source=localhost;Initial Catalog=db_Apotek;Integrated Security=True";
        SqlConnection con = new SqlConnection(url);
        Function func = new Function();
        public Form_Laporan()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Refresh();
            chart1.Series[0].Points.Clear();
            dgv_Laporan.DataSource = func.ShowData("SELECT Tgl_Transaksi, Total_Bayar FROM Tbl_Transaksi WHERE Tgl_Transaksi BETWEEN '" + dtp_Waktu1.Text + "' AND '" + dtp_Waktu2.Text + "'");
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Tgl_Transaksi, Total_Bayar FROM Tbl_Transaksi WHERE Tgl_Transaksi BETWEEN '" + dtp_Waktu1.Text + "' AND '" + dtp_Waktu2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                DataRowCollection col = func.GetData("SELECT Tgl_Transaksi, Total_Bayar FROM Tbl_Transaksi WHERE Tgl_Transaksi BETWEEN '" + dtp_Waktu1.Text + "' AND '" + dtp_Waktu2.Text + "'");
                foreach (DataRow dr in col)
                {
                    chart1.Series[0].Points.AddXY(dr["Tgl_Transaksi"].ToString(), dr["Total_Bayar"]);
                }
            }
            else
            {
                MessageBox.Show("Tidak ada data untuk ditampilkan");
            }
        }

        private void btnKelolaUser_Click(object sender, EventArgs e)
        {
            new Form_Kelola_User().Show();
            this.Close();
        }

        private void btnKelolaObat_Click(object sender, EventArgs e)
        {
            new Form_Kelola_Obat().Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new Form_Login().Show();
            this.Close();
        }
    }
}
