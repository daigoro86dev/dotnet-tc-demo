using Alba;
using API;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using RestSharp;
using Xunit.Abstractions;

namespace APITests.Tests;

public class BaseTest : IAsyncLifetime
{
    protected readonly RestClient _restClient;
    protected readonly ITestOutputHelper _output;
    protected IAlbaHost host;


    public BaseTest(ITestOutputHelper output)
    {
    }

    protected readonly TestcontainerDatabase Testcontainer = new TestcontainersBuilder<PostgreSqlTestcontainer>()
           .WithDatabase(new PostgreSqlTestcontainerConfiguration
           {
               Database = "postgres",
               Username = "postgres",
               Password = "postgres",
           })
           .Build();

    public async Task InitializeAsync()
    {
        await Testcontainer.StartAsync();
    }

    public Task DisposeAsync()
    {
        return Testcontainer.DisposeAsync().AsTask();
    }

}