using Sitecore.Configuration;
using Sitecore.Form.Core.Configuration;
using Sitecore.WFFM.Abstractions.Shared;
using System;
using System.Configuration;

namespace Sitecore.Support.Forms.Core.Dependencies
{
    [Serializable]
    public class DefaultImplSettings : ISettings
    {
        public bool IsXdbEnabled
        {
            get
            {
                return Sitecore.Configuration.Settings.GetBoolSetting(ConfigKey.XdbEnabled, true);
            }
        }

        public bool IsXdbTrackerEnabled
        {
            get
            {
                return Sitecore.Configuration.Settings.GetBoolSetting(ConfigKey.XdbTrackerEnabled, true);
            }
        }

        public bool InsertIdToAnalytics
        {
            get
            {
                return Sitecore.Configuration.Settings.GetBoolSetting(ConfigKey.InsertIdToAnalytics, false);
            }
        }

        public bool IsPreview
        {
            get
            {
                return Context.PageMode.IsPreview;
            }
        }

        public bool IsPageEditorEditing
        {
            get
            {
                return Context.PageMode.IsPageEditorEditing;
            }
        }

        public string EmailFromAddress
        {
            get
            {
                return Sitecore.Configuration.Settings.GetSetting(ConfigKey.EmailFromAddress);
            }
        }

        public string MailServer
        {
            get
            {
                return Sitecore.Configuration.Settings.GetSetting(ConfigKey.MailServer);
            }
        }

        public string MailServerUserName
        {
            get
            {
                return Sitecore.Configuration.Settings.GetSetting(ConfigKey.MailServerUserName);
            }
        }

        public string MailServerPassword
        {
            get
            {
                return Sitecore.Configuration.Settings.GetSetting(ConfigKey.MailServerPassword);
            }
        }

        public string MailServerPort
        {
            get
            {
                return Sitecore.Configuration.Settings.GetSetting(ConfigKey.MailServerPort);
            }
        }

        public string GetConnectionString(string connectionName)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
    }
}
