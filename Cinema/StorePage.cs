using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cinema
{
    public partial class StorePage : Form
    {
        User u1 = null;
        MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;password=;database=cinema");
        public StorePage(User user)
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

        private void button10_Click(object sender, EventArgs e)
        {
            StorePage storePage = new StorePage(u1);
            storePage.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CreateMoviePage createMoviePage = new CreateMoviePage(u1);
            createMoviePage.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void StorePage_Load(object sender, EventArgs e)
        {
            if (u1.email == "admin@cinema.pl")
            {
                button6.Hide();
                button10.Show();
                button9.Show();
            }

            MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;password=;database=cinema");

            connection.Open();

            MySqlCommand mdb = new MySqlCommand("SELECT id AS 'ID Produktu', name AS 'Nazwa Produktu', amount AS 'Ilość', price AS 'Cena [zł]' FROM store", connection);
            

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

        private void button5_Click(object sender, EventArgs e)
        {

            if (textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0)
            {
                MessageBox.Show("Uzupełnij puste pola", "Error");
                return;
            }

            try
            {
                connection.Open();
                string sqlQuery = "INSERT INTO store (name, amount, price) VALUES (@name, @amount, @price)";
                MySqlCommand command = new MySqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@name", textBox2.Text);
                command.Parameters.AddWithValue("@amount", textBox3.Text);
                command.Parameters.AddWithValue("@price", textBox4.Text);
                command.ExecuteNonQuery();
                connection.Close();

                StorePage storePage = new StorePage(u1);
                storePage.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Error.", "Error");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" )
            {
                MessageBox.Show("Zaznacz wiersz.");
            }
            else
            {
                var temp = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                try
                {
                    connection.Open();
                    string sqlQuery = "DELETE FROM store WHERE Id=" + temp + ";";
                    MySqlCommand command = new MySqlCommand(sqlQuery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();

                    StorePage storePage = new StorePage(u1);
                    storePage.Show();
                    this.Hide();
                }
                catch
                {
                    MessageBox.Show("Error.", "Error");
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                string q = "UPDATE store SET name='" + textBox2.Text + "', amount=" + textBox3.Text + ", price=" + textBox4.Text + " WHERE id=" + textBox1.Text + " ;";
                MySqlCommand command = new MySqlCommand(q, connection);
                command.ExecuteNonQuery();

                
                connection.Close();

                StorePage storePage = new StorePage(u1);
                storePage.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Error.", "Error");
            }
        }
    }
}
