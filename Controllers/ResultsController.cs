using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SquidMathQuiz.ViewModels;

namespace SquidMathQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {

        [HttpGet("list")]
        public IActionResult GetResult()
        {
            var context = new SquidMathQuizContext();
            return Ok(context.Results);
        }

        [HttpPost("add")]

        public IActionResult AddResult([FromBody] ResultViewModel resultModel)
        {
            var result = new SquidMathQuiz.Entities.Results();
            result.PlayerID= resultModel.PlayerID;
            result.Points = resultModel.Points;
            result.DateTime = DateTime.Now;

            var context = new SquidMathQuizContext();
            context.Results.Add(result);

            context.SaveChanges();

            return Ok();
        }


        [HttpDelete("delete/{id}")]

        public IActionResult DeleteResult(int id)
        {
            var context = new SquidMathQuizContext();
            var removeResult = context.Results.FirstOrDefault((idResult) => idResult.ID == id);
            if (removeResult != null) return NotFound();
            context.SaveChanges();
            return Ok();
        }


        




    }
}
