using MyEcommerce.Entity.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommerce.BLL.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity 
    {
        IEnumerable<T> GetAll();
        string Create(T entity);
        string Update(T entity);
        string Delete(T entity);
        T GetById(int id);
    }
}
