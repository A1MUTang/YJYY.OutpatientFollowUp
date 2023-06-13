using System.Collections.Generic;
using System.Text;
using System;
using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public static class BloodOxygenTool
{
    /// <summary>
    /// 血氧结果
    /// </summary>
    /// <param name="bloodOxygenValue">血氧值</param>
    /// <returns></returns>
    public static object GetBloodOxygenResult(int bloodOxygenValue)
    {
        //正常: >94  轻度异常: 94   严重异常: ≤93
        return bloodOxygenValue switch
        {
            > 94 => BloodOxygenResultEnum.Normal,
            94 => BloodOxygenResultEnum.MildAbnormal,
            _ => BloodOxygenResultEnum.SevereAbnormal
        };
    }
}