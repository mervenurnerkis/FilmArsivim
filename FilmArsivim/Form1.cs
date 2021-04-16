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

namespace FilmArsivim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-8RCKT9U\SQLEXPRESS;Initial Catalog=FilmArsivim;Integrated Security=True");

        void filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_FILMLER", bgl);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("insert into TBL_FILMLER (AD,KATEGORI,LINK) values (@P1,@P2,@P3)", bgl);
            komut.Parameters.AddWithValue("@P1", TxtFilmAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtKategori.Text);
            komut.Parameters.AddWithValue("@P3", TxtLink.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Film listenize eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            filmler();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            webBrowser1.Navigate(link);
        }

        private void BtnHakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje Merve Nerkis tarafınan 6 Ocak 2020'de kodlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnRenkdegis_Click(object sender, EventArgs e)
        {
            
            this.BackColor = Color.Bisque;
            
        }

        private void BtnTamekran_Click(object sender, EventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            TamEkran fr = new TamEkran();
            fr.film = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            fr.Show();
        }
    }
}
