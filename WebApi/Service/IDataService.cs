using WebApi.Entities;

namespace WebApi.Service;

public interface IDataService
{
    List<Project> GetFilteredProjects(string? statusFilter, string? responsibleFilter);
    Project GetProjectById(int projectId);
    void CreateProject(Project project);
    void AddUserStoryToProject(int projectId, UserStory userStory);
    List<Project> DummyData();
}