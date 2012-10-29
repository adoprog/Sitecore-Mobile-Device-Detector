namespace Sitecore.SharedSource.MobileDeviceDetector
{
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Diagnostics;
  using Sitecore.Pipelines.HttpRequest;
  using Sitecore.Sites;

  /// <summary>
  /// DeviceResolver class
  /// </summary>
  public class DeviceResolver : HttpRequestProcessor
  {
    /// <summary>
    /// Processes the specified args.
    /// </summary>
    /// <param name="args">The request args.</param>
    public override void Process(HttpRequestArgs args)
    {
      Assert.ArgumentNotNull(args, "args");
      if (Context.Device == null)
      {
        using (new ProfileSection("Resolve device."))
        {
          Database database = Context.Database;
          SiteContext site = Context.Site;
          string str = (site != null) ? site.Name : string.Empty;
          if (database == null)
          {
            Tracer.Warning("No database in device resolver.", "Site is \"" + str + "\".");
          }
          else
          {
            var item = DeviceResolverHelper.ResolveDevice(database) ?? DeviceItem.ResolveDevice(database);
            if (item == null)
            {
              Tracer.Warning("No device found for site \"" + str + "\".");
            }
            else
            {
              Context.Device = item;
              Tracer.Info("Device set to \"" + item.Name + "\".");
            }
          }
        }
      }
    }
  }
}