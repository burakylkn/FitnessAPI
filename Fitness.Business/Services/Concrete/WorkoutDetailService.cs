using Fitness.Business.Services.Abstract;
using Fitness.Common.Helper;
using Fitness.Data.DBManager;
using Fitness.Entities.Entity;
using Fitness.Entities.Request;
using Fitness.Entities.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Business.Services.Concrete
{
    public class WorkoutDetailService : IWorkoutDetailService
    {
        protected FitnessDbContext _context;
        protected IConfiguration _config;
        private readonly ILogger<IWorkoutDetailService> _logger;

        public WorkoutDetailService(FitnessDbContext context, IConfiguration config, ILogger<IWorkoutDetailService> logger)
        {
            _context = context;
            _config = config;
            _logger = logger;
        }

        public async Task<List<GetWorkoutDetailResponse>> GetAllWorkoutDetail()
        {
            try
            {
                var list = new List<WorkoutDetailDto>();
                _context.Connection.Open();
                MySqlCommand cmd = new MySqlCommand("GetAllWorkoutWithExercise", _context.Connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(SQLHelper.ConvertToObject<WorkoutDetailDto>(rdr));
                }
                rdr.Close();
                _context.Connection.Close();

                var response = list.GroupBy(x => (x.workout_id, x.workout_name, x.workout_area_name, x.difficulty_name, x.total_time)).Select(y => new GetWorkoutDetailResponse()
                {
                    difficulty_name = y.Key.difficulty_name,
                    total_time = y.Key.total_time,
                    workout_area_name = y.Key.workout_area_name,
                    workout_id = y.Key.workout_id,
                    workout_name = y.Key.workout_name,
                    exercises = y.Select(z => new ExerciseDto()
                    {
                        exercise_id = z.exercise_id,
                        set_count = z.set_count,
                        exercise_name = z.exercise_name,
                        reply_count = z.reply_count
                    }).ToList()
                }).ToList();

                return response;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return null;
            }
        }
        public async Task<GetWorkoutDetailResponse> GetWorkoutDetail(int id)
        {
            try
            {
                var list = new List<WorkoutDetailDto>();
                _context.Connection.Open();
                MySqlCommand cmd = new MySqlCommand("GetWorkoutWithExercise", _context.Connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("_id", id));
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(SQLHelper.ConvertToObject<WorkoutDetailDto>(rdr));
                }
                rdr.Close();
                _context.Connection.Close();

                var response = list.GroupBy(x => (x.workout_id, x.workout_name, x.workout_area_name, x.difficulty_name, x.total_time)).Select(y => new GetWorkoutDetailResponse()
                {
                    difficulty_name = y.Key.difficulty_name,
                    total_time = y.Key.total_time,
                    workout_area_name = y.Key.workout_area_name,
                    workout_id = y.Key.workout_id,
                    workout_name = y.Key.workout_name,
                    exercises = y.Select(z => new ExerciseDto()
                    {
                        exercise_id = z.exercise_id,
                        set_count = z.set_count,
                        exercise_name = z.exercise_name,
                        reply_count = z.reply_count
                    }).ToList()
                }).FirstOrDefault();

                return response;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return null;
            }
        }
        public async Task<List<GetWorkoutDetailResponse>> GetWorkoutDetailbyFilter()
        {
            try
            {
                var list = new List<WorkoutDetailDto>();
                _context.Connection.Open();
                MySqlCommand cmd = new MySqlCommand("GetAllWorkoutWithExercise", _context.Connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(SQLHelper.ConvertToObject<WorkoutDetailDto>(rdr));
                }
                rdr.Close();
                _context.Connection.Close();

                var response = list.GroupBy(x => (x.workout_id, x.workout_name, x.workout_area_name, x.difficulty_name, x.total_time)).Select(y => new GetWorkoutDetailResponse()
                {
                    difficulty_name = y.Key.difficulty_name,
                    total_time = y.Key.total_time,
                    workout_area_name = y.Key.workout_area_name,
                    workout_id = y.Key.workout_id,
                    workout_name = y.Key.workout_name,
                    exercises = y.Select(z => new ExerciseDto()
                    {
                        exercise_id = z.exercise_id,
                        set_count = z.set_count,
                        exercise_name = z.exercise_name,
                        reply_count = z.reply_count
                    }).ToList()
                }).ToList();

                return response;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return null;
            }
        }
        public async Task<List<GetWorkoutDetailResponse>> GetWorkoutDetailByFilter(GetWorkoutDetailbyFilterRequest objReq)
        {
            try
            {
                var list = new List<WorkoutDetailDto>();
                _context.Connection.Open();
                MySqlCommand cmd = new MySqlCommand("GetWorkoutWithExerciseByFilter", _context.Connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("_filter_type", objReq.filter_type));
                cmd.Parameters.Add(new MySqlParameter("_difficulty_id", objReq.difficulty_id));
                cmd.Parameters.Add(new MySqlParameter("_workout_area_id", objReq.workout_area_id));
                cmd.Parameters.Add(new MySqlParameter("_total_time", objReq.total_time));
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(SQLHelper.ConvertToObject<WorkoutDetailDto>(rdr));
                }
                rdr.Close();
                _context.Connection.Close();

                var response = list.GroupBy(x => (x.workout_id, x.workout_name, x.workout_area_name, x.difficulty_name, x.total_time)).Select(y => new GetWorkoutDetailResponse()
                {
                    difficulty_name = y.Key.difficulty_name,
                    total_time = y.Key.total_time,
                    workout_area_name = y.Key.workout_area_name,
                    workout_id = y.Key.workout_id,
                    workout_name = y.Key.workout_name,
                    exercises = y.Select(z => new ExerciseDto()
                    {
                        exercise_id = z.exercise_id,
                        set_count = z.set_count,
                        exercise_name = z.exercise_name,
                        reply_count = z.reply_count
                    }).ToList()
                }).ToList();

                return response;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return null;
            }
        }
    }
}