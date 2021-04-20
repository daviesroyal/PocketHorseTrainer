using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketHorseTrainer.API.Data;
using PocketHorseTrainer.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Controllers
{
    [Authorize] //for admin roles only
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private ApplicationDbContext context;

        public AdminController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        #region Markings
        [HttpGet("marking/face")]
        public IActionResult GetFaceMarking(int id)
        {
            var marking = context.FaceMarkings.Find(id);
            if (marking == null)
            {
                return NotFound();
            }
            return Ok(marking);
        }

        [HttpGet("markings/face")]
        public IActionResult GetFaceMarkings()
        {
            var markings = context.FaceMarkings.ToList();
            return Ok(markings);
        }

        [HttpGet("marking/leg")]
        public IActionResult GetLegMarking(int id)
        {
            var marking = context.LegMarkings.Find(id);
            if (marking == null)
            {
                return NotFound();
            }
            return Ok(marking);
        }

        [HttpGet("markings/leg")]
        public IActionResult GetLegMarkings()
        {
            var markings = context.LegMarkings.ToList();
            return Ok(markings);
        }

        [HttpPost("markings/face")]
        public IActionResult AddFaceMarking([FromBody] FaceMarking marking)
        {
            try
            {
                if (marking == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existingMarking = context.FaceMarkings.Find(marking.Id);
                if (existingMarking != null)
                {
                    return Conflict("Marking already exists!");
                }
                context.FaceMarkings.Add(marking);

            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("markings/leg")]
        public IActionResult AddLegMarking([FromBody] LegMarking marking)
        {
            try
            {
                if (marking == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existingMarking = context.LegMarkings.Find(marking.Id);
                if (existingMarking != null)
                {
                    return Conflict("Marking already exists!");
                }
                context.LegMarkings.Add(marking);

            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("markings/face")]
        public IActionResult EditFaceMarking([FromBody] FaceMarking marking)
        {
            try
            {
                if (marking == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existingMarking = context.FaceMarkings.Find(marking.Id);
                if (existingMarking != null)
                {
                    return Conflict("Marking already exists!");
                }
                context.FaceMarkings.Update(marking);

            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("markings/leg")]
        public IActionResult EditLegMarking([FromBody] LegMarking marking)
        {
            try
            {
                if (marking == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existingMarking = context.LegMarkings.Find(marking.Id);
                if (existingMarking != null)
                {
                    return Conflict("Marking already exists!");
                }
                context.LegMarkings.Update(marking);

            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{markingId}")]
        public IActionResult DeleteFaceMarking([FromRoute] int id)
        {
            try
            {
                var marking = context.FaceMarkings.Find(id);
                if (marking == null)
                {
                    return NotFound();
                }
                context.FaceMarkings.Remove(marking);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{markingId}")]
        public IActionResult DeleteLegMarking([FromRoute] int id)
        {
            try
            {
                var marking = context.LegMarkings.Find(id);
                if (marking == null)
                {
                    return NotFound();
                }
                context.LegMarkings.Remove(marking);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }
        #endregion

        #region Breed
        [HttpGet]
        public IActionResult GetBreed(int id)
        {
            var breed = context.Breeds.Find(id);
            if (breed == null)
            {
                return NotFound();
            }
            return Ok(breed);
        }

        [HttpGet("breeds")]
        public IActionResult GetBreeds()
        {
            var breeds = context.Breeds.ToList();
            return Ok(breeds);
        }

        [HttpPost]
        public IActionResult AddBreed([FromBody] Breed breed)
        {
            try
            {
                if (breed == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existingBreed = context.Breeds.Find(breed.Id);
                if (existingBreed != null)
                {
                    return Conflict("Marking already exists!");
                }
                context.Breeds.Add(breed);

            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult EditBreed([FromBody] Breed breed)
        {
            try
            {
                if (breed == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existingBreed = context.Breeds.Find(breed.Id);
                if (existingBreed != null)
                {
                    return Conflict("Marking already exists!");
                }
                context.Breeds.Update(breed);

            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{breedId}")]
        public IActionResult DeleteBreed([FromRoute] int id)
        {
            try
            {
                var breed = context.Breeds.Find(id);
                if (breed == null)
                {
                    return NotFound();
                }
                context.Breeds.Remove(breed);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }
        #endregion

        #region Color
        [HttpGet]
        public IActionResult GetColor(int id)
        {
            var color = context.Colors.Find(id);
            if (color == null)
            {
                return NotFound();
            }
            return Ok(color);
        }

        [HttpGet("colors")]
        public IActionResult GetColors()
        {
            var colors = context.Colors.ToList();
            return Ok(colors);
        }

        [HttpPost]
        public IActionResult AddColor([FromBody] CoatColor color)
        {
            try
            {
                if (color == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existingColor = context.Colors.Find(color.Id);
                if (existingColor != null)
                {
                    return Conflict("Marking already exists!");
                }
                context.Colors.Add(color);

            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult EditColor([FromBody] CoatColor color)
        {
            try
            {
                if (color == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existingColor = context.Colors.Find(color.Id);
                if (existingColor != null)
                {
                    return Conflict("Marking already exists!");
                }
                context.Colors.Update(color);

            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{colorId}")]
        public IActionResult DeleteColor([FromRoute] int id)
        {
            try
            {
                var color = context.Colors.Find(id);
                if (color == null)
                {
                    return NotFound();
                }
                context.Colors.Remove(color);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }
        #endregion

        #region Barn
        [HttpGet]
        public IActionResult GetBarn(int id)
        {
            var barn = context.Barns.Find(id);
            if (barn == null)
            {
                return NotFound();
            }
            return Ok(barn);
        }

        [HttpGet("barns")]
        public IActionResult GetBarns()
        {
            var barns = context.Barns.ToList();
            return Ok(barns);
        }

        [HttpPost]
        public IActionResult AddBarn([FromBody] Barn barn)
        {
            try
            {
                if (barn == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existingBarn = context.Barns.Find(barn.Id);
                if (existingBarn != null)
                {
                    return Conflict("Marking already exists!");
                }
                context.Barns.Add(barn);

            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult EditBarn([FromBody] Barn barn)
        {
            try
            {
                if (barn == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existingBarn = context.Barns.Find(barn.Id);
                if (existingBarn != null)
                {
                    return Conflict("Marking already exists!");
                }
                context.Barns.Update(barn);

            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{barnId}")]
        public IActionResult DeleteBarn([FromRoute] int id)
        {
            try
            {
                var barn = context.Barns.Find(id);
                if (barn == null)
                {
                    return NotFound();
                }
                context.Barns.Remove(barn);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }
        #endregion
    }
}
