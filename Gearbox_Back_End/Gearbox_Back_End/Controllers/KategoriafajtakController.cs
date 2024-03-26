using Gearbox_Back_End.Dto;
using Gearbox_Back_End.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gearbox_Back_End.Controllers
{
    [ApiController]
    [Route("/Kategoriafajtak")]
    public class KategoriafajtakController : ControllerBase
    {
        [HttpPost, Authorize(Roles = "Admin")]
        public ActionResult<KategoriafajtakDto> Post(CreateOrModifyKategoriakDto createOrModifyJogosultsagok)
        {
            try
            {
                var UjKategoria = new Kategoriafajtak
                {
                    KategoriaNev = createOrModifyJogosultsagok.kategorianev,
                };
                using (var context = new GearBoxDbContext())
                {
                    if (context != null)
                    {
                        context.Kategoriafajtaks.Add(UjKategoria);
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
        public ActionResult<KategoriafajtakDto> GetAll()
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    if (context != null)
                    {
                        return Ok(context.Kategoriafajtaks.ToList());
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
                    var kerdezett = context.Kategoriafajtaks.FirstOrDefault(x => x.Id == id);

                    if (context != null)
                    {
                        if (kerdezett != null)
                        {
                            return Ok(kerdezett);
                        }
                        else
                        {
                            return StatusCode(404, "A keresett kategória nem létezik, vagy nincs eltárolva");
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

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public ActionResult<KategoriafajtakDto> Put(int id, CreateOrModifyKategoriakDto createOrModifyJogosultsagok)
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    if (context != null)
                    {
                        var valtoztatando = context.Kategoriafajtaks.FirstOrDefault(x => x.Id == id);
                        if (valtoztatando != null)
                        {
                            valtoztatando.KategoriaNev = createOrModifyJogosultsagok.kategorianev;

                            context.Kategoriafajtaks.Update(valtoztatando);
                            context.SaveChanges();
                            return Ok("Sikeres adatváltoztatás!");
                        }
                        else
                        {
                            return StatusCode(404, "A keresett kategória nem létezik, vagy nincs eltárolva");
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

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public ActionResult<KategoriafajtakDto> Delete(int id)
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    var kerdezett = context.Kategoriafajtaks.FirstOrDefault(x => x.Id == id);

                    if (context != null)
                    {
                        if (kerdezett != null)
                        {
                            context.Kategoriafajtaks.Remove(kerdezett);
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
                return StatusCode(500, e.Message);
            }
            
        }
    }
}
