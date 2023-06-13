using System;
using System.Text.RegularExpressions;

namespace OutPatientFollowUp.Application;
/// <summary>
/// 
/// </summary>
public static class ValidateTool
{
    /// <summary>
    /// 交验身份证号格式
    /// </summary>
    /// <param name="idCardNumber"></param>
    public static IEnumerable<ValidationResult> ValidateIdCardNumber(string idCardNumber)
    {
        // 18-digit ID card number format: 6 digits for the birth date (YYYYMMDD) + 4 digits for the birthplace + 3 digits for the sequence number + 1 digit for the checksum
        string pattern = @"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$";
        if (!Regex.IsMatch(idCardNumber, pattern))
        {
            yield return new ValidationResult("身份证号格式错误");
        }
    }

    public static IEnumerable<ValidationResult> ValidatePhoneNumber(string phoneNumber)
    {
        // 18-digit ID card number format: 6 digits for the birth date (YYYYMMDD) + 4 digits for the birthplace + 3 digits for the sequence number + 1 digit for the checksum
        if (!Regex.IsMatch(phoneNumber, @"^1[3456789]\d{9}$"))
        {
            yield return new ValidationResult("手机号格式不正确", new[] { nameof(phoneNumber) });
        }
    }
}