
using System.Text.RegularExpressions;

namespace OutPatientFollowUp.Application;

public class CompleteUpdateBasicProfileInformationDto : IValidatableObject
{
    /// <summary>
    /// 姓名
    /// </summary>
    /// <value></value>
    public string Name { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    /// <value></value>
    public bool Gender { get; set; }

    /// <summary>
    /// 身份证号
    /// </summary>
    /// <value></value>
    public string IDCardNumber { get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    /// <value></value>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// 地址 (身份证上的地址)
    /// </summary>
    /// <value></value>
    public string Address { get; set; }

    /// <summary>
    /// 现住址
    /// </summary>
    /// <value></value>
    public string CurrentAddress { get; set; }

    /// <summary>
    /// 是否正在服用降压药
    /// </summary>
    /// <value></value>
    public bool IsTakingAntihypertensiveMeds { get; set; }

    /// <summary>
    /// 是否正在服用降糖药
    /// </summary>
    /// <value></value>
    public bool IsTakingAntidiabeticMeds { get; set; }

    /// <summary>
    /// 患者Id
    /// </summary>
    /// <value></value>
    /// <remarks>用于关联患者</remarks>
    public string UserId { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!Regex.IsMatch(IDCardNumber, @"^\d{17}(\d|X)$"))
        {
            yield return new ValidationResult("身份证号格式不正确", new[] { nameof(IDCardNumber) });
        }
        if (!Regex.IsMatch(PhoneNumber, @"^1[3456789]\d{9}$"))
        {
            yield return new ValidationResult("手机号格式不正确", new[] { nameof(PhoneNumber) });
        }
    }
}