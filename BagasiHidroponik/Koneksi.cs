using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// menghubungkan ke sql server
using System.Data.SqlClient;

namespace BagasiHidroponik
{
    class Koneksi
    {
        // membuat koneksi ke database kita
        public SqlConnection GetConn()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data Source= YAPART\\YOGA;database=DB_Hidroponik;User ID=sa;Password=Crandle1";
            return Conn;
        }

    }
}
