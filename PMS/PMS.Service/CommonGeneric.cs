using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;


namespace PMS.Service
{
    public class CommonGeneric<T> where T : class
    {
        private readonly PMSContext db;
        private readonly ErrorLogServices errorService;

        public CommonGeneric()
        {
            db = new PMSContext();
            errorService = new ErrorLogServices();
        }

        public T GetById(Guid Id)
        {
            try
            {
                return db.Set<T>().Find(Id);
            }
            catch (Exception ex)
            {
                errorService.SaveError(ex);
                return null;
            }
        }

        public List<T> GetList(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return db.Set<T>().Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                errorService.SaveError(ex);
                return new List<T>();
            }
        }
        
    }
}
