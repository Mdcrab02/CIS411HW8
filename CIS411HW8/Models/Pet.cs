using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace CIS411HW8.Models
{
    public class Pet
    {
        public int ID { get; set; }

        //apparently when you try to change a model after prod, the mvc app divides by zero
        //public string ImageURL { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateReceived { get; set; }

    }
}