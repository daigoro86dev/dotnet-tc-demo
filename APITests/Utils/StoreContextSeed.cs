using System.Text.Json;
using Core.Entities;
using Infrastructure.Data;

namespace APITests.Utils;

public class StoreContextSeed
{
    public static void SeedSync(StoreContext context)
    {
        if (!context.ProductBrands.Any())
        {
            var brandsData = File.ReadAllText("../../../Utils/SeedData/brands.json");

            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

            foreach (var item in brands)
            {
                context.ProductBrands.Add(item);
            }
        }

        if (!context.ProductTypes.Any())
        {
            var typesData = File.ReadAllText("../../../Utils/SeedData/types.json");

            var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

            foreach (var item in types)
            {
                context.ProductTypes.Add(item);
            }
        }

        if (!context.Products.Any())
        {
            var productsData = File.ReadAllText("../../../Utils/SeedData/products.json");

            var products = JsonSerializer.Deserialize<List<Product>>(productsData);

            foreach (var item in products)
            {
                context.Products.Add(item);
            }
        }

        context.SaveChanges();
    }
}

