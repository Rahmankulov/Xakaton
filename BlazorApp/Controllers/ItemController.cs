using BlazorApp.Database;
using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace BlazorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController:ControllerBase
    {
        AgroContext context;
        public ItemController(AgroContext _context)
        {
            context = _context;
        }

        [HttpGet]
        [Route("gettreebyid")]
        public ActionResult<Tree> GetTreeByIdAsync(int treeId)
        {
            var tree = context.Trees
                .Include(t => t.TreeLocation)
                .FirstOrDefault(t => t.TreeId == treeId);
            if (tree == null)
            {
                Console.WriteLine("Данные не получены");
            }

            return Ok(tree);
        }


        [HttpGet]
        [Route("getalltrees")]
        public ActionResult<List<Tree>> GetAllTrees()
        {
            var trees = context.Trees
                .Include(t => t.TreeLocation)
                .ToList();

            return Ok(trees);
        }
    }
}
