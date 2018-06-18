using SystemSecurityModel;
using SystemSecurityService.BindingModels;
using SystemSecurityService.Interfaces;
using SystemSecurityService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SystemSecurityService.BDImplementation
{
    public class SystemmBD : ISystemm
    {
        private SystemSecurityDBContext context;

        public SystemmBD(SystemSecurityDBContext context)
        {
            this.context = context;
        }

        public List<SystemmViewModel> GetList()
        {
            List<SystemmViewModel> result = context.Systemms
                .Select(rec => new SystemmViewModel
                {
                    ID = rec.ID,
                    SystemmName = rec.SystemmName,
                    Price = rec.Price,
                    ElementRequirements = context.ElementRequirements.Where(recPC => recPC.SystemmID == rec.ID)
                            .Select(recPC => new ElementRequirementsViewModel
                            {
                                ID = recPC.ID,
                                SystemmID = recPC.SystemmID,
                                ElementID = recPC.ElementID,
                                ElementName = recPC.Element.ElementName,
                                Count = recPC.Count
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public SystemmViewModel GetElement(int ID)
        {
            Systemm element = context.Systemms.FirstOrDefault(rec => rec.ID == ID);
            if (element != null)
            {
                return new SystemmViewModel
                {
                    ID = element.ID,
                    SystemmName = element.SystemmName,
                    Price = element.Price,
                    ElementRequirements = context.ElementRequirements
                            .Where(recPC => recPC.SystemmID == element.ID)
                            .Select(recPC => new ElementRequirementsViewModel
                            {
                                ID = recPC.ID,
                                SystemmID = recPC.SystemmID,
                                ElementID = recPC.ElementID,
                                ElementName = recPC.Element.ElementName,
                                Count = recPC.Count
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(SystemmBindModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Systemm element = context.Systemms.FirstOrDefault(rec => rec.SystemmName == model.SystemmName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = new Systemm
                    {
                        SystemmName = model.SystemmName,
                        Price = model.Price
                    };
                    context.Systemms.Add(element);
                    context.SaveChanges();
                    var groupElements = model.ElementRequirements
                                                .GroupBy(rec => rec.ElementID)
                                                .Select(rec => new
                                                {
                                                    ElementID = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    foreach (var groupElement in groupElements)
                    {
                        context.ElementRequirements.Add(new ElementRequirement
                        {
                            SystemmID = element.ID,
                            ElementID = groupElement.ElementID,
                            Count = groupElement.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void UpdElement(SystemmBindModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Systemm element = context.Systemms.FirstOrDefault(rec =>
                                        rec.SystemmName == model.SystemmName && rec.ID != model.ID);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = context.Systemms.FirstOrDefault(rec => rec.ID == model.ID);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.SystemmName = model.SystemmName;
                    element.Price = model.Price;
                    context.SaveChanges();

                    var compIDs = model.ElementRequirements.Select(rec => rec.ElementID).Distinct();
                    var updateElements = context.ElementRequirements
                                                    .Where(rec => rec.SystemmID == model.ID &&
                                                        compIDs.Contains(rec.ElementID));
                    foreach (var updateElement in updateElements)
                    {
                        updateElement.Count = model.ElementRequirements
                                                        .FirstOrDefault(rec => rec.ID == updateElement.ID).Count;
                    }
                    context.SaveChanges();
                    context.ElementRequirements.RemoveRange(
                                        context.ElementRequirements.Where(rec => rec.SystemmID == model.ID &&
                                                                            !compIDs.Contains(rec.ElementID)));
                    context.SaveChanges();
                    var groupElements = model.ElementRequirements
                                                .Where(rec => rec.ID == 0)
                                                .GroupBy(rec => rec.ElementID)
                                                .Select(rec => new
                                                {
                                                    ElementID = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    foreach (var groupElement in groupElements)
                    {
                        ElementRequirement elementPC = context.ElementRequirements
                                                .FirstOrDefault(rec => rec.SystemmID == model.ID &&
                                                                rec.ElementID == groupElement.ElementID);
                        if (elementPC != null)
                        {
                            elementPC.Count += groupElement.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.ElementRequirements.Add(new ElementRequirement
                            {
                                SystemmID = model.ID,
                                ElementID = groupElement.ElementID,
                                Count = groupElement.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DelElement(int ID)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Systemm element = context.Systemms.FirstOrDefault(rec => rec.ID == ID);
                    if (element != null)
                    {
                        context.ElementRequirements.RemoveRange(
                                            context.ElementRequirements.Where(rec => rec.SystemmID == ID));
                        context.Systemms.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
