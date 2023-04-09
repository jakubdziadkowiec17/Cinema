using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Cinema
{
    public partial class MoviePage : Form
    {
        User u1 = null;
        public MoviePage(User user)
        {
            InitializeComponent();
            u1 = user;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MainPage main = new MainPage(u1);
            main.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoginPage loginpage = new LoginPage();
            loginpage.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditProfilePage editProfilePage = new EditProfilePage(u1);
            editProfilePage.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HallPage hallPage = new HallPage(u1);
            hallPage.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MoviePage moviePage = new MoviePage(u1);
            moviePage.Show();
            this.Hide();
        }

        private void MoviePage_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;password=;database=cinema");

            connection.Open();

            MySqlCommand mdb = new MySqlCommand("SELECT name AS 'Nazwa Filmu', date_of_movie AS 'Data Filmu' FROM movie WHERE date_of_movie > NOW() AND date_of_movie IS NOT NULL ORDER BY date_of_movie DESC ", connection);
            MySqlCommand mdb1 = new MySqlCommand("SELECT name AS 'Nazwa Filmu', date_of_movie AS 'Data Filmu' FROM movie WHERE  date_of_movie IS NOT NULL ORDER BY date_of_movie DESC ", connection);

            try
            {
                if (u1.email == "admin@cinema.pl")
                {
                    button6.Hide();
                    button5.Show();
                    button8.Show();

                    MySqlDataAdapter adapter = new MySqlDataAdapter(mdb1);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(mdb);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyTicketsPage myTicketsPage = new MyTicketsPage(u1);
            myTicketsPage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BookTicketPage bookTicketPage = new BookTicketPage(u1);
            bookTicketPage.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StorePage storePage = new StorePage(u1);
            storePage.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CreateMoviePage createMoviePage = new CreateMoviePage(u1);
            createMoviePage.Show();
            this.Hide();
        }
    }
}
