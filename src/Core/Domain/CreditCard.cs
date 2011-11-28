using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain
{
    public class CreditCard
    {
        [Required]
        public string Number { get; set; }

        [Required]
        public DateTime Expiration { get; set; }
    }
}