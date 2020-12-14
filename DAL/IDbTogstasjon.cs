using GruppeInnlevering1.Model;
using System.Collections.Generic;

namespace GruppeInnlevering1.DAL
{
    public interface IDbTogstasjon
    {
        bool Admin_i_db(Admin innAdmin);
        List<avgangs> allavganger();
        List<BilletV> alleBillter();
        List<StasjonV> alleStasjoner();
        List<TogV> alleTog();
        bool endreAvgang(avgangs innAvgang);
        bool endreStasjon(StasjonV innStasjon);
        bool endreTog(TogV inntog);
        avgangs hentAvgang(int AvgangId);
        BilletV hentBilett(int BilletId);
        StasjonV hentStasjon(int StasjonId);
        List<Stasjon> hentTilListe(int id);
        TogV hentTog(int TogId);
        bool nyAdmin(Admin innAdmin);
        bool nyAvgang(avgangs innAvgang);
        bool nyStasjon(StasjonV innStasjon);
        bool nyTog(TogV innTog);
        bool setteBilletter(Samle ny, int studentpris, int voksenpris, int barnpris, string Telefonnummer, string Email, string kortnummer, int Cvc);
        bool SlettAvgang(int id);
        bool SlettSBillett(int id);
        bool SlettStasjon(int id);
        bool SlettTog(int id);
        List<Avgang> TurReturList(int result, int result1, Samle ny);
    }
}