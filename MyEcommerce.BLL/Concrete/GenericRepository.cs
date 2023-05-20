using Microsoft.EntityFrameworkCore;
using MyEcommerce.BLL.Abstract;
using MyEcommerce.DAL.Context;
using MyEcommerce.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommerce.BLL.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MyEcommerceContext _db;

        private readonly DbSet<T> _entities;
        public GenericRepository(MyEcommerceContext db)
        {
            _db = db;

            _entities = _db.Set<T>();
        }   

        public string Create(T entity)
        {
            try
            {
                _entities.Add(entity);
                _db.SaveChanges();
                return "Veri kaydedildi";
            }
            catch (Exception ex)
            {
                return ex.Message;
                
            }
        }

        public string Delete(T entity)
        {
            try
            {
                var deleted = GetById(entity.Id);
                deleted.Status = Entity.Enum.Status.deleted;
                Update(deleted);
                return "Veri Silindi";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.Where(x => x.Status == Entity.Enum.Status.created || x.Status==Entity.Enum.Status.updated);
        }

        public T GetById(int id)
        {
            var entity = _entities.Find(id);
            return entity;
           
        }

        public string Update(T entity)
        {
            string result = "";
            try
            {
                switch (entity.Status)
                {
                    case Entity.Enum.Status.created:
                        entity.Status = Entity.Enum.Status.updated; 
                        _db.Entry(entity).State=EntityState.Modified;
                        _db.SaveChanges();
                        result = "Veri güncellendi";

                        break; 
                    case Entity.Enum.Status.deleted:
                        entity.Status=Entity.Enum.Status.deleted;
                        _db.SaveChanges();
                        result = "Veri güncellendi";

                        break;
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return result;
        }
    }
} 
