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

        //Get all journal entries for a horse
        [HttpGet("{horseId}/journal")]
        public IActionResult GetAllHorseJournals([FromRoute] int id)
        {
            var entries = context.HorseJournals.Where(hj => hj.HorseId == id).Include(hj => hj.Entry).ToList();
            //handle null values
            return Ok(entries);
        }

        //Get specific journal entry by id
        [HttpGet("journal/{journalId}")]
        public IActionResult GetJournalEntryById([FromRoute] int id)
        {
            var entry = context.JournalEntries.Find(id);

            if (entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }

        //Create new journal entry for horse
        [HttpPost("{horseId}/journal/entry")]
        public IActionResult CreateJournalEntry([FromBody] JournalEntry entry, [FromRoute] int id)
        {
            try
            {
                if (entry == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }
                entry.Horse = context.Horses.Find(id);
                context.JournalEntries.Add(entry);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(entry);
        }

        //Update specific journal entry
        [HttpPut("journal/{journalId}")]
        public IActionResult EditJournalEntry([FromBody] JournalEntry entry)
        {
            try
            {
                if (entry == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                context.JournalEntries.Update(entry);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(entry);
        }

        //Delete specific journal entry
        [HttpDelete("journal/{journalId}")]
        public IActionResult DeleteEntry([FromRoute] int id)
        {
            try
            {
                var entry = context.JournalEntries.Find(id);

                if (entry == null)
                {
                    return NotFound();
                }

                context.JournalEntries.Remove(entry);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return NoContent();
        }

        //Get all training reports for a horse
        [HttpGet("{horseId}/reports")]
        public IActionResult GetAllTrainingReports([FromRoute] int id)
        {
            var reports = context.TrainingReports.Where(r => r.Horse.Id == id).ToList();
            //handle null values
            return Ok(reports);
        }

        //Get specific training report by id
        [HttpGet("reports/{reportId}")]
        public IActionResult GetTrainingReportById([FromRoute] int id)
        {
            var report = context.TrainingReports.Find(id);

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        //Create new training report for horse
        [HttpPost("{horseId}/reports/report")]

        //Update specific training report
        [HttpPut("reports/{reportId}")]

        //Delete specific training report
        [HttpDelete("reports/{reportId}")]
        public IActionResult DeleteReport([FromRoute] int id)
        {
            try
            {
                var report = context.TrainingReports.Find(id);

                if (report == null)
                {
                    return NotFound();
                }

                context.TrainingReports.Remove(report);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return NoContent();
        }

        //Get all training goals for a horse
        [HttpGet("{horseId}/goals")]
        public IActionResult GetAllHorseGoals([FromRoute] int id)
        {
            var goals = context.HorseGoals.Where(hg => hg.HorseId == id).Include(hg => hg.Goal).ToList();
            //handle null values
            return Ok(goals);
        }

        //Get specific training goal by id
        [HttpGet("goals/{goalId}")]
        public IActionResult GetGoalById([FromRoute] int id)
        {
            var goal = context.TrainingGoals.Find(id);

            if (goal == null)
            {
                return NotFound();
            }

            return Ok(goal);
        }

        //Create new training goal
        [HttpPost("{horseId}/goals/goal")]
        public IActionResult CreateHorseGoal([FromBody] Goal goal, [FromRoute] int id)
        {
            try
            {
                if (goal == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        //Update specific training goal
        [HttpPut("goals/{goalId}")]

        //Delete specific training goal
        [HttpDelete("goals/{goalId}")]
        public IActionResult DeleteGoal([FromRoute] int id)
        {
            try
            {
                var goal = context.TrainingGoals.Find(id);

                if (goal == null)
                {
                    return NotFound();
                }

                context.TrainingGoals.Remove(goal);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
