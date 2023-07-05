using System.Security.Claims;
using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class PT_MeasureEquipmentAppService : IPT_MeasureEquipmentAppService
{
    private readonly IPT_MeasureEquipmentRepository _repository;
    private readonly IOH_MeasureEquipmentRepository _measureEquipmentRepository;
    public PT_MeasureEquipmentAppService(IPT_MeasureEquipmentRepository repository, IOH_MeasureEquipmentRepository measureEquipmentRepository)
    {
        _repository = repository;
        _measureEquipmentRepository = measureEquipmentRepository;
    }

    private (string, string, string) GetLoginInfo()
    {
        var doctorId = App.User?.FindFirstValue("UserID");
        var manageName = App.User?.FindFirstValue("ManageName");
        var workUnits = App.User?.FindFirstValue("WorkUnits");
        return (doctorId, manageName, workUnits);
    }
    public async Task<DeviceDto> GetUpdateInfo(string eqpNo, string versionNumber, string apkType, string parentName, string unitName)
    {
        var updateInfos = await _repository.GetUpdateInfo(eqpNo, apkType, parentName, unitName);
        var ApkUrl = "";
        if (updateInfos.Count() > 0)
        {
            var updateInfo = updateInfos.Where(x=>x.ApkType == apkType).OrderByDescending(x => x.VersionNumber).FirstOrDefault();
            if ( updateInfo.VersionNumber != versionNumber)
            {
                ApkUrl = updateInfo.ApkUrl;
                return new DeviceDto()
                {
                    ApkUrl = ApkUrl,
                    Devices = await _measureEquipmentRepository.GetListAsync(),
                    IsForceUpdate = updateInfo.IsTough == 1 ? true : false
                };
            }
        }
        var result = new DeviceDto()
        {
            ApkUrl = ApkUrl, //updateInfo.FirstOrDefault().ApkUrl,
            Devices = await _measureEquipmentRepository.GetListAsync()
        };
        return result;
    }
}