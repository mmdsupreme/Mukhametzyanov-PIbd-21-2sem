using SystemSecurityService.Attributes;
using SystemSecurityService.BindingModels;
using SystemSecurityService.ViewModel;
using System.Collections.Generic;

namespace SystemSecurityService.Interfaces
{
    [CustomInterface("Интерфейс для работы с работниками")]
    public interface IExecutor
    {
        [CustomMethod("Метод получения списка работников")]
        List<ExecutorViewModel> GetList();

        [CustomMethod("Метод получения работника по id")]
        ExecutorViewModel GetElement(int id);

        [CustomMethod("Метод добавления работника")]
        void AddElement(ExecutorBindModel model);

        [CustomMethod("Метод изменения данных работника")]
        void UpdElement(ExecutorBindModel model);

        [CustomMethod("Метод удаления работника")]
        void DelElement(int id);
    }
}
