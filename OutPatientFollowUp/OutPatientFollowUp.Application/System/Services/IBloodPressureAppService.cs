namespace OutPatientFollowUp.Application;
/// <summary>
/// 血压应用程序服务接口。
/// </summary>
public interface IBloodPressureAppService : ITransient
{
    /// <summary>
    /// 创建血压记录。
    /// </summary>
    /// <param name="archivesCode">基础档案信息主键。</param>
    /// <param name="input">入参。</param>
    /// <remarks>会创建血压信息。</remarks>
    /// <returns></returns>
    Task<BloodPressureDto> CreateAsync(string archivesCode, CreateOrUpdateBloodPressureDto input);

    /// <summary>
    /// 获取血压。
    /// </summary>
    /// <param name="archivesCode">基础档案信息主键。</param>
    /// <remarks>会获取最新当前血压。</remarks>
    /// <returns></returns>
    Task<BloodPressureDto> GetAsync(string archivesCode);
}