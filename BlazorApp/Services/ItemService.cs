using BlazorApp.Models;
using System.Data.SqlClient;

namespace BlazorApp.Services
{
    public class ItemService
    {
        private readonly string _connectionString;

        public ItemService(string connectionString)
        {
            _connectionString = connectionString;
        }

        /*public async Task<List<Items>> GetProductsAsync()
        {
            var products = new List<Items>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("select LOGICALREF AS ID, NAME, 4.5 as PRICE from LG_001_ITEMS", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var product = new Items
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                            //Price = reader.GetDouble(2)
                        };
                        products.Add(product);
                    }
                }
            }

            return products;
        }*/
    }
}
