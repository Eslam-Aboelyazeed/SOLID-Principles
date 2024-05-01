namespace OCP
{

    #region Before

    //public class PaymentProcessor
    //{
    //    public void ProcessPayment(PaymentType type, double amount)
    //    {
    //        switch (type)
    //        {
    //            case PaymentType.CreditCard:
    //                // Process credit card payment
    //                break;
    //            case PaymentType.PayPal:
    //                // Process PayPal payment
    //                break;
    //            case PaymentType.BankTransfer:
    //                // Process bank transfer payment
    //                break;
    //                // Add more cases for other payment types
    //        }
    //    }
    //}
    //public enum PaymentType
    //{
    //    CreditCard,
    //    PayPal,
    //    BankTransfer
    //}

    #endregion

    #region After

    public interface IPaymentType
    {
        void ProcessPayment(double amount);
    }

    public class CreditCard : IPaymentType
    {
        public void ProcessPayment(double amount)
        {
            throw new NotImplementedException();
        }
    }

    public class PayPal : IPaymentType
    {
        public void ProcessPayment(double amount)
        {
            throw new NotImplementedException();
        }
    }

    public class BankTransfer : IPaymentType
    {
        public void ProcessPayment(double amount)
        {
            throw new NotImplementedException();
        }
    }

    //public class PaymentProcessor
    //{
    //    public static void ProcessPayment(IPaymentType paymentType, double amount)
    //    {
    //        paymentType.ProcessPayment(amount);
    //    }
    //}

    public class PaymentProcessor
    {
        private readonly IPaymentType paymentType;

        public PaymentProcessor(IPaymentType paymentType)
        {
            this.paymentType = paymentType;
        }

        public void ProcessPayment(double amount)
        {
            paymentType.ProcessPayment(amount);
        }
    }

    #endregion
}
