using System;

namespace Q1
{
    public delegate void AccountDelegate(double money, double amount);
    class Account
    {
        public int AccNo;
        public double Amount;
        public event AccountDelegate SmallAmount;
        public void Deposit(double money) { Amount += money; }
        public void Withdraw(double money) { 
            if (Amount - money >= 0) {
                Amount -= money;
            }
            else
            {
                SmallAmount?.Invoke(money,Amount);
            }
            
        }
        public override string ToString() => $"Account: {AccNo}, Current balance: {Amount}";

        
    }

  
    internal class Program
    {
         private static void Account_SmallAmount(double money, double amount) 
            => Console.WriteLine($"Your withdraw amount {money} is larger than balance {amount}. No withdraw recorded");
       
        static void Main(string[] args)
        {
            double money;
            Account account = new Account { AccNo = 100, Amount = 2000 };
            account.SmallAmount += Account_SmallAmount;
            Console.WriteLine("OUTPUT:");
            Console.WriteLine(account);

            Console.Write("Deposit:");
            money = double.Parse(Console.ReadLine());
            account.Deposit(money);
            Console.WriteLine(account);

            Console.Write("Withdraw:");
            money = double.Parse(Console.ReadLine());
            account.Withdraw(money);
            Console.WriteLine(account);

            Console.Write("Withdraw:");
            money = double.Parse(Console.ReadLine());
            account.Withdraw(money);
            Console.WriteLine(account);

            Console.Read();
        }
    }
}
