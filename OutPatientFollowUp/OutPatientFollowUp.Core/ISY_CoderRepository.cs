using System.Collections.Generic;
using System.Threading.Tasks;
using Furion.DependencyInjection;

namespace OutPatientFollowUp.Core
{
    public interface ISY_CoderRepository : IBaseRepository<SY_Code>, ITransient
    {
        /// <summary>
        /// 获取字典
        /// </summary>
        /// <returns></returns>
        public Task<List<Dictionary<string, string[][]>>> GetDicionary();

        /// <summary>
        /// 根据编码获取名称
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetCodeName(string code);
        /// <summary>
        /// 根据名称获取编码
        /// </summary>
        /// <param name="codeName"></param>
        /// <returns></returns>
        public string GetCodeByName(string codeName);

    }
}