using SystemSecurityModel;
using SystemSecurityService.BindingModels;
using SystemSecurityService.Interfaces;
using SystemSecurityService.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Data.Entity;

namespace SystemSecurityService.BDImplementation
{
    public class MainBD : IMainService
    {
        private SystemSecurityDBContext context;

        public MainBD(SystemSecurityDBContext context)
        {
            this.context = context;
        }

        public List<OrderViewModel> GetList()
        {
            List<OrderViewModel> result = context.Orders
                .Select(rec => new OrderViewModel
                {
                    ID = rec.ID,
                    CustomerID = rec.CustomerID,
                    SystemmID = rec.SystemmID,
                    ExecutorID = rec.ExecutorID,
                    DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
                                SqlFunctions.DateName("mm", rec.DateCreate) + " " +
                                SqlFunctions.DateName("yyyy", rec.DateCreate),
                    DateImplement = rec.DateImplement == null ? "" :
                                        SqlFunctions.DateName("dd", rec.DateImplement.Value) + " " +
                                        SqlFunctions.DateName("mm", rec.DateImplement.Value) + " " +
                                        SqlFunctions.DateName("yyyy", rec.DateImplement.Value),
                    Status = rec.Status.ToString(),
                    Count = rec.Count,
                    Sum = rec.Sum,
                    CustomerFIO = rec.Customer.CustomerFIO,
                    SystemmName = rec.Systemm.SystemmName,
                    ExecutorName = rec.Executor.ExecutorFIO
                })
                .ToList();
            return result;
        }

        public void CreateOrder(OrderBindModel model)
        {
            context.Orders.Add(new Order
            {
                CustomerID = model.CustomerID,
                SystemmID = model.SystemmID,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            });
            context.SaveChanges();
        }

        public void TakeOrderInWork(OrderBindModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Order element = context.Orders.FirstOrDefault(rec => rec.ID == model.ID);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    var SystemmElements = context.ElementRequirements
                                                .Include(rec => rec.Element)
                                                .Where(rec => rec.SystemmID == element.SystemmID);
                    foreach (var SystemmElement in SystemmElements)
                    {
                        int countOnStorages = SystemmElement.Count * element.Count;
                        var StorageElements = context.ElementRequirements
                                                    .Where(rec => rec.ElementID == SystemmElement.ElementID);
                        foreach (var StorageElement in StorageElements)
                        {
                            if (StorageElement.Count >= countOnStorages)
                            {
                                StorageElement.Count -= countOnStorages;
                                countOnStorages = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnStorages -= StorageElement.Count;
                                StorageElement.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnStorages > 0)
                        {
                            throw new Exception("Не достаточно компонента " +
                                SystemmElement.Element.ElementName + " требуется " +
                                SystemmElement.Count + ", не хватает " + countOnStorages);
                        }
                    }
                    element.ExecutorID = model.ExecutorID;
                    element.DateImplement = DateTime.Now;
                    element.Status = OrderStatus.Выполняется;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void FinishOrder(int ID)
        {
            Order element = context.Orders.FirstOrDefault(rec => rec.ID == ID);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = OrderStatus.Готов;
            context.SaveChanges();
        }

        public void PayOrder(int ID)
        {
            Order element = context.Orders.FirstOrDefault(rec => rec.ID == ID);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Status = OrderStatus.Оплачен;
            context.SaveChanges();
        }

        public void PutElementOnStorage(ElementStorageBindModel model)
        {
            ElementStorage element = context.ElementStorages
                                                .FirstOrDefault(rec => rec.StorageID == model.StorageID &&
                                                                    rec.ElementID == model.ElementID);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.ElementStorages.Add(new ElementStorage
                {
                    StorageID = model.StorageID,
                    ElementID = model.ElementID,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }
    }
}
