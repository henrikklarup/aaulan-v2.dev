using System.Collections.Generic;
using AAULAN.Models;

namespace AAULAN.ViewModels
{
    public class OrderViewModel
    {
        public Mad Mad { get; set; }
        public Pizza Pizza { get; set; }
        public List<Mad> Orders { get; set; }
        public List<Pizza> Prices { get; set; }
    }
}