using Core.CoreEntity;
using Core.Service;
using DAL.Contextt;
using DAL.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : EntityRepository
    {
        
        ProjeContext db = DbContextSingleton.Context;

        public ProjeContext GetContext()
        {
            return db;
        }

        public string Add(T model)
        {

            try
            {

                db.Set<T>().Add(model);
                db.SaveChanges();
                return "veri eklendi!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Add(List<T> models)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Any(exp);
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public string Delete(int id)
        {
            try
            {
                T deleted = GetById(id);
                deleted.DataStatus = Core.Enum.DataStatus.Deleted;
                Update(deleted);
                db.SaveChanges();
                return "veri silindi";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp).ToList();
        }

        public List<T> GetList()
        {
            return db.Set<T>().ToList();
        }

        public string RemoveForce(T model)
        {
            try
            {
                db.Set<T>().Remove(model);
                db.SaveChanges();
                return "veri kalıcı olarak silindi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string Update(T model)
        {

            try
            {
                T updated = GetById(model.Id);


                DbEntityEntry entity = db.Entry(updated);
                entity.CurrentValues.SetValues(model);

                db.SaveChanges();
                return $"{model.Id} nolu veri güncellendi";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

       

    }
}
