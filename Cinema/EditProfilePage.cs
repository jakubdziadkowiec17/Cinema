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

namespace Cinema
{
    public partial class EditProfilePage : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;password=;database=cinema");
        User u1 = null;
        public EditProfilePage(User user)
        {
            InitializeComponent();
            u1=user;

            textBox1.Text = u1.name;
            textBox2.Text = u1.surname;
            textBox3.Text = u1.password;
            textBox4.Text = u1.password;
            textBox5.Text = u1.email;
            textBox6.Text = u1.phone;
            textBox7.Text = u1.address;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoginPage loginpage = new LoginPage();
            loginpage.Show();
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
            try
            {
                 connection.Open();

                 string q= "UPDATE users SET name='" + textBox1.Text + "', surname='" + textBox2.Text + "', password='" + textBox3.Text + "', email='" + textBox4.Text + "', phone='" + textBox6.Text + "', address='" + textBox7.Text + "' WHERE email='" + textBox5.Text + "';";
                 MySqlCommand command = new MySqlCommand(q, connection);
                 command.ExecuteNonQuery();

                 u1.name = textBox1.Text;
                 u1.surname = textBox2.Text;
                 u1.password = textBox3.Text;
                 u1.email = textBox5.Text;
                 u1.phone = textBox6.Text;
                 u1.address = textBox7.Text;

                 connection.Close();
                 EditProfilePage editProfilePage = new EditProfilePage(u1);
                 editProfilePage.Show();
                 this.Hide();
            }
            catch
            {
                MessageBox.Show("Edytuj ponownie dane.", "Error");
            }
        }
        private void EditProfilePage_Load(object sender, EventArgs e)
        {
            if (u1.email == "admin@cinema.pl")
            {
                button6.Hide();
                button9.Show();
                button8.Show();
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            BookTicketPage bookTicketPage = new BookTicketPage(u1);
            bookTicketPage.Show();
            this.Hide();
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
