using AirBench.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace AirBench.Data.Repositories
{
    public class BenchRepository : IBenchRepository
    {
        private IContext context;

        public BenchRepository(IContext context)
        {
            this.context = context;
        }

        public Task<List<Bench>> GetList()
        {
            return context.Benches
                .Include(b => b.User)
                .Include(b => b.Reviews)
                .OrderByDescending(b => b.CreatedOn)
                .ToListAsync();
        }
    }
}