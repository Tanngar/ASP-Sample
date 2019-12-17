using ASPExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPExample.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}