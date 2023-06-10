namespace OutPatientFollowUp.Application
{
    public interface IDictionaryAppService : ITransient
    {
        /// <summary>
        /// 获取字典
        /// </summary>
        /// <returns></returns>
        public Task<List<Dictionary<string, string[][]>>> GetDicionary();
    }
}