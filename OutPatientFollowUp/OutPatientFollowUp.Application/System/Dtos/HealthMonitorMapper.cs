using OutPatientFollowUp.Application.HealthMonitor;
using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application
{
    public class HealthMonitorMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<HT_Bloodlipid,BloodLipidsDto>()
            .Map(dest => dest.ArchivesCode, src => src.ArchivesCode)
            .Map(dest => dest.TotalCholesterol, src => src.TC)
            .Map(dest => dest.Triglycerides, src => src.TG)
            .Map(dest => dest.HDLCholesterol, src => src.HDL)
            .Map(dest => dest.LDLCholesterol, src => src.LDL)
            .Map(dest => dest.BloodLipidsResult, src => BloodLipidsTool.GetBloodLipidsResult(src.TC,src.LDL,src.HDL,src.TG))
            .Map(dest => dest.HealthAdvice, src => BloodLipidsTool.GetBloodLipidsHealthAdvice(src.TC,src.LDL,src.HDL,src.TG))
            .Map(dest => dest.HDLCholesterolLevel, src => BloodLipidsTool.GetHDLCholesterolLevel(src.HDL))
            ;

            config.ForType<CreateOrUpdateBloodLipidsDto,HT_Bloodlipid>()
            .Map(dest => dest.TC, src => src.TotalCholesterol)
            .Map(dest => dest.TG, src => src.Triglycerides)
            .Map(dest => dest.HDL, src => src.HDLCholesterol)
            .Map(dest => dest.LDL, src => src.LDLCholesterol)
            ;
        }
    }
}