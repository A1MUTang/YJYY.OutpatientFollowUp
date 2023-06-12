
using System;

namespace OutPatientFollowUp.Core;

/// <summary>
/// 患者基本信息
/// </summary>
[Serializable]
public partial class HT_PatientBasicInfo
{
    /// <summary>
    /// 智享版加入时间
    /// </summary>
    public DateTime? JoinShareDate { get; set; }
    //public string PBI_IsDrinking { get; set; }
    /// <summary>
    /// 用户ID
    /// </summary>
    public string PBI_UserID { get; set; }
    /// <summary>
    /// 用户名
    /// </summary>
    public string PBI_UserName { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    public string PBI_Gender { get; set; }

    /// <summary>
    /// 身份证号
    /// </summary>
    public string PBI_ICard { get; set; }

    /// <summary>
    /// 国籍
    /// </summary>
    public string PBI_Country { get; set; }

    /// <summary>
    /// 籍贯
    /// </summary>
    public string PBI_OriginPlace { get; set; }

    /// <summary>
    /// 出生日期
    /// </summary>
    public DateTime? PBI_Birthday { get; set; }

    /// <summary>
    /// 民族
    /// </summary>
    public string PBI_Nation { get; set; }

    /// <summary>
    /// 户别
    /// </summary>
    public string PBI_HuBie { get; set; }

    /// <summary>
    /// 户籍地址
    /// </summary>
    public string PBI_HuJi { get; set; }

    /// <summary>
    /// 婚姻状况
    /// </summary>
    public string PBI_MarryState { get; set; }

    /// <summary>
    /// 教育程度
    /// </summary>
    public string PBI_Education { get; set; }

    /// <summary>
    /// 工作状态
    /// </summary>
    public string PBI_WorkState { get; set; }

    /// <summary>
    /// 省份
    /// </summary>
    public string PBI_Province { get; set; }

    /// <summary>
    /// 城市
    /// </summary>
    public string PBI_City { get; set; }

    /// <summary>
    /// 区县
    /// </summary>
    public string PBI_County { get; set; }

    /// <summary>
    /// 街道
    /// </summary>
    public string PBI_Street { get; set; }

    /// <summary>
    /// 详细地址
    /// </summary>
    public string PBI_Address { get; set; }

    /// <summary>
    /// 居委会
    /// </summary>
    public string PBI_JuWeiHui { get; set; }

    /// <summary>
    /// 家庭电话
    /// </summary>
    public string PBI_HomePhone { get; set; }

    /// <summary>
    /// 个人电话
    /// </summary>
    public string PBI_PersonPhone { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    public string PBI_Email { get; set; }

    /// <summary>
    /// 医疗支付方式
    /// </summary>
    public string PBI_BaoXiaoFangShi { get; set; }

    /// <summary>
    /// 医保号
    /// </summary>
    public string PBI_YiBaoHao { get; set; }

    /// <summary>
    /// 家庭人口数
    /// </summary>
    public int? PBI_PersonCount { get; set; }

    /// <summary>
    /// 户主
    /// </summary>
    public string PBI_HuZhu { get; set; }

    /// <summary>
    /// 年收入
    /// </summary>
    public string PBI_YearEarning { get; set; }

    /// <summary>
    /// 月收入
    /// </summary>
    public string PBI_Salary { get; set; }

    /// <summary>
    /// 是否有网
    /// </summary>
    public string PBI_HaveNET { get; set; }

    /// <summary>
    /// 上网时间
    /// </summary>
    public string PBI_NetTime { get; set; }

    /// <summary>
    /// 联系人1姓名
    /// </summary>
    public string PBI_ContactName1 { get; set; }

    /// <summary>
    /// 联系人1电话
    /// </summary>
    public string PBI_ContactPhone1 { get; set; }

    /// <summary>
    /// 联系人1邮箱
    /// </summary>
    public string PBI_ContactEmail1 { get; set; }

    /// <summary>
    /// 联系人1关系
    /// </summary>
    public string PBI_ContactRelation1 { get; set; }
    /// <summary>
    /// 联系人姓名2
    /// </summary>
    public string PBI_ContactName2 { get; set; }

    /// <summary>
    /// 联系人电话2
    /// </summary>
    public string PBI_ContactPhone2 { get; set; }

    /// <summary>
    /// 联系人邮箱2
    /// </summary>
    public string PBI_ContactEmail2 { get; set; }

    /// <summary>
    /// 联系人关系2
    /// </summary>
    public string PBI_ContactRelation2 { get; set; }

    /// <summary>
    /// 建档日期
    /// </summary>
    public DateTime? PBI_CreateArchivesDate { get; set; }

    /// <summary>
    /// 档案编号
    /// </summary>
    public string ArchivesCode { get; set; }

    /// <summary>
    /// 建档单位
    /// </summary>
    public string PBI_CreateArchivesUnit { get; set; }

    /// <summary>
    /// 签约医生
    /// </summary>
    public string PBI_SignDoctor { get; set; }

    /// <summary>
    /// 签约护士
    /// </summary>
    public string PBI_SignNurse { get; set; }

    /// <summary>
    /// 社区号
    /// </summary>
    public string PBI_SheQuHao { get; set; }

    /// <summary>
    /// 慢病分类
    /// </summary>
    public string PBI_ChronicDiseaseType { get; set; }

    /// <summary>
    /// 其他慢病
    /// </summary>
    public string PBI_ChronicDiseaseOther { get; set; }

    /// <summary>
    /// 慢病展示
    /// </summary>
    public string PBI_ChronicDiseaseShow { get; set; }

    /// <summary>
    /// 人群分类
    /// </summary>
    public string PBI_AgeType { get; set; }

    /// <summary>
    /// 是否绑定设备
    /// </summary>
    public string PBI_IsBindMachine { get; set; }

    /// <summary>
    /// 血压设备ID
    /// </summary>
    public string PBI_XYMacID { get; set; }

    /// <summary>
    /// 血压用户编码
    /// </summary>
    public string PBI_XYUserCode { get; set; }

    /// <summary>
    /// 血压设备厂商
    /// </summary>
    public string PBI_XYManufacture { get; set; }

    /// <summary>
    /// 血压SIM卡号
    /// </summary>
    public string PBI_XYSIM { get; set; }

    /// <summary>
    /// 血糖设备ID
    /// </summary>
    public string PBI_XTMacID { get; set; }

    /// <summary>
    /// 血糖用户编码
    /// </summary>
    public string PBI_XTUserCode { get; set; }

    /// <summary>
    /// 血糖设备厂商
    /// </summary>
    public string PBI_XTManufacture { get; set; }

    /// <summary>
    /// 血糖SIM卡号
    /// </summary>
    public string PBI_XTSIM { get; set; }

    /// <summary>
    /// 家族病史分类
    /// </summary>
    public string PBI_FamilyDiseaseType { get; set; }

    /// <summary>
    /// 高血压关系
    /// </summary>
    public string PBI_GXYRelation { get; set; }

    /// <summary>
    /// 高血压确诊日期
    /// </summary>
    public DateTime? PBI_GXYDate { get; set; }

    /// <summary>
    /// 冠心病关系
    /// </summary>
    public string PBI_GXBRelation { get; set; }

    /// <summary>
    /// 冠心病确诊日期
    /// </summary>
    public DateTime? PBI_GXBDate { get; set; }

    /// <summary>
    /// 脑卒中关系
    /// </summary>
    public string PBI_NZZRelation { get; set; }

    /// <summary>
    /// 脑卒中确诊日期
    /// </summary>
    public DateTime? PBI_NZZDate { get; set; }

    /// <summary>
    /// 糖尿病关系
    /// </summary>
    public string PBI_TNBRelation { get; set; }

    /// <summary>
    /// 糖尿病确诊日期
    /// </summary>
    public DateTime? PBI_TNBDate { get; set; }

    /// <summary>
    /// 心血管关系
    /// </summary>
    public string PBI_XXGRelation { get; set; }

    /// <summary>
    /// 心血管确诊日期
    /// </summary>
    public DateTime? PBI_XXGDate { get; set; }

    /// <summary>
    /// 吸烟习惯
    /// </summary>
    public string PBI_XiYanXiGuan { get; set; }

    /// <summary>
    /// 吸烟数量
    /// </summary>
    public string PBI_XiYanShuLiang { get; set; }

    /// <summary>
    /// 控烟目标
    /// </summary>
    public string PBI_KongYanMuBiao { get; set; }

    /// <summary>
    /// 饮酒习惯
    /// </summary>
    public string PBI_YinJiuXiGuan { get; set; }

    /// <summary>
    /// 饮酒频次
    /// </summary>
    public string PBI_YinJiuPinCi { get; set; }

    /// <summary>
    /// 饮酒量
    /// </summary>
    public string PBI_YinJiuLiang { get; set; }

    /// <summary>
    /// 限酒目标
    /// </summary>
    public string PBI_XianJiuMuBiao { get; set; }

    /// <summary>
    /// 运动习惯
    /// </summary>
    public string PBI_YunDongXiGuan { get; set; }

    /// <summary>
    /// 锻炼频次
    /// </summary>
    public string PBI_DuanLianPinCi { get; set; }

    /// <summary>
    /// 锻炼时长
    /// </summary>
    public string PBI_DuanLianShiChang { get; set; }

    /// <summary>
    /// 锻炼目标频次
    /// </summary>
    public string PBI_MuBiaoPinCi { get; set; }

    /// <summary>
    /// 锻炼目标时长
    /// </summary>
    public string PBI_MuBiaoShiChang { get; set; }

    /// <summary>
    /// 饮食口味
    /// </summary>
    public string PBI_YinShiKouWei { get; set; }

    /// <summary>
    /// 饮食习惯
    /// </summary>
    public string PBI_ShiYanLiang { get; set; }

    /// <summary>
    /// 控盐目标
    /// </summary>
    public string PBI_KongYanLiang { get; set; }

    /// <summary>
    /// 睡眠习惯
    /// </summary>
    public string PBI_ShuiMinXiGuan { get; set; }

    /// <summary>
    /// 睡眠时间
    /// </summary>
    public string PBI_ShuiMinShiJian { get; set; }

    /// <summary>
    /// 蔬菜摄入量
    /// </summary>
    public string PBI_ShuCiSheRuLiang { get; set; }

    /// <summary>
    /// 目标蔬菜摄入量
    /// </summary>
    public string PBI_MuBiaoSCSheRuLiang { get; set; }

    /// <summary>
    /// 水果摄入量
    /// </summary>
    public string PBI_ShuiGuoSheRuLiang { get; set; }

    /// <summary>
    /// 目标水果摄入量
    /// </summary>
    public string PBI_MuBiaoSGSheRuLiang { get; set; }

    /// <summary>
    /// 脂肪摄入量
    /// </summary>
    public string PBI_ZhiFangSheRuLiang { get; set; }

    /// <summary>
    /// 目标脂肪摄入量
    /// </summary>
    public string PBI_MuBiaoZFSheRuLiang { get; set; }

    /// <summary>
    /// 近期是否感到压抑/压力大/紧张着急/愤怒
    /// </summary>
    public string PBI_FeelBad { get; set; }

    /// <summary>
    /// 身高
    /// </summary>
    public decimal? PBI_Height { get; set; }

    /// <summary>
    /// 体重
    /// </summary>
    public decimal? PBI_Weight { get; set; }

    /// <summary>
    /// 目标体重
    /// </summary>
    public decimal? PBI_AimWeight { get; set; }

    /// <summary>
    /// 身体质量指数
    /// </summary>
    public decimal? PBI_BMI { get; set; }

    /// <summary>
    /// 目标身体质量指数
    /// </summary>
    public decimal? PBI_AimBMI { get; set; }

    /// <summary>
    /// 腰围
    /// </summary>
    public decimal? PBI_YaoWei { get; set; }

    /// <summary>
    /// 目标腰围
    /// </summary>
    public decimal? PBI_MuBiaoYaoWei { get; set; }

    /// <summary>
    /// 臀围
    /// </summary>
    public decimal? PBI_TunWei { get; set; }

    /// <summary>
    /// 腰臀比
    /// </summary>
    public decimal? PBI_YaoTunBi { get; set; }

    /// <summary>
    /// 血型
    /// </summary>
    public string PBI_BloodType { get; set; }

    /// <summary>
    /// RH血型
    /// </summary>
    public string PBI_RHBloodType { get; set; }

    /// <summary>
    /// 创建用户ID
    /// </summary>
    public string PBI_CreateUserID { get; set; }

    /// <summary>
    /// 创建用户
    /// </summary>
    public string PBI_CreateUser { get; set; }

    /// <summary>
    /// 创建日期
    /// </summary>
    public DateTime? PBI_CreateDate { get; set; }

    /// <summary>
    /// 是否为模板
    /// </summary>
    public string PBI_IsModel { get; set; }

    /// <summary>
    /// 模板名称
    /// </summary>
    public string PBI_ModelName { get; set; }

    /// <summary>
    /// 收藏
    /// </summary>
    public string PBI_Collect { get; set; }

    /// <summary>
    /// 删除
    /// </summary>
    public string PBI_Delete { get; set; }

    /// <summary>
    /// 取消
    /// </summary>
    public string PBI_Cancel { get; set; }

    /// <summary>
    /// 退出
    /// </summary>
    public string PBI_Quit { get; set; }

    /// <summary>
    /// 撤销
    /// </summary>
    public string PBI_Undone { get; set; }

    /// <summary>
    /// 管理问题
    /// </summary>
    public string PBI_ManageQuestion { get; set; }

    /// <summary>
    /// 下次服务时间
    /// </summary>
    public DateTime? PBI_NextTime { get; set; }

    /// <summary>
    /// 用户状态
    /// </summary>
    public string PBI_UserStatus { get; set; }

    /// <summary>
    /// 服务包截止日期
    /// </summary>
    public DateTime? PBI_ExpiryTime { get; set; }

    /// <summary>
    /// 服务包开始日期
    /// </summary>
    public DateTime? PBI_ServiceStartTime { get; set; }

    /// <summary>
    /// 服务包状态
    /// </summary>
    public bool? PBI_BakFlag { get; set; }

    /// <summary>
    /// 完成
    /// </summary>
    public string PBI_Complete { get; set; }

    /// <summary>
    /// 是否使用降压药
    /// </summary>
    public int? IsHdrug { get; set; }

    /// <summary>
    /// 是否使用降糖药
    /// </summary>
    public int? IsSdrug { get; set; }

    /// <summary>
    /// 动态编号
    /// </summary>
    public string DynamicNum { get; set; }

    /// <summary>
    /// 患者类型
    /// </summary>
    public string PatientType { get; set; }

    /// <summary>
    /// 完成度
    /// </summary>
    public double? Completion { get; set; }

    /// <summary>
    /// 管理单位
    /// </summary>
    public string PBI_ManageUnit { get; set; }

    /// <summary>
    /// 是否对接达标中心
    /// </summary>
    public string IsGxyStandard { get; set; }

    /// <summary>
    /// 年龄
    /// </summary>
    public int? PBI_Age { get; set; }

    /// <summary>
    /// 是否目标高血压
    /// </summary>
    public int? IsMBGxy { get; set; }

    /// <summary>
    /// 是否目标糖尿病
    /// </summary>
    public int? IsMBTnb { get; set; }

    /// <summary>
    /// 是否有遗传病史
    /// </summary>
    public int? IsPredispos { get; set; }

    /// <summary>
    /// 居民类型
    /// </summary>
    public string PBI_ResidentType { get; set; }

    /// <summary>
    /// 公司名称
    /// </summary>
    public string PBI_CompanyName { get; set; }

    /// <summary>
    /// 是否使用抗精神药
    /// </summary>
    public int? PBI_IsAntipsychotics { get; set; }

    /// <summary>
    /// 是否使用抗抑郁药
    /// </summary>
    public int? PBI_IsAntidepressant { get; set; }

    /// <summary>
    /// 是否使用他汀类药物
    /// </summary>
    public int? PBI_IsStatins { get; set; }

    /// <summary>
    /// 糖尿病患者类型
    /// </summary>
    public string TNBPatientType { get; set; }

    /// <summary>
    /// 是否使用其他药物
    /// </summary>
    public int? PBI_IsOtherDrugs { get; set; }

    /// <summary>
    /// 商业保险
    /// </summary>
    public string PBI_ShangYeBaoX { get; set; }

    /// <summary>
    /// 吸烟状态
    /// </summary>
    public string PBI_SmokingStatus { get; set; }

    /// <summary>
    /// 吸烟量
    /// </summary>
    public string PBI_SmokingQuantity { get; set; }

    /// <summary>
    /// 开始吸烟年龄
    /// </summary>
    public string PBI_SmokingAge { get; set; }

    /// <summary>
    /// 戒烟年龄
    /// </summary>
    public string PBI_SmokeAbstinenceAge { get; set; }

    /// <summary>
    /// 戒酒年龄
    /// </summary>
    public string PBI_AbstinenceAge { get; set; }

    /// <summary>
    /// 是否过量饮酒
    /// </summary>
    public string PBI_ExcessiveDrinking { get; set; }

    /// <summary>
    /// 饮酒类型
    /// </summary>
    public string PBI_TypesDrinking { get; set; }

    /// <summary>
    /// 黏膜黏液
    /// </summary>
    public string PBI_StickExerciseTime { get; set; }

    /// <summary>
    /// 饮酒摄入量
    /// </summary>
    public string PBI_DrinkeIntake { get; set; }

    /// <summary>
    /// 开始饮酒年龄
    /// </summary>
    public string PBI_DrinkingAge { get; set; }

    /// <summary>
    /// 饮酒状态
    /// </summary>
    public string PBI_DrinkingStatus { get; set; }

    /// <summary>
    /// 运动方式
    /// </summary>
    public string PBI_ExerciseMode { get; set; }

    /// <summary>
    /// 转诊
    /// </summary>
    public int Referral { get; set; }
}
