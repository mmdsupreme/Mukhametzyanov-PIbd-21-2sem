using SystemSecurityService.BindingModels;
using SystemSecurityService.ViewModel;
using System.Collections.Generic;

namespace SystemSecurityService.Interfaces
{
    public interface IStorage
    {
        List<StorageViewModel> GetList();

        StorageViewModel GetElement(int id);

        void AddElement(StorageBindModel model);

        void UpdElement(StorageBindModel model);

        void DelElement(int id);
    }
}
