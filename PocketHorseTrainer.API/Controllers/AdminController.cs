using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PocketHorseTrainer.API.Data;
using PocketHorseTrainer.API.Models;
using System;
using System.Linq;

namespace PocketHorseTrainer.API.Controllers
{
    [Authorize] //for admin roles only
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AdminController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        #region Markings
        [HttpGet("markings/face/{markingId}")]
        public IActionResult GetFaceMarking([FromRoute]int id)
        {
            return context.FaceMarkings.Find(id) == null ? NotFound() : base.Ok(context.FaceMarkings.Find(id));
        }

        [HttpGet("markings/face")]
        public IActionResult GetFaceMarkings()
        {
            return base.Ok(context.FaceMarkings.ToList());
        }

        [HttpGet("markings/leg/{markingId}")]
        public IActionResult GetLegMarking([FromRoute]int id)
        {
            return context.LegMarkings.Find(id) == null ? NotFound() : base.Ok(context.LegMarkings.Find(id));
        }

        [HttpGet("markings/leg")]
        public IActionResult GetLegMarkings()
        {
            return base.Ok(context.LegMarkings.ToList());
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

                if (context.FaceMarkings.Find(marking.Id) != null)
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

                if (context.LegMarkings.Find(marking.Id) != null)
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

                if (context.FaceMarkings.Find(marking.Id) != null)
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

                if (context.LegMarkings.Find(marking.Id) != null)
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

        [HttpDelete("markings/face/{markingId}")]
        public IActionResult DeleteFaceMarking([FromRoute] int id)
        {
            try
            {
                if (context.FaceMarkings.Find(id) == null)
                {
                    return NotFound();
                }
                context.FaceMarkings.Remove(context.FaceMarkings.Find(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("markings/leg/{markingId}")]
        public IActionResult DeleteLegMarking([FromRoute] int id)
        {
            try
            {
                if (context.LegMarkings.Find(id) == null)
                {
                    return NotFound();
                }
                context.LegMarkings.Remove(context.LegMarkings.Find(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }
        #endregion

        #region Breed
        [HttpGet("{breedId}")]
        public IActionResult GetBreed([FromRoute] int id)
        {
            return context.Breeds.Find(id) == null ? NotFound() : base.Ok(context.Breeds.Find(id));
        }

        [HttpGet("breeds")]
        public IActionResult GetBreeds()
        {
            return base.Ok(context.Breeds.ToList());
        }

        [HttpPost("breed")]
        public IActionResult AddBreed([FromBody] Breed breed)
        {
            try
            {
                if (breed == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (context.Breeds.Find(breed.Id) != null)
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

        [HttpPut("breed")]
        public IActionResult EditBreed([FromBody] Breed breed)
        {
            try
            {
                if (breed == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (context.Breeds.Find(breed.Id) != null)
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
                if (context.Breeds.Find(id) == null)
                {
                    return NotFound();
                }
                context.Breeds.Remove(context.Breeds.Find(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }
        #endregion

        #region Color
        [HttpGet("{colorId}")]
        public IActionResult GetColor([FromRoute] int id)
        {
            if (context.Colors.Find(id) == null)
            {
                return NotFound();
            }
            return base.Ok(context.Colors.Find(id));
        }

        [HttpGet("colors")]
        public IActionResult GetColors()
        {
            return base.Ok(context.Colors.ToList());
        }

        [HttpPost("color")]
        public IActionResult AddColor([FromBody] CoatColor color)
        {
            try
            {
                if (color == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (context.Colors.Find(color.Id) != null)
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

        [HttpPut("color")]
        public IActionResult EditColor([FromBody] CoatColor color)
        {
            try
            {
                if (color == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (context.Colors.Find(color.Id) != null)
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
                if (context.Colors.Find(id) == null)
                {
                    return NotFound();
                }
                context.Colors.Remove(context.Colors.Find(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }
        #endregion

        #region Barn
        [HttpGet("{barnId}")]
        public IActionResult GetBarn([FromRoute] int id)
        {
            return context.Barns.Find(id) == null ? NotFound() : base.Ok(context.Barns.Find(id));
        }

        [HttpGet("barns")]
        public IActionResult GetBarns()
        {
            return base.Ok(context.Barns.ToList());
        }

        [HttpPost("barn")]
        public IActionResult AddBarn([FromBody] Barn barn)
        {
            try
            {
                if (barn == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (context.Barns.Find(barn.Id) != null)
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

        [HttpPut("barn")]
        public IActionResult EditBarn([FromBody] Barn barn)
        {
            try
            {
                if (barn == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (context.Barns.Find(barn.Id) != null)
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
                if (context.Barns.Find(id) == null)
                {
                    return NotFound();
                }
                context.Barns.Remove(context.Barns.Find(id));
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
