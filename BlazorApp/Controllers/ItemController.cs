using BlazorApp.Database;
using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;

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

        /*[HttpGet]
        [Route("items")]
        public async Task<List<Items>> GetItems(int id)
        {
            if(id <= 0)
            {
                //return await Task.FromResult(context.Items.ToList());
            }
            else
            {
                //return await Task.FromResult(context.Items.Where(i=>i.Id == id).ToList());
            }
            return null;
        }*/
    }
}
