using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBrand { get; set; }
        public string BrandName{ get; set; }

        // Relación con productos (uno a muchos)
        public ICollection<ProductItem> Products { get; set; }

    }
}
