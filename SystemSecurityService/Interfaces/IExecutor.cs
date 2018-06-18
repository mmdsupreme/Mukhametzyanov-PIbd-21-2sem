using SystemSecurityService.BindingModels;
using SystemSecurityService.ViewModel;
using System.Collections.Generic;

namespace SystemSecurityService.Interfaces
{
    public interface IExecutor
    {
        List<ExecutorViewModel> GetList();

        ExecutorViewModel GetElement(int id);

        void AddElement(ExecutorBindModel model);

        void UpdElement(ExecutorBindModel model);

        void DelElement(int id);
    }
}
