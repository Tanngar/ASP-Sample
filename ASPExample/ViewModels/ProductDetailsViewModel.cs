using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPExample.Models;

namespace ASPExample.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int ReviewsCount { get; set; }
        public Product Product { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}