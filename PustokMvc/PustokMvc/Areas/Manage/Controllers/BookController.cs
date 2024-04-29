using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokMvc.Areas.Manage.ViewModels;
using PustokMvc.Data;
using PustokMvc.Models;

namespace PustokMvc.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BookController : Controller
    {
        private readonly PustokDbContext _context;

        public BookController(PustokDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {
            var query = _context.Books.Include(x => x.BookImages);
            return View(PaginatedList<Book>.Create(query, page, 2));
        }
    }
}
