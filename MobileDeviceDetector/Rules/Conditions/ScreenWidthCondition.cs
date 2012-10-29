namespace Sitecore.SharedSource.MobileDeviceDetector.Rules.Conditions
{
  using System.Web;
  using Sitecore.Diagnostics;
  using Sitecore.Rules;
  using Sitecore.Rules.Conditions;

  /// <summary>
  /// ScreenWidthCondition
  /// </summary>
  /// <typeparam name="T"></typeparam>
  internal class ScreenWidthCondition<T> : IntegerComparisonCondition<T> where T : RuleContext
  {
    /// <summary>
    /// Executes the specified rule context.
    /// </summary>
    /// <param name="ruleContext">The rule context.</param>
    /// <returns>Returns value indicating whether Device Screen Height matches Value or not</returns>
    protected override bool Execute(T ruleContext)
    {
      Assert.ArgumentNotNull(ruleContext, "ruleContext");
      int width = HttpContext.Current.Request.Browser.ScreenPixelsWidth;
      return Compare(MainUtil.GetInt(width, 1024));
    }
  }
}
