using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application
{
    public class IdAppService :  IIdAppService
    {
        private readonly ISF_IDManageRepository _idManageRepository;
        public IdAppService(ISF_IDManageRepository idManageRepository)
        {
            _idManageRepository = idManageRepository;
        }

        /// <summary>
        /// 获取ManageID
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public async Task<string> GetManangeID(string tableName)
        {
            return await _idManageRepository.GetManangeID(tableName);
        }

        /// <summary>
        ///  获取新的ManageID
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="strcode"></param>
        /// <returns></returns>
        public async Task<string> GetNewManangeID(string tableName, string strcode)
        {
            return await _idManageRepository.GetNewManangeID(tableName, strcode);
        }

    }


}