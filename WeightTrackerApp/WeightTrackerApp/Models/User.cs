using Microsoft.AspNetCore.Identity;

namespace WeightTrackerApp.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Weight> Weights { get; set; }
    }
}