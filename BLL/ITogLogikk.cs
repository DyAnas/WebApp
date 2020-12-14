using GruppeInnlevering1.Model;
using System.Collections.Generic;

namespace GruppeInnlevering1.BLL
{
    public interface ITogLogikk
    {
        bool Admin_i_db(Admin innAdmin);
        List<avgangs> allavganger();
        List<BilletV> alleBillter();
        List<StasjonV> alleStasjoner();
        List<TogV> alleTog();
        bool endreAvgang(avgangs avgang);
        bool endreStasjon(StasjonV stasjon);
        bool endreTog(TogV tog);
        avgangs hentAvgang(int id);
        BilletV hentBillett(int id);
        StasjonV hentEStasjon(int id);
        List<StasjonV> hentTilListe(int id);
        TogV hentTog(int id);
        List<avgangs> hentTurReturListe(int result, int result1, Samle ny);
        bool nyAdmin(Admin innAdmin);
        bool nyAvgang(avgangs avgang);
        bool nyStasjon(StasjonV stasjon);
        bool nyTog(TogV tog);
        bool setteAlleBilletter(Samle ny, int studentpris, int voksenpris, int barnepris, string Telefonnummer, string Email, string kortnummer, int Cvc);
        bool slettAvgang(int slettId);
        bool slettBillet(int slettId);
        bool slettStasjon(int slettId);
        bool slettTog(int slettId);
    }
}