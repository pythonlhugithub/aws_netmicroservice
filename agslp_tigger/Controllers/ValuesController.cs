using agslp_tigger.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

 
namespace agslp_tigger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private Data.ApplicationDbContext _dbt;
        public ValuesController(Data.ApplicationDbContext dbt)
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

         [HttpPost]
        public void Post([FromBody] string value)
        {
        }

         [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

         [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
