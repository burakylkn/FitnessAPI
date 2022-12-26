using Fitness.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.Entities.Response
{
    public class GetWorkoutDetailResponse
    {
        public int workout_id { get; set; }
        public string workout_name { get; set; }
        public int total_time { get; set; }
        public string difficulty_name { get; set; }
        public string workout_area_name { get; set; }
        public List<ExerciseDto> exercises { get; set; }
    }
}
