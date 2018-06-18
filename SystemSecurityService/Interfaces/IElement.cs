using SystemSecurityService.Attributes;
using SystemSecurityService.BindingModels;
using SystemSecurityService.ViewModel;
using System.Collections.Generic;

namespace SystemSecurityService.Interfaces
{
    [CustomInterface("Интерфейс для работы с компонентами")]
    public interface IElement
    {
        [CustomMethod("Метод получения списка компонент")]
        List<ElementViewModel> GetList();

        [CustomMethod("Метод получения компонента по id")]
        ElementViewModel GetElement(int id);

        [CustomMethod("Метод добавления компонента")]
        void AddElement(ElementBindModel model);

        [CustomMethod("Метод изменения данных компонента")]
        void UpdElement(ElementBindModel model);

        [CustomMethod("Метод удаления компонента")]
        void DelElement(int id);
    }
}
