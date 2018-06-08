﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSignup.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserSignup.Controllers
{
    public class UserController : Controller
    {
        public dynamic Cheese { get; private set; }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/User/Add") ]
        public IActionResult Add(User user, string verify)
        {
            if (user.Password == verify)
            {
                ViewBag.username = user.Username;

                return View("Index");
            }

            else if (user.Password == null)
            {
                ViewBag.errorPassword = "Enter a password";
                ViewBag.username = user.Username;
                ViewBag.email = user.Email;
                return View();
            }

            else if (verify == null)
            {
                ViewBag.errorVerify = "Verify your password";
                ViewBag.username = user.Username;
                ViewBag.email = user.Email;
                return View();
            }

            else if (user.Password != verify)
            {
                ViewBag.username = user.Username;
                ViewBag.email = user.Email;
                return View();
            }

            else
            {
                return View();
            }
        }
    }
}
