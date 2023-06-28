namespace OutPatientFollowUp.Core
{

    public class HT_Option
    {
        /// <summary>
        /// 选项主键    
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// 问题主键
        /// </summary>
        /// <value></value>
        public int QuestionId { get; set; }

        /// <summary>
        /// 选项内容
        /// </summary>
        /// <value></value>
        public string Content { get; set; }

        /// <summary>
        /// 选项分数    
        /// </summary>
        /// <remarks>
        ///  选项分数，用于计算得分
        /// </remarks>
        /// <value></value>
        public int Score { get; set; }
        
    }
}