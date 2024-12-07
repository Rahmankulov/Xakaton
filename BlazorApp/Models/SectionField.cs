namespace BlazorApp.Models
{
        public class SectionField
        {
            public int SectionFieldId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int FieldId { get; set; } // Внешний ключ к Field
            public Field Field { get; set; } // Навигационное свойство к Field
            public Employee? EmployeeResponsible { get; set; }
            public int? EmployeId { get; set; }
            public ICollection<TreeBlock> TreeBlocks { get; set; } // Навигационное свойство к TreeBlock
        }
}
