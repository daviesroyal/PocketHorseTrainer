using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocketHorseTrainer.API.Data;
using PocketHorseTrainer.API.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace PocketHorseTrainer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorseController : ControllerBase
    {
        private ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;


        public HorseController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            context = dbContext;
            _userManager = userManager;
        }

        //Get all horses in a barn - admin/barn manager only
        [HttpGet("barn/{id}")]
        public IActionResult GetBarnHorses(int id)
        {
            var horses = context.BarnHorses.Where(bh => bh.BarnId == id).Include(bh => bh.Horse).ToList();
            //TODO: add null handling
            return Ok(horses);
        }

        //Get all horses belonging to signed in user
        [HttpGet]
        public async Task<IActionResult> GetUserHorses(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var horses = context.HorseOwners.Where(ho => ho.OwnerId == id).Include(ho => ho.Horse).ToList();
            //TODO: add null handling
            return Ok(horses);
        }

        //Get horse by id
        [HttpGet("{id}")]
        public IActionResult GetHorseById(int id)
        {
            var horse = context.Horses.Find(id);

            if (horse == null)
            {
                return NotFound();
            }

            return Ok(horse);
        }

        //Create horse
        [HttpPost]
        public IActionResult CreateHorse([FromBody] Horse horse)
        {
            try
            {
                if (horse == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existingHorse = context.Horses.Find(horse.Id);
                if (existingHorse != null)
                {
                    return Conflict("Horse already exists!");
                }

                context.Horses.Add(horse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(horse);
        }

        //Update horse
        [HttpPut]
        public IActionResult EditHorse([FromBody] Horse horse)
        {
            try
            {
                if (horse == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }
                var existingHorse = context.Horses.Find(horse.Id);
                if (existingHorse == null)
                {
                    return NotFound();
                }
                context.Horses.Update(horse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }

        //Delete horse
        [HttpDelete("{id}")]
        public IActionResult DeleteHorse([FromRoute] int id)
        {
            try
            {
                var horse = context.Horses.Find(id);
                if (horse == null)
                {
                    return NotFound();
                }
                context.Horses.Remove(horse);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
