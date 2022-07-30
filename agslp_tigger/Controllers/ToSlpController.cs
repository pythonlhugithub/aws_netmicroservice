using agslp_tigger.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace agslp_tigger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToSlpController : ControllerBase
    {

        private Data.ApplicationDbContext _dbt;
        public ToSlpController(Data.ApplicationDbContext dbt)
        {
            _dbt = dbt;
        }

        [HttpGet]
        public IList<Wallet> Get()
        {
            return this._dbt.wallet.ToList();
        }

         [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ToSlpController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ToSlpController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ToSlpController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
