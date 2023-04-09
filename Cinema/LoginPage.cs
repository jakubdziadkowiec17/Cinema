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

namespace Cinema
{
    public partial class LoginPage : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;password=;database=cinema");
        public LoginPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterPage registerpage=new RegisterPage();
            registerpage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand();

            try
            {
                connection.Open();
                String q = "SELECT * FROM users WHERE email = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'";

                command.CommandText = q;
                command.Connection = connection;
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string surname = reader.GetString(2);
                        string email = reader.GetString(3);
                        string phone = reader.GetString(4);
                        string password = reader.GetString(5);
                        string address = reader.GetString(6);
                        User user = new User(id, name, surname, email, phone, password, address);

                        MainPage main = new MainPage(user);
                        main.Show();
                        this.Hide();
                        
                    }
                }
                else if (textBox1.TextLength == 0 || textBox2.TextLength == 0)
                {
                    MessageBox.Show("Puste pole logowania.", "Error");
                }
                else
                {
                    MessageBox.Show("Wpisz poprawne dane.", "Error");
                }
            }
            catch
            {
                MessageBox.Show("Error.", "Error");
            }
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
