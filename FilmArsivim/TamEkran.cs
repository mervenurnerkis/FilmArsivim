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
    public partial class TamEkran : Form
    {
        public TamEkran()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-8RCKT9U\SQLEXPRESS;Initial Catalog=FilmArsivim;Integrated Security=True");
       public string film;

        private void TamEkran_Load(object sender, EventArgs e)
        {
            this.Text = film.ToString();
            this.WindowState = FormWindowState.Normal;
            webBrowser1.Navigate(film);


        }
    }
}
