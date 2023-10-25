using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SpeedPassApp;
using SpeedPassApp.Models;

public class OrdersReadyForPickupModel : PageModel
{
    private readonly AppDbContext _dbContext;

    public OrdersReadyForPickupModel(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Order> ReadyForPickupOrders { get; private set; }

    public void OnGet()
    {
        // Retrieve orders that are ready for pickup (Fufilled_Status = 0)
        ReadyForPickupOrders = _dbContext.Orders.Where(o => o.Fulfilled_Status == false).ToList();
    }

    public IActionResult OnPostUpdateFulfilledStatus(int orderId)
    {
        var orderToUpdate = _dbContext.Orders.FirstOrDefault(o => o.Id == orderId);

        if (orderToUpdate != null)
        {
            // Toggle the Fulfilled_Status (if it's true, set it to false, and vice versa)
            orderToUpdate.Fulfilled_Status = !orderToUpdate.Fulfilled_Status;
            _dbContext.SaveChanges();
        }

        // Redirect back to the OrdersReadyForPickup page after updating the status
        return RedirectToPage("/OrdersReadyForPickup");
    }
}