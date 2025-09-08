using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager=CustomerManager.CreateAsSingleton();
        }
    }

    class CustomerManager
    {
        static object _lockObject = new object(); //Thread Safe Singleton için
        private static CustomerManager _customerManager;
        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            };
            

            return _customerManager;
        }
    }
}