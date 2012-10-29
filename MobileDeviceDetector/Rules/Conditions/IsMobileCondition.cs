namespace Sitecore.SharedSource.MobileDeviceDetector.Rules.Conditions
{
  using System.Web;
  using Sitecore.Diagnostics;
  using Sitecore.Rules;
  using Sitecore.Rules.Conditions;

  /// <summary>
  /// IsMobileCondition
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class IsMobileCondition<T> : WhenCondition<T> where T : RuleContext
  {
    /// <summary>
    /// Executes the specified rule context.
    /// </summary>
    /// <param name="ruleContext">The rule context.</param>
    /// <returns>
    /// Returns value indicating whether Device is Mobile or not
    /// </returns>
    protected override bool Execute(T ruleContext)
    {
      Assert.ArgumentNotNull(ruleContext, "ruleContext");

      var result = HttpContext.Current.Request.Browser.IsMobileDevice;
      return result;
    }
  }
}
