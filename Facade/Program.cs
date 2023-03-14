namespace Facade
{
    /// <summary>
    /// Facade Design Pattern
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            ShopFacade.getInstance().buyProductByCashWithFreeShipping("18520282@gm.uit.edu.vn");
            ShopFacade.getInstance().buyProductByPaypalWithStandardShipping("uit@gmail.edu.vn", "0123456789");
            // Wait for user
            Console.ReadKey();
        }
    }
    #region Facade
    public class ShopFacade
    {
        private static ShopFacade _instance;

        private AccountService accountService;
        private PaymentService paymentService;
        private ShippingService shippingService;
        private EmailService emailService;
        private SmsService smsService;

        private ShopFacade()
        {
            accountService = new AccountService();
            paymentService = new PaymentService();
            shippingService = new ShippingService();
            emailService = new EmailService();
            smsService = new SmsService();
        }

        public static ShopFacade getInstance()
        {
            if (_instance == null)
                _instance = new ShopFacade();
            return _instance;
        }

        public void buyProductByCashWithFreeShipping(string email)
        {
            Console.WriteLine("buyProductByCashWithFreeShipping");
            accountService.GetAccount(email);
            paymentService.PaymentByCash();
            shippingService.FreeShipping();
            emailService.SendMail(email);
            Console.WriteLine("Done\n");
        }

        public void buyProductByPaypalWithStandardShipping(string email, string mobilePhone)
        {
            Console.WriteLine("buyProductByPaypalWithStandardShipping");
            accountService.GetAccount(email);
            paymentService.PaymentByPaypal();
            shippingService.StandardShipping();
            emailService.SendMail(email);
            smsService.sendSMS(mobilePhone);
            Console.WriteLine("Done\n");
        }
    }

    #endregion
    #region SubSystem
    public class AccountService
    {
        public void GetAccount(string email)
        {
            Console.WriteLine("Getting the account of " + email);
        }
    }

    public class EmailService
    {
        public void SendMail(string mailTo)
        {
            Console.WriteLine("Sending an email to " + mailTo);
        }
    }

    public class PaymentService
    {
        public void PaymentByPaypal()
        {
            Console.WriteLine("Payment by Paypal");
        }
        public void PaymentByCreditCard()
        {
            Console.WriteLine("Payment by Credit Card");
        }
        public void PaymentByEBankingAccount()
        {
            Console.WriteLine("Payment by E-banking account");
        }
        public void PaymentByCash()
        {
            Console.WriteLine("Payment by cash");
        }
    }

    public class ShippingService
    {
        public void FreeShipping()
        {
            Console.WriteLine("Free Shipping");
        }

        public void StandardShipping()
        {
            Console.WriteLine("Standard Shipping");
        }

        public void ExpressShipping()
        {
            Console.WriteLine("Express Shipping");
        }
    }

    public class SmsService
    {
        public void sendSMS(string mobilePhone)
        {
            Console.WriteLine("Sending an message to " + mobilePhone);
        }
    }

    #endregion
}