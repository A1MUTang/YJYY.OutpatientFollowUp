
namespace OutPatientFollowUp;

public class CreateOrUpdateBloodPressure : IValidatableObject
{
    /// <summary>
    /// 设备号
    /// </summary>
    /// <value></value>
    public string MacID { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        throw new NotImplementedException();
    }
}