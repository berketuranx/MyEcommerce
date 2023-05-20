using MyEcommerce.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommerce.DAL.Seed
{
    internal class CategorySeed
    {
        public static List<Category> categories = new List<Category>()
        {
            new Category{Id=1,CategoryName="Giyim",Description="Yazlı kışlık giyim ürünleri"},
            new Category{Id=2,CategoryName="Teknoloji",Description="bilgisayar, telefon, tables"},
            new Category{Id=3,CategoryName="Kozmetik",Description="parfüm, makyaj malzemeleri"}

        };
    }
}
