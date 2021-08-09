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
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=hastanerandevu; Integrated Security=true;");
        public static string tcNo;
        private void button2_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM hasta where TcNo='" + textBox1.Text + "' AND sifre='" + textBox2.Text + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tcNo = textBox1.Text;
                randevu randevu = new randevu();
                randevu.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
            }

            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void yeniuye_Click(object sender, EventArgs e)
        {
            yeni_uyelik yeniuye = new yeni_uyelik();
            yeniuye.Show();
            this.Visible = false;

        }

        private void sifremiunuttum_Click(object sender, EventArgs e)
        {
            sifremiunuttum sifremiunuttum = new sifremiunuttum();
            sifremiunuttum.Show();
            this.Visible = false;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
