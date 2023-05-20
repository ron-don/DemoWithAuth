using DemoWithAuth.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoWithAuth;

public class DemoModel : PageModel
{
    private readonly ILogger<DemoModel> _logger;
    private readonly ApplicationDbContext _context;

    public DemoModel(ILogger<DemoModel> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public string? TitleTest { get; set; }

    public List<Customer>? Customers { get; set; }

    public List<ApplicationUser>? Users { get; set; }

    public async Task OnGetAsync()
    {
        if (!_context.Customers.Any())
        {
            var customer = new Customer
            {
                EmailAddress = "kelsey@gmail.com",
                Name = "Kelsey",
                PhoneNumber = "0726877526"
            };

            try
            {
                _context.Customers?.Add(customer);

                await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        TitleTest = $"This is a test. {_context.Customers.Count()} customers available.";

        Customers = _context.Customers?.ToList();

        Users = _context.Users.ToList();
    }
}