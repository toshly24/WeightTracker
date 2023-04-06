namespace WeightTrackerApp.Contact
{
    public interface IUnitOfWork
    {
        IWeightOfRepository Note { get; }
        void Save();
    }
}