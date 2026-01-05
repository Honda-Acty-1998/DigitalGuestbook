using System.ComponentModel.DataAnnotations;
namespace DigitalGuestbook.Models;

public class GuestbookEntry
{
    public int Id { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
    [Required] public string Message { get; set; } = string.Empty;
    public DateTime DatePosted { get; set; } = DateTime.Now;
}