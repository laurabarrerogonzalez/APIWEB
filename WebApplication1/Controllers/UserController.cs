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
                int userId = _userService.insertUsers(userItem);
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
                                        .Where(p => p.IdUser == id)
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

        [HttpDelete("{productId}", Name = "DeleteUser")]

        public IActionResult Delete([FromQuery] string userName, [FromQuery] string userPassword, int UserId)
        {
            var selectedUser = _serviceContext.Set<UserItem>()
                   .Where(u => u.NombreUsuario == userName
                       && u.Contraseña == userPassword
                       && u.Rol == 1)
                    .FirstOrDefault();

            if (selectedUser != null)
            {
                _userService.DeleteUser(UserId);


                return Ok(new { message = "Producto eliminado exitosamente" });
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }

    }
}
