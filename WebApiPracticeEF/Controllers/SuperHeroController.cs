using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebApiPracticeEF.Models;

namespace WebApiPracticeEF.Controllers
{
    [Route("api/[controller]")]
    //[RoutePrefix("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        //private static List<SuperHero> superHeroes = new List<SuperHero>
        //    {
        //        new SuperHero
        //        {
        //            Id = 1,
        //            Name = "Spider Man",
        //            FirstName = "Petar",
        //            LastName = "Parker",
        //            Place = "New york"
        //        },
        //        new SuperHero
        //        {
        //            Id = 2,
        //            Name="Action",
        //            FirstName = "Parbhas",
        //            LastName = "Parker",
        //            Place = "South India"
        //        },
        //         new SuperHero
        //        {
        //            Id = 3,
        //            Name="Romantic",
        //            FirstName = "Sharukh",
        //            LastName = "Khan",
        //            Place = "India"
        //        }

        //        };

        private readonly DataContext _dataContext;
        public SuperHeroController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {

            return Ok( await _dataContext.superHeroes.ToListAsync());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetById(int id)
        {
            var heros =await _dataContext.superHeroes.FindAsync(id);
            if (heros == null)
                return BadRequest("Hero is Not found");
            return Ok(heros);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
           _dataContext.superHeroes.Add(hero);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.superHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> Update(SuperHero request)
        {
            var DBSuper =await _dataContext.superHeroes.FindAsync(request.Id);
            if (DBSuper == null)
                return BadRequest("Not Found");

            DBSuper.Name = request.Name;
            DBSuper.FirstName = request.FirstName;
            DBSuper.LastName = request.LastName;
            DBSuper.Place = request.Place;

            return Ok(await _dataContext.superHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var Dbdelete =await _dataContext.superHeroes.FindAsync(id);
            if (Dbdelete == null)
                return BadRequest("Not Found");

           _dataContext.superHeroes.Remove(Dbdelete);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.superHeroes.ToListAsync());
        }
    }
}
