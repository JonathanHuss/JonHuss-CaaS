using JonHuss_CaaS.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JonHuss_CaaS.UserInterface.Models.Home
{
    public class HomeViewModel
    {
        public IEnumerable<ConversationTemplate> ConversationTemplates { get; set; }

        public HomeViewModel()
        {
            ConversationTemplates = new List<ConversationTemplate>();
        }

    }
    
}