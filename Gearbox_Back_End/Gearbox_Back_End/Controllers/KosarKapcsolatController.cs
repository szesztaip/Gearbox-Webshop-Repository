using Gearbox_Back_End.Dto;
using Gearbox_Back_End.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gearbox_Back_End.Controllers
{
    [ApiController]
    [Route("/KosarKapcsolat")]
    public class KosarKapcsolatController : ControllerBase
    {
        [HttpPost]
        public ActionResult<KosarKapcsolatDto> Post(CreateKosarKapcsolat createKosarKapcsolat)
        {
            try
            {
                var UjKosarKapcsolat = new Kosarkapcsolat
                {
                    Id = new Guid(),
                    VasarloId = createKosarKapcsolat.VasarloId,

                };
                using (var context = new GearBoxDbContext())
                {
                    if (context != null)
                    {
                        context.Kosarkapcsolats.Add(UjKosarKapcsolat);
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
        public ActionResult<JogosultsagDto> GetAll()
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    if (context != null)
                    {
                        return Ok(context.Kosarkapcsolats.Include(x => x.Kosars).ToList());
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
        public ActionResult<JogosultsagDto> Get(Guid id)
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    var kerdezett = context.Kosarkapcsolats.Include(x => x.Kosars).FirstOrDefault(x => x.Id == id);

                    if (context != null)
                    {
                        if (kerdezett != null)
                        {
                            return Ok(kerdezett);
                        }
                        else
                        {
                            return StatusCode(404, "A keresett kosárkapcsolat nem létezik, vagy nincs eltárolva");
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
        public ActionResult<JogosultsagDto> Delete(Guid id)
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    var kerdezett = context.Kosarkapcsolats.FirstOrDefault(x => x.Id == id);

                    if (context != null)
                    {
                        if (kerdezett != null)
                        {
                            context.Kosarkapcsolats.Remove(kerdezett);
                            context.SaveChanges();
                            return Ok("A kosárkapcsolat eltávolítása sikeresen megtörtént");
                        }
                        else
                        {
                            return StatusCode(404, "A keresett kosárkapcsolat eddig sem létezett, vagy nem volt eltárolva");
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
