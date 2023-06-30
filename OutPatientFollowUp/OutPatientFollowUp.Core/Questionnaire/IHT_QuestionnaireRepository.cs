using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutPatientFollowUp.Core
{
    public interface IHT_QuestionnaireRepository : IBaseRepository<HT_Questionnaire>
    {
        /// <summary>
        /// 根据问卷编码获取问卷
        /// </summary>
        /// <param name="code"></param>
        /// <param name="Gender"></param>
        /// <returns></returns>
        public Task<HT_Questionnaire> GetQuestionnaireByCodeAsync(string code, bool? Gender);

        /// <summary>
        /// 根据问卷编码获取问卷Id
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int GetQuestionnaireIdByCodeAsync(string code);

        /// <summary>
        /// 根据问卷结果Id获取问卷标题
        /// </summary>
        /// <param name="QuestionnaireResultId"></param>
        /// <returns></returns>
        public string GetQuestionnaireTitle(int QuestionnaireResultId);

        /// <summary>
        /// 根据问卷Id获取问卷标题
        /// </summary>
        /// <param name="questionnaireId"></param>
        /// <returns></returns>
        public List<HT_Question_OutPatientFollowUp> GetQuestion( int questionnaireId);

        /// <summary>
        /// 根据问卷结果Id获取问卷
        /// </summary>
        /// <param name="QuestionnaireResultId"></param>
        /// <returns></returns>
         public HT_Questionnaire GetQuestionnaire(int QuestionnaireResultId);
    }


}