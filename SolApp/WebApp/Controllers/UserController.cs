using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(CreateUserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (WebAppDBEntities db = new WebAppDBEntities())
                    {
                        var user = new users();
                        user.firstName = model.FirstName;
                        user.lastName = model.LastName;
                        user.userName = model.UserName;
                        user.gender = model.Gender;
                        user.registerDate = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

                        db.users.Add(user);
                        db.SaveChanges();
                    }
                    return Redirect("Users/");
                }
                return View(model);
            }
            catch(Exception ex)
            {
               
                throw new Exception(ex.Message);
            }
        }
        // GET: User
        public ActionResult Users()
        {
            List<UsersViewModel> listUsers;
            using (WebAppDBEntities db = new WebAppDBEntities())
            {
                listUsers = (from d in db.users
                            select new UsersViewModel
                            {
                                Id_User = d.id_user,
                                FirstName = d.firstName,
                                LastName = d.lastName,
                                UserName = d.userName,
                                Gender = d.gender,
                                RegisterDate = (DateTime)d.registerDate
                            }).ToList();                         
            }

            return View(listUsers);
        }

        public ActionResult EditUser(int id)
        {
            CreateUserViewModel model = new CreateUserViewModel();
            using (WebAppDBEntities db = new WebAppDBEntities())
            {
                var user = db.users.Find(id);
                model.FirstName = user.firstName;
                model.LastName = user.lastName;
                model.UserName = user.userName;
                model.Gender = user.gender;
                model.RegisterDate = (DateTime)user.registerDate;
                model.Id_User = user.id_user;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(CreateUserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (WebAppDBEntities db = new WebAppDBEntities())
                    {
                        var user = db.users.Find(model.Id_User);
                        user.firstName = model.FirstName;
                        user.lastName = model.LastName;
                        user.userName = model.UserName;
                        user.gender = model.Gender;
                        

                        db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/User/Users");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            using (WebAppDBEntities db = new WebAppDBEntities())
            {
                var user = db.users.Find(id);
                db.users.Remove(user);
                db.SaveChanges();
            }
            return Redirect("~/User/Users");
        }
    }

}