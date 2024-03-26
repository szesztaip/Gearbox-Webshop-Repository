using Gearbox_Back_End.Dto;
using Gearbox_Back_End.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gearbox_Back_End.Controllers
{
    [ApiController]
    [Route("/Besorolas"), Authorize(Roles = "Admin")]
    public class BesorolasController : ControllerBase
    {
        [HttpPost]
        public ActionResult<BesorolasDto> Post(CreateOrModifyBesorolasDto createOrModifyBesorolasDto)
        {
            try
            {
                var UjBesorolas = new Besorola
                {
                    Id = Guid.NewGuid(),
                    Nev = createOrModifyBesorolasDto.besorolasnev
                };
                using (var context = new GearBoxDbContext())
                {
                    if (context != null)
                    {
                        context.Besorolas.Add(UjBesorolas);
                        context.SaveChanges();
                        return StatusCode(201, "Az adatok sikeresen eltárolva!");
                    }
                    else
                    {
                        return StatusCode(406, "Nem megfeleő az adat formátuma!");
                    }
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpGet]
        public ActionResult<BesorolasDto> GetAll()
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    if (context != null)
                    {
                        return Ok(context.Besorolas.ToList());
                    }
                    else
                    {
                        return StatusCode(503, "A szerver jelenleg nem elérhető");
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("{id}")]
        public ActionResult<BesorolasDto> Get(Guid id)
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    var kerdezett = context.Besorolas.FirstOrDefault(x => x.Id == id);

                    if (context != null)
                    {
                        if (kerdezett != null)
                        {
                            return Ok(kerdezett);
                        }
                        else
                        {
                            return StatusCode(404, "A keresett besorolás nem létezik, vagy nincs eltárolva");
                        }
                    }
                    else
                    {
                        return StatusCode(503, "A szerver jelenleg nem elérhető");
                    }


                }
            }
            catch (Exception e)
            {

                return StatusCode(500,e.Message);
            }
           
        }

        [HttpPut("{id}")]
        public ActionResult<BesorolasDto> Put(Guid id, CreateOrModifyBesorolasDto createOrModifyBesorolasDto)
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    if (context != null)
                    {
                        var valtoztatando = context.Besorolas.FirstOrDefault(x => x.Id == id);
                        if (valtoztatando != null)
                        {
                            valtoztatando.Nev = createOrModifyBesorolasDto.besorolasnev;

                            context.Besorolas.Update(valtoztatando);
                            context.SaveChanges();
                            return Ok("Sikeres adatváltoztatás!");
                        }
                        else
                        {
                            return StatusCode(404, "A keresett besorolás nem létezik, vagy nincs eltárolva");
                        }
                    }
                    else
                    {
                        return StatusCode(503, "A szerver jelenleg nem elérhető");
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public ActionResult<BesorolasDto> Delete(Guid id)
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    var kerdezett = context.Besorolas.FirstOrDefault(x => x.Id == id);

                    if (context != null)
                    {
                        if (kerdezett != null)
                        {
                            context.Besorolas.Remove(kerdezett);
                            context.SaveChanges();
                            return Ok("A kategória eltávolítása sikeresen megtörtént");
                        }
                        else
                        {
                            return StatusCode(404, "A keresett kategória eddig sem létezett, vagy nem volt eltárolva");
                        }
                    }
                    else
                    {
                        return StatusCode(503, "A szerver jelenleg nem elérhető");
                    }

                }
            }
            catch (Exception e)
            {

                return StatusCode(500,e.Message);
            }
           
        }
    }
}
