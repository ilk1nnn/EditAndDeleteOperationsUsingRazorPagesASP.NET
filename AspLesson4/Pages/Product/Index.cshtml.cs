using AspLesson4.Entities;
using AspLesson4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspLesson4.Pages.Product
{
    public class IndexModel : PageModel
    {

        public static int editId = 0;

        private readonly ProductDbContext _context;

        public IndexModel(ProductDbContext context)
        {
            _context = context;
        }
        public string Message { get; set; }
        public string Info { get; set; }
        public List<Entities.Product> Products { get; set; }
        public void OnGet(string info="")
        {
            Products = _context.Products.ToList();
            Message = $"Today is {DateTime.Now.DayOfWeek}";
            Info = info;
        }
        [BindProperty]
        public Entities.Product Product { get; set; }
        public IActionResult OnPost()
        {
            _context.Products.Add(Product);
            _context.SaveChanges();
            Info = $"{Product.Name} added successfully";
            return RedirectToPage("Index",new { info=Info });
        }


        public IActionResult OnPostEdit(int id)
        {
            editId = id;
            return RedirectToPage($"/Product/Edit");
        }


        public IActionResult OnPostDelete(int id)
        {
            var product = _context.Products.Find(id);
            if(product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            Info = $"{product.Name} deleted successfully";
            return RedirectToPage("Index",new {info=Info});

        }

    }
}
