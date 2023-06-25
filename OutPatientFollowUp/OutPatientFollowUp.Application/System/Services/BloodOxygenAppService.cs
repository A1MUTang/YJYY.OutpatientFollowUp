using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class BloodOxygenAppService : IBloodOxygenAppService
{
    private readonly IHT_BloodOxygenReository _repository;

    public BloodOxygenAppService(IHT_BloodOxygenReository repository)
    {
        _repository = repository;
    }

    // /// <summary>
    // /// 根据档案编号和测量日期获取血氧信息。
    // /// </summary>
    // /// <param name="archivesCode"></param>
    // /// <returns></returns>
    // public async Task<BloodOxygenResultEnum> GetByArchivesCode(string archivesCode)
    // {
    //     return await _repository.GetByArchivesCode(archivesCode);
    // }


}