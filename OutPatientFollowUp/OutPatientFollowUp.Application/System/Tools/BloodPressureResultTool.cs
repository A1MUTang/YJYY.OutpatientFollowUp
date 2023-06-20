using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;
public static class BloodPressureResultTool
{
    /// <summary>
    /// 获取血压结果    
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static BloodPressureResultEnum GetBloodPressureResult(BloodPressureResultInput input)
    {
        if (input.SBP < 90 || input.DBP < 60)
        {
            return BloodPressureResultEnum.LowBloodPressure;
        }
        //不使用降压药不使用降糖药
        if (!input.IsUsingAntihypertensiveMedication && !input.IsUsingAntidiabeticMedication)
        {
            if (input.SBP >= 90 && input.SBP <= 120 && input.DBP >= 60 && input.DBP <= 80 && input.Age < 45)
            {
                return BloodPressureResultEnum.IsBloodPressureMetForUnder45WithoutMedication;
            }
            if (input.SBP >= 90 && input.SBP <= 140 && input.DBP >= 60 && input.DBP <= 80 && input.Age >= 45)
            {
                return BloodPressureResultEnum.IsBloodPressureMetForOver45WithoutMedication;
            }
            if (input.SBP >= 120 && input.SBP < 140 && input.DBP >= 80 && input.DBP < 90)
            {
                return BloodPressureResultEnum.IsBloodPressureAboveIdealWithoutMedication;
            }
            if (input.SBP >= 140 && input.SBP < 160 && input.DBP >= 90 && input.DBP < 100)
            {
                return BloodPressureResultEnum.IsBloodPressureSlightlyHighWithoutMedication;
            }
            if (input.SBP >= 160 && input.SBP < 180 && input.DBP >= 100 && input.DBP < 110)
            {
                return BloodPressureResultEnum.IsBloodPressureModeratelyHighWithoutMedication;
            }
            if (input.SBP >= 180 && input.SBP < 210 && input.DBP >= 110 && input.DBP < 120)
            {
                return BloodPressureResultEnum.IsBloodPressureVeryHighWithoutMedication;
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
                    return BloodPressureResultEnum.IsBloodPressureMetForOver65WithMedication;
                }
                if (input.SBP >= 140 && input.DBP >= 90)
                {
                    return BloodPressureResultEnum.IsBloodPressureNotMetForOver65WithMedication;
                }

            }
            //年龄小于65岁
            if (input.Age < 65)
            {
                if (input.SBP < 130 && input.DBP < 80)
                {
                    return BloodPressureResultEnum.IsBloodPressureMetForUnder65WithMedication;
                }
                if (input.SBP >= 130 && input.DBP >= 80)
                {
                    return BloodPressureResultEnum.IsBloodPressureNotMetForUnder65WithMedication;
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
                    return BloodPressureResultEnum.IsBloodPressureMetForOver65WithMedication;
                }
                if (input.SBP >= 150 && input.DBP >= 90)
                {
                    return BloodPressureResultEnum.IsBloodPressureNotMetForOver65WithMedication;
                }
            }
            //年龄小于65岁
            if (input.Age < 65)
            {
                if (input.SBP < 140 && input.DBP < 90)
                {
                    return BloodPressureResultEnum.IsBloodPressureMetForUnder65WithMedication;
                }
                if (input.SBP >= 140 && input.DBP >= 90)
                {
                    return BloodPressureResultEnum.IsBloodPressureNotMetForUnder65WithMedication;
                }
            }
        }
        throw Oops.Oh("未知的血压结果");

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
        public decimal SBP { get; set; }
        /// <summary>
        /// 是否使用降脂药
        /// </summary>
        /// <value></value>
        public decimal DBP { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        /// <value></value>
        public int Age { get; set; }
    }


}