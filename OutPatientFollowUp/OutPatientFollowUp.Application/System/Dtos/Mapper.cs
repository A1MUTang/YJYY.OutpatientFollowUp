using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class Mapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<DoctorinfoDto, PT_DoctorBasicInfo>()
                .Map(dest => dest.Doctor_ID, src => src.ID)
                .Map(dest => dest.Doctor_ImgPath, src => src.ImgPath)
                .Map(dest => dest.Doctor_Gender, src => src.Gender)
                .Map(dest => dest.Doctor_UserName, src => src.UserName);
        config.ForType<CreateBasicProfileInformationDto, HT_PatientBasicInfo>()
                .Map(dest => dest.ArchivesCode, src => "")//TODO:通过生成规则生成
                .Map(dest => dest.PBI_UserName, src => src.Name)
                .Map(dest => dest.PBI_Address, src => src.Address)
                //.Map(dest => dest.PBI_Age, src => ) //TODO年龄需要计算通过身份证号
                .Map(dest => dest.PBI_ICard, src => src.IDCardNumber)
                // .Map(dest => dest.PBI_IsAntidepressant, src => src.IsTakingAntidiabeticMeds) //TODO 未确认字段
                // .Map(dest => dest.PBI_IsAntipsychotics, src => src.IsTakingAntihypertensiveMeds) //TODO 未确认字段
                .Map(dest => dest.PBI_PersonPhone, src => src.PhoneNumber)
                .Map(dest => dest.PBI_Gender, src => src.Gender);

        config.ForType<HT_PatientBasicInfo, CreateBasicProfileInformationDto>()
                .Map(dest => dest.Name, src => src.PBI_UserName)
                .Map(dest => dest.Address, src => src.PBI_Address)
                .Map(dest => dest.IDCardNumber, src => src.PBI_ICard)
                .Map(dest => dest.PhoneNumber, src => src.PBI_PersonPhone)
                // .Map(dest => dest.IsTakingAntidiabeticMeds, src => src.IsTakingAntidiabeticMeds) //TODO 未确认字段
                // .Map(dest => dest.IsTakingAntihypertensiveMeds, src => src.IsTakingAntihypertensiveMeds) //TODO 未确认字段
                .Map(dest=>dest.Gender,src=>src.PBI_Gender=="1"?"男":"女");

        config.ForType<HT_PatientBasicInfo, BasicProfileInformationDto>()
                .Map(dest => dest.ArchivesCode, src => src.ArchivesCode)
                .Map(dest => dest.Name, src => src.PBI_UserName)
                .Map(dest => dest.Address, src => src.PBI_Address)
                .Map(dest => dest.IDCardNumber, src => src.PBI_ICard)
                .Map(dest => dest.PhoneNumber, src => src.PBI_PersonPhone)
                // .Map(dest => dest.IsTakingAntidiabeticMeds, src => src.IsTakingAntidiabeticMeds) //TODO 未确认字段
                // .Map(dest => dest.IsTakingAntihypertensiveMeds, src => src.IsTakingAntihypertensiveMeds) //TODO 未确认字段
                .Map(dest => dest.Gender, src => src.PBI_Gender == "1" ? "男" : "女")
                .Map(dest => dest.Province, src => src.PBI_Province)
                .Map(dest => dest.City, src => src.PBI_City)
                .Map(dest => dest.District, src => src.PBI_Country)
                .Map(dest => dest.CurrentAddress, src => src.PBI_Province + src.PBI_City + src.PBI_Country + src.PBI_Address);


        config.ForType<HT_PatientBasicInfo, ProfileInformationDetailDto>()
                .Map(dest => dest.Birthday, src => src.PBI_Birthday)
                .Map(dest => dest.BMI, src => src.PBI_BMI)
                .Map(dest => dest.ChronicDiseaseCategory, src => "")//TODO:需用通过Code查询数据库获取具体的疾病名称
                .Map(dest => dest.ChronicDiseaseCategoryCodes, src => src.PBI_ChronicDiseaseType)
                .Map(dest => dest.DietHabitsCode, src => src.PBI_ShiYanLiang)
                .Map(dest => dest.DietPreferenceCode, src => src.PBI_YinShiKouWei)
                .Map(dest => dest.EthnicityCode, src => src.PBI_Nation)
                .Map(dest => dest.ExerciseHabitsCode, src => src.PBI_YunDongXiGuan)
                .Map(dest => dest.FamilyHistory, src => "")//TODO:需用通过Code查询数据库获取具体的疾病名称
                .Map(dest => dest.FamilyHistoryCodes, src => src.PBI_FamilyDiseaseType)
                .Map(dest=> dest.FatIntakeCode,src=>src.PBI_ZhiFangSheRuLiang)
                .Map(dest=> dest.FruitIntakeEnumCode, src=>src.PBI_ShuiGuoSheRuLiang)
                .Map(dest=>dest.FruitIntakeTargetEnumCode,src=>src.PBI_MuBiaoSGSheRuLiang)
                .Map(dest=>dest.Height, src=>src.PBI_Height)
                .Map(dest=>dest.HighFatFoodIntakeCode, src=>src.PBI_MuBiaoZFSheRuLiang)
                .Map(dest=>dest.HipCircumference, src=>src.PBI_TunWei)
                .Map(dest=>dest.MaritalStatusCode, src=>src.PBI_MarryState)
                .Map(dest=>dest.OtherChronicDiseases, src=>src.PBI_ChronicDiseaseOther)
                .Map(dest=>dest.OtherMedicalHistory, src=>"")//TODO 未确认字段
                .Map(dest=>dest.PastMedicalHistory, src=>"") //TODO 未确认字段
                .Map(dest=>dest.PastMedicalHistoryCodes, src=>"")//TODO 未确认字段
                .Map(dest=>dest.PaymentMethodCode, src=>src.PBI_BaoXiaoFangShi)
                .Map(dest=>dest.PopulationCategory, src=>src.PBI_AgeType)
                .Map(dest=>dest.RecentEmotionalState, src=>src.PBI_FeelBad)
                .Map(dest=>dest.SleepDurationCode, src=>src.PBI_ShuiMinShiJian);




    }
}
