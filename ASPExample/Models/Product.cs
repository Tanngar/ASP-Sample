using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPExample.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}