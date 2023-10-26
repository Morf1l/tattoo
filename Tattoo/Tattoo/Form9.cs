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
    public partial class Form9 : Form
    {
        private SQLiteConnection DB;
        public Form9()
        {
            InitializeComponent();
        }
        private async void Form9_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.ConnectionString);
            await DB.OpenAsync();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Form3 Администратор = new Form3();
            Администратор.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string TakedBy = textBox1.Text;

            SQLiteDataAdapter dataadapter = new SQLiteDataAdapter($"SELECT * FROM Orders WHERE TakedBy='{TakedBy}'", DB);
            DataSet ds = new DataSet();

            dataadapter.Fill(ds, "Info");
            dataGridView1.DataSource = ds.Tables[0];
        }

    }
}
