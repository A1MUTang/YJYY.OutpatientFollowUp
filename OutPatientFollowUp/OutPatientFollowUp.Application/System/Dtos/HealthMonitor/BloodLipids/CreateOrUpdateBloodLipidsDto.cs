namespace OutPatientFollowUp.Application.HealthMonitor;

public class CreateOrUpdateBloodLipidsDto : IValidatableObject
{
    /// <summary>
    /// 设备号
    /// </summary>
    /// <value></value>
    public string MacID { get; set; }
    /// <summary>
    /// 总胆固醇
    /// </summary>
    /// <remarks>单位：mmol/L</remarks>
    /// <value></value>
    public decimal TotalCholesterol { get; set; }

    /// <summary>
    /// 甘油三酯
    /// </summary>
    /// <remarks>单位：mmol/L</remarks>
    /// <value></value>
    public decimal Triglycerides { get; set; }

    /// <summary>
    /// 高密度脂蛋白胆固醇
    /// </summary>
    /// <remarks>单位：mmol/L</remarks>
    /// <value></value>
    public decimal HDLCholesterol { get; set; }

    /// <summary>
    /// 低密度脂蛋白胆固醇
    /// </summary>
    /// <remarks>单位：mmol/L</remarks>
    /// <value></value>
    public decimal LDLCholesterol { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (TotalCholesterol < 0)
        {
            yield return new ValidationResult("总胆固醇必须大于0");
        }
        if (Triglycerides < 0)
        {
            yield return new ValidationResult("甘油三酯必须大于0");
        }
        if (HDLCholesterol < 0)
        {
            yield return new ValidationResult("高密度脂蛋白胆固醇必须大于0");
        }
        if (LDLCholesterol < 0)
        {
            yield return new ValidationResult("低密度脂蛋白胆固醇必须大于0");
        }
    }
}
