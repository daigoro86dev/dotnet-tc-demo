using API;
using APITests.Utils;
using Core.Entities;
using Infrastructure.Data;
using Newtonsoft.Json;

namespace APITests.Tests;

public class ProductsTests : IClassFixture<IntegrationTestFactory<Startup, StoreContext>>
{
    private readonly IntegrationTestFactory<Startup, StoreContext> _factory;

    public ProductsTests(IntegrationTestFactory<Startup, StoreContext> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Test_Get_Products()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("api/Products");

        var responseBody = await response.Content.ReadAsStringAsync();
        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseBody);

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Test_Get_ProductById()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("api/Products/1");

        var responseBody = await response.Content.ReadAsStringAsync();
        Product product = JsonConvert.DeserializeObject<Product>(responseBody);

        Assert.Equal(1, product.Id);
        response.EnsureSuccessStatusCode();
    }
}