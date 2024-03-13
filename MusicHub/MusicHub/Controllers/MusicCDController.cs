using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicHub.Model.DTO;
using MusicHub.Data;
using MusicHub.Repository.IRepository;
using MusicHub.Model;
using Microsoft.AspNetCore.Authorization;

namespace MusicHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MusicCDController : ControllerBase
    {
        private readonly IMusicCDRepository _contextCD;
        public MusicCDController(IMusicCDRepository contextcd)
        {
            _contextCD = contextcd;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetMusicCDs()
        {
            var musicCD = await _contextCD.GetAll();
            return Ok(musicCD);

        }
        [HttpGet("{id}", Name = "GetMusicCD")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetMusicCD(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var musicCD = await _contextCD.Get(u => u.Id ==id);
            if (musicCD == null)
            {
                return NotFound();
            }
            return Ok(musicCD);

        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateMusicCD([FromBody]MusicCD musicCD)
        {
            if (ModelState.IsValid)
            {
                await _contextCD.Create(musicCD);
                await _contextCD.Save();
                return Ok(musicCD);
            }

            return BadRequest(ModelState);

        }
        [HttpDelete("{id}", Name = "DeleteMusicCD")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteMusicCD(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var musicCD =await _contextCD.Get(u => u.Id == id); 
            if (musicCD == null)
            {
                return NotFound();
            }
            await _contextCD.Remove(musicCD);
            await _contextCD.Save();
            return NoContent();

        }
        [HttpPut("{id}", Name = "UpdateMusicCD")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateMusicCD(int id, MusicCD musicCD)
        {
            var existingMusicCD = await _contextCD.Get(u => u.Id == id);
            if (id != musicCD.Id || musicCD == null)
            {
                return BadRequest(ModelState);
            }
            await _contextCD.Update(existingMusicCD);
            await _contextCD.Save();
            return Ok(musicCD);

        }

    }
}
