using SystemSecurityModel;
using SystemSecurityService.BindingModels;
using SystemSecurityService.Interfaces;
using SystemSecurityService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SystemSecurityService.BDImplementation
{
    public class ElementBD : IElement
    {
        private SystemSecurityDBContext context;

        public ElementBD(SystemSecurityDBContext context)
        {
            this.context = context;
        }

        public ElementBD()
        {
            this.context = new SystemSecurityDBContext();
        }

        public List<ElementViewModel> GetList()
        {
            List<ElementViewModel> result = context.Elements
                .Select(rec => new ElementViewModel
                {
                    ID = rec.ID,
                    ElementName = rec.ElementName
                })
                .ToList();
            return result;
        }

        public ElementViewModel GetElement(int id)
        {
            Element element = context.Elements.FirstOrDefault(rec => rec.ID == id);
            if (element != null)
            {
                return new ElementViewModel
                {
                    ID = element.ID,
                    ElementName = element.ElementName
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(ElementBindModel model)
        {
            Element element = context.Elements.FirstOrDefault(rec => rec.ElementName == model.ElementName);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            context.Elements.Add(new Element
            {
                ElementName = model.ElementName
            });
            context.SaveChanges();
        }

        public void UpdElement(ElementBindModel model)
        {
            Element element = context.Elements.FirstOrDefault(rec =>
                                        rec.ElementName == model.ElementName && rec.ID != model.ID);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            element = context.Elements.FirstOrDefault(rec => rec.ID == model.ID);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ElementName = model.ElementName;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Element element = context.Elements.FirstOrDefault(rec => rec.ID == id);
            if (element != null)
            {
                context.Elements.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
