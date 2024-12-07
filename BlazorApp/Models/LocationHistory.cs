namespace BlazorApp.Models
{
    public class LocationHistory
    {
        public int LocationHistoryId { get; set; }
        public int TreeLocationId { get; set; }
        public TreeLocation TreeLocation { get; set; }
        public string ChangeDescription { get; set; }
        public DateTime Date { get; set; }
    }


}
