using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedPassApp.Models;
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
            if (!string.IsNullOrEmpty(OrderNumber)) // Check if OrderNumber is not null or empty
            {
                // Check if an order with the same order number already exists
                var existingOrder = _context.Orders.FirstOrDefault(o => o.Order_Number == OrderNumber);

                if (existingOrder == null)
                {

                    var newOrder = new Order
                    {
                        Order_Number = OrderNumber,
                        Fulfilled_Status = false // Set scan status to true for the new order
                                                 // Add other properties of the order as needed
                    };

                    // Add the new order to the context and save changes to the database
                    _context.Orders.Add(newOrder);
                    _context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("test");
                    // Handle the case where an order with the same order number already exists
                    // You can add appropriate logic here, such as displaying an error message
                }
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