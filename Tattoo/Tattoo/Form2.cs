using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tattoo
{
    public partial class Form2 : Form
    {
        private SQLiteConnection DB;
        public Form2()
        {
            InitializeComponent();
        }
        private async void Form2_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.ConnectionString);
            await DB.OpenAsync();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 Авторизация = new Form1();
            Авторизация.Show();
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string Login = textBox1.Text;
            string Password = textBox2.Text;
            string Name = textBox3.Text;
            string Phone = textBox4.Text;
            string Status = "User";

            if (Login != "" && Password != "" && Name != "" && Phone != "")
            {
                SQLiteCommand insert = new SQLiteCommand($"INSERT INTO [{Table_Users.main}] (Login,Password,Name,Phone,Status) " + $"VALUES (@Login,@Password,@Name,@Phone,@Status)", DB);
                insert.Parameters.AddWithValue("Login", Login);
                insert.Parameters.AddWithValue("Password", Password);
                insert.Parameters.AddWithValue("Name", Name);
                insert.Parameters.AddWithValue("Phone", Phone);
                insert.Parameters.AddWithValue("Status", Status);
                await insert.ExecuteNonQueryAsync();
                MessageBox.Show("Вы успешно зарегистрированы", "Регистрация", MessageBoxButtons.OK);
                Form1 Авторизация = new Form1();
                Авторизация.Show();
                this.Close();
            }
            else
            { 
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
