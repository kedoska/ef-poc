using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql("Host=localhost;Database=my_db;Username=username;Password=password"));

        services.AddScoped<Repository<Agent>, AgentRepository>();
    })
    .Build();

using var serviceScope = host.Services.CreateScope();
var services = serviceScope.ServiceProvider;

try
{
    var agentRepository = services.GetRequiredService<Repository<Agent>>();

    var newAgent = new Agent
    {
        Name = "New Agent",
    };

    _ = agentRepository.Add(newAgent);
    await agentRepository.SaveAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}


try
{
    var agentRepository = services.GetRequiredService<Repository<Agent>>();
    var agents = await agentRepository.GetAll();

    foreach (var agent in agents)
    {
        Console.WriteLine($"Agent Name: {agent.Name}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}