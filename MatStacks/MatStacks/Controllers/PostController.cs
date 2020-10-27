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
            var post = db.Posts.Where(x => x.Id == id).Include(x => x.Comments).Include(x => x.Ratings).FirstOrDefault();
            return View(post); 
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
            var post = db.Posts.Where(x => x.Id == id).Include(x => x.Comments).Include(x => x.Ratings).FirstOrDefault();
            post.Comments.Add(NewComment);
            db.Update(post);
            db.SaveChanges();

            return RedirectToAction("Index", "Post", new { Id = id });
        }

        [HttpPost]
        public IActionResult CreateRating(long Id, Rating NewRating)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            NewRating.Author = User.Identity.Name;
            var post = db.Posts.Where(x => x.Id == Id).Include(x => x.Comments).Include(x => x.Ratings).FirstOrDefault();
            post.Ratings.Add(NewRating);
            db.Update(post);
            db.SaveChanges();

            return RedirectToAction("Index", "Post", new { Id = Id });
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

            return RedirectToAction("Index","Subject", new { Id = id });
        }
    }
}
