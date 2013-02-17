namespace Sitecore.SharedSource.MobileDeviceDetector.Rules.Conditions
{
  using Sitecore.Rules;

  /// <summary>
  /// UserAgentCondition
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class PlatformVendorCondition<T> : StringPropertyCondition<T> where T : RuleContext
  {
    public PlatformVendorCondition()
    {
      this.Property = "PlatformVendor";
    }
  }
}
