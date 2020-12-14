
using GruppeInnlevering1.DAL;
using GruppeInnlevering1.Model;
using System.Collections.Generic;

namespace GruppeInnlevering1.BLL
{

    public class TogLogikk : ITogLogikk
    {
        private IDbTogstasjon DbDall;

        public TogLogikk()
        {
            DbDall = new DbTogstasjon();
        }
        public TogLogikk(IDbTogstasjon stub)
        {
            DbDall = stub;
        }

        public List<StasjonV> alleStasjoner()
        {
            List<StasjonV> alleStasjoner = DbDall.alleStasjoner();
            return alleStasjoner;
        }

        public List<avgangs> allavganger()
        {
            List<avgangs> alleAvganger = DbDall.allavganger();
            return alleAvganger;

        }


        public List<TogV> alleTog()
        {
            List<TogV> alleTog = DbDall.alleTog();
            return alleTog;

        }


        public List<BilletV> alleBillter()
        {
            List<BilletV> alleBillter = DbDall.alleBillter();
            return alleBillter;

        }

        public bool nyStasjon(StasjonV stasjon)
        {
            return DbDall.nyStasjon(stasjon);
        }


        public bool nyAvgang(avgangs avgang)
        {          
            return DbDall.nyAvgang(avgang);
        }

        public bool nyTog(TogV tog)
        {      
            return DbDall.nyTog(tog);
        }


        public bool endreStasjon(StasjonV stasjon)
        {           
            return DbDall.endreStasjon(stasjon);
        }


        public bool endreAvgang(avgangs avgang)
        {         
            return DbDall.endreAvgang(avgang);
        }

        public bool endreTog(TogV tog)
        {          
            return DbDall.endreTog(tog);
        }


        public bool slettStasjon(int slettId)
        {          
            return DbDall.SlettStasjon(slettId);
        }


        public bool slettTog(int slettId)
        {       
            return DbDall.SlettTog(slettId);
        }

        public bool slettAvgang(int slettId)
        {          
            return DbDall.SlettAvgang(slettId);
        }

        public bool slettBillet(int slettId)
        {      
            return DbDall.SlettSBillett(slettId);

        }

        public StasjonV hentEStasjon(int id)
        {    
            return DbDall.hentStasjon(id);
        }

        public avgangs hentAvgang(int id)
        {    
            return DbDall.hentAvgang(id);
        }

        public TogV hentTog(int id)
        {
            return DbDall.hentTog(id);
        }


        public BilletV hentBillett(int id)
        {           
            return DbDall.hentBilett(id);
        }

        public List<StasjonV> hentTilListe(int id)
        {
            List<StasjonV> stasjoner = new List<StasjonV>();
            List<Stasjon> sasjonerlist = DbDall.hentTilListe(id);
            foreach (Stasjon stasjon in sasjonerlist)
            {
                stasjoner.Add(new StasjonV { StasjonId = stasjon.StasjonId, StasjonNavn = stasjon.StasjonNavn });
            }

            return stasjoner;

        }

   
        public List<avgangs> hentTurReturListe(int result, int result1, Samle ny)
        {
            List<avgangs> TurReturListe = new List<avgangs>();
        
            List<Avgang> turlistee = DbDall.TurReturList(result, result1, ny);

            foreach (Avgang avgang in turlistee)
            {
                TurReturListe.Add(new avgangs
                {
                
                    AvgangId = avgang.AvgangId,

                    Tid = avgang.Tid,
               

               
                });

            }


            return TurReturListe;

        }



        public bool setteAlleBilletter(Samle ny, int studentpris, int voksenpris, int barnepris, string Telefonnummer, string Email, string kortnummer, int Cvc)
        {
         
            return DbDall.setteBilletter(ny, studentpris, voksenpris, barnepris, Telefonnummer, Email, kortnummer, Cvc);
        }

        public bool Admin_i_db(Admin innAdmin)
        {

            return DbDall.Admin_i_db(innAdmin);

        }


        public bool nyAdmin(Admin innAdmin)
        {
          
            return DbDall.nyAdmin(innAdmin);

        }

    }
}




