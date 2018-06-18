using System;
using System.Collections.Generic;
using System.Linq;
using SystemSecurityService.BindingModels;
using SystemSecurityService.Interfaces;
using SystemSecurityService.ViewModel;
using SystemSecurityModel;

namespace SystemSecurityService.ServicesList
{
    public class MainList : IMainService
    {
        private DataListSingleton source;

        public MainList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrder(OrderBindModel model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(order => order.ID) : 0;
            source.Orders.Add(new Order
            {
                ID = maxId + 1,
                CustomerID = model.CustomerID,
                SystemmID = model.SystemmID,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            });
        }

        public void FinishOrder(int id)
        {
            Order elem = source.Orders.FirstOrDefault(order => order.ID == id);
            if (elem == null)
            {
                throw new Exception("Элемент не найден");
            }
            elem.Status = OrderStatus.Готов;
        }

        public List<OrderViewModel> GetList()
        {
            List<OrderViewModel> result = source.Orders.Select(order => new OrderViewModel
            {
                ID = order.ID,
                CustomerID = order.CustomerID,
                SystemmID = order.SystemmID,
                ExecutorID = order.ExecutorID,
                DateCreate = order.DateCreate.ToLongDateString(),
                DateImplement = order.DateImplement?.ToLongDateString(),
                Status = order.Status.ToString(),
                Count = order.Count,
                Sum = order.Sum,
                CustomerFIO = source.Customers.FirstOrDefault(orderC => orderC.ID == order.CustomerID)?.CustomerFIO,
                SystemmName = source.Elements.FirstOrDefault(orderP => orderP.ID == order.SystemmID)?.ElementName,
                ExecutorName = source.Executors.FirstOrDefault(orderI => orderI.ID == order.ExecutorID)?.ExecutorFIO
            }).ToList();
            return result;
        }

        public void PayOrder(int id)
        {
            Order elem = source.Orders.FirstOrDefault(order => order.ID == id);
            if (elem == null)
            {
                throw new Exception("Элемент не найден");
            }
            elem.Status = OrderStatus.Оплачен;
        }

        public void PutElementOnStorage(ElementStorageBindModel model)
        {
            ElementStorage element = source.ElementStorages.FirstOrDefault(order => order.StorageID == model.StorageID && order.ElementID == model.ElementID);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.ElementStorages.Count > 0 ? source.ElementStorages.Max(order => order.ID) : 0;
                source.ElementStorages.Add(new ElementStorage
                {
                    StorageID = model.StorageID,
                    ElementID = model.ElementID,
                    Count = model.Count
                });
            }
        }

        public void TakeOrderInWork(OrderBindModel model)
        {
            Order element = source.Orders.FirstOrDefault(order => order.ID == model.ID);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            var SystemmElements = source.ElementRequirements.Where(order => order.ElementID == element.SystemmID);
            foreach (var SystemmElement in SystemmElements)
            {
                int countOnStorages = source.ElementStorages.Where(order => order.ElementID == SystemmElement.ElementID).Sum(order => order.Count);
                if (countOnStorages < SystemmElement.Count * element.Count)
                {
                    var ElementName = source.Elements.FirstOrDefault(order => order.ID == SystemmElement.ElementID);
                    throw new Exception("Не достаточно компонента " + ElementName?.ElementName +
                        " требуется " + SystemmElement.Count * element.Count + ", в наличии " + countOnStorages);
                }
            }
            foreach (var SystemmElement in SystemmElements)
            {
                int countOnStorages = SystemmElement.Count * element.Count;
                var StorageElements = source.ElementStorages.Where(order => order.ElementID == SystemmElement.ElementID);
                foreach (var StorageElement in StorageElements)
                {
                    if (StorageElement.Count >= countOnStorages)
                    {
                        StorageElement.Count -= countOnStorages;
                        break;
                    }
                    else
                    {
                        countOnStorages -= StorageElement.Count;
                        StorageElement.Count = 0;
                    }
                }
            }
            element.ExecutorID = model.ExecutorID;
            element.DateImplement = DateTime.Now;
            element.Status = OrderStatus.Выполняется;
        }
    }
}

