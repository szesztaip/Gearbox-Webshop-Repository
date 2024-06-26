﻿using BCrypt.Net;
using Gearbox_Back_End.Dto;
using Gearbox_Back_End.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Gearbox_Back_End.Controllers
{
    [ApiController]
    [Route("/login")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("/regisztracio")]
        public ActionResult<RegisterVasarlo> Register(RegisterVasarlo registerVasarlo)
        {
            var UjVasarlo = new Vasarlo
            {
                Id = new Guid(),
                FelhasznaloNev = registerVasarlo.Felhasznalonev,
                Telefonszam = registerVasarlo.Telefonszam,
                Hash = BCrypt.Net.BCrypt.HashPassword(registerVasarlo.Jelszo),
                Email = registerVasarlo.Email,

                Jogosultsag = 0

            };

            using (var context = new GearBoxDbContext())
            {
                if (context != null)
                {
                    context.Vasarlos.Add(UjVasarlo);
                    context.SaveChanges();
                    return StatusCode(201, "sikeres regisztráció!");
                }
                else
                {
                    return StatusCode(406, "Nem megfeleő az adat formátuma!");
                }
            }
        }

        [HttpPost("bejelentkezes")]
        public ActionResult<LoginVasarlo> Login(LoginVasarlo loginVasarlo)
        {
            try
            {
                using (var context = new GearBoxDbContext())
                {
                    if (context != null)
                    {
                        var kerdezett = context.Vasarlos.FirstOrDefault(x => x.Email == loginVasarlo.Email);
                        if (kerdezett != null)
                        {
                            if (!BCrypt.Net.BCrypt.Verify(loginVasarlo.Jelszo, kerdezett.Hash))
                            {
                                return StatusCode(406, "Hibás adatok!");
                            }
                            else
                            {
                                string token = CreateToken(kerdezett);
                                Token tokenUser = new Token();
                                tokenUser.UserToken = token;
                                return Ok(tokenUser);
                            }

                        }
                        else
                        {
                            return StatusCode(404, "Nem létezik ilyen felhasználó!");
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

        private string CreateToken(Vasarlo vasarlo)
        {
            using (var context = new GearBoxDbContext())
            {
                List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role,context.Jogosultsagoks.FirstOrDefault(x=>x.Id==vasarlo.Jogosultsag).Nev),
                new Claim(ClaimTypes.Email,vasarlo.Email),
                new Claim(ClaimTypes.Name,vasarlo.FelhasznaloNev),
                new Claim(ClaimTypes.NameIdentifier,vasarlo.Id.ToString()),
                new Claim(ClaimTypes.MobilePhone,vasarlo.Telefonszam.ToString())
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    audience: _configuration.GetValue<string>("Authentication:Schemes:Bearer:ValidAudiences:0"),
                    issuer: _configuration.GetSection("Authentication:Schemes:Bearer:ValidIssuer").Value,
                    signingCredentials: creds);
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
        }
    }
}
