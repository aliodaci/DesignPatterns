using FacadeDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager=new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }

    class Logging:ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    interface ILogging
    {
        void Log();
    }

    class Caching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Caching");
        }
    }

    interface ICaching
    {
        void Cache();
    }

    class Authorize:IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("Auothrized");
        }
    }


    interface IAuthorize
    {
        void CheckUser();
    }

    interface IValidation
    {
        void Validate();
    }

    class Validation : IValidation
    {
        public void Validate()
        {
            Console.WriteLine("Validated");
        }
    }


    class CustomerManager
    {
        private CrossCuttingConcernsFacade _concernsFacade;

        public CustomerManager()
        {
            _concernsFacade = new CrossCuttingConcernsFacade();
        }

        public void Save()
        {
            _concernsFacade.Logging.Log();
            _concernsFacade.Cache.Cache();
            _concernsFacade.Authorize.CheckUser();
            _concernsFacade.Validation.Validate();
            Console.WriteLine("Saved");
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public ICaching Cache;
        public IAuthorize Authorize;
        public IValidation Validation;

        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Cache = new Caching();
            Authorize = new Authorize();
            Validation = new Validation();  
        }
    }
}
