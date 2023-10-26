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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tattoo
{
    public partial class Form5 : Form
    {
        private SQLiteConnection DB;
        public Form5()
        {
            InitializeComponent();
        }
        private async void Form5_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.ConnectionString);
            await DB.OpenAsync();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            string Login = textBox1.Text;
            string Comment = textBox2.Text;
            string TakedBy = "None";
            string Tattoo = label6.Text;

            if (Login != "" && Comment != "")
            {
                SQLiteCommand insert = new SQLiteCommand($"INSERT INTO [{Table_Orders.main}] (Login,Comment,TakedBy, Tattoo) " + $"VALUES (@Login,@Comment,@TakedBy,@Tattoo)", DB);
                insert.Parameters.AddWithValue("Login", Login);
                insert.Parameters.AddWithValue("Comment", Comment);
                insert.Parameters.AddWithValue("TakedBy", TakedBy);
                insert.Parameters.AddWithValue("Tattoo", Tattoo);
                await insert.ExecuteNonQueryAsync();
                MessageBox.Show("Вы успешно оформили заказ", "Оформление заказа", MessageBoxButtons.OK);
                Form1 Авторизация = new Form1();
                Авторизация.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = "Курящая девушка";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "Ангел абстракции";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label6.Text = "Ворон";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label6.Text = "Анубис";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label6.Text = "Хранитель";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label6.Text = "Топоры";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label6.Text = "Акула";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label6.Text = "Дракон";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label6.Text = "Свой эскиз";
        }
    }
}
