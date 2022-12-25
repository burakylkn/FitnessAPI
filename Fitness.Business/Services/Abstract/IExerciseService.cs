using Fitness.Entities.Request;
using Fitness.Entities.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Business.Services.Abstract
{
    public interface IExerciseService
    {
        Task<GetExerciseResponse> Get(int id);
        Task<List<GetExerciseResponse>> GetAll();
        Task<int> Delete(int id);
        Task<int> Update(UpdateExerciseRequest objReq);
        Task<int> Insert(InsertExerciseRequest objReq);
    }
}
