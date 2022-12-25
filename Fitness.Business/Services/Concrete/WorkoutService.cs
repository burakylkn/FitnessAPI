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
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fitness.Business.Services.Concrete
{
    public class WorkoutService : IWorkoutService
    {
        protected FitnessDbContext _context;
        protected IConfiguration _config;
        private readonly ILogger<IWorkoutService> _logger;
        public WorkoutService(FitnessDbContext context, IConfiguration config, ILogger<IWorkoutService> logger)
        {
            _context= context;
            _config= config;
            _logger= logger;
        }

        public async Task<GetWorkoutResponse> Get(int id)
        {
            try
            {
                _context.Connection.Open();
                MySqlCommand cmd = new MySqlCommand("GetWorkout", _context.Connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("_id", id));
                var rdr =cmd.ExecuteReader();
                rdr.Read();
                var result = SQLHelper.ConvertToObject<GetWorkoutResponse>(rdr);
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
        public async Task<List<GetWorkoutResponse>> GetAll()
        {
            try
            {
                var list = new List<GetWorkoutResponse>();
                _context.Connection.Open();
                MySqlCommand cmd = new MySqlCommand("GetAllWorkout", _context.Connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(SQLHelper.ConvertToObject<GetWorkoutResponse>(rdr));
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
                MySqlCommand cmd = new MySqlCommand("DeleteWorkout", _context.Connection);
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
        public async Task<int> Update(UpdateWorkoutRequest objReq)
        {
            try
            {
                _context.Connection.Open();
                MySqlCommand cmd = new MySqlCommand("UpdateWorkout", _context.Connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("_id", objReq.id));
                cmd.Parameters.Add(new MySqlParameter("_name", objReq.name));
                cmd.Parameters.Add(new MySqlParameter("_total_time", objReq.total_time));
                cmd.Parameters.Add(new MySqlParameter("_prm_difficulty_id", objReq.prm_difficulty_id));
                cmd.Parameters.Add(new MySqlParameter("_prm_workout_area_id", objReq.prm_workout_area_id));
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
        public async Task<int> Insert(InsertWorkoutRequest objReq)
        {
            try
            {
                _context.Connection.Open();
                MySqlCommand cmd = new MySqlCommand("InsertWorkout", _context.Connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("_name", objReq.name));
                cmd.Parameters.Add(new MySqlParameter("_total_time", objReq.total_time));
                cmd.Parameters.Add(new MySqlParameter("_prm_difficulty_id", objReq.prm_difficulty_id));
                cmd.Parameters.Add(new MySqlParameter("_prm_workout_area_id", objReq.prm_workout_area_id));
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
