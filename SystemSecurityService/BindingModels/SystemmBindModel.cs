using System.Collections.Generic;

namespace SystemSecurityService.BindingModels
{
    public class SystemmBindModel
    {
        public int ID { set; get; }
        public string SystemmName { get; set; }
        public decimal Price { get; set; }
        public List<ElementRequirementsBindModel> ElementRequirements { get; set; }
    }
}
