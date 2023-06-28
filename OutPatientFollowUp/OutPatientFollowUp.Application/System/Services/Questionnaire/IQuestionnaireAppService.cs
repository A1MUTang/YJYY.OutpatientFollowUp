using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application
{
    public interface IQuestionnaireAppService :ITransient
    {
        /// <summary>
        /// 根据问卷编码获取问卷
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<QuestionnaireDto> GetQuestionnaireByCodeAsync(string code);
    }
}