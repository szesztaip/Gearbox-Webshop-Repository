using Gearbox_Back_End.Models;

namespace Gearbox_Back_End.Dto
{
    public record JogosultsagDto(int Id, string Nev, List<Vasarlo> Vasarlok);
    public record CreateOrModifyJogosultsagok(int Id, string Nev);

    public record KosarDto(Guid Id, Guid TermekId, string TermekNev, int Db, int TermekAr, Guid KosarId);
    public record CreateOrModifyKosar(Guid TermekId, string TermekNev, int Db, int TermekAr, Guid KosarId);

    public record VasarloDto(Guid Id, string Felhasznalonev, string Telefonszam, string Email, string HASH, int Jogosultsag);
    public record CreateOrModifyVasarlo(string Felhasznalonev, string Telefonszam, string Email, string Jelszo, int Jogosultsag);
    public record RegisterVasarlo(string Felhasznalonev, string Telefonszam, string Email, string Jelszo);
    public record LoginVasarlo(string Email, string Jelszo);

    public record TermekDto(Guid id, string Nev, int Kategoria,Guid BesorolasId,string Meret, string Leiras, int Db, int Ar, bool VanEraktaron, string Kep);
    public record CreateOrModifyTermek(string Nev, int Kategoria, Guid BesorolasId, string Meret , string Leiras, int Db, int Ar, bool VanEraktaron, string Kep);

    public record KosarKapcsolatDto(Guid Id, Guid VasarloId);
    public record CreateKosarKapcsolat(Guid VasarloId);

    public record EmailDto(string To, string Subject, string Body);

    public record KategoriafajtakDto(int id, string kategorianev);
    public record CreateOrModifyKategoriakDto(string kategorianev);

    public record BesorolasDto(int id, string besorolasnev);
    public record CreateOrModifyBesorolasDto(string besorolasnev);

    public record VasarlasiAdatokDto(Guid Id,Guid VasarloId,string Megye,Guid KosarId,string Telepules,string UtcaHazszam);
    public record CreateOrModifyVasarlasiAdatokDto(Guid VasarloId, string Megye, Guid KosarId, string Telepules, string UtcaHazszam);

}
