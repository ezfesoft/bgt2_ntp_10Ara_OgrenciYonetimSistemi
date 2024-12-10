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

namespace bgt2_ntp_10Ara_OgrenciYonetimSistemi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string baglanti = 
                "Server=172.20.112.108;" +
                "Database=nesneTabanliProgramlama;" +
                "User Id=ogr1;" +
                "Password=bgt2024;";

            string sorgu =
                "INSERT INTO Ogrenciler" +
                "(OgrAd, OgrSoyad, OgrYas, OgrCins, developer)" +
                "VALUES" +
                "(@ad, @soyad, @yas, @cins, 'slymn')";

            using (SqlConnection con=new SqlConnection(baglanti))
            using (SqlCommand komut=new SqlCommand(sorgu,con))
            {
                komut.Parameters.AddWithValue("@ad", textBox1.Text);
                komut.Parameters.AddWithValue("@soyad", textBox2.Text);
                komut.Parameters.AddWithValue("@yas", Convert.ToInt32(textBox3.Text));
                komut.Parameters.AddWithValue("@cins", radioButton1.Checked ? "E" : "K");

                con.Open();
                komut.ExecuteNonQuery();
                con.Close();
                this.Close();
                MessageBox.Show("Kayıt Eklendi");
            }









            



        }
    }
}
