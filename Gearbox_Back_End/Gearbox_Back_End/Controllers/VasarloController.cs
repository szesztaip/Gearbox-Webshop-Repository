using Gearbox_Back_End.Dto;
using Gearbox_Back_End.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gearbox_Back_End.Controllers
{
    [ApiController]
    [Route("/Vasarlo")]
    public class VasarloController : ControllerBase
    {
        [HttpPost]
        public ActionResult<VasarloDto> Post(CreateOrModifyVasarlo createOrModifyVasarlo)
        {
            var UjVasarlo = new Vasarlo
            {
                Id = new Guid(),
                FelhasznaloNev = createOrModifyVasarlo.Felhasznalonev,
                Telefonszam = createOrModifyVasarlo.Telefonszam,
                Email = createOrModifyVasarlo.Email,
                Hash = BCrypt.Net.BCrypt.HashPassword(createOrModifyVasarlo.Jelszo),
                Jogosultsag = createOrModifyVasarlo.Jogosultsag

            };
            using (var context = new GearBoxDbContext())
            {
                if (context != null)
                {
                    context.Vasarlos.Add(UjVasarlo);
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
        public ActionResult<JogosultsagDto> GetAll()
        {
            using (var context = new GearBoxDbContext())
            {
                if (context != null)
                {
                    return Ok(context.Vasarlos.ToList());
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpGet("{id}")]
        public ActionResult<JogosultsagDto> Get(Guid id)
        {
            using (var context = new GearBoxDbContext())
            {
                var kerdezett = context.Vasarlos.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        return Ok(kerdezett);
                    }
                    else
                    {
                        return StatusCode(404, "A keresett vásárló nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }


            }
        }

        [HttpPut("{id}")]
        public ActionResult<VasarloDto> Put(Guid id, CreateOrModifyVasarlo createOrModifyVasarlo)
        {
            using (var context = new GearBoxDbContext())
            {
                if (context != null)
                {
                    var valtoztatando = context.Vasarlos.FirstOrDefault(x => x.Id == id);
                    if (valtoztatando != null)
                    {
                        valtoztatando.FelhasznaloNev = createOrModifyVasarlo.Felhasznalonev;
                        valtoztatando.Telefonszam = createOrModifyVasarlo.Telefonszam;
                        valtoztatando.Email = createOrModifyVasarlo.Email;
                        valtoztatando.Hash = BCrypt.Net.BCrypt.HashPassword(createOrModifyVasarlo.Jelszo);
                        valtoztatando.Jogosultsag = createOrModifyVasarlo.Jogosultsag;

                        context.Vasarlos.Update(valtoztatando);
                        context.SaveChanges();
                        return Ok("Sikeres adatváltoztatás!");
                    }
                    else
                    {
                        return StatusCode(404, "A keresett vásárló nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<VasarloDto> Delete(Guid id)
        {
            using (var context = new GearBoxDbContext())
            {
                var kerdezett = context.Vasarlos.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        context.Vasarlos.Remove(kerdezett);
                        context.SaveChanges();
                        return Ok("A vásárló eltávolítása sikeresen megtörtént");
                    }
                    else
                    {
                        return StatusCode(404, "A keresett vásárló eddig sem létezett, vagy nem volt eltárolva");
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
