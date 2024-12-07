using static BlazorApp.Database.AgroContext;

namespace BlazorApp.Models
{
    public class TreeLocation
    {
        public int TreeLocationId { get; set; }
        public int BlockId { get; set; }
        public TreeBlock Block { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Tree Tree { get; set; }
        public ICollection<LocationHistory> History { get; set; }
    }
}
