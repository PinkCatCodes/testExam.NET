using EFC.DbContext;
using EFC.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFC;

public class DataAccess
{
    private readonly Context context;

    public DataAccess(Context context)
    {
        this.context = context;
    }

    public async Task<Show> CreateShow(Show show)
    {
        var created = await context.Shows.AddAsync(show);
        await context.SaveChangesAsync();
        return created.Entity;
    }
    
    public async Task AddEpisodeToShow(int showId, Episode episode)
    { 
        var show = await context.Shows.Include(s => s.Episodes).FirstOrDefaultAsync(s => s.ShowId == showId);

        if (show != null)
        {
            show.Episodes.Add(episode);
            await context.SaveChangesAsync();
        }
        else
        {
            Console.WriteLine($"Show with ID {showId} not found.");
        }
       
    }
}