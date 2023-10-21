using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpeedPassApp.Models;
using System.Linq;

namespace SpeedPassApp.Pages;
public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public string OrderNumber { get; set; }
    public bool Fulfilled_Status { get; set; }

    public IList<Order> Orders { get; set; }

    public async Task OnGetAsync()
    {
        Orders = await _context.Orders.ToListAsync();
    }
}