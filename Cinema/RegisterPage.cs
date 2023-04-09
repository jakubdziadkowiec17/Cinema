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
    public partial class RegisterPage : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;password=;database=cinema");
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPage loginpage = new LoginPage();
            loginpage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0 || textBox7.Text.Length == 0)
            {
                MessageBox.Show("Uzupełnij puste pola", "Error");
                return;
            }

            try
            {
                 connection.Open();
                 string sqlQuery = "INSERT INTO users (name, surname, email, phone, password, address) VALUES (@name, @surname, @email, @phone, @password, @address)";
                 MySqlCommand command = new MySqlCommand(sqlQuery, connection);
                 command.Parameters.AddWithValue("@name", textBox1.Text);
                 command.Parameters.AddWithValue("@surname", textBox2.Text);
                 command.Parameters.AddWithValue("@password", textBox3.Text);
                 command.Parameters.AddWithValue("@email", textBox5.Text);
                 command.Parameters.AddWithValue("@phone", textBox6.Text);
                 command.Parameters.AddWithValue("@address", textBox7.Text);
                 command.ExecuteNonQuery();
                 connection.Close();

                 LoginPage loginpage = new LoginPage();
                 loginpage.Show();
                 this.Hide();
            }
            catch
            {
                MessageBox.Show("Błąd rejestracji. Podany login posiada już konto.", "BarberShop");
            }
        }

        private void RegisterPage_Load(object sender, EventArgs e)
        {

        }
    }
}
