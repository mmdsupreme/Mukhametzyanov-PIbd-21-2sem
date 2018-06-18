using SystemSecurityService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SystemSecurityService.BindingModels;
using SystemSecurityService.ViewModel;
using SystemSecurityModel;

namespace SystemSecurityService.ServicesList
{
    public class SystemmList : ISystemm
    {
        private DataListSingleton source;

        public SystemmList()
        {
            source = DataListSingleton.GetInstance();
        }

        public void AddElement(SystemmBindModel model)
        {
            Systemm elem = source.Systemms.FirstOrDefault(Systemm => Systemm.SystemmName == model.SystemmName);
            if (elem != null)
            {
                throw new Exception("Такой коктейль уже есть");
            }
            int maxId = source.Systemms.Count > 0 ? source.Systemms.Max(Systemm => Systemm.ID) : 0;
            source.Systemms.Add(new Systemm
            {
                ID = maxId + 1,
                SystemmName = model.SystemmName,
                Price = model.Price
            });
            int maxPCId = source.ElementRequirements.Count > 0 ? source.ElementRequirements.Max(Systemm => Systemm.ID) : 0;
            var groupElements = model.ElementRequirements.GroupBy(Systemm => Systemm.ElementID).Select(Systemm => new
            {
                ElementId = Systemm.Key,
                Count = Systemm.Sum(r => r.Count)
            });
            foreach (var groupElement in groupElements)
            {
                source.ElementRequirements.Add(new ElementRequirement
                {
                    ID = ++maxPCId,
                    SystemmID = maxId + 1,
                    ElementID = groupElement.ElementId,
                    Count = groupElement.Count
                });
            }
        }

        public void DelElement(int id)
        {
            Systemm element = source.Systemms.FirstOrDefault(Systemm => Systemm.ID == id);
            if (element != null)
            {
                source.ElementRequirements.RemoveAll(Systemm => Systemm.SystemmID == id);
                source.Systemms.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public SystemmViewModel GetElement(int id)
        {
            Systemm element = source.Systemms.FirstOrDefault(Systemm => Systemm.ID == id);
            if (element != null)
            {
                return new SystemmViewModel
                {
                    ID = element.ID,
                    SystemmName = element.SystemmName,
                    Price = element.Price,
                    ElementRequirements = source.ElementRequirements.Where(SystemmPC => SystemmPC.SystemmID == element.ID).Select(SystemmPC => new ElementRequirementsViewModel
                    {
                        ID = SystemmPC.ID,
                        SystemmID = SystemmPC.SystemmID,
                        ElementID = SystemmPC.ElementID,
                        ElementName = source.Elements
                                        .FirstOrDefault(SystemmC => SystemmC.ID == SystemmPC.ElementID)?.ElementName,
                        Count = SystemmPC.Count
                    }).ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public List<SystemmViewModel> GetList()
        {
            List<SystemmViewModel> result = source.Systemms
                .Select(Systemm => new SystemmViewModel
                {
                    ID = Systemm.ID,
                    SystemmName = Systemm.SystemmName,
                    Price = Systemm.Price,
                    ElementRequirements = source.ElementRequirements.Where(SystemmPC => SystemmPC.SystemmID == Systemm.ID).Select(SystemmPC => new ElementRequirementsViewModel
                    {
                        ID = SystemmPC.ID,
                        SystemmID = SystemmPC.SystemmID,
                        ElementID = SystemmPC.ElementID,
                        ElementName = source.Elements.FirstOrDefault(SystemmC => SystemmC.ID == SystemmPC.ElementID)?.ElementName,
                        Count = SystemmPC.Count
                    }).ToList()
                }).ToList();
            return result;
        }

        public void UpdElement(SystemmBindModel model)
        {
            Systemm element = source.Systemms.FirstOrDefault(Systemm => Systemm.SystemmName == model.SystemmName && Systemm.ID != model.ID);
            if (element != null)
            {
                throw new Exception("Такая система уже есть");
            }
            element = source.Systemms.FirstOrDefault(Systemm => Systemm.ID == model.ID);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.SystemmName = model.SystemmName;
            element.Price = model.Price;
            int maxPCId = source.ElementRequirements.Count > 0 ? source.ElementRequirements.Max(Systemm => Systemm.ID) : 0;
            var compIds = model.ElementRequirements.Select(Systemm => Systemm.ElementID).Distinct();
            var updateElements = source.ElementRequirements.Where(Systemm => Systemm.SystemmID == model.ID && compIds.Contains(Systemm.ElementID));
            foreach (var updateElement in updateElements)
            {
                updateElement.Count = model.ElementRequirements.FirstOrDefault(Systemm => Systemm.ID == updateElement.ID).Count;
            }
            source.ElementRequirements.RemoveAll(Systemm => Systemm.SystemmID == model.ID && !compIds.Contains(Systemm.ElementID));
            var groupElements = model.ElementRequirements.Where(Systemm => Systemm.ID == 0).GroupBy(Systemm => Systemm.ElementID).Select(Systemm => new
            {
                ElementID = Systemm.Key,
                Count = Systemm.Sum(r => r.Count)
            });
            foreach (var groupElement in groupElements)
            {
                ElementRequirement elementPC = source.ElementRequirements.FirstOrDefault(Systemm => Systemm.SystemmID == model.ID && Systemm.ElementID == groupElement.ElementID);
                if (elementPC != null)
                {
                    elementPC.Count += groupElement.Count;
                }
                else
                {
                    source.ElementRequirements.Add(new ElementRequirement
                    {
                        ID = ++maxPCId,
                        SystemmID = model.ID,
                        ElementID = groupElement.ElementID,
                        Count = groupElement.Count
                    });
                }
            }
        }
    }
}