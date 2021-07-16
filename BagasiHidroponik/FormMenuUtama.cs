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
    public partial class HalamanUtama : Form
    {
        public HalamanUtama()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.TBL_TUMBUHAN' table. You can move, or remove it, as needed.
            this.tBL_TUMBUHANTableAdapter.Fill(this.dataSet1.TBL_TUMBUHAN);

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void masterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void hargaTanamanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //untuk berpindah ke form Lihar Data Tanaman
        private void lihatDataTanamanToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dataCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void dataTanamSeladaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void dataPanenSeladaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //untuk berpindah ke form Data Tanam Selada
        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DataTanamSelada().Show();
        }

        //untuk berpindah ke form Harga Tanaman
        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormTanaman().Show();
        }

        //untuk berpindah ke form Data Customer
        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormCostumerSelada().Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // membuat isi tabel jika di klik maka akan muncul ke form Detail Data Tanaman
            DetailDataTanaman DT = new DetailDataTanaman();
            this.Hide();
            //lalu setiap label akan di isi dari tabel yang ada dari cell pertama sampai akhir
            DT.label2.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DT.label3.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            DT.label4.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            DT.label5.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            DT.label6.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            // memunculkan form detail data tanaman
            DT.Show();
        }

        // untuk keluar dari aplikasi
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new DataPanenSelada().Show();
        }

        //untuk berpindah ke form login
        private void label6_Click(object sender, EventArgs e)
        {

            this.Hide();
            new Login().Show();

        }

        //untuk berpindah ke form About 
        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new About().Show();
        }
    }
}
