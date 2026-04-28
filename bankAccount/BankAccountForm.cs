using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bankAccount
{
    public partial class BankAccountForm : Form
    {
        private BankAccount account;
        private TextBox nameTextBox;
        private TextBox amountTextBox;
        private Label balanceLabel;
        private Button createAccountButton;
        private Button depositButton;
        private Button withdrawButton;
        public BankAccountForm()
        {
            this.Text = "Управление банковским счётом";
            this.Width = 400;
            this.Height = 300;
            nameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Width = 200,

            };
            amountTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 40),
                Width = 200,

            };
            createAccountButton = new Button
            {
                Location = new System.Drawing.Point(10, 70),
                Text = "Создать счёт",
                Width = 100
            };
            createAccountButton.Click += CreateAccountButton_Click;
            depositButton = new Button
            {
                Location = new System.Drawing.Point(120, 70),
                Text = "Пополнить",
                Width = 100
            };
            depositButton.Click += DepositButton_Click;
            withdrawButton = new Button
            {
                Location = new System.Drawing.Point(10, 100),
                Text = "Снять",
                Width = 210
            };
            withdrawButton.Click += WithdrawButton_Click;
            balanceLabel = new Label
            {
                Location = new System.Drawing.Point(10, 130),
                Width = 200,
                Text = "Баланс: 0"
            };
            this.Controls.Add(nameTextBox);
            this.Controls.Add(amountTextBox);
            this.Controls.Add(createAccountButton);
            this.Controls.Add(depositButton);
            this.Controls.Add(withdrawButton);
            this.Controls.Add(balanceLabel);
        }
        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Введите имя владельца!");
                return;
            }
            if (string.IsNullOrEmpty(amountTextBox.Text))
            {
                MessageBox.Show("Введите начальную сумму!");
                return;
            }
            decimal initialBalance;
            if (!decimal.TryParse(amountTextBox.Text, out initialBalance))
            {
                MessageBox.Show("Неверный формат суммы!");
                return;
            }
            account = new BankAccount(nameTextBox.Text, initialBalance);
            balanceLabel.Text = $"Баланс: {initialBalance}";
            MessageBox.Show("Счёт создан!");
        }
        private void DepositButton_Click(object sender, EventArgs e)
        {
            if (account == null)
            {
                MessageBox.Show("Сначала создайте счёт!");
                return;
            }
            if (string.IsNullOrEmpty(amountTextBox.Text))
            {
                MessageBox.Show("Введите сумму для пополнения!");
                return;
            }
            decimal amount;
            if (!decimal.TryParse(amountTextBox.Text, out amount))
            {
                MessageBox.Show("Неверный формат суммы!");
                return;
            }
            try
            {
                account.Deposit(amount);
                balanceLabel.Text = $"Баланс: {account.GetBalance()}";
                MessageBox.Show("Счёт пополнен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            if (account == null)
            {
                MessageBox.Show("Сначала создайте счёт!");
                return;
            }
            if (string.IsNullOrEmpty(amountTextBox.Text))
            {
                MessageBox.Show("Введите сумму для снятия!");
                return;
            }
            decimal amount;
            if (!decimal.TryParse(amountTextBox.Text, out amount))
            {
                MessageBox.Show("Неверный формат суммы!");
                return;
            }
            try
            {
                account.Withdraw(amount);
                balanceLabel.Text = $"Баланс: {account.GetBalance()}";
                MessageBox.Show("Средства сняты!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}
