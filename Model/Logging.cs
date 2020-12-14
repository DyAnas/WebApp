using System;
using System.IO;


namespace GruppeInnlevering
{
    public class Logging
    {
        private string loggingFormat;
        private string ErorrTid;

        public Logging()
        {
            //loggingFormat ble brukt til å lage en format til feilen..
            // Eksempel dd/mm/yyyy hh:mm:ss AM/PM ==> 
            loggingFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
            string fAAr = DateTime.Now.Year.ToString();
            string fMåned = DateTime.Now.Month.ToString();
            string fDag = DateTime.Now.Day.ToString();
            ErorrTid = fAAr + fMåned + fDag;


        }

        public void FeilLog(string PathNavn, string FeilMelding)
        {

            StreamWriter sw = new StreamWriter(PathNavn + ErorrTid, true);
            sw.WriteLine(loggingFormat + FeilMelding);
            sw.Flush();
            sw.Close();
        }
    }
}