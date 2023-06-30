using System.Threading.Tasks;

namespace OutPatientFollowUp.Core
{
    public interface IHT_QuestionnaireResultRepository : IBaseRepository<HT_QuestionnaireResult>
    {
        /// <summary>
        /// 根据问卷编码获取问卷结果
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public  Task<HT_QuestionnaireResult> GetQuestionnaireResultByCodeAsync(string code, string patientBasicArchivesCode );

        /// <summary>
        /// 保存问卷结果
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<bool> SaveQuestionnaireResult(HT_QuestionnaireResult input);

        /// <summary>
        /// 根据问卷结果Id获取问卷结果
        /// </summary>
        /// <param name="QuestionnaireResultId"></param>
        /// <returns></returns>
         public string GetQuestionResult(int QuestionnaireResultId);

    }
}