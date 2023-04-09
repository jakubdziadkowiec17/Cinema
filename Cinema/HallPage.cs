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
    public partial class HallPage : Form
    {
        User u1 = null;
        public HallPage(User user)
        {
            InitializeComponent();
            u1=user;
        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            BookTicketPage bookTicketPage = new BookTicketPage(u1);
            bookTicketPage.Show();
            this.Hide();
        }

        private void HallPage_Load(object sender, EventArgs e)
        {
            if (u1.email == "admin@cinema.pl")
            {
                button6.Hide();
                button5.Show();
                button8.Show();
            }
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
