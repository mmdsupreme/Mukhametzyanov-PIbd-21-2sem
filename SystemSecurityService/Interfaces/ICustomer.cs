using SystemSecurityService.BindingModels;
using SystemSecurityService.ViewModel;
using System.Collections.Generic;

namespace SystemSecurityService.Interfaces
{
    public interface ICustomer
    {
        List<CustomerViewModel> GetList();

        CustomerViewModel GetElement(int id);

        void AddElement(CustomerBindModel model);

        void UpdElement(CustomerBindModel model);

        void DelElement(int id);
    }
}
