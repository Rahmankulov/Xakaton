// Services/TreeService.cs
using BlazorApp.Database;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{
    public class TreeService
    {
        private readonly AgroContext _context;

        public TreeService(AgroContext context)
        {
            _context = context;
        }

        // Получить все деревья
        public async Task<List<Tree>> GetAllTreesAsync()
        {
            return await _context.Trees.Include(t => t.TreeLocation).ToListAsync();
        }

        // Получить дерево по ID
        public async Task<Tree> GetTreeByIdAsync(int id)
        {
            return await _context.Trees.Include(t => t.TreeLocation).FirstOrDefaultAsync(t => t.TreeId == id);
        }

        // Создать дерево
        public async Task CreateTreeAsync(Tree tree)
        {
            tree.PlantedDate = tree.PlantedDate.ToUniversalTime();
            _context.Trees.Add(tree);
            await _context.SaveChangesAsync();
        }

        // Обновить дерево
        public async Task UpdateTreeAsync(Tree tree)
        {
            _context.Trees.Update(tree);
            await _context.SaveChangesAsync();
        }

        // Удалить дерево
        public async Task DeleteTreeAsync(int id)
        {
            var tree = await _context.Trees.FindAsync(id);
            if (tree != null)
            {
                _context.Trees.Remove(tree);
                await _context.SaveChangesAsync();
            }
        }
    }
}
