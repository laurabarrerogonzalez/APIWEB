using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class OrderItem
    {
        public OrderItem() 
        { 
            OrderDate = DateTime.Now;
            Delivered = false;
            Charged = false;
        }
        [Key]
        
        public int IdOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Delivered { get; set; }
        public bool Charged { get; set; }

        public int IdCustomer { get; set; }
        //[JsonIgnore]
        public ICollection<ProductItem> Products { get; set; }

        //[JsonIgnore]
        //public ICollection<DetallePedidoItem> DetallesPedido { get; set; }


    }
}