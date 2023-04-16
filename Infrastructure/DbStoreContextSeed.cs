using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Infrastructure
{
    public class DbStoreContextSeed
    {
        public static async Task SeedAsync(DbStoreContext context)
        {
            if (!context.Brands.Any())
            {
                var data = File.ReadAllText("../Infrastructure/Seed/brands.json");
                var brands = JsonSerializer.Deserialize<List<Brand>>(data);

                context.Brands.AddRange(brands);
            }

            if (!context.Types.Any())
            {
                var data = File.ReadAllText("../Infrastructure/Seed/types.json");
                var types = JsonSerializer.Deserialize<List<Core.Entities.Type>>(data);

                context.Types.AddRange(types);
            }
            if (!context.Products.Any())
            {
                var data = File.ReadAllText("../Infrastructure/Seed/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(data);

                foreach (var product in products)
                {
                    context.Products.Add(product);

                    if (product.Images != null)
                    {
                        foreach (var image in product.Images)
                        {
                            image.ProductId = product.Id;
                            context.Images.Add(image);
                        }
                    }
                }
            }
            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
