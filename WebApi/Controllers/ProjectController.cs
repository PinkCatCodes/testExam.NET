using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Service;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IDataService _dataService;

    public ProjectController(IDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpPost]
    public IActionResult CreateProject([FromBody] Project project)
    {
        _dataService.CreateProject(project);
        return Ok(project);
    }

    [HttpPost("{projectId}/userstories")]
    public IActionResult AddUserStoryToProject(int projectId, [FromBody] UserStory userStory)
    {
        _dataService.AddUserStoryToProject(projectId, userStory);
        return Ok(userStory);
    }

    [HttpGet("{projectId}")]
    public IActionResult GetProjectById(int projectId)
    {
        var project = _dataService.GetProjectById(projectId);

        if (project == null)
        {
            return NotFound();
        }

        return Ok(project);
    }

    [HttpGet("project-filter")]
   
    public IActionResult GetFilteredProjects(string? status, string? responsible )
    {
        var projects = _dataService.GetFilteredProjects(status, responsible);
        return Ok(projects);
    }
}