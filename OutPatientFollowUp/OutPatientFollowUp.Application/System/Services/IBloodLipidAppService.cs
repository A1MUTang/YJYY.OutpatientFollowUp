using OutPatientFollowUp.Application.HealthMonitor;

namespace OutPatientFollowUp.Application
{
    public interface IBloodLipidAppService : ITransient
    {
        /// <summary>
        /// 创建或更新血脂
        /// </summary>
        /// <param name="archivesCode">基本档案信息</param>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public Task<BloodLipidsDto> CreateAsync(string archivesCode, CreateOrUpdateBloodLipidsDto input);

        /// <summary>
        /// 获取血脂详情
        /// </summary>
        /// <param name="archivesCode">基本档案信息</param>
        /// <returns></returns>
        public Task<BloodLipidsDto> GetAsync(string archivesCode);
    }
}