using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC.MyAirport.EF;
using MyAirport.EF;

namespace MyAirportWebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolsController : ControllerBase
    {
        private readonly MyAirportContext _context;

        public VolsController(MyAirportContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Retourner les vols 
        /// </summary>
        /// <returns></returns>
        // GET: api/Vols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vol>>> GetVols()
        {
            return await _context.Vols.ToListAsync();
        }

        // GET: api/Vols/5? bool bagages
        [HttpGet("{id}")]
        public async Task<ActionResult<Vol>> GetVol(int id,
            [FromQuery] bool bagages = false)
        {
            Vol volsRes;
            if (bagages)
                volsRes = await _context.Vols.Include(v => v.Bagages).FirstAsync(volRes => volRes.VolId == id);
            else
                volsRes = await _context.Vols.FindAsync(id);

            if (volsRes == null)
            {
                return NotFound();
            }
            return volsRes;

        }
           
        /// <summary>
        /// modifier vol
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vol"></param>
        /// <returns></returns>
        // PUT: api/Vols/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVol(int id, Vol vol)
        {
            if (id != vol.VolId)
            {
                return BadRequest();
            }

            _context.Entry(vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(id))
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
        /// <summary>
        /// new vol 
        /// </summary>
        /// <param name="vol"></param>
        /// <returns></returns>
        // POST: api/Vols
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Vol>> PostVol(Vol vol)
        {
            _context.Vols.Add(vol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVol", new { id = vol.VolId }, vol);
        }
     
        // DELETE: api/Vols/5
        /// <summary>
        /// Suppresion du vol grâce à son Id
        /// </summary>
        /// <param name="id">Identifiant du vol à supprimer</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vol>> DeleteVol(int id)
        {
            var vol = await _context.Vols.FindAsync(id);
            if (vol == null)
            {
                return NotFound();
            }

            _context.Vols.Remove(vol);
            await _context.SaveChangesAsync();

            return vol;
        }

        private bool VolExists(int id)
        {
            return _context.Vols.Any(e => e.VolId == id);
        }
    }
}
