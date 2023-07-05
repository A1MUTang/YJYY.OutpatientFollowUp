using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutPatientFollowUp.Core
{
    public interface IPT_MeasureEquipmentRepository : IBaseRepository<PT_EquipMentVersionManage>
    {
        public Task<List<Test>> GetUpdateInfo(string eqpNo, string apkType, string parentName, string unitName);
    }
}