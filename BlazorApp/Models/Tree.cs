using static BlazorApp.Database.AgroContext;

namespace BlazorApp.Models
{
    public class Tree
    {
        public int TreeId { get; set; }
        public string Species { get; set; } // Вид дерева
        public DateTime PlantedDate { get; set; }
        public int? TreeLocationId { get; set; }
        public string TreeStatus { get; set; }
        public TreeLocation? TreeLocation { get; set; }
        public ICollection<TreeHistory> History { get; set; }
    }
}
