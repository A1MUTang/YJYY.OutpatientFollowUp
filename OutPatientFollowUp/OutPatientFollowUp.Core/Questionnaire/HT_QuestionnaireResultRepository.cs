using System.Threading.Tasks;
using SqlSugar;
using System.Linq;

namespace OutPatientFollowUp.Core;

public class HT_QuestionnaireResultRepository : BaseRepository<HT_QuestionnaireResult>, IHT_QuestionnaireResultRepository
{
    private readonly ISqlSugarClient _context;
    public HT_QuestionnaireResultRepository(ISqlSugarClient context) : base(context)
    {
        _context = context;
    }

    public async Task<HT_QuestionnaireResult> GetQuestionnaireResultByCodeAsync(string code, string patientBasicArchivesCode )
    {
        var questionnaireId = await _context.Queryable<HT_Questionnaire>().Where(x => x.Code == code).Select(it => it.Id).FirstAsync();
        var result = await _context.Queryable<HT_QuestionnaireResult>()
        .OrderByDescending(x=>x.SubmitTime)
        .Where(x => x.QuestionnaireId == questionnaireId 
        && x.PatientBasicArchivesCode == patientBasicArchivesCode).FirstAsync();
        result.QuestionResults = await _context.Queryable<HT_QuestionResult>().Where(x => x.QuestionnaireResultId == result.Id).ToListAsync();
        return result;
    }

    public async Task<bool> SaveQuestionnaireResult(HT_QuestionnaireResult input)
    {
        var result = await _context.Insertable(input).ExecuteReturnEntityAsync();
        foreach (var questionResult in input.QuestionResults)
        {
            questionResult.QuestionnaireResultId = result.Id;
        }
         await _context.Insertable<HT_QuestionResult>(input.QuestionResults).ExecuteCommandAsync();
        return true;
    }
}