using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class DetallePedidoItem
    {
        public int IdDetalle { get; set; }

        public int IdOrder { get; set; }
        [JsonIgnore]
        public OrderItem Orders { get; set; }

        public int IdProduct { get; set; }
        [JsonIgnore]
        public ProductItem Products { get; set; }

    }
}
