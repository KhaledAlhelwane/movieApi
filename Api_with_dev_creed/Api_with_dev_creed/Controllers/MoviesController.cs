using Api_with_dev_creed.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_with_dev_creed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private List<string> _allowedExtensions = new() { ".jpg",".png"};
        private long MaxPosterZise = 1048576;
        public MoviesController(ApplicationDbContext context)
        {

            _context = context;

        }
        //get all movies
        [HttpGet]
        public async Task<IActionResult> GetAllMoviesAsync()
        {
           var lista=await _context.Movies.Include(x=>x.Gener).ToListAsync();
            if(lista.Count==0)
                return NotFound();

            return Ok(lista);

        }
        //get movie by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActionResultAsync(int id)
        {
            var movie=await _context.Movies.FindAsync(id);
            if(movie==null)
                return NotFound();
            return Ok(movie);
            
        }

        //get movies by geres Id
       
        [HttpGet("GetMoviesByGeresId")]
        public async Task<IActionResult> GetMoviesByGeresIdAsync(byte GenerId)
        {
            var movies=await _context.Movies.Where(x=>x.GenerId==GenerId).ToListAsync();
            if(movies.Count==0)
                return NotFound();
            return Ok(movies);
        }

            //create Movie 
        [HttpPost]
        public async Task<IActionResult> CreateMoviesAsync([FromForm]MovieDtoCreate Dto)
        {
            if (!_allowedExtensions.Contains(Path.GetExtension(Dto.Poster.FileName.ToLower())))
            {
                return BadRequest("only png and jpg are allowed");
            }
                if (Dto.Poster.Length > MaxPosterZise)
                    return BadRequest("you have to upload a poster less than 1 MB"+" the file your uploaded is:"+ Dto.Poster.Length);
                bool isValid=await _context.Geners.AnyAsync(x=>x.Id==Dto.GenerId);
            if (!isValid)
            {
                return BadRequest("there is no geners with this id :"+Dto.GenerId);
            }
                using var datastream = new MemoryStream();
                await Dto.Poster.CopyToAsync(datastream);
                var movie = new Movie
                {
                    Rate = Dto.Rate,
                    storyLine = Dto.storyLine,
                    Title = Dto.Title,
                    Year = Dto.Year,
                    GenerId = Dto.GenerId,
                    Poster = datastream.ToArray()
                    
                };
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
                return Ok(movie);
           
          
           

        }

        //update movie
        [HttpPut("{id}")]
        public async Task<IActionResult> UdateMovieAsync(int id,[FromForm]MovieDtoUpdate Dto)
        {
            var movie =await _context.Movies.FindAsync(id);
            if (movie == null)
                return NotFound("there is no movie with this id");
            bool isValid = await _context.Geners.AnyAsync(x => x.Id == Dto.GenerId);
            if (!isValid)
            {
                return BadRequest("there is no geners with this id :" + Dto.GenerId);
            }
            if(Dto.Poster!=null)
            {
                using var datastream = new MemoryStream();
                await Dto.Poster.CopyToAsync(datastream);
                movie.Poster= datastream.ToArray();
            }
            movie.Year = Dto.Year;
            movie.Title = Dto.Title;
            movie.storyLine= Dto.storyLine;
            movie.Rate= Dto.Rate;
            movie.GenerId= Dto.GenerId;

            _context.Movies.Update(movie);
            _context.SaveChanges(); 
            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var movie=await _context.Movies.FindAsync(id);
            if (movie == null)
                return NotFound("no movie was found!!");
             _context.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }
    }
}
