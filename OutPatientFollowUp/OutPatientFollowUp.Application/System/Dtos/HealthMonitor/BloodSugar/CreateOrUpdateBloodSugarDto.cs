using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application.HealthMonitor;

public class CreateOrUpdateBloodSugarDto : IValidatableObject
{
    /// <summary>
    /// 设备号  平板id
    /// </summary>
    /// <value></value>
    public string MacID { get; set; }

    /// <summary>
    /// 血糖值
    /// </summary>
    /// <value></value>
    public int BloodSugarValue { get; set; }

    /// <summary>
    /// 血糖类型
    /// </summary>
    /// <value></value>
    public BloodSugarTypeEnum BloodSugarType { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        return Enumerable.Empty<ValidationResult>();
    }
}




