namespace OutPatientFollowUp.Application;

public class ProfileInformationDetailDto
{

    /// <summary>
    /// 主键
    /// </summary>
    /// <value></value>
    public Guid Id { get; set; }

    public BasicProfileInformationDto BasicProfileInformation { get; set; } = null;

    /// <summary>
    /// 人群分类
    /// </summary>
    public string PopulationCategory { get; set; }

    /// <summary>
    /// 民族
    /// </summary>
    /// <value></value>
    public string Ethnicity { get; set; }

    /// <summary>
    /// 婚姻状况
    /// </summary>
    public string MaritalStatus { get; set; }

    /// <summary>
    /// 身高（单位：米）
    /// </summary>
    public float Height { get; set; }

    /// <summary>
    /// 体重（单位：千克）
    /// </summary>
    public decimal Weight { get; set; }

    /// <summary>
    /// BMI (Body Mass Index)
    /// </summary>
    public float BMI { get; set; }
    /// <summary>
    /// 腰围（单位：厘米）
    /// </summary>
    public decimal WaistCircumference { get; set; }
    /// <summary>
    /// 臀围（单位：厘米）
    /// </summary>
    public decimal HipCircumference { get; set; }

    /// <summary>
    /// 腰臀比
    /// </summary>
    public decimal WaistToHipRatio { get; set; }

    /// <summary>
    /// 慢病分类
    /// </summary>
    public string ChronicDiseaseCategory { get; set; }

    /// <summary>
    /// 慢性病其他说明
    /// </summary>
    public string OtherChronicDiseases { get; set; }

    /// <summary>
    /// 医疗费用支付方式
    /// </summary>
    public string PaymentMethod { get; set; }

    /// <summary>
    /// 既往病史
    /// </summary>
    public string PastMedicalHistory { get; set; }

    /// <summary>
    /// 既往病史其他说明
    /// </summary>
    /// <remarks>既往病史为其他时填写</remarks>
    public string OtherMedicalHistory { get; set; }

    /// <summary>
    /// 家族史
    /// </summary>
    public string FamilyHistory { get; set; }

    /// <summary>
    /// 吸烟状况
    /// </summary>
    public string SmokingStatus { get; set; }

    /// <summary>
    /// 饮酒状况
    /// </summary>
    public string AlcoholStatus { get; set; }

    /// <summary>
    /// 体育运动习惯
    /// </summary>
    public string ExerciseHabits { get; set; }

    /// <summary>
    /// 饮食口味
    /// </summary>
    public string DietPreference { get; set; }

    /// <summary>
    /// 饮食习惯
    /// </summary>
    public string DietHabits { get; set; }

    /// <summary>
    /// 控盐目标
    /// </summary>
    public string SaltTarget { get; set; }

    /// <summary>
    /// 蔬菜摄入量
    /// </summary>
    public string VegetableIntake { get; set; }

    /// <summary>
    /// 目标蔬菜摄入量
    /// </summary>
    /// <value></value>
    public string VegetableIntakeTarget { get; set; }

    /// <summary>
    /// 水果摄入量
    /// </summary>
    /// <value></value>
    public string FruitIntakeEnum { get; set; }

    /// <summary>
    /// 目标水果摄入量
    /// </summary>
    public string FruitIntakeTargetEnum { get; set; }

    /// <summary>
    /// 脂肪含量较高食物摄入量（肉类等）
    /// </summary>
    /// <value></value>
    public string FatIntake { get; set; }

    /// <summary>
    /// 目标脂肪含量较高食物摄入量
    /// </summary>
    /// <value></value>
    public string HighFatFoodIntake { get; set; }

    /// <summary>
    /// 睡眠习惯枚举
    /// </summary>
    /// <value></value>
    public string SleepHabit { get; set; }

    /// <summary>
    /// 睡眠时间
    /// </summary>
    /// <value></value>
    public string SleepDuration { get; set; }

    /// <summary>
    /// 近期情绪状态
    /// </summary>
    /// <remarks>true: 感到压抑/压力大/紧张着急/愤怒 false:无</remarks>
    /// <value></value>
    public bool RecentEmotionalState { get; set; }

}

