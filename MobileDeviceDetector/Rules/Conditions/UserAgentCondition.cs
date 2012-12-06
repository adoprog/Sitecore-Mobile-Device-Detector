namespace Sitecore.SharedSource.MobileDeviceDetector.Rules.Conditions
{
  using System;
  using System.Web;
  using Sitecore.Diagnostics;
  using Sitecore.Rules;
  using Sitecore.Rules.Conditions;

  /// <summary>
  /// UserAgentCondition
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class UserAgentCondition<T> : StringOperatorCondition<T> where T : RuleContext
  {
    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>The value.</value>
    public string Value { get; set; }

    /// <summary>
    /// Executes the specified rule context.
    /// </summary>
    /// <param name="ruleContext">The rule context.</param>
    /// <returns>Returns value indicating whether Device UserAgent matches Value or not</returns>
    protected override bool Execute(T ruleContext)
    {
      Assert.ArgumentNotNull(ruleContext, "ruleContext");
      string str = this.Value ?? string.Empty;
      var userAgent = HttpContext.Current.Request.UserAgent;
      if (!string.IsNullOrEmpty(userAgent))
      {
        return Compare(str, userAgent);
      }

      return false;
    }
  }
}
