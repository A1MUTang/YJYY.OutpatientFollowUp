using OutPatientFollowUp.Core;
using System.ComponentModel;
using System.Reflection;

namespace OutPatientFollowUp.Application;

/// <summary>
/// 血脂结果帮助类
/// </summary>
public static class BloodLipidsTool
{

    /// <summary>
    /// 获取血脂结果
    /// </summary>
    /// <param name="TotalCholesterol">总胆固醇</param>
    /// <param name="LDLCholesterol">低密度脂蛋白胆固醇</param>
    /// <param name="HDLCholesterol">高密度脂蛋白胆固醇</param>
    /// <param name="Triglyceride">甘油三酯</param>
    /// <returns></returns>
    public static BloodLipidsResultEnum GetBloodLipidsResultCode(decimal TotalCholesterol, decimal LDLCholesterol, decimal HDLCholesterol, decimal Triglyceride)
    {
        decimal nonHDLCholesterol = TotalCholesterol - HDLCholesterol;

        //TC、LDL-C、非HDL-C、TG四项，同时属于“理想水平”。
        if (TotalCholesterol < 5.2m && LDLCholesterol < 2.6m && HDLCholesterol > 1.0m && nonHDLCholesterol < 3.4m && Triglyceride < 1.7m)
        {
            // 总胆固醇 < 5.2，低密度脂蛋白胆固醇 < 3.4，高密度脂蛋白胆固醇 > 1.0，非高密度脂蛋白胆固醇 < 1.7，甘油三酯 < 1.5
            return BloodLipidsResultEnum.Ideal;
        }
        //条件：TC、LDL-C、非HDL-C、TG四项，同时属于“合适水平”。或其中“LDL-C、非HDL-C”的其中1项属于”理想水平“。
        else if (TotalCholesterol < 5.2m && LDLCholesterol < 3.4m && nonHDLCholesterol < 4.1m && Triglyceride < 1.7m)
        {
            // 总胆固醇 < 5.2，2.6 <= 低密度脂蛋白胆固醇 < 3.4，1.3 <= 高密度脂蛋白胆固醇 < 4.1，1.7 <= 非高密度脂蛋白胆固醇 < 2.6，甘油三酯 < 1.7
            return BloodLipidsResultEnum.Suitable;
        }
        // HDL-C属“降低”。TC、LDL-C、非HDL-C、TG四项中，没有任一项属于“升高”，并且有任一项属于“边缘升高”
        else if (TotalCholesterol < 6.2m && LDLCholesterol < 4.1m
        && nonHDLCholesterol < 4.9m && Triglyceride < 2.3m
        && (TotalCholesterol >= 5.2m || LDLCholesterol >= 3.4m || nonHDLCholesterol >= 4.9m || Triglyceride >= 1.7m))
        {
            // 总胆固醇 < 6.2，低密度脂蛋白胆固醇 < 4.1，高密度脂蛋白胆固醇 < 1.0，非高密度脂蛋白胆固醇 < 4.9，甘油三酯 < 2.3
            // 总胆固醇 >= 5.2，低密度脂蛋白胆固醇 >= 3.4，非高密度脂蛋白胆固醇 >= 4.1，甘油三酯 >= 1.7
            return BloodLipidsResultEnum.BorderlineHigh;
        }
        else if (TotalCholesterol >= 6.2m || LDLCholesterol >= 4.1m || nonHDLCholesterol >= 4.9m || Triglyceride >= 2.3m)
        {
            // 总胆固醇 >= 6.2，低密度脂蛋白胆固醇 >= 4.1，高密度脂蛋白胆固醇 >= 4.1，非高密度脂蛋白胆固醇 >= 4.9，甘油三酯 >= 2.3
            return BloodLipidsResultEnum.High;
        }
        else
        {
            return BloodLipidsResultEnum.Abnormal;
        }
    }

    public static string GetBloodLipidsResult(decimal TotalCholesterol, decimal LDLCholesterol, decimal HDLCholesterol, decimal Triglyceride)
    {
        var bloodLipidsResult = GetBloodLipidsResultCode(TotalCholesterol, LDLCholesterol, HDLCholesterol, Triglyceride);

        var type = bloodLipidsResult.GetType();//先获取这个枚举的类型
        var field = type.GetField(bloodLipidsResult.ToString());//通过这个类型获取到值
        var obj = (DisplayAttribute)field.GetCustomAttribute(typeof(DisplayAttribute));//得到特性
        return obj.Name ?? "";
    }

    /// <summary>
    /// 获取高密度脂蛋白胆固醇结果
    /// </summary>
    /// <param name="HDLCholesterol">高密度脂蛋白胆固醇</param>
    /// <returns></returns>
    public static HDLResultEnum GetHDLResult(decimal HDLCholesterol)
    {
        if (HDLCholesterol >= 1.0m)
        {
            return HDLResultEnum.Normal;
        }
        else
        {
            return HDLResultEnum.Low;
        }
    }

