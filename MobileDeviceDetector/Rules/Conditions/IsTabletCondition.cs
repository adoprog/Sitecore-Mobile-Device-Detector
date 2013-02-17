namespace Sitecore.SharedSource.MobileDeviceDetector.Rules.Conditions
{
  using Sitecore.Rules;

  /// <summary>
  /// IsTabletCondition
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class IsTabletCondition<T> : BooleanPropertyCondition<T> where T : RuleContext
  {
    public IsTabletCondition()
    {
      this.Value = "IsTablet";
    }
  }
}
