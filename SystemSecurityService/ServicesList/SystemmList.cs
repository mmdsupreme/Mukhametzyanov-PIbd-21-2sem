using SystemSecurityService.Interfaces;
using System;
using System.Collections.Generic;
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

        public List<SystemmViewModel> GetList()
        {
            List<SystemmViewModel> result = new List<SystemmViewModel>();
            for (int i = 0; i < source.Systemms.Count; ++i)
            {
                List<ElementRequirementsViewModel> ElementRequirements = new List<ElementRequirementsViewModel>();
                for (int j = 0; j < source.ElementRequirements.Count; ++j)
                {
                    if (source.ElementRequirements[j].SystemmID == source.Systemms[i].ID)
                    {
                        string ElementName = string.Empty;
                        for (int k = 0; k < source.Elements.Count; ++k)
                        {
                            if (source.ElementRequirements[j].ElementID == source.Elements[k].ID)
                            {
                                ElementName = source.Elements[k].ElementName;
                                break;
                            }
                        }
                        ElementRequirements.Add(new ElementRequirementsViewModel
                        {
                            ID = source.ElementRequirements[j].ID,
                            SystemmID = source.ElementRequirements[j].SystemmID,
                            ElementID = source.ElementRequirements[j].ElementID,
                            ElementName = ElementName,
                            Count = source.ElementRequirements[j].Count
                        });
                    }
                }
                result.Add(new SystemmViewModel
                {
                    ID = source.Systemms[i].ID,
                    SystemmName = source.Systemms[i].SystemmName,
                    Price = source.Systemms[i].Price,
                    ElementRequirements = ElementRequirements
                });
            }
            return result;
        }

        public SystemmViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Systemms.Count; ++i)
            {
                List<ElementRequirementsViewModel> ElementRequirements = new List<ElementRequirementsViewModel>();
                for (int j = 0; j < source.ElementRequirements.Count; ++j)
                {
                    if (source.ElementRequirements[j].SystemmID == source.Systemms[i].ID)
                    {
                        string ElementName = string.Empty;
                        for (int k = 0; k < source.Elements.Count; ++k)
                        {
                            if (source.ElementRequirements[j].ElementID == source.Elements[k].ID)
                            {
                                ElementName = source.Elements[k].ElementName;
                                break;
                            }
                        }
                        ElementRequirements.Add(new ElementRequirementsViewModel
                        {
                            ID = source.ElementRequirements[j].ID,
                            SystemmID = source.ElementRequirements[j].SystemmID,
                            ElementID = source.ElementRequirements[j].ElementID,
                            ElementName = ElementName,
                            Count = source.ElementRequirements[j].Count
                        });
                    }
                }
                if (source.Systemms[i].ID == id)
                {
                    return new SystemmViewModel
                    {
                        ID = source.Systemms[i].ID,
                        SystemmName = source.Systemms[i].SystemmName,
                        Price = source.Systemms[i].Price,
                        ElementRequirements = ElementRequirements
                    };
                }
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(SystemmBindModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Systemms.Count; ++i)
            {
                if (source.Systemms[i].ID > maxId)
                {
                    maxId = source.Systemms[i].ID;
                }
                if (source.Systemms[i].SystemmName == model.SystemmName)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            source.Systemms.Add(new Systemm
            {
                ID = maxId + 1,
                SystemmName = model.SystemmName,
                Price = model.Price
            });
            int maxPCId = 0;
            for (int i = 0; i < source.ElementRequirements.Count; ++i)
            {
                if (source.ElementRequirements[i].ID > maxPCId)
                {
                    maxPCId = source.ElementRequirements[i].ID;
                }
            }
            for (int i = 0; i < model.ElementRequirements.Count; ++i)
            {
                for (int j = 1; j < model.ElementRequirements.Count; ++j)
                {
                    if (model.ElementRequirements[i].ElementID ==
                        model.ElementRequirements[j].ElementID)
                    {
                        model.ElementRequirements[i].Count +=
                            model.ElementRequirements[j].Count;
                        model.ElementRequirements.RemoveAt(j--);
                    }
                }
            }
            for (int i = 0; i < model.ElementRequirements.Count; ++i)
            {
                source.ElementRequirements.Add(new ElementRequirement
                {
                    ID = ++maxPCId,
                    SystemmID = maxId + 1,
                    ElementID = model.ElementRequirements[i].ElementID,
                    Count = model.ElementRequirements[i].Count
                });
            }
        }

        public void UpdElement(SystemmBindModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Systemms.Count; ++i)
            {
                if (source.Systemms[i].ID == model.ID)
                {
                    index = i;
                }
                if (source.Systemms[i].SystemmName == model.SystemmName &&
                    source.Systemms[i].ID != model.ID)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Systemms[index].SystemmName = model.SystemmName;
            source.Systemms[index].Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.ElementRequirements.Count; ++i)
            {
                if (source.ElementRequirements[i].ID > maxPCId)
                {
                    maxPCId = source.ElementRequirements[i].ID;
                }
            }
            for (int i = 0; i < source.ElementRequirements.Count; ++i)
            {
                if (source.ElementRequirements[i].SystemmID == model.ID)
                {
                    bool flag = true;
                    for (int j = 0; j < model.ElementRequirements.Count; ++j)
                    {
                        if (source.ElementRequirements[i].ID == model.ElementRequirements[j].ID)
                        {
                            source.ElementRequirements[i].Count = model.ElementRequirements[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        source.ElementRequirements.RemoveAt(i--);
                    }
                }
            }
            for (int i = 0; i < model.ElementRequirements.Count; ++i)
            {
                if (model.ElementRequirements[i].ID == 0)
                {
                    for (int j = 0; j < source.ElementRequirements.Count; ++j)
                    {
                        if (source.ElementRequirements[j].SystemmID == model.ID &&
                            source.ElementRequirements[j].ElementID == model.ElementRequirements[i].ElementID)
                        {
                            source.ElementRequirements[j].Count += model.ElementRequirements[i].Count;
                            model.ElementRequirements[i].ID = source.ElementRequirements[j].ID;
                            break;
                        }
                    }
                    if (model.ElementRequirements[i].ID == 0)
                    {
                        source.ElementRequirements.Add(new ElementRequirement
                        {
                            ID = ++maxPCId,
                            SystemmID = model.ID,
                            ElementID = model.ElementRequirements[i].ElementID,
                            Count = model.ElementRequirements[i].Count
                        });
                    }
                }
            }
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.ElementRequirements.Count; ++i)
            {
                if (source.ElementRequirements[i].SystemmID == id)
                {
                    source.ElementRequirements.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Systemms.Count; ++i)
            {
                if (source.Systemms[i].ID == id)
                {
                    source.Systemms.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}