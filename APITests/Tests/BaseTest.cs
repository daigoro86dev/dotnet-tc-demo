using API;
using APITests.Utils;
using Infrastructure.Data;

namespace APITests.Tests;

public class BaseTest : IClassFixture<IntegrationTestFactory<Startup, StoreContext>>
{
    protected readonly IntegrationTestFactory<Startup, StoreContext> _factory;

    public BaseTest(IntegrationTestFactory<Startup, StoreContext> factory)
    {
        _factory = factory;
    }
}