using PagedList;
using PMS.Model;
using PMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PMS.Controllers
{
    public class AccountController : Controller
    {
        private AccountServices _service;


        public AccountController()
        {
            _service = new AccountServices();
        }

        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(RegisterViewModel model, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //model.Invalid = _service.Verify(model);
            if (_service.Verify(model))
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Please check username and password.");
            return View(model);
        }

        [HttpGet]
        public ActionResult Users()
        {
            SearchViewModel search = new SearchViewModel();
            IPagedList<UserListViewModel> models = _service.GetUserList(search);
            return View(models);
        }

        [HttpGet]
        public PartialViewResult UserList(SearchViewModel search)
        {
            return PartialView("_list", _service.GetUserList(search));
        }

        [HttpGet]
        public ActionResult Register(Guid? Id)
        {
            UserRegisterViewModel model = new UserRegisterViewModel();
            Id = new Guid("BF60FF99-0E9E-4E75-8B4F-5C70CBD3B4A0");
            if (Id != Guid.Empty && Id != null)
            {
                CommonGeneric<PMSuser> _commonservice = new CommonGeneric<PMSuser>();
                var data = _commonservice.GetById(Id.Value);
                model = new UserRegisterViewModel(data.Id, data.Name, data.UserName, data.Phone, data.Email, data.DOB);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Register(UserRegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);

            }
            return View(register);
        }

        [HttpGet]
        public JsonResult Delete(Guid Id)
        {
            return Json(_service.Delete(Id), JsonRequestBehavior.AllowGet);
        }
    }
}