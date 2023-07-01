using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using SqlSugar;
using System.Linq;
using Furion;

namespace OutPatientFollowUp.Core;

public class HT_QuestionnaireResultRepository : BaseRepository<HT_QuestionnaireResult>, IHT_QuestionnaireResultRepository
{
    private readonly ISqlSugarClient _context;
    public HT_QuestionnaireResultRepository(ISqlSugarClient context) : base(context)
    {
        _context = context;
    }

    public async Task<HT_QuestionnaireResult> GetQuestionnaireResultByCodeAsync(string code, string patientBasicArchivesCode)
    {
        var questionnaireId = await _context.Queryable<HT_Questionnaire>().Where(x => x.Code == code).Select(it => it.Id).FirstAsync();
        var result = await _context.Queryable<HT_QuestionnaireResult>()
        .OrderByDescending(x => x.SubmitTime)
        .Where(x => x.QuestionnaireId == questionnaireId
        && x.PatientBasicArchivesCode == patientBasicArchivesCode).FirstAsync();
        result.QuestionResults = await _context.Queryable<HT_QuestionResult>().Where(x => x.QuestionnaireResultId == result.Id).ToListAsync();
        return result;
    }

    public async Task<bool> SaveQuestionnaireResult(HT_QuestionnaireResult input)
    {
        var result = await _context.Insertable<HT_QuestionnaireResult>(input).ExecuteReturnEntityAsync();
        foreach (var questionResult in input.QuestionResults)
        {
            questionResult.QuestionnaireResultId = result.Id;
        }
        await _context.Insertable<HT_QuestionResult>(input.QuestionResults.ToList()).ExecuteCommandAsync();
        return true;
    }

    public string GetQuestionResult(int QuestionnaireResultId)
    {
        var questionResult = _context.Queryable<HT_QuestionnaireResult>().Where(x => x.Id == QuestionnaireResultId).First();
        return questionResult.PatientBasicArchivesCode;
    }

    public int GetQuestionnaireIdByIdAsync(int questionnaireResultId)
    {
        var questionnaireId = _context.Queryable<HT_QuestionnaireResult>().Where(x => x.Id == questionnaireResultId).Select(it => it.QuestionnaireId).First();
        return questionnaireId;
    }

    public List<HT_QuestionResult> GetHT_QuestionResults(int QuestionnaireResultId)
    {
        var questionResults = _context.Queryable<HT_QuestionResult>().Where(x => x.QuestionnaireResultId == QuestionnaireResultId).ToList();
        return questionResults;
    }

}

public static class HT_QuestionnaireResultRepositoryExtensions
{
    public static string GetQuestionPatientBasicArchivesCode(int QuestionnaireResultId)
    {
        var result = App.GetService<IHT_QuestionnaireResultRepository>().GetQuestionResult(QuestionnaireResultId);
        return result;
    }

    public static List<HT_QuestionResult> GetHT_QuestionResults(int QuestionnaireResultId)
    {
        var result = App.GetService<IHT_QuestionnaireResultRepository>().GetHT_QuestionResults(QuestionnaireResultId);
        return result;
    }

    public static int GetQuestionnaireIdByIdAsync(int questionnaireResultId)
    {
        var result = App.GetService<IHT_QuestionnaireResultRepository>().GetQuestionnaireIdByIdAsync(questionnaireResultId);
        return result;
    }


}
