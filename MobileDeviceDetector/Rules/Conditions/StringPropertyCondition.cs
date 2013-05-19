namespace Sitecore.SharedSource.MobileDeviceDetector.Rules.Conditions
{
  using Sitecore.Diagnostics;
  using Sitecore.Rules;
  using Sitecore.Rules.Conditions;

  /// <summary>
  /// StringPropertyCondition
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class StringPropertyCondition<T> : StringOperatorCondition<T> where T : RuleContext
  {
    /// <summary>
    /// Gets or sets the property.
    /// </summary>
    /// <value>The property.</value>
    public string Property { get; set; }
    
    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>The value.</value>
    public string Value { get; set; }

    /// <summary>
    /// Executes the specified rule context.
    /// </summary>
    /// <param name="ruleContext">The rule context.</param>
    /// <returns>Returns value indicating whether specified Device property matches Value or not</returns>
    protected override bool Execute(T ruleContext)
    {
      Assert.ArgumentNotNull(ruleContext, "ruleContext");
      string str = this.Value ?? string.Empty;
      var propertyValue = DeviceResolverHelper.GetStringProperty(this.Property);

      if (!string.IsNullOrEmpty(propertyValue))
      {
        return Compare(propertyValue, str);
      }

      return false;
    }
  }
}
