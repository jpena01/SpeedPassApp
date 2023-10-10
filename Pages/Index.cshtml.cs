using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace SpeedPassApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public string Order_Number { get; set; }

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderNumber == Order_Number);
            if (order != null && order.ScanStatus != 1)
            {
                order.ScanStatus = 1;
                _context.SaveChanges();
            }

            return RedirectToPage("/Index");
        }
    }
}