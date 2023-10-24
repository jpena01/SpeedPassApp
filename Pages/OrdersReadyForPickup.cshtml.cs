using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpeedPassApp;
using SpeedPassApp.Models;
using System.Threading.Tasks;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }
    public List<Order> ReadyForPickupOrders { get; private set; }

    [BindProperty]
    public string OrderNumber { get; set; }
    public bool Fulfilled_Status { get; set; }

    public IList<Order> Orders { get; set; }

    public async Task OnGetAsync()
    {
        Orders = await _context.Orders.ToListAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Orders = await _context.Orders.ToListAsync();
            return Page();
        }

        var newOrder = new Order
        {
            Order_Number = OrderNumber,
            Fulfilled_Status = false // Set the appropriate value for Fulfilled_Status
                                     // Set other properties as needed
        };

        _context.Orders.Add(newOrder);
        await _context.SaveChangesAsync();

        return RedirectToPage("./OrdersReadyForPickup");
    }

    public async Task<IActionResult> OnPostRemoveOrderAsync(int orderId)
    {
        var orderToRemove = await _context.Orders.FindAsync(orderId);

        if (orderToRemove != null)
        {
            _context.Orders.Remove(orderToRemove);
            await _context.SaveChangesAsync();
        }

        // Return success status (HTTP 200 OK)
        return new OkResult();
    }
}