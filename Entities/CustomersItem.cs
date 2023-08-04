using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Keyless]
    public class CustomersItem
    {
        public object customerId;
        public object customersName;
        public int CustomerId { get; set; }
        public string CustomersName { get; set; }
    }
}
