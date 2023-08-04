using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductItem
    {
        [Key]
        public int Id { get; set; }
        public string productName { get; set; }
        public string productMarca { get; set; }
        public int productStock { get; set; }

        //[ForeignKey("Brand")]
        //public int IdBrand { get; set; }
    }
}