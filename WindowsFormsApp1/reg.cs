using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class reg : Form
    {
        public reg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (registration.Checked == true) //выбор регистрации

            {
                try //проверка на корректность данных
                {

                    string connectionString = "server = 127.0.0.1; userid = root; password = 123123; database = phone_book; port=3306";//соединение с бд
                    MySqlConnection connection = new MySqlConnection(connectionString);
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("insert into reg values (@login, @password)")
                    {
                        Connection = connection // команда для заполнения
                    };
                    command.Parameters.AddWithValue("login", textBox1.Text);
                    command.Parameters.AddWithValue("password", textBox2.Text);
                    command.ExecuteNonQuery();//выполнение команды               
                    MessageBox.Show("Вы зарегистрировались");
                    Log.Logger("Успешная регистрация");

                }
                catch (MySqlException) ////проверка соединения с бд
                {
                    MessageBox.Show("Возникла ошибка при регистрации");
                    Log.Logger("Неудачная регистрация");
                }
            }
            else if (authorization.Checked == true) //выбор авторизации

            {
                try //проверка на корректрость данных
                {

                    MySqlConnection con = new MySqlConnection(@"server = 127.0.0.1; userid = root; password = 123123; database = phone_book; port=3306");//соединение с бд
                    MySqlDataAdapter users = new MySqlDataAdapter($"Select Count(*) From reg Where login= '{textBox1.Text}' and password = '{textBox2.Text}'", con);
                    DataTable dt = new DataTable();
                    users.Fill(dt);
                    Log.Logger("Удачная авторизация");

                    if (dt.Rows[0][0].ToString() == "1") //переход на главную форму при выборе авторизации и заполненных полей с логином и паролем
                    {

                        {
                            this.Hide();
                            main1 main = new main1();
                            main.Show();
                        }
                    }


                }
                catch (FormatException)//проверка на корректрость данных
                {
                    MessageBox.Show("Ошибка при вводе данных!");
                    Log.Logger("Неудачная авторизация");
                }
                catch (MySqlException)//проверка соединения с бд
                {
                    MessageBox.Show("Возникли неполадки с базой данных");
                    Log.Logger("Неудачная авторизация");
                }
            }
        }

        private void authorization_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
  
