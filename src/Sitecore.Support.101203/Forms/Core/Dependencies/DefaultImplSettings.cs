using Sitecore;
using Sitecore.Configuration;
using Sitecore.Form.Core.Configuration;
using Sitecore.WFFM.Abstractions.Shared;
using System;
using System.Configuration;

namespace Sitecore.Support.Forms.Core.Dependencies
{
    public class DefaultImplSettings : ISettings
    {
        public string GetConnectionString(string connectionName) =>
            System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

        public string EmailFromAddress =>
            Configuration.Settings.GetSetting(ConfigKey.EmailFromAddress);

        public bool InsertIdToAnalytics =>
            Configuration.Settings.GetBoolSetting(ConfigKey.InsertIdToAnalytics, false);

        public bool IsPageEditorEditing =>
            Context.PageMode.IsPageEditorEditing;

        public bool IsPreview =>
            Context.PageMode.IsPreview;

        public bool IsXdbEnabled =>
            Configuration.Settings.GetBoolSetting(ConfigKey.XdbEnabled, true);

        public bool IsXdbTrackerEnabled =>
            Configuration.Settings.GetBoolSetting(ConfigKey.XdbTrackerEnabled, true);

        public string MailServer =>
            Configuration.Settings.GetSetting(ConfigKey.MailServer);

        public string MailServerPassword =>
            Configuration.Settings.GetSetting(ConfigKey.MailServerPassword);

        public string MailServerPort =>
            Configuration.Settings.GetSetting(ConfigKey.MailServerPort);

        public string MailServerUserName =>
            Configuration.Settings.GetSetting(ConfigKey.MailServerUserName);
    }
}