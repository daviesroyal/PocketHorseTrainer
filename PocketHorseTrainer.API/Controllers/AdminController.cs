using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PocketHorseTrainer.API.Data;
using PocketHorseTrainer.API.Models;
using System;
using System.Linq;

namespace PocketHorseTrainer.API.Controllers
{
    [Authorize] //for admin roles only, with get and CreateMarkings exceptions
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        #region Markings
        [HttpPost("markings")]
        public IActionResult CreateMarkings([FromBody] Markings markings)
        {
            try
            {
                var newMarkings = new Markings
                {
                    FaceMarking = _context.FaceMarkings.Find(markings.FaceMarking.Id),
                    FrontLeft = _context.LegMarkings.Find(markings.FrontLeft.Id),
                    FrontRight = _context.LegMarkings.Find(markings.FrontRight.Id),
                    BackLeft = _context.LegMarkings.Find(markings.BackLeft.Id),
                    BackRight = _context.LegMarkings.Find(markings.BackRight.Id)
                };

                _context.Markings.Add(newMarkings);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("markings/face/{markingId}")]
        public IActionResult GetFaceMarking([FromRoute]int id)
        {
            return _context.FaceMarkings.Find(id) == null ? NotFound() : base.Ok(_context.FaceMarkings.Find(id));
        }

        [HttpGet("markings/face")]
        public IActionResult GetFaceMarkings()
        {
            return base.Ok(_context.FaceMarkings.ToList());
        }

        [HttpGet("markings/leg/{markingId}")]
        public IActionResult GetLegMarking([FromRoute]int id)
        {
            return _context.LegMarkings.Find(id) == null ? NotFound() : base.Ok(_context.LegMarkings.Find(id));
        }

        [HttpGet("markings/leg")]
        public IActionResult GetLegMarkings()
        {
            return base.Ok(_context.LegMarkings.ToList());
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

                if (_context.FaceMarkings.Find(marking.Id) != null)
                {
                    return Conflict("Marking already exists!");
                }
                _context.FaceMarkings.Add(marking);
                _context.SaveChanges();
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

                if (_context.LegMarkings.Find(marking.Id) != null)
                {
                    return Conflict("Marking already exists!");
                }
                _context.LegMarkings.Add(marking);
                _context.SaveChanges();
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

                var existing = _context.FaceMarkings.Find(marking.Id);
                if (existing == null)
                {
                    return NotFound();
                }

                _context.Entry(existing).CurrentValues.SetValues(marking);
                _context.SaveChanges();
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

                var existing = _context.LegMarkings.Find(marking.Id);
                if (existing == null)
                {
                    return NotFound();
                }

                _context.Entry(existing).CurrentValues.SetValues(marking);
                _context.SaveChanges();
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
                if (_context.FaceMarkings.Find(id) == null)
                {
                    return NotFound();
                }
                _context.FaceMarkings.Remove(_context.FaceMarkings.Find(id));
                _context.SaveChanges();
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
                if (_context.LegMarkings.Find(id) == null)
                {
                    return NotFound();
                }
                _context.LegMarkings.Remove(_context.LegMarkings.Find(id));
                _context.SaveChanges();
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
            return _context.Breeds.Find(id) == null ? NotFound() : base.Ok(_context.Breeds.Find(id));
        }

        [HttpGet("breeds")]
        public IActionResult GetBreeds()
        {
            return base.Ok(_context.Breeds.ToList());
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

                if (_context.Breeds.Find(breed.Id) != null)
                {
                    return Conflict("Breed already exists!");
                }
                _context.Breeds.Add(breed);
                _context.SaveChanges();
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

                var existing = _context.Breeds.Find(breed.Id);
                if (existing == null)
                {
                    return NotFound();
                }

                _context.Entry(existing).CurrentValues.SetValues(breed);
                _context.SaveChanges();
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
                if (_context.Breeds.Find(id) == null)
                {
                    return NotFound();
                }
                _context.Breeds.Remove(_context.Breeds.Find(id));
                _context.SaveChanges();
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
            if (_context.Colors.Find(id) == null)
            {
                return NotFound();
            }
            return base.Ok(_context.Colors.Find(id));
        }

        [HttpGet("colors")]
        public IActionResult GetColors()
        {
            return base.Ok(_context.Colors.ToList());
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

                if (_context.Colors.Find(color.Id) != null)
                {
                    return Conflict("Color already exists!");
                }
                _context.Colors.Add(color);
                _context.SaveChanges();
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

                var existing = _context.Colors.Find(color.Id);
                if (existing == null)
                {
                    return NotFound();
                }

                _context.Entry(existing).CurrentValues.SetValues(color);
                _context.SaveChanges();
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
                if (_context.Colors.Find(id) == null)
                {
                    return NotFound();
                }
                _context.Colors.Remove(_context.Colors.Find(id));
                _context.SaveChanges();
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
            return _context.Barns.Find(id) == null ? NotFound() : base.Ok(_context.Barns.Find(id));
        }

        [HttpGet("barns")]
        public IActionResult GetBarns()
        {
            return base.Ok(_context.Barns.ToList());
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

                if (_context.Barns.Find(barn.Id) != null)
                {
                    return Conflict("Barn already exists!");
                }
                _context.Barns.Add(barn);
                _context.SaveChanges();
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

                var existing = _context.Barns.Find(barn.Id);
                if (existing == null)
                {
                    return NotFound();
                }

                _context.Entry(existing).CurrentValues.SetValues(barn);
                _context.SaveChanges();
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
                if (_context.Barns.Find(id) == null)
                {
                    return NotFound();
                }
                _context.Barns.Remove(_context.Barns.Find(id));
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NoContent();
        }
        #endregion

        #region TargetAreas
        [HttpGet("{areaId}")]
        public IActionResult GetArea([FromRoute] int id)
        {
            return _context.Areas.Find(id) == null ? NotFound() : base.Ok(_context.Areas.Find(id));
        }

        [HttpGet("areas")]
        public IActionResult GetAreas()
        {
            return base.Ok(_context.Areas.ToList());
        }

        [HttpPost("area")]
        public IActionResult AddArea([FromBody] TargetAreas area)
        {
            try
            {
                if (area == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (_context.Areas.Find(area.Id) != null)
                {
                    return Conflict("Area already exists!");
                }
                _context.Areas.Add(area);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("area")]
        public IActionResult EditArea([FromBody] TargetAreas area)
        {
            try
            {
                if (area == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var existing = _context.Areas.Find(area.Id);
                if (existing == null)
                {
                    return NotFound();
                }

                _context.Entry(existing).CurrentValues.SetValues(area);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{areaId}")]
        public IActionResult DeleteArea([FromRoute] int id)
        {
            try
            {
                if (_context.Areas.Find(id) == null)
                {
                    return NotFound();
                }
                _context.Areas.Remove(_context.Areas.Find(id));
                _context.SaveChanges();
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
