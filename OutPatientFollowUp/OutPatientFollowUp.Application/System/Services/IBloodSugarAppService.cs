
namespace OutPatientFollowUp.Application
{
    public interface IBloodSugarAppService: ITransient
    {   
        /// <summary>
        /// 创建血糖记录
        /// </summary>
        /// <param name="archivesCode">基础档案信息主键</param>
        /// <param name="input">入参</param>
        /// <remarks>会创建血糖信息</remarks>
        /// <returns></returns>
        public Task<BloodSugarDto> CreateAsync(string archivesCode, CreateOrUpdateBloodSugarDto input);

        /// <summary>
        /// 获取血糖
        /// </summary>
        /// <param name="archivesCode">基础档案信息主键</param>
        /// <remarks>会获取最新当前血糖</remarks> 
        /// <returns></returns>
        public Task<BloodSugarDto> GetAsync(string archivesCode);
    }
}