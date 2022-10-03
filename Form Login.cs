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
    public partial class Form_Login : Form
    {
        public static string url = @"Data Source=localhost;Initial Catalog=db_Apotek;Integrated Security=True";
        SqlConnection con = new SqlConnection(url);
        Function func = new Function();
        string id;
        public Form_Login()
        {
            InitializeComponent();
        }
        void Login()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Id_User, Nama_User, Tipe_User FROM Tbl_User WHERE Username = '" + txtUsername.Text + "' AND Password = '" + txtPassword.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    id = dr["Id_User"].ToString();
                    ClassPegawai.NamaPegawai = dr["Nama_User"].ToString();
                    ClassPegawai.IdPegawai = dr["Id_User"].ToString();
                    func.Command("INSERT INTO Tbl_Log ([Waktu], [Aktifitas], [Id_User]) VALUES (getDate(), 'Login', '" + id + "')");

                    if (dr["Tipe_User"].ToString() == "Admin")
                    {
                        new Form_Admin().Show();
                        this.Hide();
                    }
                    else if (dr["Tipe_User"].ToString() == "Apoteker")
                    {
                        new Form_Kelola_Resep().Show();
                        this.Hide();
                    }
                    else if (dr["Tipe_User"].ToString() == "Kasir")
                    {
                        new Form_Transaksi().Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("Maaf Data Tidak Valid");
            }
            con.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Kolom Username dan Password Harus Di isi!");
            }
            else
            {
                Login();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
    }
}
