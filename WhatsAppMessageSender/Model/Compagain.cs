using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppMessageSender
{
    public class Compagain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status CampaignStatus { get; set; }
        public int No_Of_Participants { get; set; }
        public String Message { get; set; }

      

    }
    public enum Status
    {
       Stop=1,
       Start=2,
       Resume=3

    }

}
