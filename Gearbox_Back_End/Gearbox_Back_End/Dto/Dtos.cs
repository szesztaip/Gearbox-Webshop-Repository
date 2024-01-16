using Gearbox_Back_End.Models;

namespace Gearbox_Back_End.Dto
{
    public record JogosultsagDto(int Id, string Nev, List<Vasarlo> Vasarlok);
    public record CreateOrModifyJogosultsagok(int Id, string Nev);

    public record KosarDto(Guid Id, Guid TermekId, string TermekNev, int Db, int TermekAr, Guid VasarloId);
    public record CreateOrModifyKosar(Guid TermekId, string TermekNev, int Db, int TermekAr, Guid VasarloId);

    public record VasarloDto(Guid Id, string Keresztnev, string Vezeteknev, int Telefonszam, string Email, string Jelszo, string HASH, string SALT, int Jogosultsag);
    public record CreateOrModifyVasarlo(string Keresztnev, string Vezeteknev, int Telefonszam, string Email, string Jelszo, string HASH, string SALT, int Jogosultsag);
    public record RegisterVasarlo(string Keresztnev, string Vezeteknev, int Telefonszam, string Email, string Jelszo);
    public record LoginVasarlo(string Email, string Jelszo);

    public record TermekDto(Guid id,string Nev,string Leiras,int Db,int Ar,bool VanEraktaron, byte[] Kep);
    public record CreateOrModifyTermek(string Nev, string Leiras, int Db, int Ar, bool VanEraktaron, byte[] Kep);

    
}
