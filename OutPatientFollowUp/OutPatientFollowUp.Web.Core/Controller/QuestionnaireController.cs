using System.Threading.Tasks;
using Furion.UnifyResult;
using Microsoft.AspNetCore.Mvc;
using OutPatientFollowUp.Application;
using OutPatientFollowUp.Web.Core;

namespace OutPatientFollowUp.Core;


[ApiController]
[Route("api/[controller]")]
[UnifyModel(typeof(CustomResponse<>))]
public class QuestionnaireController  : ControllerBase
{   

    /// <summary>
    /// 获取问卷
    /// </summary>
    /// <param name="code">问卷编码</param>、
    /// <remarks>问卷编码为问卷的唯一标识，目前共有四种：脑卒中风险评估、心血管风险评估、慢阻肺风险评估、糖尿病风险评估 ，对应Code 分别是：
    /// StrokeRiskAssessment：脑卒中风险评估
    /// CardiovascularRiskAssessment：心血管风险评估
    /// CopdRiskAssessment：慢阻肺风险评估
    /// DiabetesRiskAssessment：糖尿病风险评估
    /// </remarks>
    /// <returns></returns>
    [HttpGet]
    public async Task<QuestionnaireDto> GetQuestionnaireAsync(string code)
    {
        throw new System.NotImplementedException();
        //return await _questionnaireAppService.GetQuestionnaireAsync(archivesCode);
    }

    /// <summary>
    /// 提交问卷
    /// </summary>
    /// <param name="input">问卷答案</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<QuestionResult> SubmitQuestionnaireAsync(SurveySubmissionDto input)
    {
        throw new System.NotImplementedException();
        //return await _questionnaireAppService.SubmitQuestionnaireAsync(input);
    }

    /// <summary>
    /// 获取问卷结果
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    [HttpGet("Result")]
    public async Task<QuestionResult> GetResultAsync(string code)
    {
        throw new System.NotImplementedException();
        //return await _questionnaireAppService.GetResultAsync(code);
    }


    
}