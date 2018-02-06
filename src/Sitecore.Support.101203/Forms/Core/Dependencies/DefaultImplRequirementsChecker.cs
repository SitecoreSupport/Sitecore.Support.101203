using Sitecore.Diagnostics;
using Sitecore.WFFM.Abstractions;
using Sitecore.WFFM.Abstractions.Shared;
using System;
using System.Reflection;

namespace Sitecore.Support.Forms.Core.Dependencies
{
    [Serializable]
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
            bool result;
            int num;
            for (int i = 0; i < attributes.Length; i = num + 1)
            {
                Attribute attribute = attributes[i];
                RequiredAttribute requiredAttribute = attribute as RequiredAttribute;
                bool flag = requiredAttribute != null;
                if (flag)
                {
                    PropertyInfo property = this.settings.GetType().GetProperty(requiredAttribute.PropertyName);
                    bool flag2 = property == null;
                    if (flag2)
                    {
                        throw new Exception("There is not required property " + requiredAttribute.PropertyName);
                    }
                    bool flag3 = property.PropertyType != typeof(bool);
                    if (flag3)
                    {
                        throw new Exception("Required property is not bool type");
                    }
                    bool flag4 = (bool)property.GetValue(this.settings);
                    bool flag5 = flag4 != requiredAttribute.PropertyValue;
                    if (flag5)
                    {
                        result = false;
                        return result;
                    }
                }
                num = i;
            }
            result = true;
            return result;
        }

        public bool CheckRequirements(Type objType)
        {
            Assert.ArgumentNotNull(objType, "objType");
            Attribute[] customAttributes = Attribute.GetCustomAttributes(objType, typeof(RequiredAttribute));
            return this.CheckRequirements(customAttributes);
        }
    }
}
