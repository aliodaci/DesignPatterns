using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDeseni
{
   class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var builder = new OldCustomerProductBuilder();
            director.GenerateProduct(builder);
            var model=builder.GetViewModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);
            Console.ReadLine();
        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetViewModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel productViewModel = new ProductViewModel();
        public override void ApplyDiscount()
        {
            productViewModel.DiscountedPrice = productViewModel.UnitPrice *(decimal) 0.90;
            productViewModel.DiscountApplied = true;
        }

        public override void GetProductData()
        {
            productViewModel.Id = 1;
            productViewModel.CategoryName = "Beverages";
            productViewModel.ProductName = "Chai";
            productViewModel.UnitPrice = 20;
        }

        public override ProductViewModel GetViewModel()
        {
            return productViewModel;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel productViewModel = new ProductViewModel();
        public override void ApplyDiscount()
        {
            productViewModel.DiscountedPrice = productViewModel.UnitPrice;
            productViewModel.DiscountApplied = false;
        }

        public override void GetProductData()
        {
            productViewModel.Id = 1;
            productViewModel.CategoryName = "Beverages";
            productViewModel.ProductName = "Chai";
            productViewModel.UnitPrice = 20;
        }

        public override ProductViewModel GetViewModel()
        {
            return productViewModel;
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
