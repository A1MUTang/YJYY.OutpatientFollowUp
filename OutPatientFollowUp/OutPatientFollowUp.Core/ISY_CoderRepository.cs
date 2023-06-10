using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutPatientFollowUp.Core
{
    public interface ISY_CoderRepository : IBaseRepository<SY_Code>
    {
        /// <summary>
        /// 获取字典
        /// </summary>
        /// <returns></returns>
        public Task<List<Dictionary<string, string[][]>>> GetDicionary();
    }
}