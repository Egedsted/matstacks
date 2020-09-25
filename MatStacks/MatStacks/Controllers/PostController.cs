using MatStacks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatStacks.Controllers
{
    public class PostController : Controller
    {

        public IActionResult Index(long? id)
        {
            List<Post> posts = new List<Post> { new Post { Title = "2+2", Author = "Siboni", Body = "Jeg tror at 2+2 = 3", Date = DateTime.Now, Id = 1 },
                new Post { Title = "A+B", Author = "Siboni", Body = "Jeg tror at A+B = 3", Date = DateTime.Now, Id = 2 } };
            foreach (var p in posts)
            {
                if(id == p.Id)
                {
                    return View(p);
                }
            }

            return View(); 

            //VI ER FLYVENDE
        }

    }
}
