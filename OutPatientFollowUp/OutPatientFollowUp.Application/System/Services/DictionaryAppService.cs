using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class DictionaryAppService:IDictionaryAppService
{

    private readonly ISY_CoderRepository _coderRepository;

    public DictionaryAppService(ISY_CoderRepository coderRepository)
    {
        _coderRepository = coderRepository;
    }

    /// <summary>
    /// 获取字典
    /// </summary>
    /// <returns></returns>
    public async Task<List<Dictionary<string, string[][]>>> GetDicionary()
    {
        var list = await _coderRepository.GetDicionary();
        return list;
    }

    

}