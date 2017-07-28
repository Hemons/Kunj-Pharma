using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using System.Web;
using PagedList;

namespace PMS.Service
{
    public class AccountServices
    {
        private PMSContext db;
        private ErrorLogServices errorService;
        private SecurityServices security;

        public AccountServices()
        {
            errorService = new ErrorLogServices();
        }

        public bool Verify(RegisterViewModel model)
        {
            try
            {
                using (db = new PMSContext())
                {
                    security = new SecurityServices();
                    string pass = security.Encrypt(model.password, true);

                    var user = db.PMSuser.Where(x => (x.UserName == model.user || x.Email == model.user || x.Phone == model.user) && x.Password == pass && !x.IsDeleted).FirstOrDefault();
                    if (user != null)
                    {
                        AddCookie(user);
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorService.SaveError(ex);
                return false;
            }
        }

        private void AddCookie(PMSuser user)
        {

            HttpCookie cookie = new HttpCookie("user", security.Encrypt(user.Id.ToString(), true));
            cookie.Expires = DateTime.Now.AddDays(1);

            var response = HttpContext.Current.Response;
            response.Cookies.Add(cookie);
        }

        public IPagedList<UserListViewModel> GetUserList(SearchViewModel search)
        {
            try
            {
                using (db = new PMSContext())
                {
                    search.PageNumber = search.PageNumber <= 0 ? 1 : search.PageNumber;
                    search.PageSize = search.PageSize <= 0 ? 1 : search.PageSize;
                    return db.PMSuser.Where(x => !x.IsDeleted).Select(x => new UserListViewModel
                    {
                        CreatedOn = x.CreatedOn,
                        DOB = x.DOB,
                        Email = x.Email,
                        Name = x.Name,
                        Id = x.Id,
                        Phone = x.Phone,
                        UserName = x.UserName
                    }).OrderByDescending(x => x.CreatedOn).ToPagedList(search.PageNumber, search.PageSize);
                }
            }
            catch (Exception ex)
            {
                errorService.SaveError(ex);
                return null;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                using (db = new PMSContext())
                {
                    db.PMSuser.Where(x => x.Id == id).FirstOrDefault().IsDeleted = true;
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                errorService.SaveError(ex);
                return false;
            }
        }
    }
}
