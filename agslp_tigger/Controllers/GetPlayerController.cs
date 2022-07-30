using agslp_tigger.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace agslp_tigger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetPlayerController : ControllerBase
    {
        private readonly googlepara _googlepara;
        public GetPlayerController(googlepara googlepara)
        {
            _googlepara = googlepara;
        }
        // GET: api/<GetPlayerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var pid = _googlepara.spreadSheetId;
            var pnm = _googlepara.spreadSheetAppName;
            return new string[] { pid, pnm };
        }
        // GET api/<GetPlayerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST api/<GetPlayerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GetPlayerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GetPlayerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
