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
    public class HorseController : ControllerBase
    {
        private ApplicationDbContext context;

        public HorseController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        //Get all horses - admin/barn manager only

        //Get all horses belonging to signed in user

        //Get horse by id

        //Create horse

        //Update horse

        //Delete horse

    }
}
