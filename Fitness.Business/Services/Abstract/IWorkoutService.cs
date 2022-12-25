using Fitness.Entities.Request;
using Fitness.Entities.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Business.Services.Abstract
{
    public interface IWorkoutService
    {
        Task<GetWorkoutResponse> Get(int id);
        Task<List<GetWorkoutResponse>> GetAll();
        Task<int> Delete(int id);
        Task<int> Update(UpdateWorkoutRequest objReq);
        Task<int> Insert(InsertWorkoutRequest objReq);
    }
}
