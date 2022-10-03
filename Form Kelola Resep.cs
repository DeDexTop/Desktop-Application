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
    public partial class Form_Kelola_Resep : Form
    {
        Function func = new Function();
        string id, id_obat;
        public Form_Kelola_Resep()
        {
            InitializeComponent();
        }

        new void Show()
        {
            dgv_Resep.DataSource = func.ShowData("SELECT * FROM Tbl_Resep");
            btnEdit.Visible = false;
            btnHapus.Visible = false;
            btnTambah.Visible = true;
            dgv_Resep.Columns[7].Visible = false;
        }

        void Clear()
        {
            txtNoResep.Text = "";
            dtp_Waktu.Text = "01/01/2022";
            txtNamaPasien.Text = "";
            txtNamaDokter.Text = "";
            cbx_NamaObat.Text = "";
            txtJumlah.Text = "";
            txtCari.Text = "";
        }

        private void Form_Kelola_Resep_Load(object sender, EventArgs e)
        {
            Show();
            DataRowCollection row = func.GetData("SELECT Id_Obat, Nama_Obat FROM Tbl_Obat");
            foreach(DataRow dt in row)
            {
                cbx_NamaObat.Items.Add(dt["Nama_Obat"].ToString());
                id_obat = dt["Id_Obat"].ToString();
            }
        }
        private void txtJumlah_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Hanya Bisa menginputkan angka!");
            }
        }

        private void dgv_Resep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgv_Resep.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNoResep.Text = dgv_Resep.Rows[e.RowIndex].Cells[1].Value.ToString();
            dtp_Waktu.Text = dgv_Resep.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtNamaPasien.Text = dgv_Resep.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtNamaDokter.Text = dgv_Resep.Rows[e.RowIndex].Cells[4].Value.ToString();
            cbx_NamaObat.Text = dgv_Resep.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtJumlah.Text = dgv_Resep.Rows[e.RowIndex].Cells[6].Value.ToString();

            btnEdit.Visible = true;
            btnHapus.Visible = true;
            btnTambah.Visible = false;
        }
        private void btnTambah_Click(object sender, EventArgs e)
        {
            if(txtNoResep.Text == "" || txtNamaPasien.Text == "" || txtNamaDokter.Text == "" || cbx_NamaObat.Text == "" || txtJumlah.Text == "")
            {
                MessageBox.Show("Semua kolom data harus di isi!");
            }
            else
            {
                func.Command("INSERT INTO Tbl_Resep ([No_Resep], [Tgl_Resep], [Nama_Pasien], [Nama_Dokter] ,[Nama_ObatDibeli], [Jumlah_ObatDibeli], [Id_Obat]) VALUES ('" + txtNoResep.Text + "', '" + dtp_Waktu.Text + "', '" + txtNamaPasien.Text + "', '" + txtNamaDokter.Text + "', '" + cbx_NamaObat.Text + "', '" + txtJumlah.Text + "', '" + id_obat + "')");

                Clear();
                Show();

                MessageBox.Show("Data Berhasil ditambahkan");

                btnEdit.Visible = false;
                btnHapus.Visible = false;
                btnTambah.Visible = true;
            } 
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtNoResep.Text == "" || txtNamaPasien.Text == "" || txtNamaDokter.Text == "" || cbx_NamaObat.Text == "" || txtJumlah.Text == "")
            {
                MessageBox.Show("Semua kolom data harus di isi!");
            }
            else
            {
                func.Command("UPDATE Tbl_Resep SET No_Resep = '" + txtNoResep.Text + "', Tgl_Resep = '" + dtp_Waktu.Text + "', Nama_Pasien = '" + txtNamaPasien.Text + "', Nama_Dokter = '" + txtNamaDokter.Text + "', Nama_ObatDibeli = '" + cbx_NamaObat.Text + "', Jumlah_ObatDibeli = '" + txtJumlah.Text + "' WHERE Id_Resep = '" + id + "'");

                Clear();
                Show();

                MessageBox.Show("Data berhasil diubah");

                btnEdit.Visible = false;
                btnHapus.Visible = false;
                btnTambah.Visible = true;
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            func.Command("DELETE FROM Tbl_Resep WHERE Id_Resep = '" + id + "'");
            Clear();
            Show();

            MessageBox.Show("Data berhasil dihapus");

            btnEdit.Visible = false;
            btnHapus.Visible = false;
            btnTambah.Visible = true;
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            dgv_Resep.DataSource = func.ShowData("SELECT * FROM Tbl_Resep WHERE Nama_Pasien LIKE '" + txtCari.Text + "%'");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new Form_Login().Show();
            this.Close();
        }

        
    }
}
