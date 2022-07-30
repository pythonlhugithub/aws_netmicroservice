using agslp_tigger.gsheet_source;
using agslp_tigger.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace agslp_tigger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayergController : ControllerBase
    {
        private readonly googlepara _googlepara;
        public PlayergController(googlepara googlepara)
        {
            _googlepara = googlepara;
        }
        // GET: api/<PlayergController>
        [HttpGet]
        public List<PlayerCatch> Get()
        {
            googlesheetconnection player = new googlesheetconnection(_googlepara);
            var playlist=player.Players();
            return playlist;
        }

        // GET api/<PlayergController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PlayergController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PlayergController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlayergController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
