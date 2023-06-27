using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application
{

    /// <summary>
    /// 问卷
    /// </summary>
    public class QuestionnaireDto
    {
        /// <summary>
        /// 问卷标题
        /// </summary>
        /// <value></value>
        public string Title { get; set; }

        /// <summary>
        /// 问卷问题
        /// </summary>
        /// <value></value>

        public List<QuestionDto> Questions { get; set; }

        /// <summary>
        /// 问卷描述
        /// </summary>
        /// <value></value>
        public string Description { get; set; }

    }

    /// <summary>
    /// 问题
    /// </summary>
    public class QuestionDto
    {
        /// <summary>
        /// 问题主键
        /// </summary>
        /// <value></value>
        public string Id { get; set; }
        
        /// <summary>
        /// 问题题干
        /// </summary>
        /// <value></value>
        public string Title { get; set; }

        /// <summary>
        /// 问题类型
        /// </summary>
        /// <value></value>
        public SurveyQuestionTypeEnum Type { get; set; }

        /// <summary>
        /// 问题选项
        /// </summary>
        /// <remarks>当问题类型为单选或多选时，此字段有效</remarks>
        /// <value></value>
        public List<Options> Options { get; set; } 
    }
    
    public class Options
    {
        /// <summary>
        /// 问题选项
        /// </summary>
        /// <value></value>
        public string OptionsDeatils { get; set; }
    }
}