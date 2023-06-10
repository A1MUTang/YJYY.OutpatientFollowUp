using System.Net;
using System;
using System.Threading.Tasks;
using Furion.UnifyResult;
using Microsoft.AspNetCore.Mvc;
using OutPatientFollowUp.Application;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace OutPatientFollowUp.Web.Core.Controller;

[ApiController]
[Route("api/[controller]")]
[UnifyModel(typeof(CustomResponse<>))]
public class DictionaryController : ControllerBase
{

    private readonly IDictionaryAppService _dictionaryAppService;
    public DictionaryController(IDictionaryAppService dictionaryAppService)
    {
        _dictionaryAppService = dictionaryAppService;
    }

    /// <summary>
    /// 获取字典
    /// </summary>
    /// <returns></returns>
    [HttpGet]
   public async Task<List<Dictionary<string, string[][]>>> GetDicionary()
    {
        return await _dictionaryAppService.GetDicionary();
    }

}