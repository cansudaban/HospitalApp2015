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
    public partial class yeni_uyelik : Form
    {
        public yeni_uyelik()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=hastanerandevu; Integrated Security=true;");
        private void button1_Click(object sender, EventArgs e)
        {
                if (textBox6.Text != textBox7.Text)
                {
                    MessageBox.Show("Şifreler Aynı Değil");
                }
                else
                {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox6.Text != "") && (textBox7.Text != "") && (comboBox1.Text != "") && (textBox5.Text != "") && (textBox8.Text != "") && (textBox9.Text != ""))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    string sqlKomut = "select * from hasta where tcno='" + textBox1.Text + "'";
                    SqlDataAdapter dap = new SqlDataAdapter(sqlKomut, conn);
                    DataTable dt = new DataTable();
                    dap.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Tc Kimlik Sistemimizde zaten kayıtlı.");
                    }
                    else
                    {
                        try
                        {

                            string cmd = "insert into hasta(tcno, ad, soyad, telefon, email, adres, sifre, guvenliksorusu, guvenlikcevabi) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "')";
                            SqlCommand komutSatiri = new SqlCommand(cmd, conn);
                            komutSatiri.ExecuteNonQuery();
                            MessageBox.Show("Kayıt Başarıyla Gerçekleşti");
                            conn.Close();
                            temizle();
                            giris giris = new giris();
                            giris.Show();
                            this.Visible = false;

                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Tüm Alanları Doldurunuz");
                }
                }
            }
            
           
        
        private void temizle()
        {
            foreach (Control nesne in this.Controls)
            {
                if (nesne is TextBox)
                {
                    TextBox textbox = (TextBox)nesne;
                    textbox.Clear();
                }
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            giris giris = new giris();
            giris.Show();
            this.Close();
        }

        private void yeni_uyelik_Load(object sender, EventArgs e)
        {

        }
    }
}

