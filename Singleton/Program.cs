using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager=CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }
    }
    class CustomerManager
    {
        private static CustomerManager _customerManager;//yöneltilecek nesne
        static object _lockObject=new object();
        private CustomerManager()//yapıyı oluştur
        {

        }

        public static CustomerManager CreateAsSingleton()//singleton'ı oluşturacak bir method
        {
            lock (_lockObject)
            {
                if (_customerManager==null)
                {
                    _customerManager = new CustomerManager();
                }
            }return _customerManager;//kontrol 
        }

        public void Save()
        {
            Console.WriteLine("Kaydedildi");
        }
    }
}
