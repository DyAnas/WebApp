
using GruppeInnlevering1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GruppeInnlevering1.Model;

namespace GruppeInnlevering1.BLL
{
    /*  public class TogBLL : BLL.TogLogikk
      {
          private TogRepo repo;

          public TogBLL()
          {
              repo = new DbTogstasjonDAL();
          }
          public TogBLL(TogRepo stub)
          {
              repo = stub;
          }


          // bll avganger
          public List<avgangs> allavganger()
          {
             ;
              List<avgangs> alleavganger = repo.allavganger();

              return alleavganger;

          }
          public avgangs hentAvgang(int AvgangId)
          {

             return  repo.hentAvgang(AvgangId);
              }
          public bool nyAvgang(avgangs innAvgang)
          {

              return repo.nyAvgang(innAvgang);
          }
          public bool endreAvgang(avgangs innAvgang)
          {

              return repo.endreAvgang(innAvgang);
          }
          public bool SlettAvgan(int id)
          {

              return repo.SlettAvgan(id);
          }

          // bll stasjoner 
          public List<StasjonV> alleStasjoner()
          {

              List<StasjonV> alleStasjoner = repo.alleStasjoner();
              return alleStasjoner;
          }
          public bool nyStasjon(StasjonV innStasjon)
          {

              return repo.nyStasjon(innStasjon);
          }
          public StasjonV hentStasjon(int StasjonId)
          {

              return repo.hentStasjon(StasjonId);
          }
          public bool endreStasjon(StasjonV innStasjon)
          {

              return repo.endreStasjon(innStasjon);
          }
          public bool SlettStasjon(int id)
          {

              return repo.SlettStasjon(id);
          }

          // bll billetter
          public List<BilletV> alleBillter()
          {

              List<BilletV> alleBillter = repo.alleBillter();
              return alleBillter;
          }
          public BilletV hentBilett(int BilletId)
          {

              return repo.hentBilett(BilletId);
          }
          public bool SlettSBillett(int id)
          {

              return repo.SlettSBillett(id);
          }


          // bll tog
          public List<TogV> alleTog()
          {

              List<TogV> alleTog = repo.alleTog();
              return alleTog;

          }
          public bool nyTog(TogV innTog)
          {

              return repo.nyTog(innTog);
          }
          public TogV hentTog(int TogId)
          {

              return repo.hentTog(TogId);
          }
          public bool endreTog(TogV inntog)
          {

             return repo.endreTog(inntog);
          }
          public bool SlettTog(int id)
          {

              return repo.SlettTog(id);
          }
          // Admin metoder 
          public bool Admin_i_db(Admin innAdmin)
          {

              return repo.Admin_i_db(innAdmin);
          }
          public bool nyAdmin(Admin innAdmin)
          {

              return repo.nyAdmin(innAdmin);
          }




          IEnumerable<Stasjon> hentTilListe(int id)
          {
              return repo.hentTilListe(id);
          }  */

    public class TogLogikk
    {


        public List<StasjonV> alleStasjoner()
        {

            var DbDall = new DbTogstasjon();
            List<StasjonV> alleStasjoner = DbDall.alleStasjoner();
            return alleStasjoner;


        }

        public List<avgangs> allavganger()
        {

            var DbDall = new DbTogstasjon();
            List<avgangs> alleAvganger = DbDall.allavganger();
            return alleAvganger;

        }


        public List<TogV> alleTog()
        {

            var DbDall = new DbTogstasjon();
            List<TogV> alleTog = DbDall.alleTog();
            return alleTog;

        }


        public List<BilletV> alleBillter()
        {

            var DbDall = new DbTogstasjon();
            List<BilletV> alleBillter = DbDall.alleBillter();
            return alleBillter;

        }

        public bool nyStasjon(StasjonV stasjon)
        {
            var DbDall = new DbTogstasjon();
            return DbDall.nyStasjon(stasjon);
        }


        public bool nyAvgang(avgangs avgang)
        {
            var DbDall = new DbTogstasjon();
            return DbDall.nyAvgang(avgang);
        }

