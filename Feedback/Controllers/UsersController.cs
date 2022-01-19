using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Feedback_DAL.Data;
using Feedback_DAL.Models;
using Feedback_Service.Interface;
using Feedback_DAL.ViewModels;

namespace Feedback.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUser _user;
        private readonly IAddress _address;

        public UsersController(IUser userContext, IAddress addressContext)
        {
            _user = userContext;
            _address = addressContext;
        }


        // GET: Users
        public IActionResult Index(string search, string sortOrder, string delete)
        {
            List<User> newresult = _user.GetAllUser().ToList();
            return View(newresult);
        }

        // GET: Users/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User userResult = _user.GetUserByID(id);
            Address addressResult = _address.GetAddressByID(userResult.AddressId);
            if (userResult == null && addressResult == null)
            {
                return NotFound();
            }

            UserCreateViewModel userVm = new UserCreateViewModel()
            {
                AddressLineOne = addressResult.AddressLineOne,
                AddressLineTwo = addressResult.AddressLineTwo,
                City = addressResult.City,
                State = addressResult.State,
                Country = addressResult.Country,
                Pincode = addressResult.Pincode,
           
                FirstName = userResult.FirstName,
                LastName = userResult.LastName,
                Gender = userResult.Gender,
                Email = userResult.Email,
               
            };

            return View(userVm);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,Gender,Email,Password,AddressLineOne,AddressLineTwo,City,State,Country,Pincode")] UserCreateViewModel userVm)
        {
            Address address = new Address
            {
                AddressLineOne = userVm.AddressLineOne,
                AddressLineTwo = userVm.AddressLineTwo,
                City = userVm.City,
                State = userVm.State,
                Country = userVm.Country,
                Pincode = userVm.Pincode
            };
            _address.AddAddress(address);
            User user = new User
            {
                FirstName = userVm.FirstName,
                LastName = userVm.LastName,
                Gender = userVm.Gender,
                Email = userVm.Email,
                AddressId = address.ID,
                Password = userVm.Password
            };


            _user.AddUser(user);
            return RedirectToAction(nameof(Index));

            //return View(userVm);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User user = _user.GetUserByID(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,FirstName,LastName,Gender,Email,AddressId,Password")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _user.UpdateUser(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _user.GetUserByID(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _user.GetUserByID(id);
            _address.DeleteAddressByID(user.AddressId);
            _user.DeleteUserByID(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _user.Any(id);
        }
    }
}
