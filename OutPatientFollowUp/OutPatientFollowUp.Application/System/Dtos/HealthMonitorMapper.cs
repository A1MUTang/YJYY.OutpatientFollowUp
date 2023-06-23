using System.ComponentModel;
using System.Reflection;
using OutPatientFollowUp.Application.HealthMonitor;
using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application
{
    public class HealthMonitorMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<HT_Bloodlipid, BloodLipidsDto>()
            .Map(dest => dest.ArchivesCode, src => src.ArchivesCode)
            .Map(dest => dest.TotalCholesterol, src => src.TC)
            .Map(dest => dest.Triglycerides, src => src.TG)
            .Map(dest => dest.HDLCholesterol, src => src.HDL)
            .Map(dest => dest.LDLCholesterol, src => src.LDL)
            .Map(dest => dest.BloodLipidsResult, src => BloodLipidsTool.GetBloodLipidsResult(src.TC, src.LDL, src.HDL, src.TG))
            .Map(dest => dest.BloodLipidsResultCode, src => BloodLipidsTool.GetBloodLipidsResultCode(src.TC, src.LDL, src.HDL, src.TG))
            .Map(dest => dest.HealthAdvice, src => BloodLipidsTool.GetBloodLipidsHealthAdvice(src.TC, src.LDL, src.HDL, src.TG))
            .Map(dest => dest.HDLCholesterolLevel, src => BloodLipidsTool.GetHDLCholesterolLevel(src.HDL));

            config.ForType<CreateOrUpdateBloodLipidsDto, HT_Bloodlipid>()
            .Map(dest => dest.TC, src => src.TotalCholesterol)
            .Map(dest => dest.TG, src => src.Triglycerides)
            .Map(dest => dest.HDL, src => src.HDLCholesterol)
            .Map(dest => dest.LDL, src => src.LDLCholesterol)
            ;


            config.ForType<HT_BlutdruckTemp, BloodPressureDto>()
            .Map(dest => dest.ArchivesCode, src => src.ArchivesCode)
            .Map(dest => dest.Systolic, src => src.SBP)
            .Map(dest => dest.Diastolic, src => src.DBP)
            .Map(dest => dest.HeartRate, src => src.MaiBo)
            .Map(dest => dest.BloodPressureResult, src => BloodPressureTool.GetBloodPressureResult(src.SBP, src.DBP).GetName())
            .Map(dest => dest.BloodPressureResultCode, src => BloodPressureTool.GetBloodPressureResult(src.SBP, src.DBP))
            .Map(dest => dest.HealthAdvice, src => BloodPressureTool.GetBloodPressureResult(src.ArchivesCode,src.SBP, src.DBP).GetDescription())
            .Map(dest => dest.HeartRateResult, src => BloodPressureTool.GetHreatRateResult(src.MaiBo).GetName())
            .Map(dest => dest.HeartRateResultCode, src => BloodPressureTool.GetHreatRateResult(src.MaiBo));

            config.ForType<CreateOrUpdateBloodPressureDto, HT_BlutdruckTemp>()
            .Map(dest => dest.SBP, src => src.Systolic)
            .Map(dest => dest.DBP, src => src.Diastolic)
            .Map(dest => dest.MaiBo, src => src.HeartRate)
            ;
        }
    }
}