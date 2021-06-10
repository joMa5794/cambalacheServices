using System;
using System.ComponentModel.DataAnnotations;

namespace cambalache.Entities
{
    public class ProductType
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
