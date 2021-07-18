using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BagasiHidroponik
{
    public partial class FormCostumerSelada : Form
    {
        // membuat function koneksi
        Koneksi konn = new Koneksi();
        // deklrasai tiap variable
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader rd;

        public FormCostumerSelada()
        {
            InitializeComponent();
        }

        // untuk membuat kondisi dimana semua form dalam keadaan kosong
        void KondisiAwal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            MunculCostumerSelada();
        }

        void MunculCostumerSelada()
        {
            // menyambungkan ke koneksi database
            SqlConnection conn = konn.GetConn();
            // membuka koneksi
            conn.Open();
            // membuka tabel Customer dari database
            cmd = new SqlCommand("select * from TBL_CUSTOMER", conn);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            // membuat tabel Customer terisi oleh inputan user
            da.Fill(ds, "TBL_CUSTOMER");
            dataGridView1.DataSource = ds;
            // menampilkan tabel yang telah di isini
            dataGridView1.DataMember = "TBL_CUSTOMER";
            // membuat user tidak bisa mengedit row
            dataGridView1.AllowUserToAddRows = false;
            // merefresh data grid
            dataGridView1.Refresh();
        }

        void NoOtomatis()
        {
            //deklarasi variable long dan string
            long hitung;
            string urutan;
            SqlDataReader rd;
            // memnyambungkan ke koneksi database
            SqlConnection conn = konn.GetConn();
            // membuka koneksi
            conn.Open();
            // menyeleksi kodeCustomer dari Tabel Customer , yang diambil dari yang terakhir dan order by terakhir dan berurutan
            cmd = new SqlCommand("Select KodeCustomer from TBL_CUSTOMER where KodeCustomer in(select max(KodeCustomer) from TBL_CUSTOMER) order by KodeCustomer desc", conn);
            // mengeksekusi reader
            rd = cmd.ExecuteReader();
            //membaca rd
            rd.Read();
            // jika data sudah ada menambahkan pengekodean baru
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["KodeCustomer"].ToString().Length - 3, 3)) + 1;
                string kodeurutan = "000" + hitung;
                urutan = "CUS" + kodeurutan.Substring(kodeurutan.Length - 3, 3);
            }
            // jika salah makan urutan akan berisi text CUS001
            else
            {
                urutan = "CUS001";
            }
            //menutup rd
            rd.Close();
            // membuat texbox 1 tertutup
            textBox1.Enabled = false;
            // membuat textbox 1 terisi dari urutan
            textBox1.Text = urutan;
            // menutup koneksi
            conn.Close();
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // membuat tiap text box terisi seusai cells yang ada
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            // membuat textbox 1-5 terutup
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        // mengeksusi function ketika form di buka pertama kali
        private void FormCostumerSelada_Load(object sender, EventArgs e)
        {
            KondisiAwal();
            NoOtomatis();
        }

        //membuat textbox 2 sampai 4 dapat di isi
        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //mengeksekusi function
            KondisiAwal();
            NoOtomatis();
            // mmembuat text 2 sampai 4 dapat terbuka
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // validasi ketika text box 1 sampai 5 kosong  maka akan muncul text pastikan semua box terisi
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Pastikan Semua Box Terisi");
            }
            else
            {
                // menyambungkan ke koneksi database
                SqlConnection conn = konn.GetConn();
                // mengisi tabel Customer sesuai attribut tabelnya
                cmd = new SqlCommand("insert into TBL_CUSTOMER values('" + textBox1.Text + "','" + textBox2.Text + "' ,'" + textBox3.Text + "','" + textBox4.Text + "')", conn);
                //membuka koneksi
                conn.Open();
                // mengeksekusi non query
                cmd.ExecuteNonQuery();
                // menampilkan pesan
                MessageBox.Show("data berhasil di input");
                KondisiAwal();
                NoOtomatis();
                // membuat text box 2 agar bia di isi
                textBox2.Enabled = true;
            }
        }

        // ketika menekan enter maka akan muncul data yang telah di input
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //mengkoneksikan dengan database
                SqlConnection conn = konn.GetConn();
                // membuat query untuk memilih tabel Customer
                cmd = new SqlCommand("select * from TBL_CUSTOMER where KodeCustomer='" + textBox1.Text + "'", conn);
                // membuka koneksi
                conn.Open();
                // eksekusi non query
                cmd.ExecuteNonQuery();
                // membaca database
                rd = cmd.ExecuteReader();
                // validasi read
                if (rd.Read())
                {
                    // memunculkan data tiap tiap data yang telah di input ke dalam textbox
                    textBox1.Text = rd[0].ToString();
                    textBox2.Text = rd[1].ToString();
                    textBox3.Text = rd[2].ToString();
                    textBox4.Text = rd[3].ToString();
                }
                // jika salah muncul data tidak ada
                else
                {
                    MessageBox.Show("Data Tidak Ada");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // validasi ketika text box 1 sampai 5 kosong  maka akan muncul text pastikan semua box terisi 
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Pastikan Semua Box Terisi");
            }
            else
            {
                // memnyambungkan ke koneksi database
                SqlConnection conn = konn.GetConn();
                // mengupdate tabel Customer sesuai attribut tabelnya
                cmd = new SqlCommand("update TBL_CUSTOMER set NamaCustomer= '" + textBox2.Text + "',AsalKontak= '" + textBox3.Text + "',NomerHp= '" + textBox4.Text + "' where KodeCustomer='" + textBox1.Text + "'", conn);
                // membuka koneksi
                conn.Open();
                // mengekseskusi non query
                cmd.ExecuteNonQuery();
                // menampilkan pesan
                MessageBox.Show("data berhasil di edit");
                KondisiAwal();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // menyambungkan ke koneksi database
            SqlConnection conn = konn.GetConn();
            // Menghapus Tabel Customer, dengan primary KodeCustomer
            cmd = new SqlCommand("Delete TBL_CUSTOMER where KodeCustomer='" + textBox1.Text + "'", conn);
            // membuka koneksi
            conn.Open();
            // memgeksekusi non query
            cmd.ExecuteNonQuery();
            //menampilkan Pesan
            MessageBox.Show("data berhasil di Hapus");
            KondisiAwal();
        }

        // saat close dari form makan akan langsung di alihkan ke form Halaman Utama
        private void FormCostumerSelada_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            new HalamanUtama().Show();
        }
    }
}
