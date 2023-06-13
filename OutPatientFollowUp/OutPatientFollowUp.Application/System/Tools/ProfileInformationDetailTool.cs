using System;
using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;
/// <summary>
/// 档案信息详情工具类
/// </summary>
public static class ProfileInformationDetailTool
{

    /// <summary>
    /// 获取人群分类
    /// </summary>
    /// <param name="idCardNumber"></param>
    /// <returns></returns>
    public static PopulationCategoryEnum GetPopulationCategory(string idCardNumber)
    {
        ValidateTool.ValidateIdCardNumber(idCardNumber);
        var age = GetAgeFromIdCard(idCardNumber);
        return age < 15 ? PopulationCategoryEnum.AT05 :
         age < 65 ? PopulationCategoryEnum.AT03 :
         age < 80 ? PopulationCategoryEnum.AT02 :
         PopulationCategoryEnum.AT01;
    }

    /// <summary>
    /// 根据身份证号获取生日
    /// </summary>
    /// <param name="idCardNumber">身份证号</param>
    /// <returns></returns>
    private static DateTime GetBirthdayFromIdCard(string idCardNumber)
    {
        ValidateTool.ValidateIdCardNumber(idCardNumber);
        var year = Convert.ToInt32(idCardNumber.Substring(6, 4));
        var month = Convert.ToInt32(idCardNumber.Substring(10, 2));
        var day = Convert.ToInt32(idCardNumber.Substring(12, 2));
        return new DateTime(year, month, day);
    }

    /// <summary>
    /// 根据身份证号码获取年龄
    /// </summary>
    /// <param name="idCardNumber">身份证号码</param>
    /// <returns></returns>
    public static int GetAgeFromIdCard(string idCardNumber)
    {
        ValidateTool.ValidateIdCardNumber(idCardNumber);
        var birthday = GetBirthdayFromIdCard(idCardNumber);
        var today = DateTime.Today;
        var age = today.Year - birthday.Year;
        if (birthday > today.AddYears(-age))
        {
            age--;
        }
        return age;
    }


}