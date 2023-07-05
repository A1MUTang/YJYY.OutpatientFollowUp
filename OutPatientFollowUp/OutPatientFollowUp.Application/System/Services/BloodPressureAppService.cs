using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application
{
    /// <summary>
    /// 血压应用程序服务类。
    /// </summary>
    public class BloodPressureAppService : IBloodPressureAppService
    {
        private readonly IHT_BlutdruckTempRepository _bloodPressureRepository;

        private readonly IHT_PatientBasicInfoRepository _patientBasicInfoRepository;

        public BloodPressureAppService(IHT_BlutdruckTempRepository bloodPressureRepository, IHT_PatientBasicInfoRepository patientBasicInfoRepository)
        {
            _bloodPressureRepository = bloodPressureRepository;
            _patientBasicInfoRepository = patientBasicInfoRepository;
        }

        /// <summary>
        /// 创建血压记录。
        /// </summary>
        /// <param name="archivesCode">基础档案信息主键。</param>
        /// <param name="input">入参。</param>
        /// <remarks>会创建血压信息。</remarks>
        /// <returns></returns>
        public async Task<BloodPressureDto> CreateAsync(string archivesCode, CreateOrUpdateBloodPressureDto input)
        {
            var patientBasicInfo = await _patientBasicInfoRepository.GetFirstAsync(x => x.ArchivesCode == archivesCode);
            var bloodlipid = input.Adapt<HT_BlutdruckTemp>();
            bloodlipid.ArchivesCode = archivesCode;
            bloodlipid.ID = DateTime.Now.ToString("yyyyMMddHHmmss") + bloodlipid.ArchivesCode + new Random().Next(10, 99);//TODO：这玩意有什么特殊意义吗？ 为什么和其他表的ID生成方式不同？why？我找了俩小时
            bloodlipid.CreateArchivesUnit = patientBasicInfo?.PBI_ManageUnit;
            bloodlipid.Gender = patientBasicInfo?.PBI_Gender;
            bloodlipid.ICard = patientBasicInfo?.PBI_ICard;
            bloodlipid.UserName = patientBasicInfo?.PBI_UserName;
            bloodlipid.MacID = input.MacID;
            bloodlipid.MacType ="4.1.1";
            bloodlipid.UserCode ="1";
            bloodlipid.CreateDate = DateTime.Now;
            bloodlipid.MeasureDate = DateTime.Now;
            bloodlipid.Remarks="院外随访";
            bloodlipid.DataSources = "2";
            var result = await _bloodPressureRepository.InsertReturnEntityAsync(bloodlipid);
            return result.Adapt<BloodPressureDto>();
        }

        /// <summary>
        /// 获取血压。
        /// </summary>
        /// <param name="archivesCode">基础档案信息主键。</param>
        /// <remarks>会获取最新当前血压。</remarks>
        /// <returns></returns>
        public async Task<BloodPressureDto> GetAsync(string archivesCode)
        {
            var bloodLipids = await _bloodPressureRepository.GetByArchivesCode(archivesCode);
            return bloodLipids.Adapt<BloodPressureDto>();
        }
    }


}