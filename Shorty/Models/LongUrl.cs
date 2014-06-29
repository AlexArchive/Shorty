using System.ComponentModel.DataAnnotations;

namespace Shorty.Models
{
    public class LongUrlModel
    {
        [Required]
        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "Invalid Url.")]
        public string LongUrl { get; set; } 
    }
}