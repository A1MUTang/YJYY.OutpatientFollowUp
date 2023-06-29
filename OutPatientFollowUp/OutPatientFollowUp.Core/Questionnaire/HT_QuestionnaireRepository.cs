using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Furion.FriendlyException;
using SqlSugar;

namespace OutPatientFollowUp.Core;

public class HT_QuestionnaireRepository : BaseRepository<HT_Questionnaire>, IHT_QuestionnaireRepository
{
    private readonly ISqlSugarClient _context;
    public HT_QuestionnaireRepository(ISqlSugarClient dbContext) : base(dbContext)
    {
        _context = dbContext;
    }

    public async Task<HT_Questionnaire> GetQuestionnaireByCodeAsync(string code,bool? gender )
    {
        var result = await _context.Queryable<HT_Questionnaire>().Where(x => x.Code == code).FirstAsync();
        if (result == null)
        {
            throw Oops.Oh("未找到该问卷");
        }
        result.Questions = await _context.Queryable<HT_Question_OutPatientFollowUp>().Where(x => x.QuestionnaireId == result.Id).ToListAsync();
        int noNumber = 1;
        foreach (var question in result.Questions)
        {
            question.Title = question.Title = $"{noNumber++}.{question.Title}";
            var options = await _context.Queryable<HT_Option>().Where(x => x.QuestionId == question.Id).WhereIF(gender != null,x => x.Gender == gender || x.Gender == null).ToListAsync();
            question.Options = options;
        }
        return result;
    }

}