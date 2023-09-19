using Api_with_dev_creed.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Api_with_dev_creed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenrasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GenrasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var Genras = await _context.Geners.OrderBy(m => m.Name).ToListAsync();
            return Ok(Genras);

        }
        [HttpPost]
        public async Task<IActionResult> AddGenarAsync(CreateGenraDto dto)
        {
            Gener Genras = new() { Name = dto.Name };
            await _context.AddAsync(Genras);
            _context.SaveChanges();
            // developer divers here some they return ok only and other which is more suitable depending on devcreed opinion to retrun the obj that was created because it is more suitgable for frontend or mobile developer 
            return Ok(Genras);
            
        }
        [HttpPut("{id}")] //if we do this we will get domain/api/Genars/1
        public async Task<IActionResult> UpdateGenarAsync(int id,[FromBody] CreateGenraDto Dto)
        {

            var Obj = await _context.Geners.SingleOrDefaultAsync(a => a.Id == id);
            if (Obj == null)
            {
                return NotFound($"there are no genra with this Id"+id);
            }
            Obj.Name = Dto.Name;
            _context.Update(Obj);
            await _context.SaveChangesAsync();
            // developer divers here some they return ok only and other which is more suitable depending on devcreed opinion to retrun the obj that was created because it is more suitgable for frontend or mobile developer 
            return Ok(Obj);
         
        }

        [HttpDelete("{id}")] //if we do this we will get domain/api/Genars/1
        public async Task<IActionResult> DeleteGenarAsync(int id)
        {

            var Obj = await _context.Geners.SingleOrDefaultAsync(a => a.Id == id);
            if (Obj == null)
            {
                return NotFound($"there are no genra with this Id" + id);
            }
            _context.Remove(Obj);
            await _context.SaveChangesAsync();
            // developer divers here some they return ok only and other which is more suitable depending on devcreed opinion to retrun the obj that was created because it is more suitgable for frontend or mobile developer 
            return Ok(Obj);

        }

    }
}
