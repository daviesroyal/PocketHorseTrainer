using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketHorseTrainer.API.Data;
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

        public TrainingController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        //Get all training logs for a horse

        //Get all training logs for a horse in specific time

        //Get specific training log by id

        //Create new training log for horse

        //Update specific training log

        //Delete specific training log

        //Get all training reports for a horse

        //Get all training reports for a horse in specific time

        //Get specific training report by id

        //Create new training report for horse

        //Update specific training report

        //Delete specific training report

        //Get all training goals for a horse

        //Get specific training goal by id

        //Create new training goal

        //Update specific training goal

        //Delete specific training goal
    }
}
