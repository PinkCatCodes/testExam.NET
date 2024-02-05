using System.ComponentModel.DataAnnotations;

namespace EFC.Entities;

public class Show
{
    [Key]
    public int ShowId { get; set; }
    
    [Required]
    public string Title { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; }

    public List<Episode> Episodes { get; set; }

    public Show( string title, int year, string genre)
    {
        
        Title = title;
        Year = year;
        Genre = genre;
    }

    public Show()
    {
        
    }
}