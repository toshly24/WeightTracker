using System.ComponentModel.DataAnnotations;

namespace WeightTrackerApp.ViewModels
{
    public class WeightViewModel
    {
        public int Id { get; set; }
        [Required]
        public double WeightValue { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Tag { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}