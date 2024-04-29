using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokMvc.Areas.Manage.ViewModels;
using PustokMvc.Data;
using PustokMvc.Models;
using System;

namespace PustokMvc.Areas.Manage.Controllers
{
        [Area("manage")]
    public class AuthorController : Controller
    {
        private readonly PustokDbContext _context;

        public AuthorController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            var query = _context.Authors.Include(x => x.Books);
            return View(PaginatedList<Author>.Create(query, page, 2));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            if (_context.Authors.Any(x => x.Fullname == author.Fullname))
            {
                ModelState.AddModelError("Fullname", "Fullname already exists!");
                return View(author);
            }

            _context.Authors.Add(author);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}

