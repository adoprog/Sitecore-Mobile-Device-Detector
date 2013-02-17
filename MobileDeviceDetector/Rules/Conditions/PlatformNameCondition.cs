namespace Sitecore.SharedSource.MobileDeviceDetector.Rules.Conditions
{
  using Sitecore.Rules;

  /// <summary>
  /// UserAgentCondition
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class PlatformNameCondition<T> : StringPropertyCondition<T> where T : RuleContext
  {
    public PlatformNameCondition()
    {
      this.Property = "PlatformName";
    }
  }
}
