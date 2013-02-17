namespace Sitecore.SharedSource.MobileDeviceDetector.Rules.Conditions
{
  using Sitecore.Rules;

  /// <summary>
  /// UserAgentCondition
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class HardwareVendorCondition<T> : StringPropertyCondition<T> where T : RuleContext
  {
    public HardwareVendorCondition()
    {
      this.Property = "HardwareVendor";
    }
  }
}
