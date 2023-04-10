using System.ComponentModel.DataAnnotations;

namespace WeightTrackerApp.ViewModels
{
    public class WeightViewModel
    {
        public int Id { get; set; }
        [Required]
        public double WeightValue { get; set; }
        public double HeightValue { get; set; }
        public double? BIMValue { get; set; }
        public string? UserId { get; set; }
        [Required]
        public string Tag { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}