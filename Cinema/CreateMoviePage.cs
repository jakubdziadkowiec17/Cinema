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

namespace Cinema
{
    public partial class CreateMoviePage : Form
    {
        User u1 = null;
        public CreateMoviePage(User user)
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

        private void button2_Click(object sender, EventArgs e)
        {
            BookTicketPage bookTicketPage = new BookTicketPage(u1);
            bookTicketPage.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyTicketsPage myTicketsPage = new MyTicketsPage(u1);
            myTicketsPage.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MoviePage moviePage = new MoviePage(u1);
            moviePage.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HallPage hallPage = new HallPage(u1);
            hallPage.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditProfilePage editProfilePage = new EditProfilePage(u1);
            editProfilePage.Show();
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

        private void button7_Click(object sender, EventArgs e)
        {
            LoginPage loginpage = new LoginPage();
            loginpage.Show();
            this.Hide();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;password=;database=cinema");

            if ( textBox5.Text.Length == 0 || textBox6.Text.Length == 0 )
            {
                MessageBox.Show("Uzupełnij puste pola", "Error");
                return;
            }

            try
            {
                connection.Open();
                string sqlQuery = "INSERT INTO movie (name, date_of_movie) VALUES (@name, @date_of_movie)";
                MySqlCommand command = new MySqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@name", textBox5.Text);
                command.Parameters.AddWithValue("@date_of_movie", textBox6.Text);
                command.ExecuteNonQuery();


                int id1=0;
                MySqlCommand command3 = new MySqlCommand();
                String q1 = "SELECT * FROM movie WHERE name = '" + textBox5.Text + "' AND date_of_movie = '" + textBox6.Text + "'";

                command3.CommandText = q1;
                command3.Connection = connection;
                MySqlDataReader reader = command3.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id1 = reader.GetInt32(0);
                    }
                }
                connection.Close();

                for(int i=1;i<=15;i++)
                {
                    connection.Open();
                    string q = "INSERT INTO tickets (film_id, ticket_number) VALUES (@film_id, @ticket_number)";
                    MySqlCommand command1 = new MySqlCommand(q, connection);
                    command1.Parameters.AddWithValue("@film_id", id1);
                    command1.Parameters.AddWithValue("@ticket_number", i);
                    command1.ExecuteNonQuery();
                    connection.Close();
                }
                
                MoviePage moviePage = new MoviePage(u1);
                moviePage.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Błąd rejestracji. Podany login posiada już konto.", "BarberShop");
            }
        }

        private void CreateMoviePage_Load(object sender, EventArgs e)
        {
            button6.Hide();
            button5.Show();
            button8.Show();
        }
    }
}
