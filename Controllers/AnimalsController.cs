using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace azureTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnimalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAllAnimals()
        {
            if (_context.Animals is null)
            {
                return NotFound();
            }
            return await _context.Animals.ToListAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<Animal> GetAnimal(string name)
        {
            var animal = _context.Animals.Where(animal => animal.Name == name).FirstOrDefault();
            if (animal is null)
            {
                return NotFound();
            }
            return animal;
        }

        [HttpPost]
        public async Task<ActionResult<Animal>> PostLocation(Animal request)
        {
            if (request is null) return BadRequest();

            var newAnimal = new Animal
            {
                Name = request.Name,
                Sound = request.Sound
            };

            _context.Animals.Add(newAnimal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAnimal), new { id = newAnimal.Id }, newAnimal);
        }


    }
}
