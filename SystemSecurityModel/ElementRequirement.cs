﻿namespace SystemSecurityModel
{
    public class ElementRequirement
    {
        public int ID { get; set; }
        public int SystemmID { get; set; }
        public int ElementID { get; set; }
        public int Count { get; set; }
        public virtual Systemm Systemm { set; get; }
        public virtual Element Element { set; get; }
    }
}
