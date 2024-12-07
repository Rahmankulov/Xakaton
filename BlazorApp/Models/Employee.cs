using static BlazorApp.Database.AgroContext;

namespace BlazorApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public Role Role { get; set; }
        public string Login { get; set; }

        public ICollection<EmployeeTask> Tasks { get; set; }
    }
}
