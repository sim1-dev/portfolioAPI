// so simple doesn't require mappings
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

public class TechnologyController : ControllerBase, IBasePortfolioController<Technology, TechnologyDto, CreateTechnologyDto, UpdateTechnologyDto, int>
{
    private readonly BaseContext _context;
    private readonly IMapper _mapper;

    public TechnologyController(BaseContext context, IMapper mapper) {
        this._context = context;
        this._mapper = mapper;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<TechnologyDto>>> Get() {
        List<Technology> technologies = await this._context.Technologies.ToListAsync();

        List<TechnologyDto> technologyDtos = _mapper.Map<List<TechnologyDto>>(technologies);

        return Ok(technologyDtos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TechnologyDto>> Find(int id) {
        Technology? technology = await this._context.Technologies.FirstOrDefaultAsync(technology => technology.Id == id);

        if(technology is null)
            return NotFound();

        TechnologyDto technologyDto = _mapper.Map<TechnologyDto>(technology);

        return Ok(technologyDto);
    }

    [HttpPost]
    public async Task<ActionResult<TechnologyDto>> Create([FromBody] CreateTechnologyDto createTechnologyDto) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        Technology technology = _mapper.Map<Technology>(createTechnologyDto);

        await this._context.Technologies.AddAsync(technology);

        await this._context.SaveChangesAsync();

        TechnologyDto technologyDto = _mapper.Map<TechnologyDto>(technology);

        return CreatedAtAction(nameof(Find), new { id = technology.Id }, technologyDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<TechnologyDto>> Update(int id, [FromBody] UpdateTechnologyDto updateTechnologyDto) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        Technology? existingTechnology = await this._context.Technologies.FirstOrDefaultAsync(technology => technology.Id == id);

        if(existingTechnology is null)
            return NotFound();

        Technology technology = _mapper.Map<Technology>(updateTechnologyDto);

        this._context.Entry(existingTechnology).CurrentValues.SetValues(technology);

        await this._context.SaveChangesAsync();

        TechnologyDto technologyDto = _mapper.Map<TechnologyDto>(existingTechnology);

        return CreatedAtAction(nameof(Find), new { id = technology.Id }, technologyDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id) {
        Technology? technology = await this._context.Technologies.FindAsync(id);

        if(technology is null)
            return NotFound();

        this._context.Technologies.Remove(technology);

        await this._context.SaveChangesAsync();

        return NoContent();
    }
}

