using System.ComponentModel.DataAnnotations;
using DemoWithAuth.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DemoWithAuth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeAPIController : ControllerBase
{
    private readonly ILogger<HomeAPIController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeAPIController(ILogger<HomeAPIController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomerAsync(CustomerDTO customerDTO)
    {
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            EmailAddress = customerDTO.EmailAddress,
            Name = customerDTO.Name,
            PhoneNumber = customerDTO.PhoneNumber
        };

        try
        {
            _context.Customers?.Add(customer);

            _logger.LogInformation($"Adding customer: {customer.Name} {System.Text.Json.JsonSerializer.Serialize(customer)}");

            await _context.SaveChangesAsync();
        }
        catch(Exception)
        {
            throw;
        }

        return Ok(customer.Id);
    }

    [HttpGet]
    public IActionResult Customers()
    {
        return Ok(_context.Customers?.ToList());
    }

}

public class CustomerDTO
{
    [MaxLengthAttribute(75)]
    public string? Name { get; set; } = default!;
    [Phone]
    public string? PhoneNumber { get; set; }
    [EmailAddress]
    public string? EmailAddress { get; set; }
}