using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OutPatientFollowUp.Application;

/// <summary>
/// 基础档案信息
/// </summary>
public class BasicProfileInformationDto :  IValidatableObject
{
    /// <summary>
    /// 建档号
    /// </summary>
    /// <value></value>
    public string ArchivesCode  { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    /// <value></value>
    public string Name { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    /// <value></value>
    public string Gender { get; set; }

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
    /// 省份Code
    /// </summary>
    /// <value></value>
    public string ProvinceCode { get; set; }

    /// <summary>
    /// 市
    /// </summary>
    /// <value></value>
    public string City { get; set; }

    /// <summary>
    /// 市Code
    /// </summary>
    /// <value></value>
    public string CityCode { get; set; }

    /// <summary>
    /// 区
    /// </summary>
    /// <value></value>
    public string District { get; set; }

    /// <summary>
    /// 区Code
    /// </summary>
    /// <value></value>
    public string DistrictCode { get; set; }

    /// <summary>
    /// 地址行/详细住址
    /// </summary>
    /// <value></value>
    public string AddressLine { get; set; }

    /// <summary>
    /// 现住址
    /// </summary>
    /// <remarks>拼接省市区后的住址</remarks>
    /// <value></value>
    public string CurrentAddress { get; set; }

    /// <summary>
    /// 是否正在服用降压药
    /// </summary>
    /// <value></value>
    public string IsTakingAntihypertensiveMeds { get; set; }

    /// <summary>
    /// 是否正在服用降糖药
    /// </summary>
    /// <value></value>
    public string IsTakingAntidiabeticMeds { get; set; }

    // /// <summary>
    // /// 患者Id
    // /// </summary>
    // /// <value></value>
    // /// <remarks>用于关联患者</remarks>
    // public string UserId { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!Regex.IsMatch(IDCardNumber, @"^\d{17}(\d|X)$"))
        {
            yield return new ValidationResult("身份证号格式不正确", new[] { nameof(IDCardNumber) });
        }
    }
}
