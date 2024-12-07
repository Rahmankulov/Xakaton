// Services/TreeBlockService.cs
using BlazorApp.Database;
using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{
    public class TreeBlockService
    {
        private readonly AgroContext _context;

        public TreeBlockService(AgroContext context)
        {
            _context = context;
        }

        // Получить все TreeBlock
        public async Task<List<TreeBlock>> GetAllTreeBlocksAsync()
        {
            return await _context.TreeBlocks.ToListAsync();
        }

        public async Task<List<SectionField>> GetAllSectionsAsync()
        {
            return await _context.SectionFields.ToListAsync();
        }

        // Получить TreeBlock по ID
        public async Task<TreeBlock> GetTreeBlockByIdAsync(int id)
        {
            return await _context.TreeBlocks.FirstOrDefaultAsync(tb => tb.BlockId == id);
        }

        // Создать TreeBlock
        public async Task CreateTreeBlockAsync(TreeBlock treeBlock)
        {
            _context.TreeBlocks.Add(treeBlock);
            await _context.SaveChangesAsync();
        }

        // Обновить TreeBlock
        public async Task UpdateTreeBlockAsync(TreeBlock treeBlock)
        {
            _context.TreeBlocks.Update(treeBlock);
            await _context.SaveChangesAsync();
        }

        // Удалить TreeBlock
        public async Task DeleteTreeBlockAsync(int id)
        {
            var treeBlock = await _context.TreeBlocks.FindAsync(id);
            if (treeBlock != null)
            {
                _context.TreeBlocks.Remove(treeBlock);
                await _context.SaveChangesAsync();
            }
        }
    }
}
