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
    public partial class MyTicketsPage : Form
    {
        User u1 = null;
        public MyTicketsPage(User user)
        {
            InitializeComponent();
            u1 = user;
        }

        private void MyTicketsPage_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;password=;database=cinema");

            MySqlCommand mdb = new MySqlCommand("SELECT distinct tickets.id AS 'ID Biletu', movie.name AS 'Nazwa Filmu', tickets.ticket_number AS 'Miejsce', movie.date_of_movie AS 'Data Filmu' FROM tickets, users, movie WHERE tickets.user_id="+u1.id+" AND tickets.film_id=movie.id ORDER BY movie.date_of_movie DESC, tickets.ticket_number ASC", connection);
            MySqlCommand mdb1 = new MySqlCommand("SELECT distinct tickets.id FROM tickets, movie WHERE tickets.user_id= '" + u1.id + "' AND movie.date_of_movie > NOW() AND movie.id=tickets.film_id AND movie.date_of_movie IS NOT NULL ORDER BY tickets.id ASC", connection);
            MySqlCommand mdb2 = new MySqlCommand("SELECT distinct tickets.id AS 'ID Biletu', movie.name AS 'Nazwa Filmu', tickets.ticket_number AS 'Miejsce', movie.date_of_movie AS 'Data Filmu' FROM tickets, users, movie WHERE tickets.user_id IS NOT NULL AND tickets.film_id=movie.id ORDER BY movie.date_of_movie DESC, tickets.ticket_number ASC", connection);
            MySqlCommand mdb3 = new MySqlCommand("SELECT distinct tickets.id FROM tickets, movie WHERE tickets.user_id IS NOT NULL AND movie.date_of_movie > NOW() AND movie.id=tickets.film_id AND movie.date_of_movie IS NOT NULL ORDER BY tickets.id ASC", connection);

            try
            {
                connection.Open();
                    if (u1.email == "admin@cinema.pl")
                    {
                        button6.Hide();
                        button9.Show();
                        button8.Show();

                        MySqlDataAdapter adapter = new MySqlDataAdapter(mdb2);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;

                        MySqlDataAdapter adapter1 = new MySqlDataAdapter(mdb3);
                        DataTable dt1 = new DataTable();
                        adapter1.Fill(dt1);
                        comboBox1.DataSource = dt1;
                        comboBox1.DisplayMember = "id";
                        comboBox1.ValueMember = "id";
                    }
                    else
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(mdb);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;

                        MySqlDataAdapter adapter1 = new MySqlDataAdapter(mdb1);
                        DataTable dt1 = new DataTable();
                        adapter1.Fill(dt1);
                        comboBox1.DataSource = dt1;
                        comboBox1.DisplayMember = "id";
                        comboBox1.ValueMember = "id";
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ");
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            MyTicketsPage myTicketsPage = new MyTicketsPage(u1);
            myTicketsPage.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MainPage main = new MainPage(u1);
            main.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string id_ticket = comboBox1.Text;

            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;password=;database=cinema");
               
                connection.Open();
                string q = "UPDATE tickets SET user_id=NULL WHERE id=" + id_ticket + " AND user_id IS NOT NULL;";
                MySqlCommand command = new MySqlCommand(q, connection);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    MessageBox.Show("Nie znaleziono ID", "Error");
                }

                connection.Close();
                MyTicketsPage myTicketsPage = new MyTicketsPage(u1);
                myTicketsPage.Show();
                this.Hide();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BookTicketPage bookTicketPage = new BookTicketPage(u1);
            bookTicketPage.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
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
