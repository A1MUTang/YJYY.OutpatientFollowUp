﻿using OutPatientFollowUp.Core;

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
                .Map(dest => dest.PBI_UserName, src => src.Name)
                .Map(dest => dest.PBI_IDCardAddress, src => src.Address)
                .Map(dest => dest.PBI_Age, src => ProfileInformationDetailTool.GetAgeFromIdCard(src.IDCardNumber))
                .Map(dest => dest.PBI_ICard, src => src.IDCardNumber)
                .Map(dest => dest.IsSdrug, src => src.IsTakingAntidiabeticMeds ? "1" : "0")
                .Map(dest => dest.IsHdrug, src => src.IsTakingAntihypertensiveMeds ? "1" : "0")
                .Map(dest => dest.PBI_PersonPhone, src => src.PhoneNumber)
                .Map(dest => dest.PBI_Gender, src => src.Gender ? "1" : "2")
                .Map(dest => dest.PBI_AgeType, src => ProfileInformationDetailTool.GetPopulationCategory(src.IDCardNumber).ToString())
                .Map(dest => dest.PBI_Birthday, src => ProfileInformationDetailTool.GetBirthdayFromIdCard(src.IDCardNumber))
                .Map(dest => dest.PBI_Province, src => CityRepositoryExtensions.GetCityCodeByName(src.Province, null))
                .Map(dest => dest.PBI_City, src => CityRepositoryExtensions.GetCityCodeByName(src.City, src.Province))
                .Map(dest => dest.PBI_County, src => CityRepositoryExtensions.GetCityCodeByName(src.District, null))
                .Map(dest => dest.PBI_Address, src => src.AddressLine)
                .Map(dest => dest.PBI_IDCardAddress, src => src.Address)

                // .Map(dest => dest.PBI_ChronicDiseaseType, src => "") 慢病分类默认无 数据库中是null
                //A01素食为主    
                //SA02荤食为主    
                //SA03杂食       
                //SA04荤素均衡    
                //SA05不详
                .Map(dest => dest.PBI_ShiYanLiang, src => "SA05")
                // ET01	适中
                // ET02	嗜盐
                // ET03	嗜糖
                // ET04	清淡yijiayiyun2015
                // ET05	嗜油
                // ET06	不详
                .Map(dest => dest.PBI_YinShiKouWei, src => "ET06")
                .Map(dest => dest.PBI_Nation, src => src.EthnicityCode)
                //SP01	不运动
                //SP02	有氧运动
                //SP03	剧烈运动
                //SP04	不详
                .Map(dest => dest.PBI_YunDongXiGuan, src => "SP04")
                .Map(dest => dest.PBI_ZhiFangSheRuLiang, src => "FAT08")
                .Map(dest => dest.PBI_ShuiGuoSheRuLiang, src => "FI04")
                .Map(dest => dest.PBI_MuBiaoSGSheRuLiang, src => "AFI06")
                .Map(dest => dest.PBI_MuBiaoZFSheRuLiang, src => "AFT06")
                .Map(dest => dest.PBI_MarryState, src => "MS05")
                .Map(dest => dest.PBI_BaoXiaoFangShi, src => "BX07")
                .Map(dest => dest.PBI_FeelBad, src => "0")
                .Map(dest => dest.PBI_ShuiMinShiJian, src => "ST07")
                .Map(dest => dest.PBI_ShuiMinXiGuan, src => "SLP05")
                .Map(dest => dest.PBI_SmokingStatus, src => "SKS004")
                .Map(dest => dest.PBI_ShuCiSheRuLiang, src => "VT04")
                .Map(dest => dest.PBI_MuBiaoSCSheRuLiang, src => "AV06")
                .Map(dest => dest.PBI_CreateArchivesDate, src => DateTime.Now)
                .Map(dest => dest.PBI_KongYanLiang, src => "不详");


        config.ForType<UpdateBasicProfileInformationDto, HT_PatientBasicInfo>()
                .Map(dest => dest.PBI_PersonPhone, src => src.PhoneNumber)
                .Map(dest => dest.IsSdrug, src => src.IsTakingAntidiabeticMeds)
                .Map(dest => dest.IsHdrug, src => src.IsTakingAntihypertensiveMeds);

        config.ForType<HT_PatientBasicInfo, CreateBasicProfileInformationDto>()
                .Map(dest => dest.Name, src => src.PBI_UserName)
                .Map(dest => dest.AddressLine, src => src.PBI_Address)
                .Map(dest => dest.IDCardNumber, src => src.PBI_ICard)
                .Map(dest => dest.PhoneNumber, src => src.PBI_PersonPhone)
                .Map(dest => dest.IsTakingAntidiabeticMeds, src => src.IsSdrug)
                .Map(dest => dest.IsTakingAntihypertensiveMeds, src => src.IsHdrug)
                .Map(dest => dest.Address, src => src.PBI_IDCardAddress)
                .Map(dest => dest.Gender, src => src.PBI_Gender == "1" ? "男" : "女");

        config.ForType<HT_PatientBasicInfo, BasicProfileInformationDto>()
                .Map(dest => dest.ArchivesCode, src => src.ArchivesCode)
                .Map(dest => dest.Name, src => src.PBI_UserName)
                // .Map(dest => dest.Address, src => src.PBI_OriginPlace)
                .Map(dest => dest.IDCardNumber, src => src.PBI_ICard)
                .Map(dest => dest.PhoneNumber, src => src.PBI_PersonPhone)
                .Map(dest => dest.IsTakingAntidiabeticMeds, src => src.IsSdrug == 1 ? "是" : "否")
                .Map(dest => dest.IsTakingAntihypertensiveMeds, src => src.IsHdrug == 1 ? "是" : "否")
                .Map(dest => dest.Gender, src => src.PBI_Gender == "1" ? "男" : "女")
                .Map(dest => dest.ProvinceCode, src => src.PBI_Province)
                .Map(dest => dest.CityCode, src => src.PBI_City)
                .Map(dest => dest.DistrictCode, src => src.PBI_County)
                .Map(dest => dest.Ethnicity, src => SY_CoderRepositoryExtensions.GetCodeName(src.PBI_Nation))
                .Map(dest => dest.EthnicityCode, src => src.PBI_Nation)
                .Map(dest => dest.Province, src => CityRepositoryExtensions.GetProvinceCodeName(src.PBI_Province))
                .Map(dest => dest.City, src => CityRepositoryExtensions.GetCityCodeName(src.PBI_City))
                .Map(dest => dest.District, src => CityRepositoryExtensions.GetCityCodeName(src.PBI_County))
                .Map(dest => dest.AddressLine, src => src.PBI_Address)
                 .Map(dest => dest.Address, src => src.PBI_IDCardAddress)
                .Map(dest => dest.CurrentAddress, src => CityRepositoryExtensions.GetAdressDetails(src.PBI_Province, src.PBI_City, src.PBI_County, src.PBI_Address));

        config.ForType<HT_PatientBasicInfo, ProfileInformationDetailDto>()
                .Map(dest => dest.AlcoholStatusCode, src => src.PBI_DrinkingStatus)
                .Map(dest => dest.Birthday, src => src.PBI_Birthday)
                .Map(dest => dest.BMI, src => ProfileInformationDetailTool.CalculateBMI(src.PBI_Height, src.PBI_Weight))
                .Map(dest => dest.ChronicDiseaseCategory, src => SY_CoderRepositoryExtensions.GetCodesName(src.PBI_ChronicDiseaseType))
                .Map(dest => dest.ChronicDiseaseCategoryCodes, src => src.PBI_ChronicDiseaseType == null ? "" : src.PBI_ChronicDiseaseType)
                .Map(dest => dest.DietHabitsCode, src => src.PBI_ShiYanLiang == null ? "SA05" : src.PBI_ShiYanLiang)
                .Map(dest => dest.DietPreferenceCode, src => src.PBI_YinShiKouWei == null ? "ET06" : src.PBI_YinShiKouWei)
                .Map(dest => dest.ExerciseHabitsCode, src => src.PBI_YunDongXiGuan == null ? "SP04" : src.PBI_YunDongXiGuan)
                .Map(dest => dest.FamilyHistory, src => SY_CoderRepositoryExtensions.GetCodesName(src.PBI_FamilyDiseaseType))
                .Map(dest => dest.FamilyHistoryCodes, src => src.PBI_FamilyDiseaseType)
                .Map(dest => dest.FatIntakeCode, src => src.PBI_ZhiFangSheRuLiang == null ? "FAT08" : src.PBI_ZhiFangSheRuLiang)
                .Map(dest => dest.FruitIntakeEnumCode, src => src.PBI_ShuiGuoSheRuLiang == null ? "FI04" : src.PBI_ShuiGuoSheRuLiang)
                .Map(dest => dest.FruitIntakeTargetEnumCode, src => src.PBI_MuBiaoSGSheRuLiang == null ? "AFI06" : src.PBI_MuBiaoSGSheRuLiang)
                .Map(dest => dest.Height, src => src.PBI_Height == 0 ? null : src.PBI_Height)
                .Map(dest => dest.HighFatFoodIntakeCode, src => src.PBI_MuBiaoZFSheRuLiang == null ? "AFT06" : src.PBI_MuBiaoZFSheRuLiang)
                .Map(dest => dest.HipCircumference, src => src.PBI_TunWei == 0? null : src.PBI_TunWei)
                .Map(dest => dest.MaritalStatusCode, src => src.PBI_MarryState == null ? "MS05" : src.PBI_MarryState)
                .Map(dest => dest.OtherChronicDiseases, src => src.PBI_ChronicDiseaseOther)
                .Map(dest => dest.PastMedicalHistoryCodes, src => "")
                .Map(dest => dest.PaymentMethodCode, src => src.PBI_BaoXiaoFangShi == null ? "BX07" : src.PBI_BaoXiaoFangShi)
                .Map(dest => dest.PopulationCategory, src => SY_CoderRepositoryExtensions.GetCodeName(src.PBI_AgeType))
                .Map(dest => dest.RecentEmotionalState, src => src.PBI_FeelBad == "1" ? true : false)
                .Map(dest => dest.SaltTargetCode, src => src.PBI_KongYanLiang == null ? "不详" : src.PBI_KongYanLiang)
                .Map(dest => dest.SleepDurationCode, src => src.PBI_ShuiMinShiJian == null ? "ST07" : src.PBI_ShuiMinShiJian)
                .Map(dest => dest.SleepHabitCode, src => src.PBI_ShuiMinXiGuan == null ? "SLP05" : src.PBI_ShuiMinXiGuan)
                .Map(dest => dest.SmokingStatusCode, src => src.PBI_SmokingStatus == null ? "SKS004" : src.PBI_SmokingStatus)
                .Map(dest => dest.VegetableIntakeCode, src => src.PBI_ShuCiSheRuLiang == null ? "VT04" : src.PBI_ShuCiSheRuLiang)
                .Map(dest => dest.VegetableIntakeTargetCode, src => src.PBI_MuBiaoSCSheRuLiang == null ? "AV06" : src.PBI_MuBiaoSCSheRuLiang)
                .Map(dest => dest.WaistCircumference, src => src.PBI_YaoWei == 0 ? null : src.PBI_YaoWei)
                .Map(dest => dest.Weight, src => src.PBI_Weight == 0 ? null : src.PBI_Weight)
                .Map(dest => dest.WaistToHipRatio, src => src.PBI_YaoTunBi == 0 ? null : src.PBI_YaoTunBi)
                // .Map(dest => dest.BasicProfileInformation.Address, src => src. PBI_OriginPlace)//TODO 身份证地址，未找到对应字段，
                .Map(dest => dest.BasicProfileInformation.Gender, src => src.PBI_Gender == "1" ? "男" : "女")
                .Map(dest => dest.BasicProfileInformation.Ethnicity, src => SY_CoderRepositoryExtensions.GetCodeName(src.PBI_Nation))
                .Map(dest => dest.BasicProfileInformation.EthnicityCode, src => src.PBI_Nation)
                .Map(dest => dest.BasicProfileInformation.ProvinceCode, src => src.PBI_Province)
                .Map(dest => dest.BasicProfileInformation.CityCode, src => src.PBI_City)
                .Map(dest => dest.BasicProfileInformation.DistrictCode, src => src.PBI_County)
                .Map(dest => dest.BasicProfileInformation.Province, src => CityRepositoryExtensions.GetProvinceCodeName(src.PBI_Province))
                .Map(dest => dest.BasicProfileInformation.City, src => CityRepositoryExtensions.GetCityCodeName(src.PBI_City))
                .Map(dest => dest.BasicProfileInformation.District, src => CityRepositoryExtensions.GetCityCodeName(src.PBI_County))
                .Map(dest => dest.BasicProfileInformation.AddressLine, src => src.PBI_Address)
                .Map(dest => dest.BasicProfileInformation.CurrentAddress, src => CityRepositoryExtensions.GetAdressDetails(src.PBI_Province, src.PBI_City, src.PBI_County, src.PBI_Address))
                .Map(dest => dest.BasicProfileInformation.ArchivesCode, src => src.ArchivesCode)
                .Map(dest => dest.BasicProfileInformation.Name, src => src.PBI_UserName)
                .Map(dest => dest.BasicProfileInformation.IDCardNumber, src => src.PBI_ICard)
                .Map(dest => dest.BasicProfileInformation.Address, src => src.PBI_IDCardAddress)
                .Map(dest => dest.BasicProfileInformation.PhoneNumber, src => src.PBI_PersonPhone)
                .Map(dest => dest.BasicProfileInformation.IsTakingAntidiabeticMeds, src => src.IsSdrug == 1 ? "是" : "否")
                .Map(dest => dest.BasicProfileInformation.IsTakingAntihypertensiveMeds, src => src.IsHdrug == 1 ? "是" : "否");
        config.ForType<CreateOrUpdateProfileInformationDetailDto, HT_PatientBasicInfo>()
                .Map(dest => dest.PBI_Gender, src => src.BasicProfileInformation.Gender ? "1" : "2")
                .Map(dest => dest.PBI_DrinkingStatus, src => src.AlcoholStatusCode)
                .Map(dest => dest.PBI_Birthday, src => ProfileInformationDetailTool.GetBirthdayFromIdCard(src.BasicProfileInformation.IDCardNumber))
                .Map(dest => dest.PBI_BMI, src => ProfileInformationDetailTool.CalculateBMI(src.Height, src.Weight))
                .Map(dest => dest.PBI_ChronicDiseaseType, src => src.ChronicDiseaseCategoryCodes)
                .Map(dest => dest.PBI_ShiYanLiang, src => src.DietHabitsCode)
                .Map(dest => dest.PBI_YinShiKouWei, src => src.DietPreferenceCode)
                .Map(dest => dest.PBI_YunDongXiGuan, src => src.ExerciseHabitsCode)
                .Map(dest => dest.PBI_FamilyDiseaseType, src => src.FamilyHistoryCode)
                .Map(dest => dest.PBI_ZhiFangSheRuLiang, src => src.FatIntakeCode)
                .Map(dest => dest.PBI_ShuiGuoSheRuLiang, src => src.FruitIntakeEnumCode)
                .Map(dest => dest.PBI_MuBiaoSGSheRuLiang, src => src.FruitIntakeTargetEnumCode)
                .Map(dest => dest.PBI_Height, src => src.Height == 0 ? null : src.Height)
                .Map(dest => dest.PBI_MuBiaoZFSheRuLiang, src => src.HighFatFoodIntakeCode)
                .Map(dest => dest.PBI_TunWei, src => src.HipCircumference == 0 ? null : src.HipCircumference)
                .Map(dest => dest.PBI_MarryState, src => src.MaritalStatus)
                .Map(dest => dest.PBI_ChronicDiseaseOther, src => src.OtherChronicDiseases)
                .Map(dest => dest.PBI_BaoXiaoFangShi, src => src.PaymentMethodCode)
                .Map(dest => dest.PBI_AgeType, src => ProfileInformationDetailTool.GetPopulationCategory(src.BasicProfileInformation.IDCardNumber))
                .Map(dest => dest.PBI_FeelBad, src => src.RecentEmotionalState ? "1" : "0")
                .Map(dest => dest.PBI_KongYanLiang, src => src.SaltTargetCode)
                .Map(dest => dest.PBI_ShuiMinShiJian, src => src.SleepDurationCode)
                .Map(dest => dest.PBI_ShuiMinXiGuan, src => src.SleepHabitCode)
                .Map(dest => dest.PBI_SmokingStatus, src => src.SmokingStatusCode)
                .Map(dest => dest.PBI_ShuCiSheRuLiang, src => src.VegetableIntakeCode)
                .Map(dest => dest.PBI_MuBiaoSCSheRuLiang, src => src.VegetableIntakeTargetCode)
                .Map(dest => dest.PBI_YaoWei, src => src.WaistCircumference == 0 ? null : src.WaistCircumference)
                .Map(dest => dest.PBI_Weight, src => src.Weight)
                .Map(dest => dest.PBI_YaoTunBi, src => src.WaistToHipRatio)
                .Map(dest => dest.PBI_Nation, src => src.BasicProfileInformation.Ethnicity)
                .Map(dest => dest.PBI_UserName, src => src.BasicProfileInformation.Name)
                .Map(dest => dest.PBI_ICard, src => src.BasicProfileInformation.IDCardNumber)
                .Map(dest => dest.PBI_PersonPhone, src => src.BasicProfileInformation.PhoneNumber)
                .Map(dest => dest.PBI_IDCardAddress, src => src.BasicProfileInformation.Address)
                .Map(dest => dest.PBI_Province, src => CityRepositoryExtensions.GetCityCodeByName(src.BasicProfileInformation.Province, null))
                .Map(dest => dest.PBI_City, src => CityRepositoryExtensions.GetCityCodeByName(src.BasicProfileInformation.City, src.BasicProfileInformation.Province))
                .Map(dest => dest.PBI_County, src => CityRepositoryExtensions.GetCityCodeByName(src.BasicProfileInformation.District, null))
                .Map(dest => dest.PBI_Address, src => src.BasicProfileInformation.AddressLine)
                // .Map(dest => dest.PBI_OriginPlace, src => src.BasicProfileInformation.Address)//TODO 未找到对应字段，先对应到籍贯字段
                .Map(dest => dest.IsSdrug, src => src.BasicProfileInformation.IsTakingAntidiabeticMeds ? "1" : "0")
                .Map(dest => dest.IsHdrug, src => src.BasicProfileInformation.IsTakingAntihypertensiveMeds ? "1" : "0")
                ;
    }
}
