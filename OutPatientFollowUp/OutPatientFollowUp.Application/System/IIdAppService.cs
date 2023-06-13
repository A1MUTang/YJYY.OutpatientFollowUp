namespace OutPatientFollowUp.Application
{
    public interface IIdAppService:ISingleton
    {
        /// <summary>
        /// 获取ManageID
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public Task<string> GetManangeID(string tableName);

        /// <summary>
        ///  获取新的ManageID
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="strcode"></param>
        /// <returns></returns>
        public Task<string> GetNewManangeID(string tableName, string strcode);
    }
}