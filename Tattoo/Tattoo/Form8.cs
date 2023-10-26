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
    public partial class Form8 : Form
    {
        private SQLiteConnection DB;
        public Form8()
        {
            InitializeComponent();
        }
        private async void Form8_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.ConnectionString);
            await DB.OpenAsync();

            SQLiteDataAdapter dataadapter = new SQLiteDataAdapter("SELECT * FROM Orders", DB);
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

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteDataAdapter dataadapter = new SQLiteDataAdapter("SELECT * FROM Orders", DB);
            DataSet ds = new DataSet();

            dataadapter.Fill(ds, "Info");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLiteDataAdapter dataadapter = new SQLiteDataAdapter("SELECT * FROM Orders WHERE TakedBy = 'None'", DB);
            DataSet ds = new DataSet();

            dataadapter.Fill(ds, "Info");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string ID = textBox1.Text;
            string Login = textBox2.Text;

            if (ID != "" && Login != "")
            {
                SQLiteCommand update = new SQLiteCommand($"UPDATE Orders SET TakedBy = '{Login}' WHERE ID = '{ID}'", DB);
                await update.ExecuteNonQueryAsync();
                MessageBox.Show("Обновлено");
            }
        }
    }
}
