using HeroesApp.Server.Data;
using HeroesApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;

namespace HeroesApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HeroController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("comics")]
        public async Task<IActionResult> GetComics()
        {
            return Ok(await _context.Comics.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetHeroes()
        {
            return base.Ok(await GetDbHeroes());
        }

        private async Task<List<Hero>> GetDbHeroes()
        {
            return await _context.Heroes.Include(sh => sh.Comic).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleHero(int id)
        {
            var hero = await _context.Heroes
                .Include(sh => sh.Comic)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (hero == null)
                return NotFound("Super Hero wasn't found. Too bad. :(");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHero(Hero hero)
        {
            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHero(Hero hero, int id)
        {
            var dbHero = await _context.Heroes
                .Include(sh => sh.Comic)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbHero == null)
                return NotFound("Super Hero wasn't found. Too bad. :(");

            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.HeroName = hero.HeroName;
            dbHero.ComicId = hero.ComicId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var dbHero = await _context.Heroes
                .Include(sh => sh.Comic)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbHero == null)
                return NotFound("Super Hero wasn't found. Too bad. :(");

            _context.Heroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }
    }
}
