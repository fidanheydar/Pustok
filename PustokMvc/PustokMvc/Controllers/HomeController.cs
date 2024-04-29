using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokMvc.Data;
using PustokMvc.Models;
using PustokMvc.ViewModel;
using System;
using System.Diagnostics;

namespace PustokMvc.Controllers
{
    public class HomeController : Controller
    {
        private PustokDbContext _context;
        public HomeController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel
            {
                Features = _context.Features.ToList(),
                Sliders = _context.Sliders.OrderBy(x => x.Order).ToList(),
                FeaturedBooks = _context.Books.Include(x => x.Author).Include(x => x.BookImages.Where(bi => bi.Status != null)).Where(x => x.IsFeatured).Take(10).ToList(),
                NewBooks = _context.Books.Include(x => x.Author).Include(x => x.BookImages.Where(bi => bi.Status != null)).Where(x => x.IsNew).Take(10).ToList(),
                DiscountedBooks = _context.Books.Include(x => x.Author).Include(x => x.BookImages.Where(bi => bi.Status != null)).Where(x => x.DiscountPercent > 0).OrderByDescending(x => x.DiscountPercent).Take(10).ToList(),
            };

            return View(vm);
        }

        public Book GetBookById(int id)
        {
            Book book = _context.Books.Include(x => x.Genre).FirstOrDefault(x => x.Id == id);
            return book;
        }
        

    }
}