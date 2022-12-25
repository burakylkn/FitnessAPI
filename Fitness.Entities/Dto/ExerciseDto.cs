using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.Entities.Entity
{
    public class ExerciseDto
    {
        public int exercise_id { get; set; }
        public string exercise_name { get; set; }
        public int set_count { get; set; }
        public int reply_count { get; set; }
    }
}
