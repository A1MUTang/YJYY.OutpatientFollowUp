using System.Threading.Tasks;

namespace OutPatientFollowUp.Core
{
    public interface IHT_SupplementaryExamRepository:IBaseRepository<HT_SupplementaryExam>
    {
        /// <summary>
        /// 根据档案号获取最新的补充检查信息
        /// </summary>
        /// <param name="archivesCode">档案号</param>
        /// <returns></returns>
        public Task<HT_SupplementaryExam> GetByArchivesCode(string archivesCode);
    }
}