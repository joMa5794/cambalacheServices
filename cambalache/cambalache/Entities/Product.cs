using System;
using System.ComponentModel.DataAnnotations;

namespace cambalache.Entities
{
    public class Product
    {
        [Key]
        public int? id { get; set;}
        public string name { get; set; }
        public double? price { get; set; }
        public int? type { get; set; }
        public byte[] image { get; set; }
        public string image64 { get; set; }

    }
}
