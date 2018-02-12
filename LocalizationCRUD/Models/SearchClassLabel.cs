using LocaliztionCRUD.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalizationCRUD.Models
{
    public class SearchClassLabel : RisorseLocalizzazioneLabel
    {
        public SearchClassLabel()
        {
            ResultList = new List<RisorseLocalizzazioneLabel>();
        }
        //private RisorseLocalizzazioneLabel x;

        //public SearchClassLabel(RisorseLocalizzazioneLabel x)
        //{
        //    this.x = x;
        //}

        public List<RisorseLocalizzazioneLabel> ResultList { get; set; }

        public new int? idModulo { get; set; }


       
    }


}