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
    public class DetallePedidoController : ControllerBase
    {
        private readonly IDetallePedidoService _detallepedidoService;
        private readonly object _detallePedidoService;
        private readonly ServiceContext _serviceContext;


        public DetallePedidoController(IDetallePedidoService detallePedidoService, ServiceContext serviceContext)
        {
            _detallePedidoService = detallePedidoService;
            _serviceContext = serviceContext;
        }

        //[HttpGet("{id}", Name = "GetDetallePedidoById")]
        //public IActionResult Get(int id)
        //{
        //    var detallePedidoItem = _detallePedidoService.GetDetallePedidoById(id);

        //    if (detallePedidoItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(detallePedidoItem);
        //}
    }
}
