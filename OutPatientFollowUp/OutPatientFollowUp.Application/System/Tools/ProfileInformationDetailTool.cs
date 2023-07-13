using System;
using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;
/// <summary>
/// 档案信息详情工具类
/// </summary>
public static class ProfileInformationDetailTool
{
    /// <summary>
    /// 计算BMI
    /// </summary>
    /// <param name="height">身高（单位：米）</param>
    /// <param name="weight">体重（单位：千克）</param>
    /// <returns>BMI 值</returns>
    public static decimal? CalculateBMI(decimal? height, decimal? weight)
    {
        if (height == null || weight == null || height <= 0 || weight <= 0)
        {
            return null;
        }

        return weight / (height * height);
    }
    /// <summary>
    /// 计算腰臀比
    /// </summary>
    /// <param name="waist">腰围</param>
    /// <param name="hip">臀围</param>
    /// <returns></returns>
    public static double CalculateWHR(double waist, double hip)
    {
        if (waist <= 0 || hip <= 0)
        {
            return 0;
        }

        return waist / hip;
    }

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
    public static DateTime GetBirthdayFromIdCard(string idCardNumber)
    {
        ValidateTool.ValidateIdCardNumber(idCardNumber);
        // 身份证号码会出现18位和15位的情况
        if (idCardNumber.Length == 15)
        {
            var year = Convert.ToInt32(idCardNumber.Substring(6, 2));
            var month = Convert.ToInt32(idCardNumber.Substring(8, 2));
            var day = Convert.ToInt32(idCardNumber.Substring(10, 2));
            // 15 位身份证号的年份需要加上 1900
            year += 1900;
            return new DateTime(year, month, day);
        }
        else
        {
            var year = Convert.ToInt32(idCardNumber.Substring(6, 4));
            var month = Convert.ToInt32(idCardNumber.Substring(10, 2));
            var day = Convert.ToInt32(idCardNumber.Substring(12, 2));
            return new DateTime(year, month, day);
        }
    }

    /// <summary>
    /// 根据身份证号码获取年龄
    /// </summary>
    /// <param name="idCardNumber">身份证号码</param>
    /// <returns></returns>
    public static int GetAgeFromIdCard(string idCardNumber)
    {
        ValidateTool.ValidateIdCardNumber(idCardNumber);
        // 身份证号码会出现18位和15位的情况
        var birthday = GetBirthdayFromIdCard(idCardNumber);
        var today = DateTime.Today;
        var ageTimeSpan = today - birthday;
        var age = Convert.ToInt32(ageTimeSpan.TotalDays / 365.25);
        return age;
    }


}