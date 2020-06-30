using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Manager;
using Model.Tables;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Expedicao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        private readonly IDataRepository<NotaCompra> _repository;

        public NotasController(IDataRepository<NotaCompra> repository)
        {
            _repository = repository;
        }

        // GET: api/<NotasController>
        [HttpGet()]
        public IActionResult Get([FromQuery] DateTime date, [FromQuery] string usuario)
        {
            IEnumerable<NotaCompra> notas = ((NotaCompraRepository)_repository).Get(date, usuario);
            return Ok(notas);
        }

        
    }
}
