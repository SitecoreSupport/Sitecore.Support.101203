using Sitecore.Diagnostics;
using Sitecore.WFFM.Abstractions;
using Sitecore.WFFM.Abstractions.Shared;
using System;
using System.Reflection;

namespace Sitecore.Support.Forms.Core.Dependencies
{
    public class DefaultImplRequirementsChecker : IRequirementsChecker
    {
        private readonly ISettings settings;

        public DefaultImplRequirementsChecker(ISettings settings)
        {
            Assert.ArgumentNotNull(settings, "settings");
            this.settings = settings;
        }

        public bool CheckRequirements(Attribute[] attributes)
        {
            Assert.ArgumentNotNull(attributes, "attributes");
            foreach (Attribute attribute in attributes)
            {
                RequiredAttribute attribute2 = attribute as RequiredAttribute;
                if (attribute2 != null)
                {
                    PropertyInfo property = this.settings.GetType().GetProperty(attribute2.PropertyName);
                    if (property == null)
                    {
                        throw new Exception("There is not required property " + attribute2.PropertyName);
                    }
                    if (property.PropertyType != typeof(bool))
                    {
                        throw new Exception("Required property is not bool type");
                    }
                    bool flag = (bool)property.GetValue(this.settings);
                    if (flag != attribute2.PropertyValue)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckRequirements(Type objType)
        {
            Assert.ArgumentNotNull(objType, "objType");
            Attribute[] customAttributes = Attribute.GetCustomAttributes(objType, typeof(RequiredAttribute));
            return this.CheckRequirements(customAttributes);
        }
    }
}