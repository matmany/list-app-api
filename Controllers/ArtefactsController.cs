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
  [Route("api/list/{listId}/[controller]")]
  [ApiController]
  public class ArtefactsController : ControllerBase
  {
    private readonly ListApiContext _context;

    public ArtefactsController(ListApiContext context)
    {
      _context = context;
    }

    // GET: api/Artefacts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Artefact>>> GetArtefacts([FromRoute] int listId)
    {
      var list = _context.Lists.FindAsync(listId);
      if (list == null)
      {
        return NotFound();
      }

      return await _context.Artefacts.Where(a => a.ListID == listId).ToListAsync();
    }

    // GET: api/Artefacts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Artefact>> GetArtefact([FromRoute] int listId, int id)
    {


      var artefact = await _context.Artefacts.FirstOrDefaultAsync(a =>
         a.ListID == listId && a.ID == id);

      if (artefact == null)
      {
        return NotFound();
      }

      return artefact;
    }

    // PUT: api/Artefacts/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutArtefact(int id, Artefact artefact)
    {
      if (id != artefact.ID)
      {
        return BadRequest();
      }

      _context.Entry(artefact).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ArtefactExists(id))
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

    // POST: api/Artefacts
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Artefact>> PostArtefact(Artefact artefact)
    {
      _context.Artefacts.Add(artefact);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetArtefact", new { id = artefact.ID }, artefact);
    }

    // DELETE: api/Artefacts/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArtefact(int id)
    {
      var artefact = await _context.Artefacts.FindAsync(id);
      if (artefact == null)
      {
        return NotFound();
      }

      _context.Artefacts.Remove(artefact);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool ArtefactExists(int id)
    {
      return _context.Artefacts.Any(e => e.ID == id);
    }
  }
}
