using System;
using System.Linq;
using FiftyOne.Foundation.Mobile.Detection;
using Sitecore.Configuration;

namespace Sitecore.SharedSource.MobileDeviceDetector
{
    using System.Web;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;
    using Sitecore.Rules;
    using Sitecore.SecurityModel;
    using Sitecore.Web;

    /// <summary>
    /// DeviceResolver helper class
    /// </summary>
    public class DeviceResolverHelper
    {
        /// <summary>
        /// Name of the cookie which is used to store device name.
        /// </summary>
        private const string DeviceCookieName = "sc_device";

        /// <summary>
        /// Name of the query string parameter that specifies that device should be switched permanently.
        /// </summary>
        private const string PersistedDeviceParameter = "persisted";

        /// <summary>
        /// Resolves the device.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>Resolved device</returns>
        public static DeviceItem ResolveDevice(Database database)
        {
            if (!Settings.GetBoolSetting("Sitecore.SharedSource.MobileDeviceDetector.Enabled", false))
            {
                return null;
            }

            using (new SecurityDisabler())
            {
                var resolvedDevice = GetQueryStringDevice(database);
                if (resolvedDevice != null)
                    return resolvedDevice;

                resolvedDevice = GetCookieDevice(database);
                if (resolvedDevice != null)
                    return resolvedDevice;

                resolvedDevice = GetRulesDevice(database);
                if (resolvedDevice != null)
                    return resolvedDevice;

                return null;
            }
        }

        /// <summary>
        /// Gets the query string device.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>Resolved device</returns>
        private static DeviceItem GetQueryStringDevice(Database database)
        {
            string queryString = WebUtil.GetQueryString("sc_device");
            if (String.IsNullOrEmpty(queryString))
            {
                return null;
            }
            DeviceItem item = database.Resources.Devices[queryString];
            Error.AssertNotNull(item, "Could not retrieve device: " + queryString + " (database: " + database.Name + ")");

            if (item != null && MainUtil.GetBool(WebUtil.GetQueryString(PersistedDeviceParameter), false))
            {
                HttpContext.Current.Response.Cookies.Add(new HttpCookie(DeviceCookieName, item.Name));
            }

            return item;
        }

        /// <summary>
        /// Gets the cookie device.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>Resolved device</returns>
        private static DeviceItem GetCookieDevice(Database database)
        {
            var deviceCookie = HttpContext.Current.Request.Cookies[DeviceCookieName];
            if (deviceCookie != null && !String.IsNullOrEmpty(deviceCookie.Value))
            {
                DeviceItem item = database.Resources.Devices[deviceCookie.Value];
                return item;
            }

            return null;
        }

        /// <summary>
        /// Gets the rules device.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>Resolved device</returns>
        private static DeviceItem GetRulesDevice(Database database)
        {
            DeviceItem[] all = database.Resources.Devices.GetAll();

            foreach (var device in all)
            {
                var ruleContext = new RuleContext();

                foreach (Rule<RuleContext> rule in RuleFactory.GetRules<RuleContext>(new[]
        {
          device.InnerItem }, "Conditions").Rules)
                {
                    if (rule.Condition != null)
                    {
                        var stack = new RuleStack();
                        rule.Condition.Evaluate(ruleContext, stack);
                        if (ruleContext.IsAborted)
                        {
                            continue;
                        }
                        if ((stack.Count != 0) && ((bool)stack.Pop()))
                        {
                            return device;
                        }
                    }
                }
            }

            return null;
        }

        public static bool GetBoolProperty(string propertyName)
        {
            var provider = FiftyOne.Foundation.Mobile.Detection.WebProvider.ActiveProvider;
            if (string.IsNullOrEmpty(HttpContext.Current.Request.UserAgent))
            {
                return false;
            }

            var device = provider.Match(HttpContext.Current.Request.UserAgent);

            try
            {
                return MainUtil.GetBool(device.Results[propertyName].First(), false);
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static string GetStringProperty(string propertyName)
        {
            var provider = WebProvider.ActiveProvider;
            if (string.IsNullOrEmpty(HttpContext.Current.Request.UserAgent))
            {
                return string.Empty;
            }

            var match = provider.Match(HttpContext.Current.Request.UserAgent);

            try
            {
                return match.Results[propertyName].First();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }
    }
}