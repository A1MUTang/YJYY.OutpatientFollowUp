namespace OutPatientFollowUp.Application
{
    public interface IProfileInformationAppService : ITransient
    {

        /// <summary>
        /// 获取基础档案信息
        /// </summary>
        /// <param name="idCardNumber">身份证号</param>
        /// <returns></returns>
        Task<BasicProfileInformationDto> GetBasicProfileInformationAsync(string idCardNumber);

        /// <summary>
        /// 创建基础档案信息
        /// </summary>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<BasicProfileInformationDto> CreateBasicProfileInformationAsync(CreateBasicProfileInformationDto input);

        /// <summary>
        /// 更新基础档案信息
        /// </summary>
        /// <param name="archivesCode"></param>
        /// <param name="input"></param>
        /// <remarks>手机号、是否服用降压药、是否服用降糖药</remarks>
        /// <returns></returns>
        Task<BasicProfileInformationDto> UpdateBasicProfileInformationAsync(string archivesCode,UpdateBasicProfileInformationDto input);

        /// <summary>
        /// 获取档案信息详情
        /// </summary>
        /// <param name="archivesCode">档案编号</param>
        /// <returns></returns>
        Task<ProfileInformationDetailDto> GetProfileInformationDetailAsync(string archivesCode);

        /// <summary>
        /// 创建或更新档案信息详情
        /// </summary>
        /// <param name="archivesCode"></param>
        /// <param name="input">入参</param>
        /// <remarks>会生成对应的修改记录（审计日志）</remarks>
        /// <returns></returns>
        Task<ProfileInformationDetailDto> CreateOrUpdateProfileInformationDetailAsync(string archivesCode,CreateOrUpdateProfileInformationDetailDto input);

    }
}