    /// <summary>
    /// 获取血脂健康建议
    /// </summary>
    /// <param name="bloodLipidsResult">血脂结果</param>
    /// <param name="hDLResult"></param>
    /// <returns></returns>
    public static string GetBloodLipidsHealthAdvice(BloodLipidsResultEnum bloodLipidsResult, HDLResultEnum hDLResult)
    {
        //整体结果属于“边缘升高、升高”
        if (((bloodLipidsResult == BloodLipidsResultEnum.High || bloodLipidsResult == BloodLipidsResultEnum.BorderlineHigh) && hDLResult == HDLResultEnum.Low) || hDLResult == HDLResultEnum.Normal)
        {
            return bloodLipidsResult.GetDescription();
        }
        return string.Empty;
    }
    /// <summary>
    /// 获取血脂健康建议
    /// </summary>
    /// <param name="TotalCholesterol">总胆固醇</param>
    /// <param name="LDLCholesterol">低密度脂蛋白胆固醇</param>
    /// <param name="HDLCholesterol">高密度脂蛋白胆固醇</param>
    /// <param name="Triglyceride">甘油三酯</param>
    /// <returns></returns>
    public static string GetBloodLipidsHealthAdvice(decimal TotalCholesterol, decimal LDLCholesterol, decimal HDLCholesterol, decimal Triglyceride)
    {
        var bloodLipidsResult = GetBloodLipidsResultCode(TotalCholesterol, LDLCholesterol, HDLCholesterol, Triglyceride);
        var nonHDLCholesterol = TotalCholesterol - HDLCholesterol;
        var hDLResult = GetHDLResult(HDLCholesterol);
        //整体结果属于“边缘升高、升高”
        if (hDLResult == HDLResultEnum.Low && ((bloodLipidsResult == BloodLipidsResultEnum.Ideal || bloodLipidsResult == BloodLipidsResultEnum.Suitable)) || bloodLipidsResult == BloodLipidsResultEnum.Abnormal)
            return string.Empty;

        //当处于边缘升高时获取，达到边缘升高的指标名称，替换到健康建议中
        if (bloodLipidsResult == BloodLipidsResultEnum.BorderlineHigh)
        {
            var healthAdvice = bloodLipidsResult.GetDescription();
            var healthAdviceContent = new List<string>();
            if (TotalCholesterol >= 5.2m)
                healthAdviceContent.Add("总胆固醇");
            if (LDLCholesterol >= 3.4m)
                healthAdviceContent.Add("低密度脂蛋白胆固醇");
            if (Triglyceride >= 1.7m)
                healthAdviceContent.Add("甘油三酯");
            if (nonHDLCholesterol >= 4.1m)
                healthAdviceContent.Add("高密度脂蛋白胆固醇");
            var healthAdviceContentString = string.Join("、", healthAdviceContent);
            healthAdvice = string.Format(healthAdvice, healthAdviceContentString);
            return healthAdvice;
        }
        //当处于升高时获取，达到升高的指标名称，替换到健康建议中
        else if (bloodLipidsResult == BloodLipidsResultEnum.High)
        {
            var healthAdvice = bloodLipidsResult.GetDescription();
            var healthAdviceContent = new List<string>();
            if (TotalCholesterol >= 6.2m)
                healthAdviceContent.Add("总胆固醇");
            if (LDLCholesterol >= 4.1m)
                healthAdviceContent.Add("低密度脂蛋白胆固醇");
            if (Triglyceride >= 2.3m)
                healthAdviceContent.Add("甘油三酯");
            if (nonHDLCholesterol > 4.9m)
                healthAdviceContent.Add("高密度脂蛋白胆固醇");
            var healthAdviceContentString = string.Join("、", healthAdviceContent);
            healthAdvice = string.Format(healthAdvice, healthAdviceContentString);
            return healthAdvice;
        }
        return bloodLipidsResult.GetDescription();
    }

    /// <summary>
    /// 获取高密度脂蛋白胆固醇健康建议
    /// </summary>
    /// <param name="hDLResult">高密度脂蛋白胆固醇结果</param>
    /// <returns></returns>
    public static string GetHDLCholesterolLevel(HDLResultEnum hDLResult)
    {
        if (hDLResult == HDLResultEnum.Low)
        {
            return hDLResult.GetDescription();
        }
        return string.Empty;
    }
    /// <summary>
    /// 获取高密度脂蛋白胆固醇 (HDL-C)水平
    /// </summary>
    /// <returns></returns>
    public static string GetHDLCholesterolLevel(decimal HDLCholesterol)
    {
        var hDLResult = GetHDLResult(HDLCholesterol);
        if (hDLResult == HDLResultEnum.Low)
        {
            return hDLResult.GetDescription();
        }
        return string.Empty;
    }

}