using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadKey();
        }
    }
    class Logging:ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }

        
    }

    public interface ILogging
    {
         void Log(); // TODO:public koyunca neden hata alıyorum ?
    }

    public class Caching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("cached");
        }
    }

    public interface ICaching
    {
        void Cache();
    }

    public class Authorize:IAuthorize
    {
        
        public void CheckUser()
        {
            Console.WriteLine("User checked");
        }
    }

    public interface IAuthorize
    {
        void CheckUser();
    }

    class CustomerManager
    {
        private CrossCuttongConcernFacede _concerns;

        public CustomerManager()
        {
            _concerns = new CrossCuttongConcernFacede();
        }
        public void Save()
        {
            _concerns.Logging.Log();
            _concerns.Caching.Cache();
            _concerns.Authorize.CheckUser();
            Console.WriteLine("Saved");
        }

        
    }

    public class CrossCuttongConcernFacede
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;

        public CrossCuttongConcernFacede()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
        }

    }
}
