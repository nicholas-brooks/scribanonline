using System.ComponentModel.DataAnnotations;

namespace scribanonline.Models
{
    public class GenerateInput
    {
        [Required]
        public string Model { get; set; } = null!;

        [Required]
        public string Template { get; set; } = null!;
    }
}