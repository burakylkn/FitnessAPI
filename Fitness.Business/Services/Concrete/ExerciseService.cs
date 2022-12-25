using Fitness.Business.Services.Abstract;
using Fitness.Common.Helper;
using Fitness.Data.DBManager;
using Fitness.Entities.Request;
using Fitness.Entities.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Business.Services.Concrete
{
    public class ExerciseService : IExerciseService
    {
        protected FitnessDbContext _context;
        protected IConfiguration _config;
        private readonly ILogger<IExerciseService> _logger;

        public ExerciseService(FitnessDbContext context, IConfiguration config, ILogger<IExerciseService> logger)
        {
            _context = context;
            _config = config;
            _logger = logger;
        }

        public async Task<GetExerciseResponse> Get(int id)
        {
            try
            {
                _context.Connection.Open();
                MySqlCommand cmd = new MySqlCommand("GetExercise", _context.Connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("_id", id));
                var rdr = cmd.ExecuteReader();
                rdr.Read();
                var result = SQLHelper.ConvertToObject<GetExerciseResponse>(rdr);
                rdr.Close();
                _context.Connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                
                return null;
            }
        }
        public async Task<List<GetExerciseResponse>> GetAll()
        {
            try
            {
                var list = new List<GetExerciseResponse>();
                _context.Connection.Open();
                MySqlCommand cmd = new MySqlCommand("GetAllExercise", _context.Connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(SQLHelper.ConvertToObject<GetExerciseResponse>(rdr));
                }
                rdr.Close();
                _context.Connection.Close();

                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        public async Task<int> Delete(int id)
        {
            try
            {
                _context.Connection.Open();
                MySqlCommand cmd = new MySqlCommand("DeleteExercise", _context.Connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("_id", id));
                var result = cmd.ExecuteNonQuery();
                _context.Connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }
        public async Task<int> Update(UpdateExerciseRequest objReq)
        {
            try
            {
                _context.Connection.Open();
                MySqlCommand cmd = new MySqlCommand("UpdateExercise", _context.Connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("_id", objReq.id));
                cmd.Parameters.Add(new MySqlParameter("_name", objReq.name));
                cmd.Parameters.Add(new MySqlParameter("_set_count", objReq.set_count));
                cmd.Parameters.Add(new MySqlParameter("_reply_count", objReq.reply_count));
                cmd.Parameters.Add(new MySqlParameter("_workout_id", objReq.workout_id));
                cmd.Parameters.Add(new MySqlParameter("_updated_at", DateTime.Now));
                cmd.Parameters.Add(new MySqlParameter("_updated_by", _config["Application:UserName"]));
                var result = cmd.ExecuteNonQuery();
                _context.Connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }
        public async Task<int> Insert(InsertExerciseRequest objReq)
        {
            try
            {
                _context.Connection.Open();
                MySqlCommand cmd = new MySqlCommand("InsertExercise", _context.Connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("_name", objReq.name));
                cmd.Parameters.Add(new MySqlParameter("_set_count", objReq.set_count));
                cmd.Parameters.Add(new MySqlParameter("_reply_count", objReq.reply_count));
                cmd.Parameters.Add(new MySqlParameter("_workout_id", objReq.workout_id));
                cmd.Parameters.Add(new MySqlParameter("_created_at", DateTime.Now));
                cmd.Parameters.Add(new MySqlParameter("_created_by", _config["Application:UserName"]));
                var result = cmd.ExecuteNonQuery();
                _context.Connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }
    }
}
