using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.Entities.Entity
{
    public class WorkoutDetailDto
    {
        public int workout_id { get; set; }
        public string workout_name { get; set; }
        public int total_time { get; set; }
        public string difficulty_name { get; set; }
        public string workout_area_name { get; set; }
        public int exercise_id { get; set; }
        public string exercise_name { get; set; }
        public int set_count { get; set; }
        public int reply_count { get; set; }
    }
}
