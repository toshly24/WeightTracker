namespace WeightTrackerApp.Models
{
    public class Weight
    {
        public int Id { get; set; }
        public double WeightValue { get; set; }
        public double HeightValue { get; set; }
        public double? BIMValue { get; set; }
        public string UserId { get; set; }
        public string Tag { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public User User { get; set; }
    }
}