namespace LSP
{

    #region Before 
    //public class Account
    //{
    //    public decimal Balance { get; protected set; }
    //    public virtual void Deposit(decimal amount)
    //    {
    //        Balance += amount;
    //    }
    //    public virtual void Withdraw(decimal amount)
    //    {
    //        if (Balance >= amount)
    //        {
    //            Balance -= amount;
    //        }
    //        else
    //        {
    //            throw new InvalidOperationException("Insufficient balance.");
    //        }
    //    }
    //}
    //public class SavingsAccount : Account
    //{
    //    public decimal InterestRate { get; set; }
    //    public override void Withdraw(decimal amount)
    //    {
    //        // Impose a withdrawal fee
    //        amount += 5.0m;
    //        base.Withdraw(amount);
    //    }
    //}

    #endregion


    #region After

    public abstract class Account
    {
        public decimal Balance { get; set; }

        public abstract void Deposit(decimal amount);
        public abstract void Withdraw(decimal amount);

    }

    public class RegularAccount : Account
    {
        public override void Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public override void Withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }
    }

    public class SavingAccount : Account
    {
        public decimal InterestRate { get; set; }

        public override void Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public override void Withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }
    }

    #endregion

}
