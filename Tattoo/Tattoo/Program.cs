using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tattoo
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    static class DataBase // строка подключения к БД
    {
        public static string ConnectionString = @"Data Source=ladno.db; Integrated Security=False; MultipleActiveResultSets=True";
    }

    static class Table_Orders
    {
        public static string main = "Orders";
        public static string ID = "ID";
        public static string Cost = "Cost";
        public static string Login = "Login";
        public static string Comment = "Comment";
        public static string TakedBy = "TakedBy";
        public static string OrderStatus = "OrderStatus";
    }
    static class Table_Storage
    {
        public static string main = "Storage";
        public static string ID = "ID";
        public static string ItemName = "ItemName";
        public static string ItemAmount = "ItemAmount";
    }
    static class Table_Users
    {
        public static string main = "Users";
        public static string ID = "ID";
        public static string Login = "Login";
        public static string Password = "Password";
        public static string Name = "Name";
        public static string Phone = "Phone";
        public static string Status = "Status";
    }
}
