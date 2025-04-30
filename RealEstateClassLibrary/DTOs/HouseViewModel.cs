using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateClassLibrary.DTOs
{
    public class HouseViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Mode { get; set; }
        public string? Type { get; set; }
        public decimal Price { get; set; }
        public string? Location { get; set; }
        public int Size { get; set; }
        public int NoOfBeds { get; set; }
        public int NoOfBaths { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
