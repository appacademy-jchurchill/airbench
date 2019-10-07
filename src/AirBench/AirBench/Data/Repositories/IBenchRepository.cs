using System.Collections.Generic;
using System.Threading.Tasks;
using AirBench.Models;

namespace AirBench.Data.Repositories
{
    public interface IBenchRepository
    {
        Task<List<Bench>> GetList();
    }
}