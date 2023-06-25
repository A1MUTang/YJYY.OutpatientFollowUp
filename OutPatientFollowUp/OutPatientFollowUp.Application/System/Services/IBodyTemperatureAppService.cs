using OutPatientFollowUp.Core;
using OutPatientFollowUp.Dto;

namespace OutPatientFollowUp.Application
{
    public interface IBodyTemperatureAppService : ITransient
    {
        /// <summary>
        /// 根据档案编号获取体温信息。
        /// </summary>
        /// <param name="archivesCode"></param>
        /// <returns></returns>
        public Task<TemperatureDto> GetByArchivesCodeAsync(string archivesCode);

        /// <summary>
        /// 创建体温记录。
        /// </summary>
        /// <param name="archivesCode">基础档案信息主键。</param>
        /// <param name="input">入参。</param>
        /// <remarks>会创建体温信息。</remarks>
        /// <returns></returns>
        public Task<TemperatureDto> CreateAsync(string archivesCode, CreateOrUpdateTemperatureDto input);

    }
}