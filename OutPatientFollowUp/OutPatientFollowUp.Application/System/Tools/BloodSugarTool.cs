using System.Linq;
using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public static class BloodSugarTool
{



    public static BloodSugarResultEnum GetBloodSugarResult(BloodSugarTypeEnum sugarType, decimal bloodSugar)
    {
        if (sugarType == BloodSugarTypeEnum.Fasting)
        {
            if (bloodSugar < 3.9m)
            {
                return BloodSugarResultEnum.Low;
            }
            else if (bloodSugar < 6.1m)
            {
                return BloodSugarResultEnum.Normal;
            }
            else if (bloodSugar < 7.0m)
            {
                return BloodSugarResultEnum.High;
            }
            else
            {
                return BloodSugarResultEnum.VeryHigh;
            }
        }
        else if (sugarType == BloodSugarTypeEnum.Postprandial || sugarType == BloodSugarTypeEnum.Random)
        {
            if (bloodSugar < 3.9m)
            {
                return BloodSugarResultEnum.Low;
            }
            else if (bloodSugar < 7.8m)
            {
                return BloodSugarResultEnum.Normal;
            }
            else if (bloodSugar < 11.1m)
            {
                return BloodSugarResultEnum.High;
            }
            else
            {
                return BloodSugarResultEnum.VeryHigh;
            }
        }
        else
        {
            throw new ArgumentException("血糖异常，请重新测量或联系管理员");
        }

    }

    public static string GetBloodSugarHealthAdvice(BloodSugarTypeEnum sugarType, decimal bloodSugar, string archivesCode)
    {
        var basicProfileInformation = HT_PatientBasicInfoRepositoryExtensions.GetByArchivesCode(archivesCode);
        var hasDiabetes = basicProfileInformation.PBI_ChronicDiseaseType == null ? false : basicProfileInformation.PBI_ChronicDiseaseType.Contains("CD02"); //糖尿病 
        var isHighBloodPressure = basicProfileInformation.PBI_ChronicDiseaseType == null ? false : basicProfileInformation.PBI_ChronicDiseaseType.Contains("CD01"); //是否有高血压
        var age = basicProfileInformation.PBI_Age; 
        var IsHdrug = basicProfileInformation.IsHdrug == 1; //是否服用降糖药 

        if (bloodSugar < 3.9m)
        {
            return "您本次测量血糖值偏低或疑似低血糖;发现低血糖应立即口服15-20g糖类食品，每15分钟监测血糖1次，如血糖持续不稳定请及时就医联系您的医生。坚持血糖监测将更及时提醒您的健康问题。";
        }

        if (bloodSugar > 33.3m)
        {
            return "数值错误，建议复测。";
        }

        if (!hasDiabetes)
        {
            if (!IsHdrug)
            {
                if (sugarType == BloodSugarTypeEnum.Fasting)
                {
                    if (bloodSugar >= 3.9m && bloodSugar < 6.1m)
                    {
                        if (age < 40 && !isHighBloodPressure)
                        {
                            return "您本次测量血糖值为理想血糖。建议保持健康生活方式；坚持血糖监测将有助于更好的管理您的健康。";
                        }

                        if (age >= 40 && isHighBloodPressure)
                        {
                            return "您本次测量血糖值为理想血糖。建议您每1年至少测量 1次空腹血糖，并接受医务人员的健康指导。";
                        }
                    }
                    else if (bloodSugar >= 6.1m && bloodSugar < 7.0m)
                    {
                        return "您本次测量血糖值偏高，建议您每半年至少测量 1次空腹血糖，并接受医务人员的健康指导。";
                    }
                    else if (bloodSugar >= 7.0m)
                    {
                        return "您本次测量血糖值严重偏高明显超标，高血糖风险大，请及时就医。请坚持糖尿病饮食、合理运动、规律用药；坚持血糖监测将及时提醒您的健康问题。";
                    }
                }
                else
                {
                    if (bloodSugar >= 3.9m && bloodSugar < 7.8m)
                    {
                        if (age < 40 && !isHighBloodPressure)
                        {
                            return "您本次测量血糖值为理想血糖。建议保持健康生活方式；坚持血糖监测将有助于更好的管理您的健康。";
                        }
                        if (age >= 40 || isHighBloodPressure)
                        {
                            return "您本次测量血糖值为理想血糖。建议您每1年至少测量 1次空腹血糖，并接受医务人员的健康指导。";
                        }
                    }
                    if (bloodSugar >= 7.8m && bloodSugar < 11.1m)
                    {
                        return "您本次测量血糖值偏高，建议您每半年至少测量 1次空腹血糖，并接受医务人员的健康指导。";
                    }
                    if (bloodSugar >= 11.1m)
                    {
                        return "您本次测量血糖值严重偏高明显超标，高血糖风险大，请及时就医。请坚持糖尿病饮食、合理运动、规律用药；坚持血糖监测将及时提醒您的健康问题。";
                    }

                }
            }
            else
            {
                if (sugarType == BloodSugarTypeEnum.Fasting)
                {
                    if (bloodSugar < 7.0m)
                    {
                        return "您本次测量血糖值达到控制目标，请坚持糖尿病饮食、合理运动、规律用药；坚持血糖监测将及时提醒您的健康问题。如出现血糖不稳定情况请及时就医联系您的医生。";
                    }
                    if (bloodSugar >= 7.0m)
                    {
                        return "您本次测量血糖值末达到控制目标，请坚持糖尿病饮食、合理运动适当增加运动、规律用药、必要时遵医嘱调整用药；坚持血糖监测将及时提醒您的健康问题。如血糖持续不稳定情况请及时就医联系您的医生，调整治疗方案。";
                    }
                }
                else
                {
                    if (bloodSugar < 10m)
                    {
                        return "您本次测量血糖值达到控制目标，请坚持糖尿病饮食、合理运动、规律用药；坚持血糖监测将及时提醒您的健康问题。如出现血糖不稳定情況请及时就医联系您的医生。";
                    }
                    if (bloodSugar >= 10m)
                    {
                        return "您本次测量血糖值末达到控制目标，请坚持糖尿病饮食、合理运动适当增加运动、规律用药、必要时遵医嘱调整用药；坚持血糖监测将及时提醒您的健康问题。如血糖持续不稳定情况请及时就医联系您的医生，调整治疗方案。";
                    }
                }
            }

        }
        else
        {
            if (sugarType == BloodSugarTypeEnum.Fasting)
            {
                if (bloodSugar < 7.0m)
                {
                    return "您本次测量血糖值达到控制目标，请坚持糖尿病饮食、合理运动、规律用药；坚持血糖监测将及时提醒您的健康问题。如出现血糖不稳定情况请及时就医联系您的医生。";
                }
                if (bloodSugar >= 7.0m)
                {
                    return "您本次测量血糖值末达到控制目标，请坚持糖尿病饮食、合理运动适当增加运动、规律用药、必要时遵医嘱调整用药；坚持血糖监测将及时提醒您的健康问题。如血糖持续不稳定情况请及时就医联系您的医生，调整治疗方案。";
                }
            }
            else
            {
                if (bloodSugar < 10m)
                {
                    return "您本次测量血糖值达到控制目标，请坚持糖尿病饮食、合理运动、规律用药；坚持血糖监测将及时提醒您的健康问题。如出现血糖不稳定情況请及时就医联系您的医生。";
                }
                if (bloodSugar >= 10m)
                {
                    return "您本次测量血糖值末达到控制目标，请坚持糖尿病饮食、合理运动适当增加运动、规律用药、必要时遵医嘱调整用药；坚持血糖监测将及时提醒您的健康问题。如血糖持续不稳定情况请及时就医联系您的医生，调整治疗方案。";
                }
            }
        }
        return "data error";

    }
}