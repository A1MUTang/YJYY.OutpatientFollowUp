using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application;

public class QuestionnaireMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<QuestionnaireDto, HT_Questionnaire>()
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.EstimatedTime, src => src.EstimatedTime)
            .Map(dest => dest.Questions, src => src.Questions);

        config.ForType<QuestionDto, HT_Question_OutPatientFollowUp>()
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.Options, src => src.Options);

        config.ForType<OptionsDto, HT_Option>()
            .Map(dest => dest.Content, src => src.Content);

        config.ForType<List<HT_QuestionResult>, QuestionResultDto>()
            .Map(dest => dest, src => QuestionResultDto(src));

        config.ForType<SurveySubmissionDto, HT_QuestionnaireResult>()
            .Map(dest => dest.PatientBasicArchivesCode, src => src.PatientBasicArchivesCode)
            .Map(dest => dest.QuestionnaireId, src => HT_QuestionnaireRepositoryExtensions.GetQuestionnaireIdByCodeAsync(src.QuestionnaireCode))
            .Map(dest => dest.QuestionResults, src => src.QuestionSubmissions);

        config.ForType<QuestionSubmissionDto, HT_QuestionResult>()
            .Map(dest => dest.QuestionId, src => src.QuestionId)
            .Map(dest => dest.Answer, src => src.AnswerText)
            .Ignore(dest => dest.QuestionnaireResultId);
    }


    public static QuestionResultDto QuestionResultDto(List<HT_QuestionResult> questionResult)
    {
        return new QuestionResultDto()
        {
            Title = HT_QuestionnaireRepositoryExtensions.GetQuestionnaireTitle(questionResult.First().QuestionnaireResultId),
            ResultCode = GetQuestionnaireResultCode(questionResult),
            Result = GetQuestionnaireResult(questionResult),
            HealthAdvice = GetHealthAdvice(questionResult),
        };


    }

    public static List<string> GetHealthAdvice(List<HT_QuestionResult> questionResults)
    {
        // 需要添加年龄判断，从档案信息中拿到年龄，通过问卷结果Id拿到当前问卷人
        var archivesCode = HT_QuestionnaireResultRepositoryExtensions.GetQuestionPatientBasicArchivesCode(questionResults.First().QuestionnaireResultId);
        var patient = HT_PatientBasicInfoRepositoryExtensions.GetByArchivesCode(archivesCode);
        var age = ProfileInformationDetailTool.GetAgeFromIdCard(patient.PBI_ICard);
        var gender = patient.PBI_Gender == "1";
        var isASCVD = GetASCVDResult(questionResults); //是否ASCVD
        var isDiabetes = GetDiabetesState(questionResults); //是否糖尿病
        var bloodLipidLevel = GetBloodLipidLevel(questionResults); //血脂水平
        var remainingLifeRiskFactor = GetRemainingLifeRiskFactor(questionResults); //余生危险因素
        var riskFactor = GetRiskFactor(questionResults, age, gender); //危险因素
        return GetHealthAdvice(age, isASCVD, isDiabetes, bloodLipidLevel, remainingLifeRiskFactor, riskFactor);
    }

    /// <summary>
    /// 健康建议
    /// </summary>
    /// <param name="age">年龄</param>
    /// <param name="isASCVD">ASCVD</param>
    /// <param name="isDiabetes">是否有糖尿病</param>
    /// <param name="bloodLipidLevel">血脂水平</param>
    /// <param name="remainingLifeRiskFactor">余生危险因素</param>
    /// <param name="riskFactor">危险因素</param>
    /// <returns></returns>
    private static List<string> GetHealthAdvice(int age, bool isASCVD, bool isDiabetes, int bloodLipidLevel, int remainingLifeRiskFactor, int riskFactor)
    {
        var result = new List<string>();
        result.Add(GetStrokeRiskAssessmentHealthAdvice(age, isASCVD, isDiabetes, bloodLipidLevel, remainingLifeRiskFactor, riskFactor));
        return result;
    }

    private static string GetStrokeRiskAssessmentHealthAdvice(int age, bool isASCVD, bool isDiabetes, int bloodLipidLevel, int remainingLifeRiskFactor, int riskFactor)
    {
        var resultCode = GetResultCode(age, isASCVD, isDiabetes, bloodLipidLevel, remainingLifeRiskFactor, riskFactor);
        switch (resultCode)
        {
            //低危或中危
            case 0:
                return "LDL-C<3.4mmol/L;LDL-C基线值较高不能达目标值者基线值较高不能达目标值者，LDL-C至少降低50%";
            case 1:
                return age < 55 ?
                    remainingLifeRiskFactor >= 2 ?
                    "LDL-C<2.6mmol/L;LDL-C基线值较高不能达目标值者基线值较高不能达目标值者，LDL-C至少降低50%"
                    : "LDL-C<3.4mmol/L;LDL-C基线值较高不能达目标值者基线值较高不能达目标值者，LDL-C至少降低50%"
                : "LDL-C<3.4mmol/L;LDL-C基线值较高不能达目标值者基线值较高不能达目标值者，LDL-C至少降低50%";
            //高危
            case 2:
                return "LDL-C<2.6 mmol/L;LDL--C基线值较高不能达目标值者基线值较高不能达目标值者，LDL-C至少降低50%";
            case 3:
                return "LDL-C<1.8mmol/L;LDL-C基线值较高不能达目标值者基线值较高不能达目标值者，LDL-C至少降低50%;患者患者LDL--CC基线在目标值以内者LDL-c至少降低30%左右";

        }
        return "";
    }

    public static string GetQuestionnaireResultCode(List<HT_QuestionResult> questionResults)
    {
        // 需要添加年龄判断，从档案信息中拿到年龄，通过问卷结果Id拿到当前问卷人
        var archivesCode = HT_QuestionnaireResultRepositoryExtensions.GetQuestionPatientBasicArchivesCode(questionResults.First().QuestionnaireResultId);
        var patient = HT_PatientBasicInfoRepositoryExtensions.GetByArchivesCode(archivesCode);
        var age = ProfileInformationDetailTool.GetAgeFromIdCard(patient.PBI_ICard);
        var gender = patient.PBI_Gender == "1";
        var isASCVD = GetASCVDResult(questionResults); //是否ASCVD
        var isDiabetes = GetDiabetesState(questionResults); //是否糖尿病
        var bloodLipidLevel = GetBloodLipidLevel(questionResults); //血脂水平
        var remainingLifeRiskFactor = GetRemainingLifeRiskFactor(questionResults); //余生危险因素
        var riskFactor = GetRiskFactor(questionResults, age, gender); //危险因素
        return GetResultCode(age, isASCVD, isDiabetes, bloodLipidLevel, remainingLifeRiskFactor, riskFactor).ToString();
    }

    public static string GetQuestionnaireResult(List<HT_QuestionResult> questionResults)
    {
        // 需要添加年龄判断，从档案信息中拿到年龄，通过问卷结果Id拿到当前问卷人
        var archivesCode = HT_QuestionnaireResultRepositoryExtensions.GetQuestionPatientBasicArchivesCode(questionResults.First().QuestionnaireResultId);
        var patient = HT_PatientBasicInfoRepositoryExtensions.GetByArchivesCode(archivesCode);
        var age = ProfileInformationDetailTool.GetAgeFromIdCard(patient.PBI_ICard);
        var gender = patient.PBI_Gender == "1";
        var isASCVD = GetASCVDResult(questionResults); //是否ASCVD
        var isDiabetes = GetDiabetesState(questionResults); //是否糖尿病
        var bloodLipidLevel = GetBloodLipidLevel(questionResults); //血脂水平
        var remainingLifeRiskFactor = GetRemainingLifeRiskFactor(questionResults); //余生危险因素
        var riskFactor = GetRiskFactor(questionResults, age, gender); //危险因素
        //使用降压药  暂时未用到该问题
        var useAntihypertensiveDrugs = getAnswer("使用降压药", questionResults);
        return GetResult(age, isASCVD, isDiabetes, bloodLipidLevel, remainingLifeRiskFactor, riskFactor);

    }

    private static int GetResultCode(int age, bool isASCVD, bool isDiabetes, int bloodLipidLevel, int remainingLifeRiskFactor, int riskFactor)
    {
        if (isASCVD)
            return 3;// highRisk + "极高危";
        if (bloodLipidLevel == 4
        || (isDiabetes && age > 40)
        || (bloodLipidLevel >= 1 && bloodLipidLevel <= 3 && riskFactor == 3)
        || (bloodLipidLevel == 2 || bloodLipidLevel == 3 && riskFactor >= 2 && riskFactor <= 3))
        {
            return 2;// highRisk + "高危";
        }
        if ((bloodLipidLevel == 1 && riskFactor == 2)
        || (bloodLipidLevel == 2 || bloodLipidLevel == 3 && riskFactor == 1))
        {
            return 1;
        }
        return 0;
    }


    /// <summary>
    /// 评估结果
    /// </summary>
    /// <param name="age">年龄</param>
    /// <param name="isASCVD">ASCVD</param>
    /// <param name="isDiabetes">是否有糖尿病</param>
    /// <param name="bloodLipidLevel">血脂水平</param>
    /// <param name="remainingLifeRiskFactor">余生危险因素</param>
    /// <param name="riskFactor">危险因素</param>
    /// <returns></returns>
    private static string GetResult(int age, bool isASCVD, bool isDiabetes, int bloodLipidLevel, int remainingLifeRiskFactor, int riskFactor)
    {
        // 分层为极高危和单纯高危时，ASCVD10年危险评估替换为总体心血管危险评估:总体心血管危险评估：高危 or  总体心血管危险评估：极高危 
        //高危及以上返回值
        var highRisk = "1.ASCVD10年危险评估：";
        //中危及以下返回值
        var lowRisk = "1.总体心血管危险评估：";
        var resultLevel = GetResultCode(age, isASCVD, isDiabetes, bloodLipidLevel, remainingLifeRiskFactor, riskFactor);
        switch (resultLevel)
        {
            case 3:
                return highRisk + "极高危";
            case 2:
                return highRisk + "高危";
            case 1:
                return lowRisk + "中危";
            case 0:
                return lowRisk + "低危";
        }
        return "";
    }

    private static int GetRiskFactor(List<HT_QuestionResult> questionResult, int age, bool gender)
    {
        var riskFactor = 0;
        var hdlc = getAnswer("HDL-C", questionResult);
        if (hdlc == "≥1.0mmol/L")
        {
            riskFactor++;
        }
        var smoking = getAnswer("吸烟或被动吸烟", questionResult);
        if (smoking == "是")
        {
            riskFactor++;
        }
        //男性≥45岁或女性≥55岁	，危险因素	+1
        if (gender)
        {
            if (age >= 45)
            {
                riskFactor++;
            }
        }
        else
        {
            if (age >= 55)
            {
                riskFactor++;
            }
        }


        return riskFactor;
    }

    /// <summary>
    /// 获取余生危险因素
    /// </summary>
    /// <param name="questionResult"></param>
    /// <returns></returns>
    private static int GetRemainingLifeRiskFactor(List<HT_QuestionResult> questionResult)
    {
        var remainingLifeRiskFactor = 0;
        //BMI≥28kg/m余生危险因素	+1
        var height = int.Parse(getAnswer("身高", questionResult));
        var weight = int.Parse(getAnswer("体重", questionResult));

        var bmi = GetBMI(height, weight);
        if (bmi >= 28)
            remainingLifeRiskFactor++;

        //吸烟或被动吸烟“是”	危险因素	+1，余生危险因素	+1
        var smoking = getAnswer("吸烟或被动吸烟", questionResult);
        if (smoking == "是")
            remainingLifeRiskFactor++;

        //血压 2级以上血压	余生危险因素	+1
        //修改为血压_收缩压，血压_舒张压
        //血压_收缩压
        var systolicBloodPressure = getAnswer("血压_收缩压", questionResult);
        //血压_舒张压
        var diastolicBloodPressure = getAnswer("血压_舒张压", questionResult);
        //如何判断是否是二级高血压 二级   160-179 || 100-109 source:兵兵
        if (int.Parse(systolicBloodPressure) >= 160 || int.Parse(diastolicBloodPressure) >= 100)
            remainingLifeRiskFactor++;

        //HDL-C <1.0mmol/L<1.0mmol/L危险因素+1，余生危险因素+1   ≥1.01.0mmol/L
        var hdlc = getAnswer("HDL-C", questionResult);
        if (hdlc == "<1.0mmol/L")
        {
            remainingLifeRiskFactor++;
        }

        //非-HDL-C ≥ 5.25.2  mmol/L 余生危险因素+1
        var nonHdlc = getAnswer("非-HDL-C", questionResult);
        if (nonHdlc == "≥5.2mmol/L")
            remainingLifeRiskFactor++;
        return remainingLifeRiskFactor;
    }

    /// <summary>
    /// 获取是否有糖尿病
    /// </summary>
    /// <param name="questionResult"></param>
    /// <param name="isDiabetes"></param>
    /// <returns></returns>
    private static bool GetDiabetesState(List<HT_QuestionResult> questionResult)
    {
        var isDiabetes = false;
        //使用降糖药物选“是	”糖尿病	;选蓝色中任意一个	糖尿病  ，满足任意条件即使糖尿病//TODO: 还没写
        var useAntidiabeticDrugs = getAnswer("使用降糖药物", questionResult);
        //空腹血糖  ≥≥7.0mmol/L7.0mmol/L    糖尿病
        var fastingBloodGlucose = getAnswer("空腹血糖", questionResult);
        //餐后2小时血糖 ≥≥11.1mmol/L11.1mmol/L   糖尿病
        var postprandialBloodGlucose = getAnswer("餐后2小时血糖", questionResult);
        if (useAntidiabeticDrugs == "是")
            isDiabetes = true;
        else if (fastingBloodGlucose == "是")
            isDiabetes = true;
        else if (postprandialBloodGlucose == "是")
            isDiabetes = true;
        //糖尿病 有 糖尿病
        var diabetes = getAnswer("糖尿病", questionResult);
        if (diabetes == "有")
            isDiabetes = true;
        return isDiabetes;
    }

    /// <summary>
    /// 获取血脂水平
    /// </summary>
    /// <param name="questionResult"></param>
    /// <returns></returns>
    private static int GetBloodLipidLevel(List<HT_QuestionResult> questionResult)
    {

        var bloodLipidLevel = 0;
        //血脂水平 
        //TC 3.13.1≤TC<4.1水平1;4.14.1≤TC<5.TC<5.2 水平2;5.25.2≤TC<7.2TC<7.2 血脂水平3;≥7.2mmol/L 血脂水平4
        //LDL-C 1.81.8≤LDL--C<2.6C<2.6 水平1;2.6LDL--C<3.4C 水平2;3.4≤LDL--C<4.1C 水平3;≥4.1mmol/L 水平4
        var tc = getAnswer("TC", questionResult);
        var ldlc = getAnswer("LDL-C", questionResult);
        //同时判断TC和LDL-C，优先判断水平高的
        if (tc == "≥7.2mmol/L" || ldlc == "≥4.1mmol/L")
            bloodLipidLevel = 4;
        else if (tc == "5.2≤TC<7.2" || ldlc == "3.4≤LDL--C<4.1C")
            bloodLipidLevel = 3;
        else if (tc == "4.1≤TC<5.2" || ldlc == "2.6LDL--C<3.4C")
            bloodLipidLevel = 2;
        else if (tc == "3.13.1≤TC<4.1" || ldlc == "1.81.8≤LDL--C<2.6C")
            bloodLipidLevel = 1;

        return bloodLipidLevel;

    }

    /// <summary>
    /// 获取是否有ASCVD
    /// </summary>
    /// <param name="questionResult"></param>
    /// <returns></returns>
    private static bool GetASCVDResult(List<HT_QuestionResult> questionResult)
    {
        var isASCVD = false;
        //缺血性脑卒中 有 ASCVD 满足其中一个条件就是ASCVD //TODO: 还没写
        var ischemicStroke = getAnswer("缺血性脑卒中", questionResult);
        //短暂性脑缺血发作 有 ASCVD
        var transientIschemicAttack = getAnswer("短暂性脑缺血发作", questionResult);
        //心肌梗死史 有 ASCVD
        var myocardialInfarction = getAnswer("心肌梗死史", questionResult);
        //心绞痛 有 ASCVD
        var anginaPectoris = getAnswer("心绞痛", questionResult);
        //冠状动脉血运重建 有 ASCVD
        var coronaryArteryBypassGrafting = getAnswer("冠状动脉血运重建", questionResult);
        //外周血管疾病 有 ASCVD
        var peripheralVascularDisease = getAnswer("外周血管疾病", questionResult);

        if (ischemicStroke == "有" || transientIschemicAttack == "有" || myocardialInfarction == "有" || anginaPectoris == "有" || coronaryArteryBypassGrafting == "有" || peripheralVascularDisease == "有")
            isASCVD = true;
        return isASCVD;
    }

    private static string getAnswer(string title, List<HT_QuestionResult> questionResult)
    {
        //查询问卷题目
        var questions = HT_QuestionnaireRepositoryExtensions.GetQuestion(questionResult.FirstOrDefault().QuestionnaireResultId);
        var answerQuestionId = questions.Where(x => x.Title == title).FirstOrDefault().Id;
        var answer = questionResult.Where(x => x.QuestionId == answerQuestionId).FirstOrDefault().Answer;

        return answer;
    }

    public static double GetBMI(int height, int weight)
    {
        return weight / (height * height);
    }
}