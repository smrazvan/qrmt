using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QRMES.Models
{
    public class AddProductDto
    {
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Introduceti macar un caracter")]
        public string CodIdx { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Numele necesita cel putin initiala")]
        public string StoreCode { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Numele necesita cel putin initiala")]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double UnitPrice { get; set; }
    }
}
