namespace Sitecore.SharedSource.MobileDeviceDetector.Rules.Conditions
{
  using Sitecore.Rules;

  /// <summary>
  /// UserAgentCondition
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class BrowserNameCondition<T> : StringPropertyCondition<T> where T : RuleContext
  {
    public BrowserNameCondition()
    {
      this.Property = "BrowserName";
    }
  }
}
