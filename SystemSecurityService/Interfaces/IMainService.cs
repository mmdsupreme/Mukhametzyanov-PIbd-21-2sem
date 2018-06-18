using SystemSecurityService.Attributes;
using SystemSecurityService.BindingModels;
using SystemSecurityService.ViewModel;
using System.Collections.Generic;

namespace SystemSecurityService.Interfaces
{
    [CustomInterface("Интерфейс для работы с заказами")]
    public interface IMainService
    {
        [CustomMethod("Метод получения списка заказов")]
        List<OrderViewModel> GetList();

        [CustomMethod("Метод создания заказа")]
        void CreateOrder(OrderBindModel model);

        [CustomMethod("Метод передачи заказа в работу")]
        void TakeOrderInWork(OrderBindModel model);

        [CustomMethod("Метод передачи заказа на оплату")]
        void FinishOrder(int id);

        [CustomMethod("Метод фиксирования оплаты по заказу")]
        void PayOrder(int id);

        [CustomMethod("Метод пополнения компонент на складе")]
        void PutElementOnStorage(ElementStorageBindModel model);
    }
}
