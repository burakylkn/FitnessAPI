using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.Entities.Request
{
    public class UpdateWorkoutRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public int total_time { get; set; }
        public int prm_difficulty_id { get; set; }
        public int prm_workout_area_id { get; set; }
    }
}
