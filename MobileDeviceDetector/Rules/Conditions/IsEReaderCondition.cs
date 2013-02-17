namespace Sitecore.SharedSource.MobileDeviceDetector.Rules.Conditions
{
  using Sitecore.Rules;

  /// <summary>
  /// IsMobileCondition
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class IsEReaderCondition<T> : BooleanPropertyCondition<T> where T : RuleContext
  {
    public IsEReaderCondition()
    {
      this.Value = "IsEReader";
    }
  }
}
