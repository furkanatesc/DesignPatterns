using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerManager manager = new CustomerManager();
            manager.CreditCalculatorBase = new Before2010CreditCalculator();
            manager.SaveCredit();
            

            manager.CreditCalculatorBase = new After2010CreditCalculator();
            manager.SaveCredit();
            Console.ReadLine();

        }

        abstract class CreditCalculatorBase
        {
            public abstract void Calculate();
        }

        class Before2010CreditCalculator : CreditCalculatorBase
        {
            public override void Calculate()
            {
                Console.WriteLine("Credit calculated using before2010");
            }
        }

        class After2010CreditCalculator : CreditCalculatorBase
        {
            public override void Calculate()
            {
                Console.WriteLine("Credit calculated using after2010");
            }
        }

        class CustomerManager
        {
            public CreditCalculatorBase CreditCalculatorBase { get; set; }
            public void SaveCredit()
            {
                Console.WriteLine("Customer amanager business");
                CreditCalculatorBase.Calculate();
            }
        }
    }
}
