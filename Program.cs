namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

           var order = new Order();
            order.Payment = new BoletoPayment();

        }

        //pix,cartao,boleto,stripe,applepay...


        

        public class Order
        {
            public Payment Payment { get; set; }
        }

        public enum EPaymentType
        {
            Pix = 1,
            CreditCard = 2,
            Boleto = 3,
        }

       
        //
        // SOLID
        // INTERFACE SEGREGATION PRINCIPLE

        public class PixPayment : Payment
        {
            public bool IsExpired()
            {
                throw new NotImplementedException();
            }

            public void pay()
            {
                throw new NotImplementedException();
            }
        }

        public class CreditCardPayment : Payment
        {
            public void pay()
            {
                throw new NotImplementedException();
            }
        }

        public class BoletoPayment : Payment
        {
            public bool IsExpired()
            {
                throw new NotImplementedException();
            }

            public void pay()
            {
                throw new NotImplementedException();
            }
        }

        public class StripePayment : Payment
        {
            public override void pay()
            {
                base.pay();
            }
        }

        public abstract class Payment
        {
            public virtual void pay()
            {
               //IMPLEMENTACAO

            }

        }

    }
}