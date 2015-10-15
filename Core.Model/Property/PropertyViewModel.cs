using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Model.Property
{
    public class PropertyViewModel
    {
        public Guid Id { get; set; }
        public string OwnerName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
