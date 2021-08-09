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
using System.Collections;

namespace hastanerandevusistemi
{
    public partial class randevu : Form
    {
        public randevu()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=hastanerandevu; Integrated Security=true;");
        ArrayList strList = new ArrayList();
        ArrayList saat = new ArrayList();
        string tcnu= giris.tcNo.ToString();
        private void randevu_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string sorgu = "select ilAd from iller";
            SqlDataAdapter adp = new SqlDataAdapter(sorgu, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            conn.Close();



            conn.Open();
            SqlCommand komut = new SqlCommand("select saat from muayene", conn);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                strList.Add(dr["saat"].ToString());
            }
            for (int i = 0; i <= strList.Count; i++)
            {
                if (strList.Contains(k1.Text))
                {
                    k1.BackColor = Color.Red;
                    k1.Enabled = false;

                }
                if (strList.Contains(k2.Text))
                {
                    k2.BackColor = Color.Red;
                    k2.Enabled = false;

                }
                if (strList.Contains(k3.Text))
                {
                    k3.BackColor = Color.Red;
                    k3.Enabled = false;
                }
                if (strList.Contains(k4.Text))
                {
                    k4.BackColor = Color.Red;
                    k4.Enabled = false;
                }
                if (strList.Contains(k5.Text))
                {
                    k5.BackColor = Color.Red;
                    k5.Enabled = false;
                }
                if (strList.Contains(k6.Text))
                {
                    k6.BackColor = Color.Red;
                    k6.Enabled = false;
                }
                if (strList.Contains(k7.Text))
                {
                    k7.BackColor = Color.Red;
                    k7.Enabled = false;
                }
                if (strList.Contains(k8.Text))
                {
                    k8.BackColor = Color.Red;
                    k8.Enabled = false;

                }
                if (strList.Contains(k9.Text))
                {
                    k9.BackColor = Color.Red;
                    k9.Enabled = false;
                }
                if (strList.Contains(k10.Text))
                {
                    k10.BackColor = Color.Red;
                    k10.Enabled = false;
                }
                if (strList.Contains(k11.Text))
                {
                    k11.BackColor = Color.Red;
                    k11.Enabled = false;
                }
                if (strList.Contains(k12.Text))
                {
                    k12.BackColor = Color.Red;
                    k12.Enabled = false;
                }
                if (strList.Contains(k13.Text))
                {
                    k13.BackColor = Color.Red;
                    k13.Enabled = false;
                }
                if (strList.Contains(k14.Text))
                {
                    k14.BackColor = Color.Red;
                    k14.Enabled = false;
                }
                if (strList.Contains(k15.Text))
                {
                    k15.BackColor = Color.Red;
                    k15.Enabled = false;
                }
            }
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string komut = "select hastaneAd from hastane where ilNo = (select ilNo from iller where ilAd ='" + comboBox1.Text + "')";
            SqlDataAdapter adap = new SqlDataAdapter(komut, conn);
            DataSet dst = new DataSet();
            adap.Fill(dst);
            for (int i = 0; i <= dst.Tables[0].Rows.Count - 1; i++)
            {
                comboBox2.Items.Add(dst.Tables[0].Rows[i][0].ToString());
            }
            conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string sorgu = "select bAd from bolum";
            SqlDataAdapter adp = new SqlDataAdapter(sorgu, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                comboBox3.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            conn.Close();
        }

        private void randevukaydet_Click(object sender, EventArgs e)
        {
            if ((comboBox1.Text != "") && (comboBox2.Text != "") && (comboBox3.Text != "") && (comboBox4.Text != "") && (dateTimePicker1.Text != "") && (textBox1.Text != ""))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {

                    string cmd = "insert into muayene(TcNo,il, hastane,bolum, doktor, tarih, saat) values ('" + tcnu +"','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + dateTimePicker1.Text + "','" + textBox1.Text + "')";
                    SqlCommand komutSatiri = new SqlCommand(cmd, conn);
                    komutSatiri.ExecuteNonQuery();
                    listBox1.Items.Add("TcNo: " + tcnu.ToString());
                    listBox1.Items.Add("İl: " + comboBox1.Text);
                    listBox1.Items.Add("Hastane: " + comboBox2.Text);
                    listBox1.Items.Add("Bölüm: " + comboBox3.Text);
                    listBox1.Items.Add("Doktor: " + comboBox4.Text);
                    listBox1.Items.Add("Tarih: " + dateTimePicker1.Text);
                    listBox1.Items.Add("Saat: " + textBox1.Text);
                    MessageBox.Show("Kayıt Başarıyla Gerçekleşti");
                    conn.Close();

                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex +"Lütfen Bilgilerinizi Doğru Giriniz.");
                }
                conn.Close();
            }
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void k1_click(object sender, EventArgs e)
        {
            string alinan = ((Button)sender).Text;
            textBox1.Text = alinan;

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string sorgu = "select adSoyad from doktor";
            SqlDataAdapter adp = new SqlDataAdapter(sorgu, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                comboBox4.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guncelle guncelle = new guncelle();
            guncelle.Show();
            this.Visible = false;
        }

        private void cikisyap_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


