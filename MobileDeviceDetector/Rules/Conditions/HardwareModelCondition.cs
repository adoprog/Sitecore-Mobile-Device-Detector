namespace Sitecore.SharedSource.MobileDeviceDetector.Rules.Conditions
{
  using Sitecore.Rules;

  /// <summary>
  /// UserAgentCondition
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class HardwareModelCondition<T> : StringPropertyCondition<T> where T : RuleContext
  {
    public HardwareModelCondition()
    {
      this.Property = "HardwareModel";
    }
  }
}
