using System.Collections.Generic;
using System.Threading.Tasks;
using OutPatientFollowUp.Application.HealthMonitor;
using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application
{
    public class BloodSugarAppService : IBloodSugarAppService
    {
        private readonly IHT_GlucoseRepository _repository;
        private readonly IHT_PatientBasicInfoRepository _patientBasicInfoRepository;
        public BloodSugarAppService(IHT_GlucoseRepository repository, IHT_PatientBasicInfoRepository patientBasicInfoRepository)
        {
            _repository = repository;
            _patientBasicInfoRepository = patientBasicInfoRepository;
        }

        /// <summary>
        /// 创建血糖记录。
        /// </summary>
        /// <param name="archivesCode">基础档案信息主键。</param>
        /// <param name="input">入参。</param>
        /// <remarks>会创建血糖信息。</remarks>
        /// <returns></returns>
        /// <summary>
        /// 创建血压记录。
        /// </summary>
        /// <param name="archivesCode">基础档案信息主键。</param>
        /// <param name="input">入参。</param>
        /// <remarks>会创建血压信息。</remarks>
        /// <returns></returns>
        public async Task<BloodSugarDto> CreateAsync(string archivesCode, CreateOrUpdateBloodSugarDto input)
        {
            var patientBasicInfo = await _patientBasicInfoRepository.GetFirstAsync(x => x.ArchivesCode == archivesCode);
            var bloodlipid = input.Adapt<HT_Glucose>();
            bloodlipid.ArchivesCode = archivesCode;
            bloodlipid.ID = DateTime.Now.ToString("yyyyMMddHHmmss") + bloodlipid.ArchivesCode + new Random().Next(10, 99);//TODO：这玩意有什么特殊意义吗？ 为什么和其他表的ID生成方式不同？why？我找了俩小时
            bloodlipid.CreateArchivesUnit = patientBasicInfo?.PBI_ManageUnit;
            bloodlipid.Gender = patientBasicInfo?.PBI_Gender;
            bloodlipid.ICard = patientBasicInfo?.PBI_ICard;
            bloodlipid.UserName = patientBasicInfo?.PBI_UserName;
            bloodlipid.CreateDate = DateTime.Now;
            bloodlipid.MeasureDate =DateTime.Now;
            var result = await _repository.InsertReturnEntityAsync(bloodlipid);
            return result.Adapt<BloodSugarDto>();
        }

        /// <summary>
        /// 获取血压。
        /// </summary>
        /// <param name="archivesCode">基础档案信息主键。</param>
        /// <remarks>会获取最新当前血压。</remarks>
        /// <returns></returns>
        public async Task<BloodSugarDto> GetAsync(string archivesCode)
        {
            //TODO 查询都未添加管理组织的过滤
            var bloodLipids = await _repository.GetByArchivesCode(archivesCode);
            return bloodLipids.Adapt<BloodSugarDto>();
        }


    }
}