using System.Collections.Generic;

namespace SystemSecurityService.ViewModel
{
    public class SystemmViewModel
    {
        public int ID { get; set; }
        public string SystemmName { get; set; }
        public decimal Price { get; set; }
        public List<ElementRequirementsViewModel> ElementRequirements { get; set; }
    }
}
