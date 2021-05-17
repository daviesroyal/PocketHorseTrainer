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
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HorseController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _context = dbContext;
            _userManager = userManager;
        }

        #region horse
        //Get all horses belonging to signed in user
        [HttpGet]
        public async Task<IActionResult> GetUserHorses()
        {
            var user = await _userManager.GetUserAsync(User).ConfigureAwait(false);
            var horses = await _context.Horses.Where(h => h.Owner.Id == user.Id)
                                              .Select(h => new Horse { Id = h.Id, Name = h.Name, Age = h.Age, Barn = h.Barn, Breed = h.Breed, Color = h.Color, Markings = new Markings { FaceMarking = h.Markings.FaceMarking, FrontLeft = h.Markings.FrontLeft, FrontRight = h.Markings.FrontRight, BackLeft = h.Markings.BackLeft, BackRight = h.Markings.BackRight} })
                                              .ToListAsync()
                                              .ConfigureAwait(false);

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
            var horse = _context.Horses.Find(id);

            if (horse == null)
            {
                return NotFound();
            }

            return Ok(horse);
        }

        //Create horse
        [HttpPost("add")]
        public IActionResult CreateHorse([FromBody] Horse horse)
        {
            try
            {
                if (horse == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var newHorse = new Horse
                {
                    Name = horse.Name,
                    Age = horse.Age,
                    Owner = _userManager.GetUserAsync(User).Result,
                    Barn = _context.Barns.Find(horse.Barn.Id),
                    Breed = _context.Breeds.Find(horse.Breed.Id),
                    Color = _context.Colors.Find(horse.Color.Id),
                    Markings = _context.Markings.Find(horse.Markings.Id)
                };

                _context.Horses.Add(newHorse);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Update horse
        [HttpPut("edit")]
        public IActionResult EditHorse([FromBody] Horse horse)
        {
            try
            {
                if (horse == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }
                var existingHorse = _context.Horses.Find(horse.Id);
                if (existingHorse == null)
                {
                    return NotFound();
                }

                horse.Owner = _userManager.GetUserAsync(User).Result;

                _context.Entry(existingHorse).CurrentValues.SetValues(horse);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Delete horse
        [HttpDelete("{horseId}")]
        public IActionResult DeleteHorse([FromRoute] int id)
        {
            try
            {
                var horse = _context.Horses.Find(id);
                if (horse == null)
                {
                    return NotFound();
                }
                _context.Horses.Remove(horse);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region journals
        //Get all journal entries for a horse
        [HttpGet("{horseId}/journal")]
        public IActionResult GetAllHorseJournals([FromRoute] int id)
        {
            var entries = _context.HorseJournals.Where(hj => hj.HorseId == id).Include(hj => hj.Entry).ToList();

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
            var entry = _context.JournalEntries.Find(id);

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
                entry.Horse = _context.Horses.Find(id);
                _context.JournalEntries.Add(entry);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
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

                var existingEntry = _context.JournalEntries.Find(id);

                if (existingEntry == null)
                {
                    return NotFound();
                }

                _context.Entry(existingEntry).CurrentValues.SetValues(entry);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Delete specific journal entry
        [HttpDelete("journal/{journalId}")]
        public IActionResult DeleteEntry([FromRoute] int id)
        {
            try
            {
                var entry = _context.JournalEntries.Find(id);

                if (entry == null)
                {
                    return NotFound();
                }

                _context.JournalEntries.Remove(entry);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region reports
        //Get all training reports for a horse
        [HttpGet("{horseId}/reports")]
        public IActionResult GetAllTrainingReports([FromRoute] int id)
        {
            var reports = _context.TrainingReports.Where(r => r.Horse.Id == id).ToList();

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
            var report = _context.TrainingReports.Find(id);

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
                    Horse = _context.Horses.Find(id)
                };

                _context.TrainingReports.Add(report);
                _context.SaveChanges();
                return Ok();
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

                var report = _context.TrainingReports.Find(id);

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

                //report = new Report(entries);

                _context.Entry(report).CurrentValues.SetValues(entries);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Delete specific training report
        [HttpDelete("reports/{reportId}")]
        public IActionResult DeleteReport([FromRoute] int id)
        {
            try
            {
                var report = _context.TrainingReports.Find(id);

                if (report == null)
                {
                    return NotFound();
                }

                _context.TrainingReports.Remove(report);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region goals
        //Get all training goals for a horse
        [HttpGet("{horseId}/goals")]
        public IActionResult GetAllHorseGoals([FromRoute] int id)
        {
            var goals = _context.HorseGoals.Where(hg => hg.HorseId == id).Include(hg => hg.Goal).ToList();

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
            var goal = _context.TrainingGoals.Find(id);

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

                goal.Horse = _context.Horses.Find(id);
                _context.TrainingGoals.Add(goal);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
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

                var existingGoal = _context.TrainingGoals.Find(id);

                if (existingGoal == null)
                {
                    return NotFound();
                }

                _context.Entry(existingGoal).CurrentValues.SetValues(goal);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Delete specific training goal
        [HttpDelete("goals/{goalId}")]
        public IActionResult DeleteGoal([FromRoute] int id)
        {
            try
            {
                var goal = _context.TrainingGoals.Find(id);

                if (goal == null)
                {
                    return NotFound();
                }

                _context.TrainingGoals.Remove(goal);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
