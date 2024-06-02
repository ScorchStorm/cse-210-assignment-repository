public class Account
{
    private float _balance;

    public float Withdraw()
    {
        Console.WriteLine("How much would you like to withdraw from your account? ");
        public float _amount = float.Parse(Console.ReadLine());
        if (_amount > _balance)
        {
            return 0;
        }
        _balance -= _amount;
        return _amount;
    }

    public void Deposit()
    {
        Console.WriteLine("How much would you like to deposit into your account? ");
        _amount = float.Parse(Console.ReadLine());
        _balance += _amount;
    }
    public float GetAccountBalance()
    {
        return _balance;
    }
}