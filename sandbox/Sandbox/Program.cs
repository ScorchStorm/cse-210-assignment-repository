using System;

class Program
{
    static void Main(string[] args)
    {
        Account account = new Account();
        Console.WriteLine($"You have a balance of ${account.GetAccountBalance()}");
        account.Deposit();
        Console.WriteLine($"You have a balance of ${account.GetAccountBalance()}");
        account.Withdraw();
        Console.WriteLine($"You have a balance of ${account.GetAccountBalance()}");
    }
}