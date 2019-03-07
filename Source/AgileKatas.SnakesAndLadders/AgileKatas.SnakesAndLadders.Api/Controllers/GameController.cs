using System;
using System.Collections.Generic;
using AgileKatas.SnakesAndLadders.Api.ViewModels;
using AgileKatas.SnakesAndLadders.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AgileKatas.SnakesAndLadders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IGame _game;

        public GameController(IGame game)
        {
            _game = game;
        }

        [HttpGet]
        public ActionResult<BoardViewModel> Start()
        {
            throw new NotImplementedException();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
