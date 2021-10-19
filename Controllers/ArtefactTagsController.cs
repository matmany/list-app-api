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
    public class ArtefactTagsController : ControllerBase
    {
        private readonly ListApiContext _context;

        public ArtefactTagsController(ListApiContext context)
        {
            _context = context;
        }

        // GET: api/ArtefactTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtefactTag>>> GetArtefactTags()
        {
            return await _context.ArtefactTags.ToListAsync();
        }

        // GET: api/ArtefactTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtefactTag>> GetArtefactTag(int id)
        {
            var artefactTag = await _context.ArtefactTags.FindAsync(id);

            if (artefactTag == null)
            {
                return NotFound();
            }

            return artefactTag;
        }

        // PUT: api/ArtefactTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtefactTag(int id, ArtefactTag artefactTag)
        {
            if (id != artefactTag.ID)
            {
                return BadRequest();
            }

            _context.Entry(artefactTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtefactTagExists(id))
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

        // POST: api/ArtefactTags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArtefactTag>> PostArtefactTag(ArtefactTag artefactTag)
        {
            _context.ArtefactTags.Add(artefactTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtefactTag", new { id = artefactTag.ID }, artefactTag);
        }

        // DELETE: api/ArtefactTags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtefactTag(int id)
        {
            var artefactTag = await _context.ArtefactTags.FindAsync(id);
            if (artefactTag == null)
            {
                return NotFound();
            }

            _context.ArtefactTags.Remove(artefactTag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtefactTagExists(int id)
        {
            return _context.ArtefactTags.Any(e => e.ID == id);
        }
    }
}
