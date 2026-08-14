using AssignmentService.Data;
using AssignmentService.DTOs;
using AssignmentService.Models;
using AssignmentService.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssignmentService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssignmentsController : ControllerBase
{
    private readonly AssignmentDbContext _context;
    private readonly IConfiguration _configuration;

    public AssignmentsController(
        AssignmentDbContext context,
        IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var assignments = await _context.Assignments
            .AsNoTracking()
            .ToListAsync();

        return Ok(assignments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var assignment = await _context.Assignments
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        if (assignment == null)
        {
            return NotFound();
        }

        return Ok(assignment);
    }

    [HttpGet("course/{courseId}")]
    public async Task<IActionResult> GetByCourse(int courseId)
    {
        var assignments = await _context.Assignments
            .AsNoTracking()
            .Where(a => a.CourseId == courseId)
            .ToListAsync();

        return Ok(assignments);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAssignmentDto dto)
    {
        if (!ApiKeyValidator.IsValid(Request, _configuration))
        {
            return Unauthorized();
        }

        var assignment = new Assignment
        {
            CourseId = dto.CourseId,
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate
        };

        _context.Assignments.Add(assignment);
        await _context.SaveChangesAsync();

        return Ok(assignment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateAssignmentDto dto)
    {
        if (!ApiKeyValidator.IsValid(Request, _configuration))
        {
            return Unauthorized();
        }

        var assignment = await _context.Assignments.FindAsync(id);

        if (assignment == null)
        {
            return NotFound();
        }

        assignment.CourseId = dto.CourseId;
        assignment.Title = dto.Title;
        assignment.Description = dto.Description;
        assignment.DueDate = dto.DueDate;

        await _context.SaveChangesAsync();

        return Ok(assignment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!ApiKeyValidator.IsValid(Request, _configuration))
        {
            return Unauthorized();
        }

        var assignment = await _context.Assignments.FindAsync(id);

        if (assignment == null)
        {
            return NotFound();
        }

        _context.Assignments.Remove(assignment);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}