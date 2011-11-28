using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class ProductInput
    {
        [Required]
        public int ProductId { get; set; }
    }
}