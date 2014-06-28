using System.ComponentModel.DataAnnotations;

namespace Shorty.Models
{
    public class LongUrl
    {
        [Required]
        public string UrlToShorten { get; set; } 
    }
}