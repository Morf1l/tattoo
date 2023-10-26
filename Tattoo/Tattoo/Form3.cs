using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tattoo
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 Контроль = new Form6();
            Контроль.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 Пользователи = new Form7();
            Пользователи.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 Заказы = new Form8();
            Заказы.Show();
            this.Close();
        }
    }
}
