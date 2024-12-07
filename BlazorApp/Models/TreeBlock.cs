using static BlazorApp.Database.AgroContext;

namespace BlazorApp.Models
{
    public class TreeBlock
    {
        public int BlockId { get; set; }
        public string Name { get; set; }
        public int SectionFieldId { get; set; } // Внешний ключ к SectionField
        public SectionField SectionField { get; set; }
        public ICollection<TreeLocation> TreeLocations { get; set; }
    }
}
