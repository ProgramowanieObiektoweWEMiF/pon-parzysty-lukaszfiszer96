using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PO_Messenger.Models
{   
    [Serializable]
    public class Email : Message
    {

        public string Topic { get; set; }
        public string RecipientEmial { get; set; }
        private string messageType = "Email";

        public string MessageType
        {
            get { return messageType; }

        }

       
    }
}