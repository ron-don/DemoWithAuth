using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DemoWithAuth.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // public DbSet<ExampleView>? ExampleViews { get; set; }

    public DbSet<Customer>? Customers { get; set; }
}

// hangfire
//rabbitmq
//windows message queueing
// quartz

// redis - cache

// swaggerUI

// serilog

//async await

public class ApplicationUser : IdentityUser
{
    public DateTimeOffset DOB { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    [MaxLength(75)]
    public string? CreatedBy { get; set; } = default!;
    public decimal CurrentBalance { get; set; }
    [Phone]
    public string? SecondPhoneNumber { get; set; }
    [EmailAddress]
    public string? SecondEmailAddress { get; set; }
}

[Keyless]
public class ExampleView
{
    public string? Title { get; set; } = default!;
    public decimal CurrentBalance { get; set; }
}

public class Customer
{
    public Guid Id { get; set; }
    
    [MaxLength(75)]
    public string? Name { get; set; } = default!;
    [Phone]
    public string? PhoneNumber { get; set; }
    [EmailAddress]
    public string? EmailAddress { get; set; }
}