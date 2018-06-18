using SystemSecurityService.BindingModels;
using SystemSecurityService.ViewModel;
using System.Collections.Generic;

namespace SystemSecurityService.Interfaces
{
    public interface IReportService
    {
        void SaveSystemmPrice(ReportBindModel model);

        List<StorageLoadViewModel> GetStoragesLoad();

        void SaveStoragesLoad(ReportBindModel model);

        List<CustomerOrderViewModel> GetCustomerOrders(ReportBindModel model);

        void SaveCustomerOrders(ReportBindModel model);
    }
}
