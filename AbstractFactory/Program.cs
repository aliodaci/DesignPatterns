using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory2());
            productManager.GetAll();
            Console.ReadLine();
        }
    }

    public abstract class Logging
    {
        public abstract void Log(string message);//method
    }

    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with lo4net");
        }
    }

    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with Nlogged");
        }
    }

    public abstract class Caching
    {
        public abstract void Cahce(string data);
    }

    public class MemCashing : Caching
    {
        public override void Cahce(string data)
        {
            Console.WriteLine("Cached with memche");
        }
    }

    public class RedisCashing : Caching
    {
        public override void Cahce(string data)
        {
            Console.WriteLine("Cached with rediscache");
        }
    }

    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory1 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCashing();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public class Factory2 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCashing();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }

    public class ProductManager
    {
        private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCuttingConcernsFactory crossCuttingFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingFactory;
            _logging=_crossCuttingConcernsFactory.CreateLogger();
            _caching = _crossCuttingConcernsFactory.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log("logged");
            _caching.Cahce("data");
            Console.WriteLine("Products listed'");
        }
    }
}
