using System.ComponentModel.DataAnnotations;

namespace Inforce.DAL.Entities.Shortener;

public class ShortenedUrl
{
    [Key]
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string LongUrl { get; set; }
    
    [Required]
    public string ShortUrl { get; set; }

    [Required]
    public string Code { get; set; }
    
    [Required]
    public DateTime CreatedOnUtc { get; set; }
}