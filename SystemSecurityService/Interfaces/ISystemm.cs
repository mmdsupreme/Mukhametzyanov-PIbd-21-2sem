using SystemSecurityService.Attributes;
using SystemSecurityService.BindingModels;
using SystemSecurityService.ViewModel;
using System.Collections.Generic;

namespace SystemSecurityService.Interfaces
{
    [CustomInterface("Интерфейс для работы с коктейлями")]
    public interface ISystemm
    {
        [CustomMethod("Метод получения списка коктейлей")]
        List<SystemmViewModel> GetList();

        [CustomMethod("Метод получения коктейля по id")]
        SystemmViewModel GetElement(int id);

        [CustomMethod("Метод добавления коктейля")]
        void AddElement(SystemmBindModel model);

        [CustomMethod("Метод изменения данных коктейля")]
        void UpdElement(SystemmBindModel model);

        [CustomMethod("Метод удаления коктейля")]
        void DelElement(int id);
    }
}
