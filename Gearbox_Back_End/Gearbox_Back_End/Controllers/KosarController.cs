using Gearbox_Back_End.Dto;
using Gearbox_Back_End.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gearbox_Back_End.Controllers
{
    [ApiController]
    [Route("/Kosar")]
    public class KosarController : ControllerBase
    {
        [HttpPost]
        public ActionResult<KosarDto> Post(Guid termekazon,Guid kosarazon,CreateOrModifyKosar createOrModifyKosar)
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    if (context != null)
                    {
                        var termek = context.Termeks.FirstOrDefault(x => x.Id == termekazon);
                        if (termek == null)
                        {
                            return NotFound("Nincs ilyen termék!");
                        }
                        var UjKosar = new Kosar
                        {
                            Id = new Guid(),
                            TermekId = termek.Id,
                            TermekNev = termek.Nev,
                            Db = createOrModifyKosar.Db,
                            TermekAr = termek.Ar * createOrModifyKosar.Db,
                            KosarId = kosarazon

                        };

                        context.Kosars.Add(UjKosar);
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
        public ActionResult<KosarDto> GetAll()
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    if (context != null)
                    {
                        return Ok(context.Kosars.Include(x => x.Termek).ToList());
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
        public ActionResult<KosarDto> Get(Guid id)
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    var kerdezett = context.Kosars.Include(x => x.Termek).FirstOrDefault(x => x.Id == id);

                    if (context != null)
                    {
                        if (kerdezett != null)
                        {
                            return Ok(kerdezett);
                        }
                        else
                        {
                            return StatusCode(404, "A keresett kosár nem létezik, vagy nincs eltárolva");
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
        public ActionResult<KosarDto> Put(Guid id,Guid termekazon, CreateOrModifyKosar createOrModifyKosar)
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    if (context != null)
                    {
                        var valtoztatando = context.Kosars.FirstOrDefault(x => x.Id == id);
                        var termek = context.Termeks.FirstOrDefault(x => x.Id == termekazon);
                        if (termek == null)
                        {
                            return NotFound("Nincs ilyen termék!");
                        }
                        if (valtoztatando != null)
                        {
                            valtoztatando.TermekId = termek.Id;
                            valtoztatando.TermekNev = termek.Nev;
                            valtoztatando.Db = createOrModifyKosar.Db;
                            valtoztatando.TermekAr = termek.Ar * createOrModifyKosar.Db;

                            context.Kosars.Update(valtoztatando);
                            context.SaveChanges();
                            return Ok("Sikeres adatváltoztatás!");
                        }
                        else
                        {
                            return StatusCode(404, "A keresett kosár nem létezik, vagy nincs eltárolva");
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
        public ActionResult<KosarDto> Delete(Guid id)
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    var kerdezett = context.Kosars.FirstOrDefault(x => x.Id == id);

                    if (context != null)
                    {
                        if (kerdezett != null)
                        {
                            context.Kosars.Remove(kerdezett);
                            context.SaveChanges();
                            return Ok("A kosár eltávolítása sikeresen megtörtént");
                        }
                        else
                        {
                            return StatusCode(404, "A keresett kosár eddig sem létezett, vagy nem volt eltárolva");
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
    }
}
