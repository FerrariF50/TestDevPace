using System;
using System.Collections.Generic;
using System.Text;

namespace DevPace.CORE.DAL.Models
{
    public class Customer
    {
        public int CustomersId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
