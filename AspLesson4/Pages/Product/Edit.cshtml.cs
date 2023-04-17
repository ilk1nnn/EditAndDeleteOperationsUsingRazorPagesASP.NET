using AspLesson4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspLesson4.Pages.Product
{
    public class EditModel : PageModel
    {


        private readonly ProductDbContext _context;

		public EditModel(ProductDbContext context)
		{
			_context = context;
		}


        [BindProperty]
        public Entities.Product Product { get; set; }


        public void OnGet(int id)
        {
            //Product.Id = id;
        }

        
        public IActionResult OnPost()
        {
			var productFromDb = _context.Products.Find(IndexModel.editId);
            productFromDb.Name = Product.Name;
            productFromDb.Price = Product.Price;
            _context.SaveChanges();
			return RedirectToPage("Index");
		}



        
	}
}
