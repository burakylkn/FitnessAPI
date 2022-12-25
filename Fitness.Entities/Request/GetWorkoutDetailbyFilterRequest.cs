using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.Entities.Request
{
    public class GetWorkoutDetailbyFilterRequest
    {
        public int? filter_type { get; set; } //1 => and, 2=> or
        public int? workout_area_id { get; set; }
        public int? difficulty_id { get; set; }
        public int? total_time { get; set; }
    }
}
