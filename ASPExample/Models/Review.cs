using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPExample.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Author { get; set; }

        [Required(ErrorMessage = "Heading is required.")]
        public string Heading { get; set; }

        [Required(ErrorMessage = "Body is required.")]
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}