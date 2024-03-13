using Gearbox_Back_End.Dto;
using Gearbox_Back_End.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gearbox_Back_End.Controllers
{
    [ApiController]
    [Route("/VasarlasiAdatok")]
    public class VasarlasiAdatokController : ControllerBase
    {
        [HttpPost]
        public ActionResult<VasarlasiAdatokDto> Post(CreateOrModifyVasarlasiAdatokDto createOrModifyVasarlasiAdatokDto)
        {
            var UjVasarlas = new Vasalasiadatok
            {
                Id = new Guid(),
                VasarloId = createOrModifyVasarlasiAdatokDto.VasarloId,
                Megye = createOrModifyVasarlasiAdatokDto.Megye,
                KosarId = createOrModifyVasarlasiAdatokDto.KosarId,
                Telepules = createOrModifyVasarlasiAdatokDto.Telepules,
                UtcaHazszam = createOrModifyVasarlasiAdatokDto.UtcaHazszam
            };
            using (var context = new GearBoxDbContext())
            {
                if (context != null)
                {
                    context.Vasalasiadatoks.Add(UjVasarlas);
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
        public ActionResult<VasarlasiAdatokDto> GetAll()
        {
            using (var context = new GearBoxDbContext())
            {
                if (context != null)
                {
                    return Ok(context.Vasalasiadatoks.ToList());
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpGet("{id}")]
        public ActionResult<VasarlasiAdatokDto> Get(Guid id)
        {
            using (var context = new GearBoxDbContext())
            {
                var kerdezett = context.Vasalasiadatoks.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        return Ok(kerdezett);
                    }
                    else
                    {
                        return StatusCode(404, "A keresett vásárlási adat nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }


            }
        }

        [HttpPut("{id}")]
        public ActionResult<VasarlasiAdatokDto> Put(Guid id, CreateOrModifyVasarlasiAdatokDto createOrModifyVasarlasiAdatokDto)
        {
            using (var context = new GearBoxDbContext())
            {
                if (context != null)
                {
                    var valtoztatando = context.Vasalasiadatoks.FirstOrDefault(x => x.Id == id);
                    if (valtoztatando != null)
                    {
                        valtoztatando.VasarloId = createOrModifyVasarlasiAdatokDto.VasarloId;
                        valtoztatando.Megye = createOrModifyVasarlasiAdatokDto.Megye;
                        valtoztatando.KosarId = createOrModifyVasarlasiAdatokDto.KosarId;
                        valtoztatando.Telepules = createOrModifyVasarlasiAdatokDto.Telepules;
                        valtoztatando.UtcaHazszam = createOrModifyVasarlasiAdatokDto.UtcaHazszam;

                        context.Vasalasiadatoks.Update(valtoztatando);
                        context.SaveChanges();
                        return Ok("Sikeres adatváltoztatás!");
                    }
                    else
                    {
                        return StatusCode(404, "A keresett vásárlási adat nem létezik, vagy nincs eltárolva");
                    }
                }
                else
                {
                    return StatusCode(503, "A szerver jelenleg nem elérhető");
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<VasarlasiAdatokDto> Delete(Guid id)
        {
            using (var context = new GearBoxDbContext())
            {
                var kerdezett = context.Vasalasiadatoks.FirstOrDefault(x => x.Id == id);

                if (context != null)
                {
                    if (kerdezett != null)
                    {
                        context.Vasalasiadatoks.Remove(kerdezett);
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
    }
}
