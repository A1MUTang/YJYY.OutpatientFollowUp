using System;
using System.Threading.Tasks;
using OutPatientFollowUp.Application.HealthMonitor;
using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class BloodLipidsAppService : IBloodLipidAppService
{
    private readonly IBloodLipidReository _bloodLipidReository;
    private readonly IHT_PatientBasicInfoRepository _patientBasicInfoRepository;

    private readonly IIdAppService _idAppService;
    public BloodLipidsAppService(IBloodLipidReository bloodLipidRepository, IHT_PatientBasicInfoRepository patientBasicInfoRepository, IIdAppService idAppService)
    {
        _bloodLipidReository = bloodLipidRepository;
        _patientBasicInfoRepository = patientBasicInfoRepository;
        _idAppService = idAppService;
    }
    
    /// <summary>
    /// 创建或更新血脂
    /// </summary>
    /// <param name="archivesCode">基本档案信息</param>
    /// <param name="input">入参</param>
    /// <returns></returns>
    public async Task<BloodLipidsDto> CreateAsync(string archivesCode, CreateOrUpdateBloodLipidsDto input)
    {
        var patientBasicInfo = await _patientBasicInfoRepository.GetFirstAsync(x => x.ArchivesCode == archivesCode);
        if (patientBasicInfo == null)
        {
            throw Oops.Oh("未找到基本档案信息");
        }
        var bloodlipid =  input.Adapt<HT_Bloodlipid>();
        bloodlipid.ArchivesCode = archivesCode;
        bloodlipid.ID =  DateTime.Now.ToString("yyyyMMddHHmmss") + bloodlipid.ArchivesCode + new Random().Next(10, 99);//TODO：这玩意有什么特殊意义吗？ 为什么和其他表的ID生成方式不同？why？我找了俩小时
        bloodlipid.CreateArchivesUnit = patientBasicInfo?.PBI_ManageUnit;
        bloodlipid.Gender = patientBasicInfo?.PBI_Gender;
        bloodlipid.ICard = patientBasicInfo?.PBI_ICard;
        bloodlipid.UserName = patientBasicInfo?.PBI_UserName;
       var result =  await _bloodLipidReository.InsertReturnEntityAsync(bloodlipid);
       return result.Adapt<BloodLipidsDto>();
    }

    /// <summary>
    /// 获取血脂
    /// </summary>
    /// <param name="archivesCode">入参</param>
    /// <returns></returns>
    public async Task<BloodLipidsDto> GetAsync(string archivesCode)
    {
        var bloodLipids = await _bloodLipidReository.GetByArchivesCodeAsync(archivesCode);
        return bloodLipids.Adapt<BloodLipidsDto>();
    }
}