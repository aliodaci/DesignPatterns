using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel=new StandardKernel();
            kernel.Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
            productManager.Save();


            Console.ReadLine();
        }
    }

    interface IProductDal
    {
        void Save();
    }

    class EfProductDal:IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Save with EF");
        }
    }

    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Save with Nh");
        }
    }

    class ProductManager
    {
        IProductDal _product;

        public ProductManager(IProductDal product)
        {
            _product = product;
        }

        public void Save()
        {
            //Business Code
            _product.Save();
        }
    }
}
