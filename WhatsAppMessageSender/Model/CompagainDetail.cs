using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppMessageSender
{
    public class CompagainDetail
    {
        public int Id { get; set; }
        public int C_Id { get; set; }
        [ForeignKey("C_Id")]
        public Compagain Compagain { get; set; }
        public long Number { get; set; }
        public bool isSend { get; set; }
    }

}
