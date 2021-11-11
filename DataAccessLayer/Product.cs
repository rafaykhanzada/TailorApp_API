using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer
{
    public class Product : HasId
    {
        public string Name { get; set; }
        public string short_description { get; set; }
        public string long_description { get; set; }
        public int ratings { get; set; }
        public double prince { get; set; }
        public string SKU { get; set; }
        [ForeignKey("Category_Id")]
        public int CategoryId { get; set; }
        public string thumbnail { get; set; }

        public Category Category_Id { get; set; }

    }
}
