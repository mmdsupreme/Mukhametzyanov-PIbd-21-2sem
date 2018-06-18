using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemSecurityModel
{
    public class Systemm
    {
        public int ID { set; get; }

        [Required]
        public string SystemmName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("SystemmID")]
        public virtual List<Order> Orders { set; get; }

        [ForeignKey("SystemmID")]
        public virtual List<ElementRequirement> ElementRequirements { set; get; }
    }
}
