using GruppeInnlevering1.Models;
using GruppeInnlevering1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppeInnlevering1.BLL
{
    public class TogBLL : BLL.TogLogikk
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


    }
    }




