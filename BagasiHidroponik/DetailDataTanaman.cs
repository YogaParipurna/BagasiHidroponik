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
    public partial class DetailDataTanaman : Form
    {
        public DetailDataTanaman()
        {
            InitializeComponent();
        }

        // saat di tekan akan membuka form lihat data barang
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new HalamanUtama().Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void DetailDataTanaman_Load(object sender, EventArgs e)
        {

        }
    }
}
