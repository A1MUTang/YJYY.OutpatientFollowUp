using OutPatientFollowUp.Application.HealthMonitor;

namespace OutPatientFollowUp.Application
{
    public interface IBloodOxygenAppService : ITransient
    {
        /// <summary>
        /// 获取血氧信息
        /// </summary>
        /// <param name="archivesCode"></param>
        /// <returns></returns>
        Task<BloodOxygenDto> GetByArchivesCode(string archivesCode);


        /// <summary>
        /// 录入血氧信息
        /// </summary>
        /// <param name="archivesCode"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<BloodOxygenDto> CreateAsync(string archivesCode, CreateOrUpdateBloodOxygenDto input);

    }
}