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
    public partial class Form_Kelola_User : Form
    {
        Function func = new Function();
        string id;
        public Form_Kelola_User()
        {
            InitializeComponent();
        }
        new void Show()
        {
            dgv_User.DataSource = func.ShowData("SELECT * FROM Tbl_User");
        }
        void Clear()
        {
            txtAlamat.Text = "";
            txtCari.Text = "";
            txtNama.Text = "";
            txtPasword.Text = "";
            txtTelepon.Text = "";
            txtUsername.Text = "";
            cbxTipeUser.Text = "";
            txtCari.Text = "";
        }

        private void Form_Kelola_User_Load(object sender, EventArgs e)
        {
            Show();
        }

        private void dgv_User_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dgv_User.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbxTipeUser.Text = dgv_User.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtNama.Text = dgv_User.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtAlamat.Text = dgv_User.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtTelepon.Text = dgv_User.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtUsername.Text = dgv_User.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtPasword.Text = dgv_User.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void txtTelepon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Hanya Bisa menginputkan angka!");
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if(cbxTipeUser.Text == "" || txtNama.Text == "" || txtTelepon.Text == "" || txtAlamat.Text == "" || txtUsername.Text == "" || txtPasword.Text == "")
            {
                MessageBox.Show("Semua kolom data harus di isi!");
            }
            else
            {
                func.Command("INSERT INTO Tbl_User ([Tipe_User], [Nama_User], [Telepon], [Alamat], [Username], [Password]) VALUES ('" + cbxTipeUser.Text + "', '" + txtNama.Text + "', '" + txtTelepon.Text + "', '" + txtAlamat.Text + "', '" + txtUsername.Text + "', '" + txtPasword.Text + "')");

                Clear();
                Show();

                MessageBox.Show("Data berhasil ditambahkan");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (cbxTipeUser.Text == "" || txtNama.Text == "" || txtTelepon.Text == "" || txtAlamat.Text == "" || txtUsername.Text == "" || txtPasword.Text == "")
            {
                MessageBox.Show("Semua kolom data harus di isi!");
            }
            else
            {
                func.Command("UPDATE Tbl_User SET Tipe_User = '" + cbxTipeUser.Text + "', Nama_User = '" + txtNama.Text + "', Alamat = '" + txtAlamat.Text + "', Telepon = '" + txtTelepon.Text + "', Username = '" + txtUsername.Text + "', Password = '" + txtPasword.Text + "' WHERE Id_User = '" + id + "'");

                Clear();
                Show();

                MessageBox.Show("Data berhasil diubah");
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            func.Command("DELETE FROM Tbl_User WHERE Id_User = '" + id + "'");

            Clear();
            Show();

            MessageBox.Show("Data berhasil dihapus");
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            dgv_User.DataSource = func.ShowData("SELECT * FROM Tbl_User WHERE Nama_User LIKE '" + txtCari.Text + "%'");
        }

        private void btnKelolaObat_Click(object sender, EventArgs e)
        {
            new Form_Kelola_Obat().Show();
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
    }
}
