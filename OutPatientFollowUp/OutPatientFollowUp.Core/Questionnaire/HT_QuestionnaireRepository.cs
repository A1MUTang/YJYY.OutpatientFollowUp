using System.Threading.Tasks;
using SqlSugar;

namespace OutPatientFollowUp.Core;

public class HT_QuestionnaireRepository : BaseRepository<HT_Questionnaire>, IHT_QuestionnaireRepository
{
    private readonly ISqlSugarClient _context;
    public HT_QuestionnaireRepository(ISqlSugarClient dbContext) : base(dbContext)
    {
        _context = dbContext;
    }

    public async Task<HT_Questionnaire> GetQuestionnaireByCodeAsync(string code)
    {
        var result = await _context.Queryable<HT_Questionnaire>().Where(x => x.Code == code).FirstAsync();
        result.Questions = await _context.Queryable<HT_Question>().Where(x => x.QuestionnaireId == result.Id).ToListAsync();
        foreach (var question in result.Questions)
        {
            question.Options = await _context.Queryable<HT_Options>().Where(x => x.QuestionId == question.Id).ToListAsync();
        }
        return await _context.Queryable<HT_Questionnaire>().Where(x => x.Code == code).FirstAsync();
    }

}