using SystemSecurityService.BindingModels;
using SystemSecurityService.ViewModel;
using System.Collections.Generic;

namespace SystemSecurityService.Interfaces
{
    public interface IElement
    {
        List<ElementViewModel> GetList();

        ElementViewModel GetElement(int id);

        void AddElement(ElementBindModel model);

        void UpdElement(ElementBindModel model);

        void DelElement(int id);
    }
}
