using Gearbox_Back_End.Dto;
using Gearbox_Back_End.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Gearbox_Back_End.Controllers
{
    [ApiController]
    [Route("/Termek")]
    public class TermekController : ControllerBase
    {

        [HttpPost]
        public ActionResult<TermekDto> Post(CreateOrModifyTermek createOrModifyTermek)
        {
            var UjTermek = new Termek
            {
                Id = new Guid(),
                Nev = createOrModifyTermek.Nev,
                Kategoria = createOrModifyTermek.Kategoria,
                Leiras = createOrModifyTermek.Leiras,
                Db = createOrModifyTermek.Db,
                Ar = createOrModifyTermek.Ar,
                VanEraktaron = createOrModifyTermek.VanEraktaron,
                Kep = createOrModifyTermek.Kep

            };
            using (var context = new GearBoxDbContext())
            {
                if (context != null)
                {
                    context.Termeks.Add(UjTermek);
                    context.SaveChanges();
                    return StatusCode(201, "Az adatok sikeresen eltárolva!");
                }
                else
                {
                    return StatusCode(406, "Nem megfeleő az adat formátuma!");
                }
            }
        }

        [HttpGet]
        public ActionResult<TermekDto> GetAll()
        {
            using (var context = new GearBoxDbContext())
            {
                if (context != null)
                {
                    return Ok(context.Termeks.ToList());
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TermekDto> Get(Guid id)
        {
            using (var context = new GearBoxDbContext())
            {
                var kerdezett = context.Termeks.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        return Ok(kerdezett);
                    }
                    else
                    {
                        return StatusCode(404, "A keresett termék nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }


            }
        }

        [HttpPut("{id}")]
        public ActionResult<TermekDto> Put(Guid id, CreateOrModifyTermek createOrModifyTermek)
        {
            using (var context = new GearBoxDbContext())
            {
                if (context != null)
                {
                    var valtoztatando = context.Termeks.FirstOrDefault(x => x.Id == id);
                    if (valtoztatando != null)
                    {
                        valtoztatando.Nev = createOrModifyTermek.Nev;
                        valtoztatando.Kategoria = createOrModifyTermek.Kategoria;
                        valtoztatando.Leiras = createOrModifyTermek.Leiras;
                        valtoztatando.Db = createOrModifyTermek.Db;
                        valtoztatando.Ar = createOrModifyTermek.Ar;
                        valtoztatando.VanEraktaron = createOrModifyTermek.VanEraktaron;
                        valtoztatando.Kep = createOrModifyTermek.Kep;

                        context.Termeks.Update(valtoztatando);
                        context.SaveChanges();
                        return Ok("Sikeres adatváltoztatás!");
                    }
                    else
                    {
                        return StatusCode(404, "A keresett termék nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<TermekDto> Delete(Guid id)
        {
            using (var context = new GearBoxDbContext())
            {
                var kerdezett = context.Termeks.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        context.Termeks.Remove(kerdezett);
                        context.SaveChanges();
                        return Ok("A termék eltávolítása sikeresen megtörtént");
                    }
                    else
                    {
                        return StatusCode(404, "A keresett termék eddig sem létezett, vagy nem volt eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }

            }
        }
    }
}
