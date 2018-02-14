using LocaliztionCRUD.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalizationCRUD.Models
{    
    public class SearchClassMessage : RisorseLocalizzazioneMessage
    {
         //Contenitore
        public List<RisorseLocalizzazioneMessage> ResultList { get; set; }

        public new int? idModulo { get; set; }
    }
}