        public bool nyTog(TogV tog)
        {
            var DbDall = new DbTogstasjon();
            return DbDall.nyTog(tog);
        }


        public bool endreStasjon(StasjonV stasjon)
        {
            var DbDall = new DbTogstasjon();
            return DbDall.endreStasjon(stasjon);
        }


        public bool endreAvgang(avgangs avgang)
        {
            var DbDall = new DbTogstasjon();
            return DbDall.endreAvgang(avgang);
        }

        public bool endreTog(TogV tog)
        {
            var DbDall = new DbTogstasjon();
            return DbDall.endreTog(tog);
        }


        public bool slettStasjon(int slettId)
        {
            var DbDall = new DbTogstasjon();
            return DbDall.SlettStasjon(slettId);
        }


        public bool slettTog(int slettId)
        {
            var DbDall = new DbTogstasjon();
            return DbDall.SlettTog(slettId);
        }

        public bool slettAvgang(int slettId)
        {
            var DbDall = new DbTogstasjon();
            return DbDall.SlettAvgan(slettId);
        }

        public bool slettBillet(int slettId)
        {
            var DbDall = new DbTogstasjon();
            return DbDall.SlettSBillett(slettId);

        }

        public StasjonV hentEStasjon(int id)
        {
            var DbDall = new DbTogstasjon();
            return DbDall.hentStasjon(id);
        }

        public avgangs hentAvgang(int id)
        {
            var DbDall = new DbTogstasjon();
            return DbDall.hentAvgang(id);
        }

        public TogV hentTog(int id)
        {
            var DbDall = new DbTogstasjon();

            return DbDall.hentTog(id);
        }


        public BilletV hentBillett(int id)
        {
            var DbDall = new DbTogstasjon();

            return DbDall.hentBilett(id);
        }

        public List<StasjonV> hentTilListe(int id)
        { List<StasjonV> stasjoner = new List<StasjonV>();
            var DbDall = new DbTogstasjon();
           List<Stasjon> sasjonerlist = DbDall.hentTilListe(id);
            foreach (Stasjon stasjon in sasjonerlist)
            {
                stasjoner.Add(new StasjonV { StasjonId = stasjon.StasjonId, StasjonNavn = stasjon.StasjonNavn });
            }

            return stasjoner;

        }


        public List<avgangs> hentTurListe(int result, int result1)
        {
            List<avgangs> turListe = new List<avgangs>();
            var DbDall = new DbTogstasjon();
            List<Avgang> turlistee = DbDall.ReturListe(result, result1);

            foreach (Avgang avgang in turlistee)
            {
                turListe.Add(new avgangs
                {
                    //TogId = avgang.Tog.TogId,
                    AvgangId = avgang.AvgangId,
                    
                    Tid = avgang.Tid ,
                    
                   // StasjonId = avgang.Stasjon.StasjonId
                });


        }


                return turListe;

            }
        


        public List<avgangs> hentReturListe(int result, int result1)
        {
            var DbDall = new DbTogstasjon();
            List<avgangs> returListe = new List<avgangs>();
            List<Avgang> returliste = DbDall.ReturListe(result, result1);
            foreach(Avgang avgang in returliste)
            {
                returListe.Add(new avgangs
                {
                    AvgangId = avgang.AvgangId,
                   
                  StasjonId = avgang.Stasjon.StasjonId,
                    Tid = avgang.Tid ,
                 // TogId = avgang.Tog.TogId
                });

            }
            return returListe;
        }


        public bool setteAlleBilletter(Samle ny, int studentpris, int voksenpris, int barnepris, string Telefonnummer, string Email, string kortnummer, int Cvc)
        {
            var DbDall = new DbTogstasjon();

            return DbDall.setteBilletter(ny, studentpris, voksenpris, barnepris, Telefonnummer, Email, kortnummer, Cvc);



        }

        public bool Admin_i_db(Admin innAdmin)
        {
            var DbDall = new DbTogstasjon();

            return DbDall.Admin_i_db(innAdmin);

        }


        public bool nyAdmin(Admin innAdmin)
        {
            var DbDall = new DbTogstasjon();


            return DbDall.nyAdmin(innAdmin);

        }














    }
}




