using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditBase creditBase = new CreditManagerProxy();
            Console.WriteLine(creditBase.Calculater());
            Console.WriteLine(creditBase.Calculater());

            Console.ReadLine();
        }
    } 

    abstract class CreditBase
    {
       public abstract int Calculater();
    }

    class CreditManager : CreditBase
    {
        public override int Calculater()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }
            return result;
        }
    }

    class CreditManagerProxy : CreditBase
    {
        private CreditManager _creditManager;
        private int _cachedValue;
        public override int Calculater()
        {
            if (_creditManager==null)
            {
                _creditManager=new CreditManager();
                _cachedValue=_creditManager.Calculater();
            }
            return _cachedValue;
        }
    }
}
