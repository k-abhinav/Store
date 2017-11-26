using Store.Core.Entities;
using System;

namespace Store.Core.Access
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
    }
}
