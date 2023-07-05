namespace OutPatientFollowUp.Application
{
    public interface IPT_MeasureEquipmentAppService : ITransient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eqpNo"></param>
        /// <param name="versionNumber"></param>
        /// <param name="apkType"></param>
        /// <param name="parentName"></param>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public Task<DeviceDto> GetUpdateInfo(string eqpNo,string versionNumber, string apkType, string parentName, string unitName);

    }
}