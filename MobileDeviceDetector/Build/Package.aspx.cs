namespace Sitecore.SharedSource.MobileDeviceDetector.Build
{
  using System;

  using Sitecore.Install;
  using Sitecore.Install.Framework;
  using Sitecore.SecurityModel;

  public partial class Package : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      using (new SecurityDisabler())
      {
        Sitecore.Context.SetActiveSite("shell");
        PackageGenerator.GeneratePackage(
          Sitecore.Configuration.Settings.DataFolder + "/packages/Mobile Device Detector.xml",
          Sitecore.Configuration.Settings.DataFolder + "/packages/Mobile Device Detector.zip",
          new SimpleProcessingContext());
      }
    }
  }
}