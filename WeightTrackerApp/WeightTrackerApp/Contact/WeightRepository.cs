using WeightTrackerApp.Data;
using WeightTrackerApp.Models;

namespace WeightTrackerApp.Contact
{
    public class WeightRepository : GenericRepository<Weight>, IWeightOfRepository
    {
        public WeightRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}