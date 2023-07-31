using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;
using System.Web.Http.Cors;
using WebApplication1.IServices;
using WebApplication1.Services;


namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ServiceContext _serviceContext;
        

        public UserController(IUserService userService, ServiceContext serviceContext)
        {
            _userService = userService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "insertUsers")]
        public IActionResult Post([FromQuery] string userNombreUsuario, [FromQuery] string userContraseña, [FromBody] UserItem userItem)
        {
            var selectedUser = _serviceContext.Set<UserItem>()
                               .Where(u => u.NombreUsuario == userNombreUsuario
                               && u.Contraseña == userContraseña
                               && u.Rol == 1)
                               .FirstOrDefault();
            if (selectedUser != null)
            {
                int userId = _userService.insertUser(userItem);
                return Ok(userItem);
            }
            else
            {
                return Unauthorized("El usuario no está autorizado o no existe");
               
            }
        }


        [HttpPut("{id}", Name = "UpdateUser")]
        public IActionResult Put(int id, [FromBody] UserItem updatedUserItem)
        {
            var existingUserItem = _serviceContext.Set<UserItem>()
                                        .Where(p => p.Id == id)
                                        .FirstOrDefault();


            if (existingUserItem == null)
            {

                return NotFound();
            }
            else
            {
                existingUserItem.NombreUsuario = updatedUserItem.NombreUsuario;
                existingUserItem.Contraseña = updatedUserItem.Contraseña;
            }

            _userService.UpdateUser(existingUserItem);
            return Ok(existingUserItem);


        }


        [HttpDelete("{id}", Name = "DeleteUser")]
        public IActionResult Delete(int id)
        {
            var existingUserItem = _serviceContext.Set<UserItem>()
                                        .FirstOrDefault(p => p.Id == id);

            if (existingUserItem == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(existingUserItem);
            return Ok(existingUserItem);
        }

    }
}
