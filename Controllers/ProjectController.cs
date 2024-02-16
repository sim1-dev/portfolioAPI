using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Core.DataContexts;
using PortfolioAPI.Core.Models;
using PortfolioAPI.Dtos;

namespace PortfolioAPI.Controllers;

[ApiController]
[Route("api/[controller]"), Authorize]
//[Authorize]
public class ProjectController : ControllerBase, IBasePortfolioController<Project, ProjectDto, CreateProjectDto, UpdateProjectDto, int>
{
    private readonly BaseContext _context;
    private readonly IMapper _mapper;

    public ProjectController(BaseContext context, IMapper mapper) {
        this._context = context;
        this._mapper = mapper;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ProjectDto>>> Get() {
        List<Project> projects = await this._context.Projects
        .Include(projects => projects.Company)
        .ToListAsync();

        if(projects is null)
            return NotFound();

        IEnumerable<ProjectDto> projectsDto = _mapper.Map<IEnumerable<ProjectDto>>(projects);

        return Ok(projectsDto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProjectDto>> Find(int id) {
        Project? project = await this._context.Projects.Include(project => project.Company).FirstOrDefaultAsync(project => project.Id == id);

        if(project is null)
            return NotFound();

        ProjectDto projectDto = _mapper.Map<ProjectDto>(project);

        return Ok(project);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectDto>> Create([FromBody] CreateProjectDto createProjectDto) {
        if (!ModelState.IsValid)
		    return BadRequest(ModelState);

            Project project = _mapper.Map<Project>(createProjectDto);
            project.Company = await this._context.Companies.FirstOrDefaultAsync(company => company.Id == createProjectDto.CompanyId);

            if(project.Company is null)
                return NotFound();

            this._context.Projects.Add(project);
            await this._context.SaveChangesAsync();

            ProjectDto projectDto = _mapper.Map<ProjectDto>(project);

            return CreatedAtAction(nameof(Find), new { id = project.Id }, projectDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ProjectDto>> Update([FromRoute] int id, [FromBody] UpdateProjectDto updateProjectDto) {
        if (!ModelState.IsValid)
		    return BadRequest(ModelState);

            if (updateProjectDto is null)
                return BadRequest();

            Project? existingProject = await this._context.Projects.FirstOrDefaultAsync(project => project.Id == id);

            if(existingProject is null)
                return NotFound();

            this._context.Entry(existingProject).CurrentValues.SetValues(updateProjectDto);

            await this._context.SaveChangesAsync();

            ProjectDto projectDto = _mapper.Map<ProjectDto>(existingProject);

            return CreatedAtAction(nameof(Find), new { id = existingProject.Id }, projectDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id) {
        Project? project = await this._context.Projects.FirstOrDefaultAsync(project => project.Id == id);

        if(project is null)
            return NotFound();

        this._context.Projects.Remove(project);
        await this._context.SaveChangesAsync();

        return NoContent();
    }

}