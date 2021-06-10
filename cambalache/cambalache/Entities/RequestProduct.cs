using System;
namespace cambalache.Entities
{
    public class RequestProduct
    {
        public string name { get; set; }
        public double? priceMin { get; set; }
        public double? priceMax { get; set; }
        public int? type { get; set; }
        public RequestProduct()
        {
                   
        }
    }
}
