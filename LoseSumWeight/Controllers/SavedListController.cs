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

        [HttpPost]
        public IActionResult PlaceOrder(int productId, int selectedQuantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                // Product not found, handle the error, show a message, etc.
                return NotFound();
            }

            if (ModelState.IsValid && selectedQuantity > 0 && selectedQuantity <= product.LeftInStock)
            {
                product.IsFavorite = false;
                product.SelectedQuantity = selectedQuantity;
                product.LeftInStock -= selectedQuantity;
                _context.SaveChanges();
            }
            else
            {
                // Handle invalid quantity or other validation errors
                ModelState.AddModelError(string.Empty, "Invalid quantity selection.");
            }

            return RedirectToAction("Index");
        }


    }
}
