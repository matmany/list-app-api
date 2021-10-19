using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListApi;
using ListApi.Models;

namespace ListApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ListGroupsController : ControllerBase
  {
    private readonly ListApiContext _context;

    public ListGroupsController(ListApiContext context)
    {
      _context = context;
    }

    // GET: api/ListGroups
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ListGroup>>> GetListGroups()
    {
      return await _context.ListGroups.ToListAsync();
    }

    // GET: api/ListGroups/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ListGroup>> GetListGroup(int id)
    {
      var listGroup = await _context.ListGroups.FindAsync(id);

      if (listGroup == null)
      {
        return NotFound();
      }

      return listGroup;
    }

    // PUT: api/ListGroups/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutListGroup(int id, ListGroup listGroup)
    {
      if (id != listGroup.ID)
      {
        return BadRequest();
      }

      _context.Entry(listGroup).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ListGroupExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/ListGroups
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ListGroup>> PostListGroup(ListGroup listGroup)
    {
      _context.ListGroups.Add(listGroup);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetListGroup", new { id = listGroup.ID }, listGroup);
    }

    // DELETE: api/ListGroups/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteListGroup(int id)
    {
      var listGroup = await _context.ListGroups.FindAsync(id);
      if (listGroup == null)
      {
        return NotFound();
      }

      _context.ListGroups.Remove(listGroup);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool ListGroupExists(int id)
    {
      return _context.ListGroups.Any(e => e.ID == id);
    }
  }
}
