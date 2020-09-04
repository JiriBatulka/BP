namespace BP.Models
{
    public class Customer : User
    {
        public double? CurrentLat { get; set; }
        public double? CurrentLng { get; set; }
    }
}
