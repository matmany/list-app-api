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
  [Route("api/list-groups/{listGroupId}/[controller]")]
  [ApiController]
  public class ListsController : ControllerBase
  {
    private readonly ListApiContext _context;

    public ListsController(ListApiContext context)
    {
      _context = context;
    }

    // GET: api/Lists
    [HttpGet]
    public async Task<ActionResult<IEnumerable<List>>> GetLists([FromRoute] int listGroupId)
    {
      var listGroup = await _context.ListGroups.FindAsync(listGroupId);

      if (listGroup == null)
      {
        return NotFound();
      }

      return await _context.Lists.Where(l => l.ListGroupID == listGroupId).ToListAsync();
    }

    // GET: api/Lists/5
    [HttpGet("{id}")]
    public async Task<ActionResult<List>> GetList([FromRoute] int listGroupId, int id)
    {
      var list = await _context.Lists.FirstOrDefaultAsync(l =>
       l.ListGroupID == listGroupId && l.ID == id);

      if (list == null)
      {
        return NotFound();
      }

      return list;
    }

    // PUT: api/Lists/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutList(int id, List list)
    {
      if (id != list.ID)
      {
        return BadRequest();
      }

      _context.Entry(list).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ListExists(id))
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

    // POST: api/Lists
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<List>> PostList(List list)
    {
      _context.Lists.Add(list);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetList", new { id = list.ID }, list);
    }

    // DELETE: api/Lists/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteList(int id)
    {
      var list = await _context.Lists.FindAsync(id);
      if (list == null)
      {
        return NotFound();
      }

      _context.Lists.Remove(list);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool ListExists(int id)
    {
      return _context.Lists.Any(e => e.ID == id);
    }
  }
}
