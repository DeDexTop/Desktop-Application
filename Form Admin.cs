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
    public partial class Form_Admin : Form
    {
        Function func = new Function();
        private Form activateForm;
        public Form_Admin()
        {
            InitializeComponent();
        }
        new void Show()
        {
            dgvLog.DataSource = func.ShowData("Select Tbl_Log.Id_Log, Tbl_User.Nama_User, Tbl_Log.Waktu, Tbl_Log.Aktifitas FROM Tbl_Log JOIN Tbl_User ON Tbl_Log.Id_User = Tbl_User.Id_User WHERE Waktu = '" + dtp_Waktu.Text + "'");
        }

        private void Form_Admin_Load(object sender, EventArgs e)
        {
            dgvLog.DataSource = func.ShowData("Select Tbl_Log.Id_Log, Tbl_User.Nama_User, Tbl_Log.Waktu, Tbl_Log.Aktifitas FROM Tbl_Log JOIN Tbl_User ON Tbl_Log.Id_User = Tbl_User.Id_User");
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activateForm != null)
            {
                activateForm.Close();
            }
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(childForm);
            this.panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Show();
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
