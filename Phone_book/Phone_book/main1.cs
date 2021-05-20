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

namespace Phone_book
{
    public partial class main1 : Form
    {
        public main1()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection
            {
                ConnectionString = @"server = 127.0.0.1; userid = root; password = 123123; database = phone_book; port=3306"
            }; // connection для настройки подключения к БД
            DataSet ds = new DataSet();


            MySqlDataAdapter ad = new MySqlDataAdapter("Select id as id, surname as Фамилия, name as Имя, patronymic as Отчество, date as Дата_рождения, name_phone as Вид_контакта, phone as Телефон  from person ", con);// параметры- команда для выполнения + connection
            ad.Fill(ds, "Table"); // заполнение DataSet данными из БД
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void add_Click(object sender, EventArgs e) // кнопка "добавить"
        {
            try //проверка на корректность данных
            {
                MySqlConnection con = new MySqlConnection(@"server = 127.0.0.1; userid = root; password = 123123; database = phone_book; port=3306"); //соединение с бд
                con.Open();//соединение с бд
                MySqlCommand command = new MySqlCommand("insert into person(surname, name, patronymic, date, name_phone, phone)" +
                " values (@surname, @name, @patronymic, @date, @name_phone, @phone)")
                {
                    Connection = con//команда для заполнения
                };

                command.Parameters.AddWithValue("surname", textBox1.Text);
                command.Parameters.AddWithValue("name", textBox2.Text);
                command.Parameters.AddWithValue("patronymic", textBox9.Text);
                command.Parameters.AddWithValue("date", textBox4.Text);
                command.Parameters.AddWithValue("name_phone", textBox5.Text);
                command.Parameters.AddWithValue("phone", textBox6.Text);       
                command.ExecuteNonQuery();//выполнение команды
                Form2_Load(sender, e);

            }
            catch (MySqlException)
            {
                MessageBox.Show("Нет соединения");
            }
            catch (MySql.Data.Types.MySqlConversionException)
            {
                MessageBox.Show("Некорректные данные ");
            }

        }



        private void del_Click(object sender, EventArgs e) //кнопка "удалить"
        {
            MySqlConnection con = new MySqlConnection(@"server = 127.0.0.1; userid = root; password = 123123; database = phone_book; port=3306");
            con.Open();//соединение с бд
            MySqlCommand command = new MySqlCommand("delete from  person where id = @delet")
            {
                Connection = con//команда для заполнения
            };
            command.Parameters.AddWithValue("delet", textBox7.Text);
            command.ExecuteNonQuery();//
            Form2_Load(sender, e);
        }

        private void reference_Click(object sender, EventArgs e) //кнопка "справка"
        {
            //переход на форму со справкой
            this.Hide();
            info info = new info();
            info.Show();
        }

        private void output_Click(object sender, EventArgs e) //кнопка "выход"
        {
            //закрыть программу
            Close();
        }

        private void search_Click(object sender, EventArgs e) // кнопка "поиск"
        {
         
                for (int i = 0; i < dataGridView1.RowCount; i++) //пербор строк в dataGridView1
            {
                    dataGridView1.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                            if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox8.Text)) //возвращает значение, записанное в текстовое поле 
                            {
                                dataGridView1.Rows[i].Selected = true;//указывает на выбранную строку
                                break;
                            }

                }
        }

      
    }
    }

