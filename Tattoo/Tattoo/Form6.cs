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
    public partial class Form6 : Form
    {
        private SQLiteConnection DB;
        public Form6()
        {
            InitializeComponent();
        }
        private async void Form6_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.ConnectionString);
            await DB.OpenAsync();

            SQLiteDataAdapter dataadapter = new SQLiteDataAdapter("SELECT * FROM Storage", DB);
            DataSet ds = new DataSet();

            dataadapter.Fill(ds, "Info");
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form3 Администратор = new Form3();
            Администратор.Show();
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string ID = textBox1.Text;
            string ItemAmount = textBox2.Text;

            if (ID != "" && ItemAmount != "")
            {
                SQLiteCommand update = new SQLiteCommand($"UPDATE Storage SET ItemAmount = '{ItemAmount}' WHERE ID = '{ID}'", DB);
                await update.ExecuteNonQueryAsync();
                MessageBox.Show("Обновлено");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kolvo = textBox4.Text;
            string price = textBox5.Text;
            int result = Convert.ToInt32(price) * Convert.ToInt32(kolvo);

            MessageBox.Show("Чтобы купить предмет в количестве " + kolvo + " штук, Вам потребуется " + result + " рублей.","Вычисления", MessageBoxButtons.OK);
        }
    }
}
