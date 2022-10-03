using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lks_Desktop_2022
{
    public partial class Form_Transaksi : Form
    {
        Function func = new Function();
        string Id_Resep, Id_Obat;
        int harga;
        public Form_Transaksi()
        {
            InitializeComponent();
            labelNama.Text = ClassPegawai.NamaPegawai;
            labelDate.Text = DateTime.Now.ToShortDateString();
            labelTime.Text = DateTime.Now.ToLongTimeString();
        }
        void Data()
        {
            DataRowCollection row = func.GetData("SELECT Id_Resep ,No_Resep FROM Tbl_Resep");
            foreach(DataRow dr in row)
            {
                cbxNoResep.Items.Add(dr["No_Resep"].ToString());
                Id_Resep = dr["Id_Resep"].ToString();
            }
            DataRowCollection col = func.GetData("SELECT Nama_Obat FROM Tbl_Obat");
            foreach(DataRow dr in col)
            {
                cbx_NamaObat.Items.Add(dr["Nama_Obat"]);
            }
            btnSave.Enabled = true;
        }
        void Label()
        {
            int total = 0;
            for(int i = 0; i < dgv_Kasir.Rows.Count; i++)
            {
                total += Convert.ToInt32(dgv_Kasir.Rows[i].Cells[8].Value);
                labelTotal.Text = total.ToString();
                harga = total;
            }
        }

        void Clear()
        { 
            txtNamaPasien.Text = "";
            txtNamaDokter.Text = "";
            txtHarga.Text = "";
            txtQuantity.Text = "";
            cbx_NamaObat.Text = "";
            cbxNoResep.Text = "";
            cbxTipeResep.Text = "";
            dtp_Waktu2.Text = "1/1/2020";
            txtBayar.Text = "";
        }

        private void cbxTipeResep_TextChanged(object sender, EventArgs e)
        {
            if(cbxTipeResep.Text == "Non Resep")
            {
                cbxNoResep.Enabled = false;
                cbxNoResep.Text = "-";
                dtp_Waktu2.Enabled = false;
                txtNamaPasien.Enabled = false;
                txtNamaPasien.Text = "-";
                txtNamaDokter.Enabled = false;
                txtNamaDokter.Text = "-";
                txtHarga.Enabled = false;
                txtQuantity.Text = "";
            }
            else if(cbxTipeResep.Text == "Resep")
            {
                cbxNoResep.Enabled = true;
                cbxNoResep.Text = "";
                dtp_Waktu2.Enabled = true;
                txtNamaPasien.Enabled = true;
                txtNamaPasien.Text = "";
                txtNamaDokter.Enabled = true;
                txtNamaDokter.Text = "";
                txtHarga.Enabled = true;
                txtQuantity.Text = "";
            }
        }

        private void cbxNoResep_TextChanged(object sender, EventArgs e)
        {
            DataRowCollection col = func.GetData("SELECT Tbl_Resep.No_Resep, Tbl_Resep.Tgl_Resep, Tbl_Resep.Nama_Dokter, Tbl_Resep.Nama_Pasien, Tbl_Obat.Nama_Obat, Tbl_Obat.Harga, Tbl_Resep.Jumlah_ObatDibeli FROM Tbl_Resep JOIN Tbl_Obat ON Tbl_Resep.Id_Obat = Tbl_Obat.Id_Obat WHERE No_Resep = '" + cbxNoResep.Text + "'");
            foreach (DataRow dr in col)
            {
                dtp_Waktu2.Text = dr["Tgl_Resep"].ToString();
                txtNamaPasien.Text = dr["Nama_Pasien"].ToString();
                txtNamaDokter.Text = dr["Nama_Dokter"].ToString();
                cbx_NamaObat.Text = dr["Nama_Obat"].ToString();
                txtHarga.Text = dr["Harga"].ToString();
                txtQuantity.Text = dr["Jumlah_ObatDIbeli"].ToString();
            }
        }

        private void cbx_NamaObat_TextChanged(object sender, EventArgs e)
        {
            DataRowCollection col = func.GetData("SELECT Id_Obat, Harga FROM Tbl_Obat WHERE Nama_Obat = '" + cbx_NamaObat.Text + "'");
            foreach (DataRow dr in col)
            {
                Id_Obat = dr["Id_Obat"].ToString();
                txtHarga.Text = dr["Harga"].ToString();
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Hanya bisa menginputkan angka");
            }
        }

        private void Form_Transaksi_Load(object sender, EventArgs e)
        {
            Data();
        }

        private void btnTambahkan_Click(object sender, EventArgs e)
        {
            if (cbxTipeResep.Text == "Resep")
            {
                dgv_Kasir.Rows.Add(cbxTipeResep.Text, cbxNoResep.Text, dtp_Waktu2.Text, txtNamaPasien.Text, txtNamaDokter.Text, cbx_NamaObat.Text, txtHarga.Text, txtQuantity.Text, Convert.ToInt32(txtHarga.Text) * Convert.ToInt32(txtQuantity.Text));
            }
            else if (cbxTipeResep.Text == "Non Resep")
            {
                dgv_Kasir.Rows.Add(cbxTipeResep.Text, cbxNoResep.Text, "-", txtNamaPasien.Text, txtNamaDokter.Text, cbx_NamaObat.Text, txtHarga.Text, txtQuantity.Text, Convert.ToInt32(txtHarga.Text) * Convert.ToInt32(txtQuantity.Text));
            }
            Label();
            Clear();
        }

        private void btnKosongkan_Click(object sender, EventArgs e)
        {
            dgv_Kasir.Rows.Clear();
            Label();
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtBayar.Text) < harga)
            {
                MessageBox.Show("Uang yang di masukan kurang!");
            }
            else
            {
                MessageBox.Show("Transaksi berhasil");

                int kembalian = Convert.ToInt32(txtBayar.Text) - harga;
                labelKembalian.Text = kembalian.ToString();

                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cbxTipeResep.Text == "Resep")
            {
                for (int i = 0; i < dgv_Kasir.Rows.Count - 1; i++)
                {
                    func.Command("INSERT INTO Tbl_Transaksi ([No_Transaksi], [Tgl_Transaksi], [Total_Bayar], [Id_User], [Id_Obat]) VALUES ('" + dtp_Waktu.Text + "', getDate(), '" + Convert.ToInt32(labelTotal.Text) + "', '" + ClassPegawai.IdPegawai + "', '" + Id_Obat + "')");
                }
                
            }
            else if(cbxTipeResep.Text == "Non Resep")
            {
                for (int i = 0; i < dgv_Kasir.Rows.Count - 1; i++)
                {
                    func.Command("INSERT INTO Tbl_Transaksi ([No_Transaksi], [Tgl_Transaksi], [Total_Bayar], [Id_User], [Id_Obat]) VALUES ('" + dtp_Waktu.Text + "', getDate(), '" + Convert.ToInt32(labelTotal.Text) + "', '" + ClassPegawai.IdPegawai + "', '" + Id_Obat + "')");
                }
            }
            dgv_Kasir.Rows.Clear();
            Label();

            MessageBox.Show("Data Tersimpan");
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            new Form_Login().Show();
            this.Hide();
        }
    }
}
