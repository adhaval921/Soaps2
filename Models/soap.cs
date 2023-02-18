using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcSoaps.Models
{
    public class soap
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Type { get; set; }
        public string Colour { get; set; }
        public decimal Price { get; set; }
    }
}
