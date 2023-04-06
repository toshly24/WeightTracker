using WeightTrackerApp.Contact;

namespace WeightTrackerApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public IWeightOfRepository Weight { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            Weight = new WeightRepository(context);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}