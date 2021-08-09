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
    public partial class guncelle : Form
    {
        public guncelle()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=hastanerandevu; Integrated Security=true;");
        private void button1_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            if (textBox1.Text !="" && textBox4.Text!="" && textBox8.Text != "" && textBox9.Text != "" && textBox6.Text != "" && textBox5.Text != "" && comboBox1.Text != "")
            {
                string sorgu = "update hasta set telefon ='"+ textBox4.Text +"' ,email ='"+textBox8.Text +"', adres='"+textBox9.Text+ "', sifre='" + textBox6.Text + "',guvenliksorusu='" + comboBox1.Text + "',guvenlikcevabi='" + textBox5.Text + "' where TcNo =" + textBox1.Text +"";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                DialogResult secenek = MessageBox.Show("Değişiklikleri kaydetmek istiyor musunuz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            
                if (secenek == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Güncelleme İşlemi Gerçekleşti");
                }
                else if (secenek == DialogResult.No)
                {
                    MessageBox.Show("Güncelleme İşlemi Gerçekleşmedi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurunuz.");
            }
            conn.Close();
        }
    

        private void guncelle_Load(object sender, EventArgs e)
        {
            
        }
        string secilen;
        private void button2_Click(object sender, EventArgs e)
        {
            secilen = textBox1.Text;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string sorgu = "select * from hasta where tcno='" +secilen+"'";
            SqlDataAdapter adp = new SqlDataAdapter(sorgu, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            textBox4.Text = ds.Tables[0].Rows[0][3].ToString();
            textBox8.Text = ds.Tables[0].Rows[0][4].ToString();
            textBox9.Text = ds.Tables[0].Rows[0][5].ToString();
            textBox6.Text = ds.Tables[0].Rows[0][6].ToString();
            comboBox1.Text = ds.Tables[0].Rows[0][7].ToString();
            textBox5.Text = ds.Tables[0].Rows[0][8].ToString();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
