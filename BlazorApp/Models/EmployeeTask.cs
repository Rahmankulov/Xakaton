namespace BlazorApp.Models
{
    public class EmployeeTask
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public int TreeId { get; set; }
        public Tree Tree { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
