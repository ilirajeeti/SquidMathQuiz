using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SquidMathQuiz.Entities;
using SquidMathQuiz.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SquidMathQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        [HttpGet("list")]
        public IActionResult GetPlayers()
        {   
            var context = new SquidMathQuizContext();
            return Ok(context.Players);
        }

        //[HttpGet("ActiveList/{id}")]

        //public IActionResult GetActivePlayers(int id)
        //{
        //    var context = new SquidMathQuizContext();
        //    var playerToGet = context.Players.FirstOrDefault((idi) => idi.ID == id);
        //    if (playerToGet == null) return NotFound();

        //    return Ok(playerToGet);
        //}


        [HttpPost("add")]
        public IActionResult AddPlayers([FromBody] PlayerViewModel playerModel)
        {
            var player = new Players();
            player.FirstName = playerModel.FirstName;
            player.DateTime = DateTime.Now;
            var context = new SquidMathQuizContext();
            context.Players.Add(player);
            context.SaveChanges();

            return Ok(player);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeletePlayer(int id)
        {
            var context = new SquidMathQuizContext();
            var playerToRemove = context.Players.FirstOrDefault((s) => s.ID == id);
            if (playerToRemove == null) return NotFound();
            context.Players.Remove(playerToRemove);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdatePlayer([FromBody] PlayerViewModel playerModel, int id)
        {
            var context = new SquidMathQuizContext();
            var playerToUpdate = context.Players.FirstOrDefault((s) => s.ID == id);
            if (playerToUpdate == null) return NotFound();

            playerToUpdate.FirstName = playerModel.FirstName;
            playerToUpdate.DateTime = DateTime.Now.AddDays(2);

            context.SaveChanges();
            return Ok();
        }
    }
}
