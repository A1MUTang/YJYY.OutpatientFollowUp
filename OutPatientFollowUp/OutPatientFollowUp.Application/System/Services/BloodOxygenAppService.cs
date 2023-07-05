using OutPatientFollowUp.Application.HealthMonitor;
using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class BloodOxygenAppService : IBloodOxygenAppService
{
    private readonly IHT_BloodOxygenRepository _repository;
    private readonly IHT_PatientBasicInfoRepository _patientBasicInfoRepository;

    public BloodOxygenAppService(IHT_BloodOxygenRepository repository, IHT_PatientBasicInfoRepository patientBasicInfoRepository)
    {
        _repository = repository;
        _patientBasicInfoRepository = patientBasicInfoRepository;
    }


    /// <summary>
    /// 根据档案编号和测量日期获取血氧信息。
    /// </summary>
    /// <param name="archivesCode"></param>
    /// <returns></returns>
    public async Task<BloodOxygenDto> GetByArchivesCode(string archivesCode)
    {
        var result = await _repository.GetByArchivesCode(archivesCode);
        return result.Adapt<BloodOxygenDto>();
    }

    /// <summary>
    /// 创建血氧记录。
    /// </summary>
    /// <param name="archivesCode">基础档案信息主键。</param>
    /// <param name="input">入参。</param>
    /// <remarks>会创建血氧信息。</remarks>
    /// <returns></returns>
    public async Task<BloodOxygenDto> CreateAsync(string archivesCode, CreateOrUpdateBloodOxygenDto input)
    {
        var patientBasicInfo = await _patientBasicInfoRepository.GetFirstAsync(x => x.ArchivesCode == archivesCode);
        if (patientBasicInfo == null)
        {
            throw Oops.Oh("未找到基本档案信息");
        }
        var bloodOxygen = input.Adapt<HT_BloodOxygen>();
        bloodOxygen.ArchivesCode = archivesCode;
        bloodOxygen.ID = DateTime.Now.ToString("yyyyMMddHHmmss") + bloodOxygen.ArchivesCode + new Random().Next(10, 99);
        var result = await _repository.InsertReturnEntityAsync(bloodOxygen);
        return result.Adapt<BloodOxygenDto>();
    }


}