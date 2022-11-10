using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Nizami.Models
{

    public class Orders
    {
        [BindNever]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [BindNever]
        public bool Shipped { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Line3 { get; set; }

        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state name")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        [RegularExpression(@"\d{5}",
            ErrorMessage = "Security Code is not valid")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; }

        [Required]
        [RegularExpression(@"\d{16}",
            ErrorMessage="Credit Card number is not valid")]
        public string CardNumber { get; set; }

        [Required]
        [RegularExpression(@"\d{3}",
            ErrorMessage= "Security Code is not valid")]
        public string CVV { get; set; }

        public bool GiftWrap { get; set; }
    }
}
