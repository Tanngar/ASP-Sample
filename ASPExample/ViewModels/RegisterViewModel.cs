using ASPExample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPExample.ViewModels
{
    public class RegisterViewModel
    {
        public User User { get; set; }

        [Required]
        public string RepeatPassword { get; set; }
    }
}