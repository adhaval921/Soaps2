using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcSoaps.Models
{
    public class SoapTypeViewModel
    {
        public List<soap> Soaps { get; set; }
        public SelectList Type { get; set; }
        public string SoapType { get; set; }
        public string SearchString { get; set; }
    }
}
