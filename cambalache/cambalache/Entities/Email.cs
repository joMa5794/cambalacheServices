using System;
using System.ComponentModel.DataAnnotations;

namespace cambalache.Entities
{
    public class Email
    {
        public string subject { get; set; }
        public string name { get; set; }
        public string emailContact { get; set; }
        public string message { get; set; }
    }
}
