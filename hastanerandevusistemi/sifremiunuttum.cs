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

namespace hastanerandevusistemi
{
    public partial class sifremiunuttum : Form
    {
        public sifremiunuttum()
        {
            InitializeComponent();
        }

        private void sifremiunuttum_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=hastanerandevu; Integrated Security=true;");
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT sifre FROM hasta where TcNo='" + textBox1.Text + "' AND guvenliksorusu='" + comboBox1.Text + "' AND guvenlikcevabi='"+textBox2.Text+"'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                label6.Text = (string)dr["sifre"];
            }
            else
            {
                textBox2.Text = "";
                MessageBox.Show("Lütfen Bilgilerinizi Doğru Giriniz.");
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            giris giris = new giris();
            giris.Show();
            this.Visible = false;
        }
    }
}
