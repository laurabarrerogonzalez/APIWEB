using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserItem
    {
        public object customerId;
        public object customersName;

        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public int Rol { get; set; }



        //public int UserRol { get; set; }
    }
}
