using IssueTrackingApi.Data;
using IssueTrackingApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace IssueTrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    { 
        private readonly IssueDbContext _context;
        public IssueController(IssueDbContext context) =>_context = context;

        [HttpGet]
        public async Task<IEnumerable<Issue>> GetAll()
            => await _context.Issues.ToListAsync();

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var Issue = await _context.Issues.FindAsync(id);
            return Issue == null ? NotFound() : Ok(Issue);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Issue issue)
        {
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = issue.Id }, issue);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Issue issue)
        {
            //if (id != issue.Id) return BadRequest();
            var isFound = await _context.Issues.FindAsync(id);
            if (isFound == null)
                return NotFound();
            isFound.Title = issue.Title;
            isFound.Description = issue.Description;
            isFound.Priority = issue.Priority;
            isFound.IssueType = issue.IssueType;
            isFound.Completed = issue.Completed;
            //_context.Entry(issue).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var isFound = await _context.Issues.FindAsync(id);
            if (isFound == null) return NotFound();

            _context.Issues.Remove(isFound);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
