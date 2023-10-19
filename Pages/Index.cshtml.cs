using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace SpeedPassApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public string OrderNumber { get; set; }

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var order = _context.Orders.FirstOrDefault(o => o.Order_Number == OrderNumber);
            if (order != null && order.Scan_Status != true)
            {
                order.Scan_Status = true;
                _context.SaveChanges();
            }

            return RedirectToPage("/Index");
        }
        public IActionResult OnPostUpdateScanStatus(int orderId)
        {
            // Logic to update scan status...

            // Set a flag indicating that a print request is needed
            ViewData["PrintRequested"] = true;

            return Page();
        }
    }
}