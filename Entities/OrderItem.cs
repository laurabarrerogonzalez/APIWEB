using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Delivered { get; set; }
        public bool Charged { get; set; }

        //[ForeignKey("ProductItem")]
        //public int IdProductItem { get; set; }

        [ForeignKey("CustomersItem")]
        public int IdCustomersItem { get; set; }
    }
}