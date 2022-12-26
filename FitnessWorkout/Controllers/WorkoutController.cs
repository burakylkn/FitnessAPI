using Fitness.Business.Services.Abstract;
using Fitness.Entities.Request;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fitness.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;
        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get Workout by id", Description = "Get Workout by id")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var workout = await _workoutService.Get(id);
            if (workout==null)
            {
                return NoContent();
            }
            return Ok(workout);
        }
        [HttpGet]
        [SwaggerOperation(Summary = "Get All Workout", Description = "Get All Workout")]
        public async Task<IActionResult> GetAll()
        {
            var workouts = await _workoutService.GetAll();

            if (workouts == null || workouts.Count<1)
            {
                return NoContent();
            }

            return Ok(workouts);
        }
        [HttpDelete]
        [SwaggerOperation(Summary = "Delete Workout", Description = "Soft Delete Workout")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var result = await _workoutService.Delete(id);

            if (result.Equals(0))
                return BadRequest();

            return Ok(result);
        }
        [HttpPut]
        [SwaggerOperation(Summary = "Update Workout", Description = "Update Workout")]
        public async Task<IActionResult> Update([FromBody] UpdateWorkoutRequest objReq)
        {
            var result = await _workoutService.Update(objReq);

            if (result.Equals(0))
                return BadRequest();

            return Ok(result);
        }
        [HttpPost]
        [SwaggerOperation(Summary = "Insert Workout", Description = "Insert Workout")]
        public async Task<IActionResult> Insert([FromBody] InsertWorkoutRequest objReq)
        {
            var result = await _workoutService.Insert(objReq);

            if (result.Equals(0))
                return BadRequest();

            return Ok(result);
        }
    }
}
