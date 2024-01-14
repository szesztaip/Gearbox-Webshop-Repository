using Gearbox_Back_End.Dto;
using Gearbox_Back_End.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gearbox_Back_End.Controllers
{
    [ApiController]
    [Route("/Kosar")]
    public class KosarController : ControllerBase
    {
        [HttpPost]
        public ActionResult<KosarDto> Post(CreateOrModifyKosar createOrModifyKosar)
        {
            var UjKosar = new Kosar
            {
                Id = new Guid(),
                TermekId = createOrModifyKosar.TermekId,
                TermekNev = createOrModifyKosar.TermekNev,
                Db = createOrModifyKosar.Db,
                TermekAr = createOrModifyKosar.TermekAr,
                VasarloId = createOrModifyKosar.VasarloId

            };
            using (var context = new GearBoxDbContext())
            {
                if (context != null)
                {
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

        [HttpGet]
        public ActionResult<KosarDto> GetAll()
        {
            using (var context = new GearBoxDbContext())
            {
                if (context != null)
                {
                    return Ok(context.Kosars.ToList());
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpGet("{id}")]
        public ActionResult<KosarDto> Get(Guid id)
        {
            using (var context = new GearBoxDbContext())
            {
                var kerdezett = context.Kosars.FirstOrDefault(x => x.Id == id);

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

        [HttpPut("{id}")]
        public ActionResult<KosarDto> Put(Guid id, CreateOrModifyKosar createOrModifyKosar)
        {
            using (var context = new GearBoxDbContext())
            {
                if (context != null)
                {
                    var valtoztatando = context.Kosars.FirstOrDefault(x => x.Id == id);
                    if (valtoztatando != null)
                    {
                        valtoztatando.TermekId = createOrModifyKosar.TermekId;
                        valtoztatando.TermekNev = createOrModifyKosar.TermekNev;
                        valtoztatando.Db = createOrModifyKosar.Db;
                        valtoztatando.TermekAr = createOrModifyKosar.TermekAr;
                        valtoztatando.VasarloId = createOrModifyKosar.VasarloId;

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

        [HttpDelete("{id}")]
        public ActionResult<KosarDto> Delete(Guid id)
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
    }
}
