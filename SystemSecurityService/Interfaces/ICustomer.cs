﻿using SystemSecurityService.Attributes;
using SystemSecurityService.BindingModels;
using SystemSecurityService.ViewModel;
using System.Collections.Generic;

namespace SystemSecurityService.Interfaces
{
    [CustomInterface("Интерфейс для работы с покупателями")]
    public interface ICustomer
    {
        [CustomMethod("Метод получения списка покупателей")]
        List<CustomerViewModel> GetList();

        [CustomMethod("Метод получения покупателя по id")]
        CustomerViewModel GetElement(int id);

        [CustomMethod("Метод добавления покупателя")]
        void AddElement(CustomerBindModel model);

        [CustomMethod("Метод изменения данных покупателя")]
        void UpdElement(CustomerBindModel model);

        [CustomMethod("Метод удаления покупателя")]
        void DelElement(int id);
    }
}
