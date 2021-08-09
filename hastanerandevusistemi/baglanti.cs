using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace hastanerandevusistemi
{
    class baglanti
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0; Data Source=hastane.accdb");
        public void baglantiAc()
        {
            conn.Open();
        }
        public void baglantiKapat()
        {
            conn.Close();
        }
        public OleDbDataReader bilgi(string sorgu)
        {
            OleDbCommand cmd = new OleDbCommand(sorgu, conn);
            OleDbDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
    }

}
