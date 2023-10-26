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
    public partial class Form7 : Form
    {
        private SQLiteConnection DB;
        public Form7()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 Администратор = new Form3();
            Администратор.Show();
            this.Close();
        }

        private async void Form7_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.ConnectionString);
            await DB.OpenAsync();

            SQLiteDataAdapter dataadapter = new SQLiteDataAdapter("SELECT * FROM Users", DB);
            DataSet ds = new DataSet();

            dataadapter.Fill(ds, "Info");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string Login = textBox1.Text;

            if (Login != "")
            {
                SQLiteCommand Delete = new SQLiteCommand($"DELETE FROM Users WHERE Login = '{Login}'", DB);
                await Delete.ExecuteNonQueryAsync();
                MessageBox.Show("Удалено");
            }
        }
    }
}
