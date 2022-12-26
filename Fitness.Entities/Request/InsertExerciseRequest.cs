﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.Entities.Request
{
    public class InsertExerciseRequest
    {
        public string name { get; set; }
        public int set_count { get; set; }
        public int reply_count { get; set; }
        public int workout_id { get; set; }
    }
}
