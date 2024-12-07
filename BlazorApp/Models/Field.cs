using static BlazorApp.Database.AgroContext;

namespace BlazorApp.Models
{
    public class Field
    {
        public int FieldId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Employee? EmployeeResponsible { get; set; }
        public int? EmployeId { get; set; }
        public ICollection<SectionField> SectionFields { get; set; }
        public ICollection<TreeBlock> Blocks { get; set; }
    }
}
