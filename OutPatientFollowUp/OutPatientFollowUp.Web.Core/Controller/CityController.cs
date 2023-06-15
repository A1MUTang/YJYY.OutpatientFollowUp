using System.Net;
using System;
using System.Threading.Tasks;
using Furion.UnifyResult;
using Microsoft.AspNetCore.Mvc;
using OutPatientFollowUp.Application;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Web.Core.Controller;

[ApiController]
[Route("api/[controller]")]
[UnifyModel(typeof(CustomResponse<>))]
public class CityController : ControllerBase
{

    private readonly ICityAppService _cityAppService;
    public CityController(ICityAppService cityAppService)
    {
        _cityAppService = cityAppService;
    }

    /// <summary>
    /// 获取城市
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetProvinceList")]
    public async Task<IEnumerable<SY_City>> GetProvinceList()
    {
        return await _cityAppService.GetProvinceListAsync();
    }

    /// <summary>
    /// 获取子级市区
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetChildCityList")]
    public async Task<IEnumerable<SY_City>> GetCityList(string code)
    {
        return await _cityAppService.GetCityListAsync(code);
    }


}