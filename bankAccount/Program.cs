using System;
using System.Windows.Forms;
public class BankAccount
{
    private string ownerName;
    private decimal balance;
    private const decimal maxAmount = 1000000;
    public BankAccount(string ownerName, decimal initialBalance)
    {
        this.ownerName = ownerName;
        this.balance = initialBalance;
    }
    public string GetOwnerName()
    {
        return ownerName;
    }
    public decimal GetBalance()
    {
        return balance;
    }
    public void Deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Сумма пополнения не может быть отрицательной.");
        }
        if (amount > maxAmount)
        {
            throw new ArgumentException($"Сумма пополнения не может превышать { maxAmount }.");
        }
        balance += amount;
    }
    public void Withdraw(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Сумма снятия не может быть отрицательной.");
        }
        if (amount > maxAmount)
        {
            throw new ArgumentException($"Сумма снятия не может превышать { maxAmount }.");
        }
        if (amount > balance)
        {
            throw new InvalidOperationException("Недостаточно средств на счёте.");
        }
        balance -= amount;
    }
}
public class BankAccountForm : Form
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
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new BankAccountForm());
    }
}