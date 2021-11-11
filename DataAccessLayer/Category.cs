using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class Category : HasId
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
