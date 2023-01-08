using API;
using APITests.Utils;
using Core.Entities;
using Infrastructure.Data;
using Newtonsoft.Json;

namespace APITests.Tests;

public class ProductsTests : BaseTest
{
    private readonly HttpClient _client;

    public ProductsTests(IntegrationTestFactory<Startup, StoreContext> factory) : base(factory)
    {
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task Test_Get_Products()
    {
        var response = await _client.GetAsync("api/Products");

        var responseBody = await response.Content.ReadAsStringAsync();
        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseBody);

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Test_Get_ProductById()
    {
        var response = await _client.GetAsync("api/Products/1");

        var responseBody = await response.Content.ReadAsStringAsync();
        Product product = JsonConvert.DeserializeObject<Product>(responseBody);

        Assert.Equal(1, product.Id);
        response.EnsureSuccessStatusCode();
    }
}