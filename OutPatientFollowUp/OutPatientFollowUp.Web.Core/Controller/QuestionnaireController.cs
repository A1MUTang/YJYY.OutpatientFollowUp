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


    
}