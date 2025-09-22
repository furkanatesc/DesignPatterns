using System;

namespace DecoratorOrnegim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar { Make = "BMW", Model = "3.20", HirePrice = 2500m };

            // %10 indirim uygulayan dekoratör
            var discounted = new SpecialOffer(personalCar) { DiscountPercentage = 10 };

            // Üstüne sabit 150 birim sigorta ücreti ekleyen dekoratör
            var insured = new InsuranceOffer(discounted) { InsuranceFee = 150m };

            Console.WriteLine("Base (Concrete)     : {0}", personalCar.HirePrice); // 2500
            Console.WriteLine("Special Offer       : {0}", discounted.HirePrice);  // 2250
            Console.WriteLine("Special+Insurance   : {0}", insured.HirePrice);     // 2250 + 150 = 2400

            Console.ReadLine();
        }
    }

    // 1) Ortak sözleşme
    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    // 2) Somut arabalar
    class PersonalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    // 3) Dekoratör tabanı: İçeriği sarar ve varsayılan delegasyon yapar
    abstract class CarDecoratorBase : CarBase
    {
        protected readonly CarBase Inner;

        protected CarDecoratorBase(CarBase inner)
        {
            Inner = inner;
        }

        // Varsayılan davranış: içteki arabaya delegasyon
        public override string Make //bmw
        {
            get => Inner.Make;
            set => Inner.Make = value;
        }

        public override string Model //3.20
        {
            get => Inner.Model;
            set => Inner.Model = value;
        }

        public override decimal HirePrice //2250
        {
            get => Inner.HirePrice;
            set => Inner.HirePrice = value;
        }
    }

    // 4a) İndirim uygulayan dekoratör
    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountPercentage { get; set; }

        public SpecialOffer(CarBase inner) : base(inner) 
        {

        }

        public override decimal HirePrice
        {
            get
            {
                var basePrice = base.HirePrice; // Inner.HirePrice
                return basePrice - (basePrice * DiscountPercentage / 100m); // 2500-(2500*10/100
            }
            set => base.HirePrice = value; // isteğe bağlı: tabanı da güncelleyebilir
        }
    }

    // 4b) Sigorta ücreti ekleyen dekoratör
    class InsuranceOffer : CarDecoratorBase
    {
        public decimal InsuranceFee { get; set; }

        public InsuranceOffer(CarBase inner) : base(inner) { }

        public override decimal HirePrice
        {
            get => base.HirePrice + InsuranceFee; // önceki (dekorlu) fiyata ekle
            set => base.HirePrice = value;
        }
    }
}
