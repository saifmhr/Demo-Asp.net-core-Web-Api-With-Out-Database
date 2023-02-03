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
        private static List<SuperHero> superHeroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id = 1,
                    Name = "Spider Man",
                    FirstName = "Petar",
                    LastName = "Parker",
                    Place = "New york"
                },
                new SuperHero
                {
                    Id = 2,
                    Name="Action",
                    FirstName = "Parbhas",
                    LastName = "Parker",
                    Place = "South India"
                },
                 new SuperHero
                {
                    Id = 3,
                    Name="Romantic",
                    FirstName = "Sharukh",
                    LastName = "Khan",
                    Place = "India"
                }

                };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            
            return Ok( superHeroes );             
        
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetById(int id)
        {
            var heros = superHeroes.Find(h=>h.Id==id);
            if(heros==null)
                return BadRequest("Hero is Not found");
            return Ok( heros );
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return Ok( superHeroes );
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> Update(SuperHero super )
        {
            var Super=superHeroes.Find(h=>h.Id==super.Id);
            if (super == null)
                return BadRequest("Not Found");

            Super.Name=super.Name;
            Super.FirstName=super.FirstName;
            Super.LastName=super.LastName;
            Super.Place=super.Place;

            return Ok(super);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var delete=superHeroes.Find(h=>h.Id==id);
            if (delete == null)
                return BadRequest("Not Found");

            superHeroes.Remove(delete);
            return Ok(superHeroes);
        }
    }
}
