namespace WeightTrackerApp.Contact
{
    public interface IUnitOfWork
    {
        IWeightOfRepository Weight { get; }
        void Save();
    }
}