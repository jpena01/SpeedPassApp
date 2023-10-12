using Microsoft.AspNetCore.Mvc.RazorPages;
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
        // Retrieve orders that are ready for pickup (ScanStatus = 1)
        ReadyForPickupOrders = _dbContext.Orders.Where(o => o.Scan_Status == true).ToList();
    }

}