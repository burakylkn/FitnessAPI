using Fitness.Business.Services.Abstract;
using Fitness.Entities.Request;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace Fitness.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class WorkoutDetailController : ControllerBase
    {
        private readonly IWorkoutDetailService _workoutDetailService;
        public WorkoutDetailController(IWorkoutDetailService workoutDetailService)
        {
            _workoutDetailService = workoutDetailService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get All Workout With Exercises", Description = "Get All Workout With Exercises")]
        public async Task<IActionResult> GetAllWorkoutDetail()
        {
            var workouts = await _workoutDetailService.GetAllWorkoutDetail();
            if (workouts == null || workouts.Count<1)
            {
                return NoContent();
            }
            return Ok(workouts);
        }
        [HttpGet]
        [SwaggerOperation(Summary = "Get Workout With Exercises by id", Description = "Get Workout With Exercises by id")]
        public async Task<IActionResult> GetWorkoutDetail([FromQuery] int id)
        {
            var workout = await _workoutDetailService.GetWorkoutDetail(id);
            if (workout == null)
            {
                return NoContent();
            }
            return Ok(workout);
        }
        [HttpGet]
        [SwaggerOperation(Summary = "Get Workout With Exercises By Filter", Description = "Get Workout With Exercises By Filter")]
        public async Task<IActionResult> GetWorkoutDetailByFilter([FromBody] GetWorkoutDetailbyFilterRequest objReq)
        {
            var workouts = await _workoutDetailService.GetWorkoutDetailByFilter(objReq);
            if (workouts == null || workouts.Count<1)
            {
                return NoContent();
            }
            return Ok(workouts);
        }
    }
}
