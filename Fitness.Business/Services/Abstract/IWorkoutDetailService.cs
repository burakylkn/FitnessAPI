using Fitness.Entities.Request;
using Fitness.Entities.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Business.Services.Abstract
{
    public interface IWorkoutDetailService
    {
        Task<List<GetWorkoutDetailResponse>> GetAllWorkoutDetail();
        Task<GetWorkoutDetailResponse> GetWorkoutDetail(int id);
        Task<List<GetWorkoutDetailResponse>> GetWorkoutDetailByFilter(GetWorkoutDetailbyFilterRequest objReq);
    }
}
