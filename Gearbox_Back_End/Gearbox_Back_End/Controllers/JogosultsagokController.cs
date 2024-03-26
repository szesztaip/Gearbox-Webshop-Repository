using Gearbox_Back_End.Dto;
using Gearbox_Back_End.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gearbox_Back_End.Controllers
{
    [ApiController]
    [Route("/Jogosultsag"), Authorize(Roles = "Admin")]
    public class JogosultsagokController : ControllerBase
    {
        [HttpPost]
        public ActionResult<JogosultsagDto> Post(CreateOrModifyJogosultsagok createOrModifyJogosultsagok)
        {
            try
            {
                var UjJog = new Jogosultsagok
                {
                    Nev = createOrModifyJogosultsagok.Nev,
                };
                using (var context = new GearBoxDbContext())
                {
                    if (context != null)
                    {
                        context.Jogosultsagoks.Add(UjJog);
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
                        return Ok(context.Jogosultsagoks.ToList());
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
        public ActionResult<JogosultsagDto> Get(int id)
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    var kerdezett = context.Jogosultsagoks.FirstOrDefault(x => x.Id == id);

                    if (context != null)
                    {
                        if (kerdezett != null)
                        {
                            return Ok(kerdezett);
                        }
                        else
                        {
                            return StatusCode(404, "A keresett jogosultság nem létezik, vagy nincs eltárolva");
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

        [HttpPut("{id}")]
        public ActionResult<JogosultsagDto> Put(int id, CreateOrModifyJogosultsagok createOrModifyJogosultsagok)
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    if (context != null)
                    {
                        var valtoztatando = context.Jogosultsagoks.FirstOrDefault(x => x.Id == id);
                        if (valtoztatando != null)
                        {
                            valtoztatando.Id = createOrModifyJogosultsagok.Id;
                            valtoztatando.Nev = createOrModifyJogosultsagok.Nev;

                            context.Jogosultsagoks.Update(valtoztatando);
                            context.SaveChanges();
                            return Ok("Sikeres adatváltoztatás!");
                        }
                        else
                        {
                            return StatusCode(404, "A keresett jogosultság nem létezik, vagy nincs eltárolva");
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

        [HttpDelete("{id}")]
        public ActionResult<JogosultsagDto> Delete(int id)
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    var kerdezett = context.Jogosultsagoks.FirstOrDefault(x => x.Id == id);

                    if (context != null)
                    {
                        if (kerdezett != null)
                        {
                            context.Jogosultsagoks.Remove(kerdezett);
                            context.SaveChanges();
                            return Ok("A jogosultság eltávolítása sikeresen megtörtént");
                        }
                        else
                        {
                            return StatusCode(404, "A keresett jogosultság eddig sem létezett, vagy nem volt eltárolva");
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
