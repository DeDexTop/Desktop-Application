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
    public partial class Form_Kelola_Obat : Form
    {
        Function func = new Function();
        string id;
        public Form_Kelola_Obat()
        {
            InitializeComponent();
        }
        new void Show()
        {
            dgv_Obat.DataSource = func.ShowData("SELECT * FROM Tbl_Obat");
        }
        void Clear()
        {
            txtCari.Text = "";
            txtHarga.Text = "";
            txtJumlah.Text = "";
            txtKodeObat.Text = "";
            txtNamaObat.Text = "";
            dtp_Waktu.Text = "01/01/2022";
        }
        private void Form_Kelola_Obat_Load(object sender, EventArgs e)
        {
            Show();
        }
        private void dgv_Obat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgv_Obat.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKodeObat.Text = dgv_Obat.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtNamaObat.Text = dgv_Obat.Rows[e.RowIndex].Cells[2].Value.ToString();
            dtp_Waktu.Text = dgv_Obat.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtJumlah.Text = dgv_Obat.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtHarga.Text = dgv_Obat.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if(txtKodeObat.Text == "" || txtNamaObat.Text == "" || txtJumlah.Text == "" || txtHarga.Text == "")
            {
                MessageBox.Show("Semua kolom data harus di isi");
            }
            else
            {
                func.Command("INSERT INTO Tbl_Obat ([Kode_Obat], [Nama_Obat], [Expired_Date], [Jumlah], [Harga]) VALUES ('" + txtKodeObat.Text + "', '" + txtNamaObat.Text + "', '" + dtp_Waktu.Text + "', '" + txtJumlah.Text + "', '" + txtHarga.Text + "')");

                Clear();
                Show();

                MessageBox.Show("Data berhasil ditambahkan");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtKodeObat.Text == "" || txtNamaObat.Text == "" || txtJumlah.Text == "" || txtHarga.Text == "")
            {
                MessageBox.Show("Semua kolom data harus di isi");
            }
            else
            {
                func.Command("UPDATE Tbl_Obat SET Kode_Obat = '" + txtKodeObat.Text + "', Nama_Obat = '" + txtNamaObat.Text + "', Expired_Date = '" + dtp_Waktu.Text + "', Jumlah = '" + txtJumlah.Text + "', Harga = '" + txtHarga.Text + "' WHERE Id_Obat = '" + id + "'");

                Clear();
                Show();

                MessageBox.Show("Data berhasil Diubah");
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            func.Command("DELETE FROM Tbl_Obat WHERE Id_Obat = '" + id + "'");

            Clear();
            Show();

            MessageBox.Show("Data berhasil Dihapus");
        }

        private void txtJumlah_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Hanya Bisa menginputkan angka!");
            }
        }

        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Hanya Bisa menginputkan angka!");
            }
        }

        private void btnKelolaUser_Click(object sender, EventArgs e)
        {
            new Form_Kelola_User().Show();
            this.Close();
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            new Form_Laporan().Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new Form_Login().Show();
            this.Close();
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
           dgv_Obat.DataSource = func.ShowData("SELECT * FROM Tbl_Obat WHERE Nama_Obat LIKE '" + txtCari.Text + "%'");
        }
    }
}
