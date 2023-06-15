
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
    /// 省份
    /// </summary>
    /// <value></value>
    public string Province { get; set; }

    /// <summary>
    /// 市
    /// </summary>
    /// <value></value>
    public string City { get; set; }

    /// <summary>
    /// 区
    /// </summary>
    /// <value></value>
    public string District { get; set; }

    /// <summary>
    /// 地址行/详细住址
    /// </summary>
    /// <value></value>
    public string AddressLine { get; set; }

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

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!string.IsNullOrEmpty(IDCardNumber) &&!Regex.IsMatch(IDCardNumber, @"^\d{17}(\d|X)$"))
        {
            yield return new ValidationResult("身份证号格式不正确", new[] { nameof(IDCardNumber) });
        }
        if (!string.IsNullOrEmpty(PhoneNumber) && !Regex.IsMatch(PhoneNumber, @"^1[3456789]\d{9}$"))
        {
            yield return new ValidationResult("手机号格式不正确", new[] { nameof(PhoneNumber) });
        }
    }
}