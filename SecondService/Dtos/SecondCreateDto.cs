using System.ComponentModel.DataAnnotations;

namespace SecondService.Dtos
{
    public class SecondCreateDto
    {
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string CommandLine { get; set; }
    }
}
