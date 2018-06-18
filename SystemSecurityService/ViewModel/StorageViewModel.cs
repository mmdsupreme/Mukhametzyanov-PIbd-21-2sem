using System.Collections.Generic;

namespace SystemSecurityService.ViewModel
{
    public class StorageViewModel
    {
        public int ID { get; set; }
        public string StorageName { get; set; }
        public List<ElementStorageViewModel> StorageElements { get; set; }
    }
}
