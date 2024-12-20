﻿// Services/TreeBlockService.cs
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
            return await _context.TreeBlocks.Include(p=>p.SectionField).ToListAsync();
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
            if (treeBlock.TreeLocations!=null)
            foreach(var treeLoc in treeBlock.TreeLocations)
            {
                var tree = new Tree
                {
                    TreeLocation = treeLoc,  // Связь с TreeLocation
                    TreeStatus = AgroContext.StatusTree.Ready
                };
                if (treeBlock.Species != null)
                {
                    tree.Species = treeBlock.Species;
                }
                _context.Trees.Add(tree);
            }
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
