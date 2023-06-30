using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Furion;
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

    public async Task<HT_Questionnaire> GetQuestionnaireByCodeAsync(string code, bool? gender)
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
            var options = await _context.Queryable<HT_Option>().Where(x => x.QuestionId == question.Id).WhereIF(gender != null, x => x.Gender == gender || x.Gender == null).ToListAsync();
            question.Options = options;
        }
        return result;
    }

    public int GetQuestionnaireIdByCodeAsync(string code)
    {
        var questionnaireId = _context.Queryable<HT_Questionnaire>().Where(x => x.Code == code).Select(it => it.Id).First();
        return questionnaireId;
    }

    public string GetQuestionnaireTitle(int QuestionnaireResultId)
    {
        var questionnaireId = _context.Queryable<HT_QuestionnaireResult>().Where(x => x.Id == QuestionnaireResultId).Select(it => it.QuestionnaireId).First();
        var questionnaireTitle = _context.Queryable<HT_Questionnaire>().Where(x => x.Id == questionnaireId).Select(it => it.Title).First();
        return questionnaireTitle;
    }

    public List<HT_Question_OutPatientFollowUp> GetQuestion(int questionnaireId)
    {
        var questionnaire = _context.Queryable<HT_Question_OutPatientFollowUp>().Where(x => x.QuestionnaireId == questionnaireId).ToList();
        return questionnaire;
    }

    public HT_Questionnaire GetQuestionnaire(int QuestionnaireResultId)
    {
        var questionnaireId = _context.Queryable<HT_QuestionnaireResult>().Where(x => x.Id == QuestionnaireResultId).Select(it => it.QuestionnaireId).First();
        var questionnaire = _context.Queryable<HT_Questionnaire>().Where(x => x.Id == questionnaireId).First();
        return questionnaire;
    }
}

public static class HT_QuestionnaireRepositoryExtensions
{
    public static int GetQuestionnaireIdByCodeAsync(string code)
    {
        var questionnaireId = App.GetService<IHT_QuestionnaireRepository>().GetQuestionnaireIdByCodeAsync(code);
        return questionnaireId;
    }

    public static string GetQuestionnaireTitle(int QuestionnaireResultId)
    {
        var questionnaireTitle = App.GetService<IHT_QuestionnaireRepository>().GetQuestionnaireTitle(QuestionnaireResultId);
        return questionnaireTitle;
    }
    

    public static HT_Questionnaire GetQuestionnaire(int QuestionnaireResultId)
    {
        var questionnaire = App.GetService<IHT_QuestionnaireRepository>().GetQuestionnaire(QuestionnaireResultId);
        return questionnaire;
    }

    public static List<HT_Question_OutPatientFollowUp> GetQuestion(int questionnaireId)
    {
        var questionnaireTitle = App.GetService<IHT_QuestionnaireRepository>().GetQuestion(questionnaireId);
        return questionnaireTitle;
    }
}

