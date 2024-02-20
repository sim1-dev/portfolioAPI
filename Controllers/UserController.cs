using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using PortfolioAPI.Core.DataContexts;
using PortfolioAPI.Core.Models;
using PortfolioAPI.Dtos;

namespace PortfolioAPI.Controllers;

[ApiController]
[Route("api/users"), Authorize]
public class UsersController : ControllerBase, IBasePortfolioController<User, UserDto, CreateUserDto, UpdateUserDto, string>
{
    private readonly BaseContext _context;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;


    public UsersController(BaseContext context, IMapper mapper, UserManager<User> userManager) {
        this._context = context;
        this._mapper = mapper;
        this._userManager = userManager;
    }
    [HttpGet]
    public async Task<ActionResult<Collection<UserDto>>> Get() {
        IQueryable<User> usersQuery = _context.Users.AsQueryable();

        List<User> users = await usersQuery.ToListAsync();
        List<UserDto> usersDto = _mapper.Map<List<UserDto>>(users);
        return Ok(usersDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> Find(string id) {
        User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user is null)
            return NotFound();

        UserDto userDto = _mapper.Map<UserDto>(user);
        return Ok(userDto);
    }
    [HttpPost]
    public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserDto userDto) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        User user = _mapper.Map<User>(userDto);

        try {
            IdentityResult result = await _userManager.CreateAsync(user, "Password1!");

            if(!result.Succeeded)
                return StatusCode(500, "An error has occurred while creating the user");

            await _userManager.AddToRoleAsync(user, "User");

            UserDto newUserDto = _mapper.Map<UserDto>(user);

            return CreatedAtAction(nameof(Find), new { id = user.Id }, newUserDto);
        }
        catch (DbUpdateException e)
        when (e.InnerException is MySqlException mySqlException && mySqlException.Number == 1062) {
            return BadRequest("Email already taken");
        }
        catch (Exception e) {
            return StatusCode(500, $"An error has occurred: {e.Message}");;
        }
    }
    [HttpPatch("{userId}")]
    public async Task<ActionResult<UserDto>> Update([FromRoute] string userId, [FromBody] UpdateUserDto updateUserDto) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        User? user = await _context.Users.FindAsync(userId);

        if (user is null)
            return NotFound($"User with ID {userId} not found.");

        try {
            this._context.Entry(user).CurrentValues.SetValues(updateUserDto);

            await _context.SaveChangesAsync();

            UserDto userDto = _mapper.Map<UserDto>(user);

            return CreatedAtAction(nameof(Find), new { id = user.Id }, userDto);
        }
        catch (DbUpdateException e)
        when (e.InnerException is MySqlException mySqlException && mySqlException.Number == 1062) {
            return BadRequest("Email already taken");
        }
        catch (Exception) {
            return StatusCode(500, "An error has occurred");
        }
    }


    [HttpDelete("{userId}")]
    public async Task<ActionResult> Delete(string userId) {
        User? user = await _context.Users.FindAsync(userId);

        if (user is null)
            return NotFound($"No User found with ID {userId}");

        try {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (DbUpdateException e)
        when (e.InnerException is MySqlException) {
            return BadRequest("User has other records, please delete assigned tasks");
        }
        catch (Exception) {
            return StatusCode(500, "An error has occurred");
        }

    }
}

