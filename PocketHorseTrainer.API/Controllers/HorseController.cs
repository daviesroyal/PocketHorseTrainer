using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocketHorseTrainer.API.Data;
using PocketHorseTrainer.API.Models;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace PocketHorseTrainer.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HorseController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HorseController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            context = dbContext;
            _userManager = userManager;
        }

        //Get all horses belonging to signed in user
        [HttpGet]
        public async Task<IActionResult> GetUserHorses()
        {
            var user = await _userManager.GetUserAsync(User).ConfigureAwait(false);
            var horses = await context.HorseOwners.Where(ho => ho.OwnerId == user.Id).Include(ho => ho.Horse).ToListAsync().ConfigureAwait(false);

            if (horses == null)
            {
                return BadRequest();
            }

            return Ok(horses);
        }

        //Get horse by id
        [HttpGet("{horseId}")]
        public IActionResult GetHorseById([FromRoute] int id)
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

                horse.Owner = (ApplicationUser)User.Identity;
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
        [HttpDelete("{horseId}")]
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

            if (entries == null)
            {
                return BadRequest();
            }

            return Ok(entries);
        }

        //Get specific journal entry by id
        [HttpGet("journal/{entryId}")]
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
        [HttpPost("{horseId}/journal")]
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
        public IActionResult EditJournalEntry([FromBody] JournalEntry entry, [FromRoute] int id)
        {
            try
            {
                if (entry == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existingEntry = context.JournalEntries.Find(id);

                if (existingEntry == null)
                {
                    return NotFound();
                }

                context.JournalEntries.Update(entry);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
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

            if (reports == null)
            {
                return BadRequest();
            }

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
        [HttpPost("{horseId}/reports")]
        public IActionResult CreateTrainingReport([FromRoute] int id, [FromBody] List<JournalEntry> entries)
        {
            try
            {
                if (entries == null)
                {
                    return BadRequest();
                }

                foreach (JournalEntry entry in entries)
                {
                    if (entry.Horse.Id != id)
                    {
                        return BadRequest("Cannot include more than one horse in a training report.");
                    }
                }

                var report = new Report(entries)
                {
                    Horse = context.Horses.Find(id)
                };

                context.TrainingReports.Add(report);
                return Ok(report);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Update specific training report
        [HttpPut("reports/{reportId}")]
        public IActionResult EditTrainingReport([FromRoute] int id, [FromBody] List<JournalEntry> entries)
        {
            try
            {
                if (entries == null)
                {
                    return BadRequest();
                }

                var report = context.TrainingReports.Find(id);

                if (report == null)
                {
                    return NotFound();
                }

                foreach (JournalEntry entry in entries)
                {
                    if (entry.Horse.Id != report.Horse.Id)
                    {
                        return BadRequest("Cannot include more than one horse in a training report.");
                    }
                }

                report = new Report(entries);

                context.TrainingReports.Update(report);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }

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

            if (goals == null)
            {
                return BadRequest();
            }

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
        [HttpPost("{horseId}/goal")]
        public IActionResult CreateHorseGoal([FromBody] Goal goal, [FromRoute] int id)
        {
            try
            {
                if (goal == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                goal.Horse = context.Horses.Find(id);
                context.TrainingGoals.Add(goal);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(goal);
        }

        //Update specific training goal
        [HttpPut("goals/{goalId}")]
        public IActionResult EditTrainingGoal([FromBody] Goal goal, [FromRoute] int id)
        {
            try
            {
                if (goal == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existingGoal = context.TrainingGoals.Find(id);

                if (existingGoal == null)
                {
                    return NotFound();
                }

                context.TrainingGoals.Add(goal);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }

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
