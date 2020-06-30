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
    public class HistoricoController : ControllerBase
    {
        private readonly IDataRepository<HistoricoAprovacao> _repository;

        public HistoricoController(IDataRepository<HistoricoAprovacao> repository)
        {
            _repository = repository;
        }
        
        // POST api/<HistoricoController>
        [HttpPost]
        public void Post([FromBody] HistoricoAprovacao value)
        {
            _repository.Add(value);
        }
        
    }
}
