using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC.Entities;

public class Episode
{
    [Key]
    public int EpisodeId { get; set; }
    public string Title { get; set; }
    public int Runtime { get; set; }
    public int SeasonId { get; set; }
   
    
    [ForeignKey("Show")]
    public int ShowId { get; set; }
    public Show Show { get; set; }

   
    public Episode(string title, int runtime, int seasonId)
    {
        Title = title;
        Runtime = runtime;
        SeasonId = seasonId;
    }

    public Episode()
    {
        
    }

    
}