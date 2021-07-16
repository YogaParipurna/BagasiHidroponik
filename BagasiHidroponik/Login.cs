using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BagasiHidroponik
{
    public partial class Login : Form
    {
        // Deklarasi variable String 
        readonly string Username = "Yoga";
        readonly string Password = "123";

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // membuat username dan password terisi otomatis dengan text dibawah
            TxtUsername.Text = "Yoga";
            TxtPassword.Text = "123";
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // jika username dan password sesuai yang di isi maka akan muncul text Kamu berhasil Login lalu akan berpindah ke form halaman Utama
            if (TxtUsername.Text == Username && TxtPassword.Text == Password)
            {
                MessageBox.Show("Kamu berhasil login");
                this.Hide();
                new HalamanUtama().Show();
            }
            //jika username dan password kosong akan muncul pesan seperti dibawah 
            else if (TxtUsername.Text == "" || TxtPassword.Text == "")
            {
                MessageBox.Show("Kamu belum mengisi form login");
            }
            //jika username dan password salah isinya akan muncul pesan seperti dibawah
            else
            {
                MessageBox.Show("Username atau Password Salah ");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
