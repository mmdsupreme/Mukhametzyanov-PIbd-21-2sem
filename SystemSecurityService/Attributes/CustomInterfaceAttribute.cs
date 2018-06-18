using System;

namespace SystemSecurityService.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class CustomInterfaceAttribute : Attribute
    {
        public string Description { get; private set; }
        public CustomInterfaceAttribute(string description)
        {
            Description = string.Format("Описание интерфейса: ", description);
        }
    }
}