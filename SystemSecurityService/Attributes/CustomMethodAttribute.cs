using System;

namespace SystemSecurityService.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomMethodAttribute : Attribute
    {
        public string Description { get; private set; }
        public CustomMethodAttribute(string description)
        {
            Description = string.Format("Описание метода: ", description);
        }
    }
}