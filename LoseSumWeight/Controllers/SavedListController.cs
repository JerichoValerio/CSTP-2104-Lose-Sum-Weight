using LoseSumWeight.Data;
using Microsoft.AspNetCore.Mvc;

namespace LoseSumWeight.Controllers
{
    public class SavedListController : Controller
    {
        private readonly LoseSumWeightContext _context;

        public SavedListController(LoseSumWeightContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var favouriteProducts = _context.Products.Where(m => m.IsFavorite).ToList();
            return View(favouriteProducts);
        }

        public IActionResult RemoveFromCart(int id)
        {
            var product = _context.Products.FirstOrDefault(m => m.Id == id && m.IsFavorite);
            if (product == null)
            {
                return NotFound();
            }

            // Remove the movie from the favorites list
            product.IsFavorite = false;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
