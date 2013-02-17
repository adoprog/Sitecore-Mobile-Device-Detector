namespace Sitecore.SharedSource.MobileDeviceDetector.Rules.Conditions
{
  using Sitecore.Rules;

  /// <summary>
  /// IsMobileCondition
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class IsConsoleCondition<T> : BooleanPropertyCondition<T> where T : RuleContext
  {
    public IsConsoleCondition()
    {
      this.Value = "IsConsole";
    }
  }
}
