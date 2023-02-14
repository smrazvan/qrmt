using System.ComponentModel.DataAnnotations;

namespace QRMES.Models
{
    public class UpdateProductDto
    {
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Introduceti macar un caracter")]
        public string? CodIdx { get; set; } = null;

        [StringLength(20, MinimumLength = 1, ErrorMessage = "Numele necesita cel putin initiala")]
        public string? StoreCode { get; set; } = null;

        [StringLength(150, MinimumLength = 3, ErrorMessage = "Numele necesita cel putin initiala")]
        public string? Name { get; set; } = null;

        public DateTime? RegistrationDate { get; set; } = null;

        public int? Quantity { get; set; } = null;

        public double? UnitPrice { get; set; } = null;
    }
}
