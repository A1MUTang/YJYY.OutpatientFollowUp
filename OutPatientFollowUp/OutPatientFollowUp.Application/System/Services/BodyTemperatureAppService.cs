using OutPatientFollowUp.Core;
using OutPatientFollowUp.Dto;

namespace OutPatientFollowUp.Application;

public class BodyTemperatureAppService : IBodyTemperatureAppService
{
    private readonly IHT_BodyTemperatureRepository _bodyTemperatureRepository;

    private readonly IHT_PatientBasicInfoRepository _patientBasicInfoRepository;

    public BodyTemperatureAppService(IHT_BodyTemperatureRepository bodyTemperatureRepository, IHT_PatientBasicInfoRepository patientBasicInfoRepository)
    {
        _bodyTemperatureRepository = bodyTemperatureRepository;
        _patientBasicInfoRepository = patientBasicInfoRepository;
    }

    /// <summary>
    /// 根据档案编号获取体温信息。
    /// </summary>
    /// <param name="archivesCode"></param>
    /// <returns></returns>
    public async Task<TemperatureDto> GetByArchivesCodeAsync(string archivesCode)
    {
        var bodyTemperature = await _bodyTemperatureRepository.GetByArchivesCode(archivesCode);
        return bodyTemperature.Adapt<TemperatureDto>();
    }

    /// <summary>
    /// 创建体温记录。
    /// </summary>
    /// <param name="archivesCode">基础档案信息主键。</param>
    /// <param name="input">入参。</param>
    /// <remarks>会创建体温信息。</remarks>
    /// <returns></returns>
    public async Task<TemperatureDto> CreateAsync(string archivesCode, CreateOrUpdateTemperatureDto input)
    {
        var patientBasicInfo = await _patientBasicInfoRepository.GetFirstAsync(x => x.ArchivesCode == archivesCode);
        var bodyTemperature = input.Adapt<HT_BodyTemperature>();
        bodyTemperature.ArchivesCode = archivesCode;
        bodyTemperature.ID = DateTime.Now.ToString("yyyyMMddHHmmss") + bodyTemperature.ArchivesCode + new Random().Next(10, 99);//TODO：这玩意有什么特殊意义吗？ 为什么和其他表的ID生成方式不同？why？我找了俩小时
        bodyTemperature.CreateArchivesUnit = patientBasicInfo?.PBI_ManageUnit;
        bodyTemperature.Gender = patientBasicInfo?.PBI_Gender;
        bodyTemperature.ICard = patientBasicInfo?.PBI_ICard;
        bodyTemperature.UserName = patientBasicInfo?.PBI_UserName;
        bodyTemperature.CreateDate = DateTime.Now;
        bodyTemperature.MeasureDate = DateTime.Now;
        var result = await _bodyTemperatureRepository.InsertReturnEntityAsync(bodyTemperature);
        return result.Adapt<TemperatureDto>();
    }

}