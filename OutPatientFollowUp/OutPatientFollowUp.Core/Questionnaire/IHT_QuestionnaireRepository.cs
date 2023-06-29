using System.Threading.Tasks;

namespace OutPatientFollowUp.Core
{
    public interface IHT_QuestionnaireRepository:IBaseRepository<HT_Questionnaire>
    {
        /// <summary>
        /// 根据问卷编码获取问卷
        /// </summary>
        /// <param name="code"></param>
        /// <param name="Gender"></param>
        /// <returns></returns>
        public Task<HT_Questionnaire> GetQuestionnaireByCodeAsync(string code,bool? Gender );


    }
}