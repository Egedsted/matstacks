using MatStacks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatStacks.Controllers
{
    public class PostController : Controller
    {
        private readonly SubjectDataContext db;
        public PostController(SubjectDataContext db)
        {
            this.db = db;
        }
        public IActionResult Index(long? id)
        {
            var post = db.Posts.Where(x => x.Id == id).Include(x => x.Comments).FirstOrDefault();
            return View(post); 

            //HJÆLP
        }

        [HttpPost]
        public IActionResult CreateComment(long id, Comment NewComment)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            NewComment.Date = DateTime.Now;
            NewComment.Author = User.Identity.Name;
            //NewComment.Id = 0;
            var post = db.Posts.Where(x => x.Id == id).Include(x => x.Comments).FirstOrDefault();
            post.Comments.Add(NewComment);
            db.Update(post);
            db.SaveChanges();

            return RedirectToAction("Index", "Post", new { Id = id });
        }

        public IActionResult Create(long Id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(long id, Post p)
        {
            if (!ModelState.IsValid)
                return View();
            p.Date = DateTime.Now;
            p.Author = User.Identity.Name;
            p.Id = 0;
            var subject = db.Subjects.Where(x => x.Id == id)
                .Include(x => x.Posts).FirstOrDefault();
            subject.Posts.Add(p);
            db.Update(subject);
            db.SaveChanges();

            return View();
        }
    }
}
