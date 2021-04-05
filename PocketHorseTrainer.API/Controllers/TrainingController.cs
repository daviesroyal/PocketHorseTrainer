using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocketHorseTrainer.API.Data;
using PocketHorseTrainer.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TrainingController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            context = dbContext;
            _userManager = userManager;
        }

        //Get all journal entries for a horse
        [HttpGet("horse/{horseId}/journal")]
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

        //Update specific journal entry

        //Delete specific journal entry
        [HttpDelete("{id}")]
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
        [HttpGet("horse/{horseId}/reports")]
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

        //Update specific training report

        //Delete specific training report
        [HttpDelete("{id}")]
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

        //Update specific training goal

        //Delete specific training goal
        [HttpDelete("{id}")]
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
