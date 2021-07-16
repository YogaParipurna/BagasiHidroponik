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

namespace BagasiHidroponik
{
    public partial class FormTanaman : Form
    {
        // membuat function koneksi
        Koneksi konn = new Koneksi();
        // deklrasai tiap variable
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader rd;


        // untuk membuat kondisi dimana semua form dalam keadaan kosong
        void KondisiAwal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            //memanggil fuction Muncul Data tanaman
            MunculDataTanaman();
        }

        //
        void MunculDataTanaman()
        {
            // memnyambungkan ke koneksi database
            SqlConnection conn = konn.GetConn();
            // membuka koneksi
            conn.Open();
            // membuka tabel tumbuhan dari database
            cmd = new SqlCommand("select * from TBL_TUMBUHAN", conn);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            // membuat tabel tumbuhan terisi oleh inputan user
            da.Fill(ds, "TBL_TUMBUHAN");
            dataGridView1.DataSource = ds;
            // menampilkan tabel yang telah di isini
            dataGridView1.DataMember = "TBL_TUMBUHAN";
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
            // menyeleksi kode barang dari Tabel Tumbuhan , yang diambil dari yang terakhir dan order by terakhir dan berurutan
            cmd = new SqlCommand("Select KodeTanaman from TBL_TUMBUHAN where KodeTanaman in(select max(KodeTanaman) from TBL_TUMBUHAN) order by KodeTanaman desc", conn);
            // mengeksesuki reader
            rd = cmd.ExecuteReader();
            //membaca rd
            rd.Read();
            // jika data sudah ada menambahkan pengekodean baru
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["KodeTanaman"].ToString().Length - 3, 3)) + 1;
                string kodeurutan = "000" + hitung;
                urutan = "TNM" + kodeurutan.Substring(kodeurutan.Length - 3, 3);
            }
            // jika salah makan urutan akan berisi text TNM 001
            else
            {
                urutan = "TNM001";
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

        public FormTanaman()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // mengeksusi function ketika form di buka pertama kali
        private void FormTanaman_Load(object sender, EventArgs e)
        {
            KondisiAwal();
            NoOtomatis();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // validasi ketika text box 1 sampai 5 kosong  maka akan muncul text pastikan semua box terisi
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text =="" || textBox4.Text =="" || textBox5.Text == "")
            {
                MessageBox.Show("Pastikan Semua Box Terisi");
            }
            else
            {
                // memnyambungkan ke koneksi database
                SqlConnection conn = konn.GetConn();
                // mengisi tabel tumbuhan sesuai attribut tabelnya
                cmd = new SqlCommand("insert into TBL_TUMBUHAN values('"+ textBox1.Text + "','"+ textBox2.Text + "' ,'"+ textBox3.Text + "','"+ textBox4.Text + "' ,'" + textBox5.Text + "')", conn);
                // membuka koneksi
                conn.Open();
                // mengekseskusi non query
                cmd.ExecuteNonQuery();
                // menampilkan pesan
                MessageBox.Show("data berhasil di input");
                KondisiAwal();
                NoOtomatis();
                // membuat textbox 2 agar  bisa di isi
                textBox2.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // ketika menekan enter maka akan muncul data yang telah di input
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                    //mengkoneksikan dengan database
                    SqlConnection conn = konn.GetConn();
                    // membuat query untuk memilih tabel tumbuhan
                    cmd = new SqlCommand("select * from TBL_TUMBUHAN where KodeTanaman='"+ textBox1.Text+ "'", conn);
                    // membuka koneksi
                    conn.Open();
                    // eksekusi non query
                    cmd.ExecuteNonQuery();
                    // membaca database
                    rd = cmd.ExecuteReader();
                    // validasi read
                    if(rd.Read())
                    {
                        // memunculkan data tiap tiap data yang telah di input ke dalam textbox
                        textBox1.Text = rd[0].ToString();
                        textBox2.Text = rd[1].ToString();
                        textBox3.Text = rd[2].ToString();
                        textBox4.Text = rd[3].ToString();
                        textBox5.Text = rd[4].ToString();
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
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Pastikan Semua Box Terisi");
            }
            else
            {
                // memnyambungkan ke koneksi database
                SqlConnection conn = konn.GetConn();
                // mengupdate tabel tumbuhan sesuai attribut tabelnya
                cmd = new SqlCommand("update TBL_TUMBUHAN set NamaTanaman= '" + textBox2.Text + "',HargaBeli= '" + textBox3.Text + "',HargaJual= '" + textBox4.Text + "',JumlahTanaman='" + textBox5.Text +"' where KodeTanaman='"+ textBox1.Text +"'", conn);
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
                // memnyambungkan ke koneksi database
                SqlConnection conn = konn.GetConn();
                // Menghapus Tabel Tumbuhan, dengan primary KodeTanaman
                cmd = new SqlCommand("Delete TBL_TUMBUHAN where KodeTanaman='" + textBox1.Text + "'", conn);
                // membuka koneksi
                conn.Open();
                // memgeksekusi non query
                cmd.ExecuteNonQuery();
                //menampilkan Pesan
                MessageBox.Show("data berhasil di Hapus");
                KondisiAwal();
        }

        //membuat textbox 2 sampai 4 dapat di isi
        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // membuat tiap text box terisi seusai cells yang ada
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            // membuat textbox 1-5 terutup
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //mengeksekusi function
            KondisiAwal();
            NoOtomatis();
            // mmembuat text 2 sampai 5 dapat terbuka
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
        }

        // saat close dari form makan akan langsung di alihkan ke form Halaman Utama
        private void FormTanaman_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            new HalamanUtama().Show();
        }
    }
}
