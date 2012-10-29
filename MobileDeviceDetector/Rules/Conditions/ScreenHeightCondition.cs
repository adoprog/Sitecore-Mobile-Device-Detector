namespace Sitecore.SharedSource.MobileDeviceDetector.Rules.Conditions
{
  using System.Web;
  using Sitecore.Diagnostics;
  using Sitecore.Rules;
  using Sitecore.Rules.Conditions;

  /// <summary>
  /// ScreenHeightCondition
  /// </summary>
  /// <typeparam name="T"></typeparam>
  internal class ScreenHeightCondition<T> : IntegerComparisonCondition<T> where T : RuleContext
  {
    /// <summary>
    /// Executes the specified rule context.
    /// </summary>
    /// <param name="ruleContext">The rule context.</param>
    /// <returns>Returns value indicating whether Device Screen Height matches Value or not</returns>
    protected override bool Execute(T ruleContext)
    {
      Assert.ArgumentNotNull(ruleContext, "ruleContext");
      int height = HttpContext.Current.Request.Browser.ScreenPixelsHeight;
      return Compare(MainUtil.GetInt(height, 1024));
    }

  }
}
