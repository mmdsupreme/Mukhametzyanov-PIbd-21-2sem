﻿using System;

namespace SystemSecurityModel
{
    public class MessageInfo
    {
        public int Id { get; set; }
 
         public string MessageId { get; set; }
 
         public string FromMailAddress { get; set; }
 
         public string Subject { get; set; }
 
         public string Body { get; set; }
 
         public DateTime DateDelivery { get; set; }
 
         public int? CustomerID { get; set; }
 
         public virtual Customer Customer { get; set; }
    }
}
