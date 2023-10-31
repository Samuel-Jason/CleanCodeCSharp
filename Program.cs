using Microsoft.Data.SqlClient;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var order = new Order();

        }
        //pix,cartao,boleto,stripe,applepay...

        public interface ISqlConnection
        {

        }


        internal abstract class Payment
        {
            private const int _DaysToExpire = 2;
            private readonly ISqlConnection _conn;

            public Payment(ISqlConnection conn)
            {

            }
            public virtual void pay()
            {
                //IMPLEMENTACAO
            }

            // struct - value type
            // 01/01/1900 com ? o padrao se torna null
            public DateTime? ExpireDate { get; private set; }
                = DateTime.Now.AddDays(_DaysToExpire);

        }

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



    }
}