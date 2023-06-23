using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;
public static class BloodPressureTool
{
    /// <summary>
    /// 获取血压结果    
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static BloodPressureHealthAdviceEnum GetBloodPressureResultWithMedication(BloodPressureResultInput input)
    {
        //TODO: 有空再优化，也可能有空就忘了
        if (input.SBP < 90 || input.DBP < 60)
        {
            return BloodPressureHealthAdviceEnum.LowBloodPressure;
        }
        //不使用降压药不使用降糖药
        if (!input.IsUsingAntihypertensiveMedication && !input.IsUsingAntidiabeticMedication)
        {
            if (input.SBP >= 90 && input.SBP <= 120 && input.DBP >= 60 && input.DBP <= 80 && input.Age < 45)
            {
                return BloodPressureHealthAdviceEnum.IsBloodPressureMetForUnder45WithoutMedication;
            }
            if (input.SBP >= 90 && input.SBP <= 140 && input.DBP >= 60 && input.DBP <= 80 && input.Age >= 45)
            {
                return BloodPressureHealthAdviceEnum.IsBloodPressureMetForOver45WithoutMedication;
            }
            if (input.SBP >= 120 && input.SBP < 140 && input.DBP >= 80 && input.DBP < 90)
            {
                return BloodPressureHealthAdviceEnum.IsBloodPressureAboveIdealWithoutMedication;
            }
            if (input.SBP >= 140 && input.SBP < 160 && input.DBP >= 90 && input.DBP < 100)
            {
                return BloodPressureHealthAdviceEnum.IsBloodPressureSlightlyHighWithoutMedication;
            }
            if (input.SBP >= 160 && input.SBP < 180 && input.DBP >= 100 && input.DBP < 110)
            {
                return BloodPressureHealthAdviceEnum.IsBloodPressureModeratelyHighWithoutMedication;
            }
            if (input.SBP >= 180 && input.SBP < 210 && input.DBP >= 110 && input.DBP < 120)
            {
                return BloodPressureHealthAdviceEnum.IsBloodPressureVeryHighWithoutMedication;
            }
        }

        //使用降压药&使用降糖药
        if (input.IsUsingAntihypertensiveMedication && input.IsUsingAntidiabeticMedication)
        {
            //年龄大于等于65岁
            if (input.Age > 65)
            {
                if (input.SBP < 140 && input.DBP < 90)
                {
                    return BloodPressureHealthAdviceEnum.IsBloodPressureMetForOver65WithMedication;
                }
                if (input.SBP >= 140 && input.DBP >= 90)
                {
                    return BloodPressureHealthAdviceEnum.IsBloodPressureNotMetForOver65WithMedication;
                }

            }
            //年龄小于65岁
            if (input.Age < 65)
            {
                if (input.SBP < 130 && input.DBP < 80)
                {
                    return BloodPressureHealthAdviceEnum.IsBloodPressureMetForUnder65WithMedication;
                }
                if (input.SBP >= 130 && input.DBP >= 80)
                {
                    return BloodPressureHealthAdviceEnum.IsBloodPressureNotMetForUnder65WithMedication;
                }
            }
        }
        //使用降压药&不使用降糖药
        if (input.IsUsingAntihypertensiveMedication && !input.IsUsingAntidiabeticMedication)
        {
            //年龄大于等于65岁
            if (input.Age > 65)
            {
                if (input.SBP < 150 && input.DBP < 90)
                {
                    return BloodPressureHealthAdviceEnum.IsBloodPressureMetForOver65WithMedication;
                }
                if (input.SBP >= 150 && input.DBP >= 90)
                {
                    return BloodPressureHealthAdviceEnum.IsBloodPressureNotMetForOver65WithMedication;
                }
            }
            //年龄小于65岁
            if (input.Age < 65)
            {
                if (input.SBP < 140 && input.DBP < 90)
                {
                    return BloodPressureHealthAdviceEnum.IsBloodPressureMetForUnder65WithMedication;
                }
                if (input.SBP >= 140 && input.DBP >= 90)
                {
                    return BloodPressureHealthAdviceEnum.IsBloodPressureNotMetForUnder65WithMedication;
                }
            }
        }
        throw Oops.Oh("未知的血压结果");

    }


    public static BloodPressureHealthAdviceEnum GetBloodPressureResult(string ArchivesCode, int SBP, int DBP)
    {
        var patientBasicInfo = HT_PatientBasicInfoRepositoryExtensions.GetByArchivesCode(ArchivesCode);
        var input = new BloodPressureResultInput
        {
            SBP = SBP,
            DBP = DBP,
            Age = ProfileInformationDetailTool.GetAgeFromIdCard(patientBasicInfo.PBI_ICard),
            IsUsingAntidiabeticMedication = patientBasicInfo.IsSdrug == 1,
            IsUsingAntihypertensiveMedication = patientBasicInfo.IsHdrug == 1
        };
        return GetBloodPressureResult(input);
    }

    public class BloodPressureResultInput
    {
        /// <summary>
        /// 是否使用降压药
        /// </summary>
        /// <value></value>
        public bool IsUsingAntihypertensiveMedication { get; set; }
        /// <summary>
        /// 是否使用降糖药
        /// </summary>
        /// <value></value>
        public bool IsUsingAntidiabeticMedication { get; set; }
        /// <summary>
        /// 是否使用降脂药
        /// </summary>
        /// <value></value>
        public int SBP { get; set; }
        /// <summary>
        /// 是否使用降脂药
        /// </summary>
        /// <value></value>
        public int DBP { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        /// <value></value>
        public int Age { get; set; }
    }

    public static HeartRateResultEnum GetPulseResult(int HeartRate)
    {
        if (HeartRate < 60)
        {
            return HeartRateResultEnum.Bradycardia;
        }
        else if (HeartRate < 100)
        {
            return HeartRateResultEnum.Normal;
        }
        else
        {
            return HeartRateResultEnum.Tachycardia;
        }
    }

    public static BloodPressureResultEnum GetBloodPressureResult(BloodPressureResultInput input)
{
    if (input.SBP < 90 || input.DBP < 60)
    {
        return BloodPressureResultEnum.Low;
    }
    else if (input.SBP < 120 && input.DBP < 80)
    {
        return BloodPressureResultEnum.Ideal;
    }
    else if (input.SBP < 140 && input.DBP < 90)
    {
        return BloodPressureResultEnum.Normal;
    }
    else if (input.SBP < 160 && input.DBP < 100)
    {
        return BloodPressureResultEnum.Mild;
    }
    else if (input.SBP < 180 && input.DBP < 110)
    {
        return BloodPressureResultEnum.Moderate;
    }
    else
    {
        return BloodPressureResultEnum.Severe;
    }
}


}