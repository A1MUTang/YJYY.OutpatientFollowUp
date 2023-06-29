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

    private readonly IQuestionnaireAppService _questionnaireAppService;
    private readonly IHT_QuestionnaireResultAppService _questionnaireResultAppService;
    public QuestionnaireController(IQuestionnaireAppService questionnaireAppService, IHT_QuestionnaireResultAppService questionnaireResultAppService)
    {
        _questionnaireAppService = questionnaireAppService;
        _questionnaireResultAppService = questionnaireResultAppService;
    }

    /// <summary>
    /// 获取问卷
    /// </summary>
    /// <param name="code">问卷编码</param>
    /// <param name="Gender"></param>、
    /// <remarks>问卷编码为问卷的唯一标识，目前共有四种：脑卒中风险评估、心血管风险评估、慢阻肺风险评估、糖尿病风险评估 ，对应Code 分别是：
    /// StrokeRiskAssessment：脑卒中风险评估
    /// CardiovascularRiskAssessment：心血管风险评估
    /// CopdRiskAssessment：慢阻肺风险评估
    /// DiabetesRiskAssessment：糖尿病风险评估
    /// </remarks>
    /// <returns></returns>
    [HttpGet]
    public async Task<QuestionnaireDto> GetQuestionnaireAsync(string code ,bool? Gender )
    {
        return await _questionnaireAppService.GetQuestionnaireByCodeAsync(code,Gender);
    }

    /// <summary>
    /// 提交问卷
    /// </summary>
    /// <param name="input">问卷答案</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> SubmitQuestionnaireAsync(SurveySubmissionDto input)
    {
        return await _questionnaireResultAppService.SaveQuestionnaireResult(input);
    }

    /// <summary>
    /// 获取问卷结果
    /// </summary>
    /// <param name="code"></param>
    /// <param name="patientBasicArchivesCode"></param>
    /// <returns></returns>
    [HttpGet("Result")]
    public async Task<QuestionResultDto> GetResultAsync(string code, string patientBasicArchivesCode)
    {
        return await _questionnaireResultAppService.GetQuestionnaireResultByCodeAsync(code, patientBasicArchivesCode);
    }


    
}