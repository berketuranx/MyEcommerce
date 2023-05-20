using MyEcommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommerce.DAL.Seed
{
    internal class ProductSeed
    {
        public static List<Product> products = new List<Product>()
        {
            new Product{Id=1,ProductName="Nike Airmax",Description="yazlık sneaker",CategoryId=1,UnitPrice=2000,UnitsInStock=50},
             new Product{Id=2,ProductName="Lenovo Tablet",Description="Tablet",CategoryId=2,UnitPrice=20000,UnitsInStock=5},
             new Product{Id=3,ProductName="Kenzo",Description="Yazlık fresh koku",CategoryId=3,UnitPrice=1000,UnitsInStock=10}
        };
    }
}
