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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        List<Ogrenci> ogrenciler = new List<Ogrenci>();

        private void Form3_Load(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM Ogrenciler";
            string baglanti =
                "Server=172.20.112.108;" +
                "Database=nesneTabanliProgramlama;" +
                "User Id=ogr1;" +
                "Password=bgt2024;";

            using (SqlConnection con = new SqlConnection(baglanti))
            using (SqlCommand komut = new SqlCommand(sorgu, con))
            {
                con.Open();
                using (SqlDataReader reader = komut.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ogrenci ogr = new Ogrenci();
                        
                        ogr.OgrID=reader.GetInt32(0);
                        ogr.OgrAd = reader.GetString(1);
                        ogr.OgrSoyad = reader.GetString(2);
                        ogr.OgrYas = reader.GetInt32(3);
                        ogr.OgrCins = reader.GetString(4);
                        ogr.developer = reader.GetString(5);

                        ogrenciler.Add(ogr);
                    }
                }
            }
            listBox1.DataSource = ogrenciler;
            listBox1.DisplayMember = "OgrAd";


        }
    }
}
