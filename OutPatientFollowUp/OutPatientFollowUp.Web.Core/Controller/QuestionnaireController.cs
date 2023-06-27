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
    /// <param name="code">问卷编码</param>
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
    public async Task<QuestionResultcs> SubmitQuestionnaireAsync(SurveySubmissionDto input)
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
    public async Task<QuestionResultcs> GetResultAsync(string code)
    {
        throw new System.NotImplementedException();
        //return await _questionnaireAppService.GetResultAsync(code);
    }


    
}