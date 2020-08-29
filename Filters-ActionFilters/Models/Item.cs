using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Filters_ActionFilters.Models
{
    public class Item
    {
        [Required]
        public string Name { get; set; }
        
        [MaxLength(3)]
        public string Code { get; set; }
    }
}