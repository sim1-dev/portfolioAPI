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
public class CompanyController : ControllerBase, IBasePortfolioController<Company, CompanyDto, CreateCompanyDto, UpdateCompanyDto, int>
{
    private readonly BaseContext _context;
    private readonly IMapper _mapper;

    public CompanyController(BaseContext context, IMapper mapper) {
        this._context = context;
        this._mapper = mapper;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<CompanyDto>>> Get() {
        List<Company> companies = await this._context.Companies
            .Include(company => company.Projects!)
            .ThenInclude(project => project.Technologies)
            .ToListAsync();

        if(companies is null)
            return NotFound();

        return Ok(_mapper.Map<IEnumerable<CompanyDto>>(companies));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CompanyDto>> Find(int id) {

        Company? company = await this._context.Companies.Include(company => company.Projects).FirstOrDefaultAsync(company => company.Id == id);

        if(company is null)
            return NotFound();

        CompanyDto companyDto = _mapper.Map<CompanyDto>(company);

        return Ok(companyDto);
    }

    [HttpPost]
    public async Task<ActionResult<CompanyDto>> Create([FromBody] CreateCompanyDto createCompanyDto) {
        if (!ModelState.IsValid)
		    return BadRequest(ModelState);

        if (createCompanyDto is null)
            return BadRequest();

        Company company = _mapper.Map<Company>(createCompanyDto);

        this._context.Companies.Add(company);

        await this._context.SaveChangesAsync();

        CompanyDto companyDto = _mapper.Map<CompanyDto>(company);

        return CreatedAtAction(nameof(Find), new { id = company.Id }, companyDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<CompanyDto>> Update([FromRoute] int id, [FromBody] UpdateCompanyDto updateCompanyDto) {
        if (!ModelState.IsValid)
		    return BadRequest(ModelState);

        if (updateCompanyDto is null)
            return BadRequest();

        Company? existingCompany = await this._context.Companies.FindAsync(id);

        if (existingCompany is null)
            return NotFound($"Company {id} not found");

        this._context.Entry(existingCompany).CurrentValues.SetValues(updateCompanyDto);

        await this._context.SaveChangesAsync();

        CompanyDto companyDto = _mapper.Map<CompanyDto>(existingCompany);

        return Ok(companyDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id) {
        Company? company = await this._context.Companies.FindAsync(id);

        if (company is null)
            return NotFound();

        this._context.Companies.Remove(company);

        await this._context.SaveChangesAsync();
        
        return Ok();
    }
}