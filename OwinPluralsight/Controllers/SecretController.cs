﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OwinPluralsight.Controllers
{
    public class SecretController : Controller
    {
        // GET: Secret
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}