using Fitness.Business.Services.Abstract;
using Fitness.Entities.Request;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Fitness.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get Exercise by id", Description = "Get Exercise by id")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var exercise = await _exerciseService.Get(id);

            return Ok(exercise);
        }
        [HttpGet]
        [SwaggerOperation(Summary = "Get All Exercise", Description = "Get All Exercise")]
        public async Task<IActionResult> GetAll()
        {
            var exercises = await _exerciseService.GetAll();

            return Ok(exercises);
        }
        [HttpDelete]
        [SwaggerOperation(Summary = "Delete Exercise", Description = "Soft Delete Exercise")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var result = await _exerciseService.Delete(id);

            if (result.Equals(0))
                return BadRequest();

            return Ok(result);
        }
        [HttpPut]
        [SwaggerOperation(Summary = "Update Exercise", Description = "Update Exercise")]
        public async Task<IActionResult> Update([FromBody] UpdateExerciseRequest objReq)
        {
            var result = await _exerciseService.Update(objReq);

            if (result.Equals(0))
                return BadRequest();

            return Ok(result);
        }
        [HttpPost]
        [SwaggerOperation(Summary = "Insert Exercise", Description = "Insert Exercise")]
        public async Task<IActionResult> Insert([FromBody] InsertExerciseRequest objReq)
        {
            var result = await _exerciseService.Insert(objReq);

            if (result.Equals(0))
                return BadRequest();

            return Ok(result);
        }
    }
}
