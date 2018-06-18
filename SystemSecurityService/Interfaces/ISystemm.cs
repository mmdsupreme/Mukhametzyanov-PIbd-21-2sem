using SystemSecurityService.BindingModels;
using SystemSecurityService.ViewModel;
using System.Collections.Generic;

namespace SystemSecurityService.Interfaces
{
    public interface ISystemm
    {
        List<SystemmViewModel> GetList();

        SystemmViewModel GetElement(int id);

        void AddElement(SystemmBindModel model);

        void UpdElement(SystemmBindModel model);

        void DelElement(int id);
    }
}
