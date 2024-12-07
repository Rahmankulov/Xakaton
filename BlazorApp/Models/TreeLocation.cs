using static BlazorApp.Database.AgroContext;

namespace BlazorApp.Models
{
    public class TreeLocation
    {
        public int TreeLocationId { get; set; }
        public int BlockId { get; set; }
        public TreeBlock Block { get; set; }
        public string RowId { get; set; }
        public string ColId { get; set; }
        public string QRCode { get; set; }
        public LocationTreeStatus LocationTreeStatus {get;set;}

        public Tree Tree { get; set; }
        public ICollection<LocationHistory> History { get; set; }
    }
}
