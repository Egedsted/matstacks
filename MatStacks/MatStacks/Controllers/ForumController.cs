﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MatStacks.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace MatStacks.Controllers
{

    public class ForumController : Controller
    {
        private readonly SubjectDataContext db;

        public ForumController(SubjectDataContext db)
        {
            this.db = db; 

             
        }

        public IActionResult Index()
        {
            var subjects = db.Subjects.ToList(); 

            return View(subjects);
        }

        [HttpGet] // default værdi, totalt unødvendig kodning
        public IActionResult Create()
        {

            return View(); 

        }

        [HttpPost]
        public IActionResult Create(Subject subject)
        {
            if (!ModelState.IsValid)
                return View();
          
            db.Subjects.Add(subject);
            db.SaveChanges();

            return RedirectToAction("Index");     
        }
        

        //Smart pis man ka lukke sammen hvis man har lyst 
        #region 


        #endregion
    }
}