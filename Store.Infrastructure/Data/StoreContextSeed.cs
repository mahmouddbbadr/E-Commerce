using Microsoft.Extensions.Logging;
using Store.Core.Entities;
using System.Text.Json;

namespace Store.Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var productBrands = File.ReadAllText("../Store.Infrastructure/DataSeed/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrands);
                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.ProductTypes.Any())
                {
                    var productTypes = File.ReadAllText("../Store.Infrastructure/DataSeed/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(productTypes);
                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText("../Store.Infrastructure/DataSeed/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);
                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
