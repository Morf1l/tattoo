using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Security.Cryptography.X509Certificates;

namespace Tattoo
{
    public partial class Form1 : Form
    {
        private SQLiteConnection DB;
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.ConnectionString);
            await DB.OpenAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string Login = textBox1.Text;
            string Password = textBox2.Text;

            if (Login != "" && Password != "")
            {
                SQLiteDataReader read;
                SQLiteCommand commandRead = new SQLiteCommand($"SELECT * FROM [{Table_Users.main}]" + $" WHERE {Table_Users.Login}=@Login " + $"AND {Table_Users.Password}=@Password", DB);
                commandRead.Parameters.AddWithValue("Login", Login);
                commandRead.Parameters.AddWithValue("Password", Password);
                read = (SQLiteDataReader)await commandRead.ExecuteReaderAsync();
                if (await read.ReadAsync())
                {
                    if (read[$"{Table_Users.Status}"].ToString() == "Admin")
                    {
                        Form3 Админ = new Form3();
                        Админ.Show();
                        this.Hide();
                        
                    }
                    if (read[$"{Table_Users.Status}"].ToString() == "Worker")
                    {
                        Form4 Сотрудник = new Form4();
                        Сотрудник.Show();
                        this.Hide();
                    }
                    if (read[$"{Table_Users.Status}"].ToString() == "User")
                    {
                        Form5 Пользователь = new Form5();
                        Пользователь.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Данные неверные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                read.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 Регистрация = new Form2();
            Регистрация.Show();
            this.Hide();
        }
    }
}
