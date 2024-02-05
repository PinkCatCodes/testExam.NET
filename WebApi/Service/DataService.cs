using WebApi.Entities;

namespace WebApi.Service;

public class DataService : IDataService
{
    private List<Project> Projects { get; set; } 

    public DataService()
    {
        Projects = DummyData();
    }

    public List<Project> DummyData()
    {
        var projects = new List<Project>();

       
        for (int i = 1; i <= 2; i++)
        {
            var project = new Project
            {
                Id = i,
                Title = $"Project {i}",
                Status = "Active",
                Responsible = "VIA", 
                UserStories = new List<UserStory>()
            };

            for (int j = 1; j <= 3; j++)
            {
                var userStory = new UserStory
                {
                    Id = j, 
                    Description = $"User Story {j} for Project {i}", 
                    Estimate = 2
                };

                project.UserStories.Add(userStory);
            }

            projects.Add(project);
        }

        return projects;
    }
    
    public void CreateProject(Project project)
    {
        try
        {
            
            Projects.Add(project);
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred:{e.Message}");
        }
    }
    
    public Project GetProjectById(int projectId)
    {
        try
        {

            return Projects.FirstOrDefault(p => p.Id == projectId);
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred:{e.Message}");
           
        }

        return null;
    }
    
    

    public void AddUserStoryToProject(int projectId, UserStory userStory)
    {
        try
        {
            var project = Projects.FirstOrDefault(p => p.Id == projectId);

            if (project != null)
            {
                
                userStory.Id = project.UserStories.Count + 1;
                project.UserStories.Add(userStory);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred:{e.Message}");
        }
    }

    

    public List<Project> GetFilteredProjects(string? status, string? responsible)
    {
        try
        {
            var filter = Projects;

            if (!string.IsNullOrEmpty(status))
            {
                filter = filter.Where(p => p.Status == status).ToList();
            }

            if (!string.IsNullOrEmpty(responsible))
            {
                filter = filter.Where(p => p.Responsible == responsible).ToList();
            }

            return filter;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred::{e.Message}");
            return new List<Project>();
        }
    }

   
   
}