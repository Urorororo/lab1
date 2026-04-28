using System;
using System.Windows.Forms;

namespace bankAccount
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BankAccountForm());
        }
    }
}