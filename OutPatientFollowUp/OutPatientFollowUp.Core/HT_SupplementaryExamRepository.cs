using System.Threading.Tasks;
using Furion;
using SqlSugar;

namespace OutPatientFollowUp.Core;

public class HT_SupplementaryExamRepository:BaseRepository<HT_SupplementaryExam>,IHT_SupplementaryExamRepository
{
    private readonly ISqlSugarClient _context;

    public HT_SupplementaryExamRepository(ISqlSugarClient context) : base(context)
    {
        _context = context;
    }

    public Task<HT_SupplementaryExam> GetByArchivesCode(string archivesCode)
    {
       return _context.Queryable<HT_SupplementaryExam>().Where(x => x.ArchivesCode == archivesCode).OrderByDescending(x=>x.CreateTime).FirstAsync();
    }



    public Task<HT_SupplementaryExam> GetByArchivesCodeAndExamType(string archivesCode)
    {
        return _context.Queryable<HT_SupplementaryExam>().Where(x => x.ArchivesCode == archivesCode).OrderByDescending(x => x.CreateTime).FirstAsync();
    }



    

}
public static class HT_SupplementaryExamRepositoryExtensions
{
}
