using Microsoft.EntityFrameworkCore;
using DigitalGuestbook.Models;
namespace DigitalGuestbook.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<GuestbookEntry> Entries { get; set; }
}