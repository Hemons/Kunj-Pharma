using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Service
{
    public class ErrorLogServices
    {
        PMSContext db;
        ErrorLog error;

        public ErrorLogServices()
        {
            db = new PMSContext();
        }

        public void SaveError(Exception ex)
        {
            using (db = new PMSContext())
            {
                error = new ErrorLog
                {
                    CreatedOn = DateTime.Now,
                    HelpLink = ex.HelpLink,
                    HResult = ex.HResult,
                    Message = ex.Message,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace
                };
                db.ErrorLog.Add(error);
                db.SaveChanges();
            }
        }
    }
}
