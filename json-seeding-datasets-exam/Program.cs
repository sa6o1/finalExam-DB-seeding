
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=JsonSeedingExam;Trusted_Connection=True;MultipleActiveResultSets=true"));
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await dbContext.Database.MigrateAsync();
    Console.WriteLine("Database migrated and seeded successfully.");
}

Console.WriteLine("Application finished.");