using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRMES.Entities
{
    public class Product
    {
        //public int Id { get; set; }

        [Key]
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Introduceti macar un caracter")]
        public string CodIdx { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Numele necesita cel putin initiala")]
        public string StoreCode { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Numele necesita cel putin initiala")]
        public string Name { get; set; }

        public DateTime RegistrationDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double UnitPrice { get; set; }
    }
//    CodIdx - text, lungime maxima 20 caractere, cheie primara
//CodMagazin - text, lungime maxima 20 caractere
//Denumire- text, lunime maxima 150 de caractere
//DataInregistare - data(datetime)
//Cantitate - numeric
//Pret Unitar - numeric
}
