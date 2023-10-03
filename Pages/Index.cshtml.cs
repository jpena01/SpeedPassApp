using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace SpeedPassApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public string orderNumber { get; set; }

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
            if (order != null && order.ScanStatus != true)
            {
                order.ScanStatus = true;
                _context.SaveChanges();
            }

            return RedirectToPage("/Index");
        }
    }
}