using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GruppeInnlevering1.Models;

namespace GruppeInnlevering1.DAL
{
    public class TogSub : DAL.TogRepo
    {
        public bool Admin_i_db(Admin innAdmin)
        {
          if (innAdmin.Email == "")
            {
                return false;
            }
          else
            {
                return true;
            }
        }

        public List<avgangs> allavganger()
        {
            TimeSpan s = new TimeSpan(10, 1, 2);
            var alleavgangerListe = new List<avgangs>();
            var avgang = new avgangs()
            {
                AvgangId = 1,
                Tid = s,
                StasjonId = 3,
                TogId = 1

            };
            alleavgangerListe.Add(avgang);
            alleavgangerListe.Add(avgang);
            alleavgangerListe.Add(avgang);
            return alleavgangerListe;

        }

        public List<BilletV> alleBillter()
        {
            DateTime retur = new DateTime(2020, 1, 1);
            DateTime tur = new DateTime(2019, 11, 1);

            var alleBilletterListe = new List<BilletV>();
            var Billett = new BilletV()
            {
                AvgangFra = 1,
                AvgangTil = 2,
                BilletId = 1,
                Cvc = 123,
                DatoRetur = retur,
                DatoTur = tur,
                Email = "perhansen@gmail.com",
                gyldig = "ja",
                Kortnummer = "1234567890123456",
                Pris = 12,
                Telefonnummer = "12345678",
                Type = "Student"

            };
            alleBilletterListe.Add(Billett);
            alleBilletterListe.Add(Billett);
            alleBilletterListe.Add(Billett);
            alleBilletterListe.Add(Billett);
            return alleBilletterListe;
        }


        public List<StasjonV> alleStasjoner()
        {
            var alleStasjonerListe = new List<StasjonV>();
            var stasjon = new StasjonV
            {
                StasjonId = 1,
                StasjonNavn = "Oslo"
            };
            alleStasjonerListe.Add(stasjon);
            alleStasjonerListe.Add(stasjon);
            alleStasjonerListe.Add(stasjon);
            return alleStasjonerListe;

        }

        public List<TogV> alleTog()
        {
            var alleTogListe = new List<TogV>();
            var tog = new TogV()
            {

                TogId = 1,
                TogNavn = "Osloskien"
            };
            alleTogListe.Add(tog);
            alleTogListe.Add(tog);
            alleTogListe.Add(tog);
            return alleTogListe;
        }

        public bool endreAvgang(avgangs innAvgang)
        {
            if (innAvgang.AvgangId == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool endreStasjon(StasjonV innStasjon)
        {
            if(innStasjon.StasjonId == 0){
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool endreTog(TogV inntog)
        {
            if (inntog.TogId == 0)
            {
                return false;
            }else
            {
                return true;
            }
        }

        public avgangs hentAvgang(int AvgangId)
        {
            if (AvgangId == 0)
            {
                var avgang = new avgangs();
                avgang.AvgangId = 0;
                return avgang;
            }
            else
            {
                TimeSpan s = new TimeSpan(10, 1, 2);
                var avgang = new avgangs()
                {
                    AvgangId = 1,
                    Tid = s,
                    StasjonId = 3,
                    TogId = 1

                };
                return avgang;
            }
        }

        public BilletV hentBilett(int BilletId)
        {
            var billet = new BilletV(); 
            if (BilletId == 0)
            {
                billet.BilletId = 0;
                return billet;
            }
            else
            {
                DateTime retur = new DateTime(2020, 1, 1);
                DateTime tur = new DateTime(2019, 11, 1);
                var billett1 = new BilletV()
                {
                    AvgangFra = 1,
                    AvgangTil = 2,
                    BilletId = 1,
                    Cvc = 123,
                    DatoRetur = retur,
                    DatoTur = tur,
                    Email = "perhansen@gmail.com",
                    gyldig = "ja",
                    Kortnummer = "1234567890123456",
                    Pris = 12,
                    Telefonnummer = "12345678",
                    Type = "Student"

                };
                return billett1;
            }
        }

        public StasjonV hentStasjon(int StasjonId)
        {
           if (StasjonId == 0)
            {
                var stasjon = new StasjonV();
                stasjon.StasjonId = 0;
                return stasjon;
            }
           else
            {
                var stasjon = new StasjonV
                {
                    StasjonId = 1,
                    StasjonNavn = "Oslo"
                };
                return stasjon;
            }
        }

        public TogV hentTog(int TogId)
        {
           if(TogId== 0)
            {
                var tog = new TogV();
                tog.TogId = 0;
                return tog;
            }
           else
            {
                var tog = new TogV()
                {
                    TogId = 1,
                    TogNavn = "Osloskien"
                };
                return tog; 
            }
        }

        public bool nyAdmin(Admin innAdmin)
        {
            if (innAdmin.Email == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool nyAvgang(avgangs innAvgang)
        {
            if(innAvgang.AvgangId ==0)
            {
                return false;
            }else 
            {
                return true;
            }
        }

        public bool nyStasjon(StasjonV innStasjon)
        {
            if (innStasjon.StasjonNavn == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool nyTog(TogV innTog)
        {
            if (innTog.TogNavn== "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool SlettAvgan(int id)
        {
           if (id == 0)
            {
                return false;
            }
           else
            {
                return true;
            }
        }

        public bool SlettSBillett(int id)
        {
            if (id ==0)
            {
                return false;
            }else
            {
                return true;
            }
        }

        public bool SlettStasjon(int id)
        {
        if (id ==0)
            {
                return false;
            }else
            {
                return true;
            }
        }

        public bool SlettTog(int id)
        {
          if(id ==0)
            {
                return false;
            }
            return true;
        }
    }
}
