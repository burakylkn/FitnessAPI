using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.Entities.Request
{
    public class InsertWorkoutRequest
    {
        public string name { get; set; }
        public int total_time { get; set; }
        public int prm_difficulty_id { get; set; }
        public int prm_workout_area_id { get; set; }
    }
}
