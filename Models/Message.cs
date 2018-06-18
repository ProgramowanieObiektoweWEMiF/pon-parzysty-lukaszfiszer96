using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PO_Messenger.Models
{   [Serializable]
    public class Message
    {
        public string Contents { get; set; }
        public string Recipient { get; set; }
    }
}