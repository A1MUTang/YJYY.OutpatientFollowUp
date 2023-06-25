using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public static class BloodSugarTool
{

    public static string GetBloodSugarResult(BloodSugarTypeEnum sugarType, decimal bloodSugar)
    {
        if (sugarType == BloodSugarTypeEnum.Fasting)
        {
            if (bloodSugar < 3.9m)
            {
                return "低血糖";
            }
            else if (bloodSugar < 6.1m)
            {
                return "正常";
            }
            else if (bloodSugar < 7.0m)
            {
                return "偏高";
            }
            else
            {
                return "很高";
            }
        }
        else if (sugarType == BloodSugarTypeEnum.Postprandial || sugarType == BloodSugarTypeEnum.Random)
        {
            if (bloodSugar < 3.9m)
            {
                return "低血糖";
            }
            else if (bloodSugar < 7.8m)
            {
                return "正常";
            }
            else if (bloodSugar < 11.1m)
            {
                return "偏高";
            }
            else
            {
                return "很高";
            }
        }
        else
        {
            throw new ArgumentException("Invalid blood sugar type.");
        }

    }


}