
using Newtonsoft.Json;
using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class CreateOrUpdateProfileInformationDetailDto
{
    public CompleteUpdateBasicProfileInformationDto BasicProfileInformation { get; set; }




    /// <summary>
    /// 婚姻状况
    /// </summary>
    public string MaritalStatus { get; set; }

    /// <summary>
    /// 身高（单位：米）
    /// </summary>
    public decimal? Height { get; set; }

    /// <summary>
    /// 体重（单位：千克）
    /// </summary>
    public decimal? Weight { get; set; }

    /// <summary>
    /// BMI (Body Mass Index)
    /// </summary>
    public float? BMI { get; set; }
    
    /// <summary>
    /// 腰围（单位：厘米）
    /// </summary>
    public decimal? WaistCircumference { get; set; }

    /// <summary>
    /// 臀围（单位：厘米）
    /// </summary>
    public decimal? HipCircumference { get; set; }

    /// <summary>
    /// 腰臀比
    /// </summary>
    public decimal? WaistToHipRatio { get; set; }

    /// <summary>
    /// 慢病分类
    /// <remarks>多个分类用逗号分隔</remarks>
    /// </summary>
    public string ChronicDiseaseCategoryCodes { get; set; }

    /// <summary>
    /// 慢性病其他说明
    /// </summary>
    public string OtherChronicDiseases { get; set; }

    /// <summary>
    /// 医疗费用支付方式
    /// </summary>
    public string PaymentMethodCode { get; set; }

    /// <summary>
    /// 既往病史
    /// <remarks>多个分类用逗号分隔</remarks>
    /// </summary>
    public string PastMedicalHistoryCodes { get; set; }

    /// <summary>
    /// 既往病史其他说明
    /// </summary>
    /// <remarks>既往病史为其他时填写</remarks>
    public string OtherMedicalHistory { get; set; }

    /// <summary>
    /// 家族史
    /// </summary>
    public string FamilyHistoryCode { get; set; }

    /// <summary>
    /// 吸烟状况
    /// </summary>
    public string SmokingStatusCode { get; set; }

    /// <summary>
    /// 饮酒状况
    /// </summary>
    public string AlcoholStatusCode { get; set; }

    /// <summary>
    /// 体育运动习惯
    /// </summary>
    public string ExerciseHabitsCode { get; set; }

    /// <summary>
    /// 饮食口味
    /// </summary>
    public string DietPreferenceCode { get; set; }

    /// <summary>
    /// 饮食习惯
    /// </summary>
    public string DietHabitsCode { get; set; }

    /// <summary>
    /// 控盐目标
    /// </summary>
    public string SaltTargetCode { get; set; }

    /// <summary>
    /// 蔬菜摄入量
    /// </summary>
    public string VegetableIntakeCode { get; set; }

    /// <summary>
    /// 目标蔬菜摄入量
    /// </summary>
    /// <value></value>
    public string VegetableIntakeTargetCode { get; set; }

    /// <summary>
    /// 水果摄入量
    /// </summary>
    /// <value></value>
    public string FruitIntakeEnumCode { get; set; }

    /// <summary>
    /// 目标水果摄入量
    /// </summary>
    public string FruitIntakeTargetEnumCode { get; set; }

    /// <summary>
    /// 脂肪含量较高食物摄入量（肉类等）
    /// </summary>
    /// <value></value>
    public string FatIntakeCode { get; set; }

    /// <summary>
    /// 目标脂肪含量较高食物摄入量
    /// </summary>
    /// <value></value>
    public string HighFatFoodIntakeCode { get; set; }

    /// <summary>
    /// 睡眠习惯枚举
    /// </summary>
    /// <value></value>
    public string SleepHabitCode { get; set; }

    /// <summary>
    /// 睡眠时间
    /// </summary>
    /// <value></value>
    public string SleepDurationCode { get; set; }

    /// <summary>
    /// 近期情绪状态
    /// </summary>
    /// <remarks>true: 感到压抑/压力大/紧张着急/愤怒 false:无</remarks>
    /// <value></value>
    public bool RecentEmotionalState { get; set; }


}
