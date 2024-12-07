namespace BlazorApp.Models
{
    public class TreeHistory
    {
        public int TreeHistoryId { get; set; }
        public int TreeId { get; set; }
        public Tree Tree { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
