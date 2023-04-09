using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Collections;
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
    public partial class BookTicketPage : Form
    {
        User u1 = null;
        public BookTicketPage(User user)
        {
            InitializeComponent();
            u1 = user;
            
        }

        private void BookTicketPage_Load(object sender, EventArgs e)
        {
            if (u1.email == "admin@cinema.pl")
            {
                button6.Hide();
                button10.Show();
                button9.Show();
            }

            MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;password=;database=cinema");

            connection.Open();

            MySqlCommand mdb = new MySqlCommand("SELECT DISTINCT tickets.id AS 'ID Biletu', movie.name AS 'Nazwa Filmu', tickets.ticket_number AS 'Miejsce', movie.date_of_movie AS 'Data Filmu' FROM tickets, users, movie WHERE tickets.user_id IS NULL AND movie.date_of_movie > NOW() AND tickets.film_id=movie.id ORDER BY movie.date_of_movie DESC, tickets.ticket_number ASC", connection);
            MySqlCommand mdb1 = new MySqlCommand("SELECT DISTINCT movie.name FROM movie, tickets WHERE movie.date_of_movie > NOW() AND movie.date_of_movie IS NOT NULL ", connection);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(mdb);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                MySqlDataAdapter adapter1 = new MySqlDataAdapter(mdb1);
                DataTable dt1 = new DataTable();
                adapter1.Fill(dt1);
                comboBox1.DataSource = dt1;
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MainPage main = new MainPage(u1);
            main.Show();
            this.Hide();
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

        private void button7_Click(object sender, EventArgs e)
        {
            LoginPage loginpage = new LoginPage();
            loginpage.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string id_ticket = textBox1.Text;

            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;password=;database=cinema");

                connection.Open();
                string q = "UPDATE tickets SET user_id=" + u1.id + " WHERE id=" + id_ticket + " ;";
                MySqlCommand command = new MySqlCommand(q, connection);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    MessageBox.Show("Nie znaleziono ID", "Error");
                }

                connection.Close();
                BookTicketPage bookTicketPage = new BookTicketPage(u1);
                bookTicketPage.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ", "Error");
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string id_movie = comboBox1.Text;

            MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;password=;database=cinema");

            connection.Open();

            MySqlCommand mdb = new MySqlCommand("SELECT DISTINCT tickets.id AS 'ID Biletu', movie.name AS 'Nazwa Filmu', tickets.ticket_number AS 'Miejsce', movie.date_of_movie AS 'Data Filmu' FROM tickets, users, movie WHERE tickets.user_id IS NULL AND movie.date_of_movie > NOW() AND tickets.film_id=movie.id AND movie.name='"+id_movie+"' ORDER BY movie.date_of_movie DESC, tickets.ticket_number ASC", connection);
            

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(mdb);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CreateMoviePage createMoviePage = new CreateMoviePage(u1);
            createMoviePage.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            StorePage storePage = new StorePage(u1);
            storePage.Show();
            this.Hide();
        }
    }
}
