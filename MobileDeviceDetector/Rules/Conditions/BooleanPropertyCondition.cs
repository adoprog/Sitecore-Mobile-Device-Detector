namespace Sitecore.SharedSource.MobileDeviceDetector.Rules.Conditions
{
  using Sitecore.Diagnostics;
  using Sitecore.Rules;
  using Sitecore.Rules.Conditions;

  public class BooleanPropertyCondition <T> : WhenCondition<T> where T : RuleContext
  {
    public string Value { get; set; }         

    /// <summary>
    /// Executes the specified rule context.
    /// </summary>
    /// <param name="ruleContext">The rule context.</param>
    /// <returns>
    /// Returns value indicating whether the specified property is true or not
    /// </returns>
    protected override bool Execute(T ruleContext)
    {
      Assert.ArgumentNotNull(ruleContext, "ruleContext");
      return DeviceResolverHelper.GetBoolProperty(this.Value);
    }
  }
}
