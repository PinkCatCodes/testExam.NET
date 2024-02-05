// See https://aka.ms/new-console-template for more information


using EFC;
using EFC.DbContext;
using EFC.Entities;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main()
    {
        await RunAsync();
    }

    static async Task RunAsync()
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<Context>()
            .AddScoped<DataAccess>()
            .BuildServiceProvider();

        using (var scope = serviceProvider.CreateScope())
        {
            var dataAccess = scope.ServiceProvider.GetRequiredService<DataAccess>();

            // Exercise 3.5 - Create Show
            var newShow = new Show { Title = "Example Show", Genre = "A great show." };
            dataAccess.CreateShow(newShow);

            Console.WriteLine("Show created successfully!");

            // Exercise 3.6 - Add Episode
            var episode = new Episode { Title = "Episode 1", Runtime = 45 };
            dataAccess.AddEpisodeToShow(newShow.ShowId, episode);

            Console.WriteLine("Episode added to the show successfully!");
        }
    }
}