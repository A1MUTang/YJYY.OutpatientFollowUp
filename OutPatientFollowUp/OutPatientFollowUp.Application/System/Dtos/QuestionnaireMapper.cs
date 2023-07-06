using System.Data;
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
    public static string GetQuestionnaireResultCode(List<HT_QuestionResult> questionResults)
    {
        var questionnaire = HT_QuestionnaireRepositoryExtensions.GetQuestionnaire(questionResults.First().QuestionnaireResultId);

        switch (questionnaire.Code)
        {
            case "CardiovascularRiskAssessment":
                return GetCardiovascularRiskAssessmentResultCode(questionResults).ToString();
            case "StrokeRiskAssessment":
                return GetStrokeRiskAssessmentResultCode(questionResults).ToString();
            case "CopdRiskAssessment":
                return GetCopdRiskAssessmentResultCode(questionResults).ToString();
            case "DiabetesRiskAssessment":
                return GetDiabetesRiskAssessmentResultCode(questionResults).ToString();
            default:
                return "未知问卷";
        }

    }

    public static string GetQuestionnaireResult(List<HT_QuestionResult> questionResults)
    {
        var questionnaire = HT_QuestionnaireRepositoryExtensions.GetQuestionnaire(questionResults.First().QuestionnaireResultId);
        switch (questionnaire.Code)
        {
            case "CardiovascularRiskAssessment":
                return GetCardiovascularRiskAssessmentResult(questionResults);
            case "StrokeRiskAssessment":
                return GetStrokeRiskAssessmentResult(questionResults);
            case "CopdRiskAssessment":
                return GetCopdRiskAssessmentResult(questionResults);
            case "DiabetesRiskAssessment":
                return GetDiabetesRiskAssessmentResult(questionResults);
            default:
                return "未知问卷";
        }
    }

    public static List<string> GetHealthAdvice(List<HT_QuestionResult> questionResults)
    {
        var questionnaire = HT_QuestionnaireRepositoryExtensions.GetQuestionnaire(questionResults.First().QuestionnaireResultId);
        switch (questionnaire.Code)
        {
            case "CardiovascularRiskAssessment":
                return GetCardiovascularRiskHealthAdvice(questionResults);
            case "StrokeRiskAssessment":
                return GetStrokeRiskAssessmentHealthAdvice(questionResults);
            case "CopdRiskAssessment":
                return GetCopdRiskAssessmentHealthAdvice(questionResults);
            case "DiabetesRiskAssessment":
                return GetDiabetesRiskAssessmentHealthAdvice(questionResults);
            default:
                return new List<string>() { "未知问卷" };
        }

    }
    private static string GetDiabetesRiskAssessmentResult(List<HT_QuestionResult> questionResults)
    {
        var score = GetDiabetesRiskAssessmentScore(questionResults);
        // ≥25	高风险
        // ＜25	非高风险
        if (score >= 25)
            return "高风险";
        else
            return "非高风险";
    }


    private static List<string> GetDiabetesRiskAssessmentHealthAdvice(List<HT_QuestionResult> questionResults)
    {
        var score = GetDiabetesRiskAssessmentScore(questionResults);
        // ≥25	建议进行口服葡萄糖耐量试验检查来筛查糖尿病建议进行口服葡萄糖耐量试验检查来筛查糖尿病	。。
        // ＜25	建议至少每建议至少每	33年应该重复筛查一次年应该重复筛查一次	。。如状态变化较大如状态变化较大	，，可增加筛查次数可增加筛查次数	。。
        if (score >= 25)
            return new List<string>() { "建议进行口服葡萄糖耐量试验检查来筛查糖尿病。" };
        else
            return new List<string>() { "建议至少每3年应该重复筛查一次。如状态变化较大，可增加筛查次数。" };
    }

    private static int GetDiabetesRiskAssessmentResultCode(List<HT_QuestionResult> questionResults)
    {
        var score = GetDiabetesRiskAssessmentScore(questionResults);
        // ≥25	高风险
        // ＜25	非高风险
        if (score >= 25)
            return 1;
        else
            return 0;
    }

    private static decimal GetDiabetesRiskAssessmentScore(List<HT_QuestionResult> questionResults)
    {
        //年龄
        var age = GetAnswer("年龄（岁）", questionResults);
        //收缩压（mmHg）
        var systolicBloodPressure = GetAnswer("收缩压（mmHg）", questionResults);
        //身高（cm）
        var height = Convert.ToDecimal(GetAnswer("身高（cm）", questionResults));
        //体重（kg）
        var weight = Convert.ToDecimal(GetAnswer("体重（kg）", questionResults));
        //腰围（cm）
        var waistline = GetAnswer("腰围（cm）", questionResults);
        //糖尿病家族史（父母、同胞、子女）
        var diabetesFamilyHistory = GetAnswer("糖尿病家族史（父母、同胞、子女）", questionResults);

        var ageScore = GetDiabetesRiskAssessmentAgeScore(age);
        var systolicBloodPressureScore = GetDiabetesRiskAssessmentSystolicBloodPressureScore(systolicBloodPressure);
        var bmiScore = GetDiabetesRiskAssessmentBmiScore(height, weight);
        var archivesCode = HT_QuestionnaireResultRepositoryExtensions.GetQuestionPatientBasicArchivesCode(questionResults.First().QuestionnaireResultId);
        var patient = HT_PatientBasicInfoRepositoryExtensions.GetByArchivesCode(archivesCode);
        var gender = patient.PBI_Gender == "1";
        var waistlineScore = 0m;
        if (gender)
            waistlineScore = GetDiabetesRiskAssessmentWaistlineScoreMan(waistline);
        else
            waistlineScore = GetDiabetesRiskAssessmentWaistlineScoreWoman(waistline);
        var diabetesFamilyHistoryScore = GetDiabetesFamilyHistoryScore(diabetesFamilyHistory);

        int genderScore = gender ? 2 : 0;

        var sumScore = ageScore + systolicBloodPressureScore + bmiScore + waistlineScore + diabetesFamilyHistoryScore + genderScore;

        return sumScore;
    }

    private static int GetDiabetesFamilyHistoryScore(string diabetesFamilyHistory)
    {
        // 无
        // 有
        switch (diabetesFamilyHistory)
        {
            case "无":
                return 0;
            case "有":
                return 6;
            default:
                return 0;
        }
    }

    private static decimal GetDiabetesRiskAssessmentWaistlineScoreWoman(string waistline)
    {
        // 女:<70.0
        // 女:70.0~74.9
        // 女:75.0~79.9
        // 女:80.0~84.9
        // 女:85.0~89.9
        // 女:≥90.0
        switch (waistline)
        {
            case "<70.0":
                return 0;
            case "70.0~74.9":
                return 3;
            case "75.0~79.9":
                return 5;
            case "80.0~84.9":
                return 7;
            case "85.0~89.9":
                return 8;
            case "≥90.0":
                return 10;
            default:
                return 0;
        }
    }

    private static decimal GetDiabetesRiskAssessmentWaistlineScoreMan(string waistline)
    {
        // 男:<75.0 
        // 男:75.0~79.9 
        // 男:80.0~84.9 
        // 男:85.0~89.9 
        // 男:90.0~94.9 
        // 男:≥95.0 
        switch (waistline)
        {
            case "<75.0":
                return 0;
            case "75.0~79.9":
                return 3;
            case "80.0~84.9":
                return 5;
            case "85.0~89.9":
                return 7;
            case "90.0~94.9":
                return 8;
            case "≥95.0":
                return 10;
            default:
                return 0;
        }
    }

    private static int GetDiabetesRiskAssessmentBmiScore(decimal height, decimal weight)
    {
        // 体质指数：<22.0  得分：0
        // 体质指数：22.0~23.9  得分：1
        // 体质指数：24.0~29.9  得分：3
        // 体质指数：≥30.0  得分：5
        var bim = GetBMI(height, weight);
        if (bim < 22.0m)
        {
            return 0;
        }
        else if (bim >= 22.0m && bim <= 23.9m)
        {
            return 1;
        }
        else if (bim >= 24.0m && bim <= 29.9m)
        {
            return 3;
        }
        else if (bim >= 30.0m)
        {
            return 5;
        }
        else
        {
            throw Oops.Oh("BMI错误");
        }
    }

    private static int GetDiabetesRiskAssessmentSystolicBloodPressureScore(string systolicBloodPressure)
    {
        // <110	0
        // 110~119	1
        // 120~129	3
        // 130~139	6
        // 140~149	7
        // 150~159	8
        // ≥160	10

        switch (systolicBloodPressure)
        {
            case "<110":
                return 0;
            case "110~119":
                return 1;
            case "120~129":
                return 3;
            case "130~139":
                return 6;
            case "140~149":
                return 7;
            case "150~159":
                return 8;
            case "≥160":
                return 10;
            default:
                throw Oops.Oh("收缩压错误");
        }
    }

    private static int GetDiabetesRiskAssessmentAgeScore(string age)
    {
        // 20~24
        // 25~34
        // 35~39
        // 40~44
        // 45~49
        // 50~54
        // 55~59
        // 60~64
        // 65~74

        switch (age)
        {
            case "20~24":
                return 0;
            case "25~34":
                return 4;
            case "35~39":
                return 8;
            case "40~44":
                return 11;
            case "45~49":
                return 12;
            case "50~54":
                return 13;
            case "55~59":
                return 15;
            case "60~64":
                return 16;
            case "65~74":
                return 18;
            default:
                throw Oops.Oh("年龄错误");
        }
    }

    private static List<string> GetCopdRiskAssessmentHealthAdvice(List<HT_QuestionResult> questionResults)
    {
        var source = GetCopdRiskAssessmentScore(questionResults);
        if (source <= 4)
            return new List<string>() { "如有呼吸问题可咨询医生，医生会帮助评估您的呼吸问题的类型" };
        if (source >= 5)
            return new List<string>() { "您的呼吸问题可能是慢性阻塞性肺疾病(慢阻肺)导致，建议进行肺功能检查" }; 
        throw Oops.Oh("未知错误");
    }

    private static List<string> GetStrokeRiskAssessmentHealthAdvice(List<HT_QuestionResult> questionResults)
    {
        //十年卒中风险率
        var tenYearStrokeRiskRate = GetTenYearStrokeRiskRate(questionResults);
        
        switch (GetStrokeRiskAssessmentResultCode(questionResults))
        {
            case 0:
                return new List<string>() { tenYearStrokeRiskRate !=0?$"10年卒中风险 {tenYearStrokeRiskRate}%。建议您健康饮食、适当运动、避免肥胖、戒烟限酒、定期体检。":"" + $"建议您健康饮食、适当运动、避免肥胖、戒烟限酒、定期体检。" };
            case 1:
                return new List<string>() { tenYearStrokeRiskRate !=0?$"10年卒中风险 {tenYearStrokeRiskRate}%。建议您健康饮食、适当运动、避免肥胖、戒烟限酒、定期体检。":"" + $"建议您健康饮食、适当运动、避免肥胖、戒烟限酒、定期体检。" };
            case 2:
                return new List<string>() { tenYearStrokeRiskRate !=0?$"10年卒中风险 {tenYearStrokeRiskRate}%。建议您健康饮食、适当运动、避免肥胖、戒烟限酒、定期体检。":"" + $"建议您及时到医院相关门诊或病区，在专家指导下行相应检查和规范干预治疗。" };
            default:
                return new List<string>() { "未知" };
        }
        
    }

    private static List<string> GetCardiovascularRiskHealthAdvice(List<HT_QuestionResult> questionResults)
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
        var useAntihypertensiveDrugs = GetUseAntihypertensiveDrugs(questionResults);//使用降压药  

        return GetHealthAdvice(age, isASCVD, isDiabetes, bloodLipidLevel, remainingLifeRiskFactor, riskFactor, useAntihypertensiveDrugs);
    }

    private static object GetCopdRiskAssessmentResultCode(List<HT_QuestionResult> questionResults)
    {
        var source = GetCopdRiskAssessmentScore(questionResults);
        if (source <= 4)
            return 0;
        if (source >= 5)
            return 1;
        throw Oops.Oh("未知错误");
    }

    private static int GetCopdRiskAssessmentScore(List<HT_QuestionResult> questionResults)
    {
        //您的年龄？
        var age = GetAnswer("您的年龄？", questionResults);
        //在您的生命中，您是否已经至少吸了 100 支烟？
        var isSmoking = GetAnswer("在您的生命中，您是否已经至少吸了 100 支烟？", questionResults);
        //过去1个月内，您感到气短有多频繁？
        var isShortnessOfBreath = GetAnswer("过去 1 个月内，您感到气短有多频繁？", questionResults);
        //您是否曾咳出“东西”，例如黏液或痰？
        var isCough = GetAnswer("您是否曾咳出“东西”，例如黏液或痰？", questionResults);
        //请选择能够最准确地描述您在过去 12 个月内日常生活状况的答案。因为呼吸问题，我的活动量比以前少了。
        var isActivity = GetAnswer("请选择能够最准确地描述您在过去 12 个月内日常生活状况的答案。因为呼吸问题，我的活动量比以前少了。", questionResults);

        var ageScore = GetAgeSourceRiskAssessment(age);
        var smokingScore = GetSmokingSourceRiskAssessment(isSmoking);
        var shortnessOfBreathScore = GetShortnessOfBreathSourceRiskAssessment(isShortnessOfBreath);
        var coughScore = GetCoughSourceRiskAssessment(isCough);
        var activityScore = GetActivitySourceRiskAssessment(isActivity);

        var source = ageScore + smokingScore + shortnessOfBreathScore + coughScore + activityScore;

        return source;
    }

    private static string GetCopdRiskAssessmentResult(List<HT_QuestionResult> questionResults)
    {
        var source = GetCopdRiskAssessmentScore(questionResults);
        if (source <= 4)
            return "如有呼吸问题可咨询医生";
        if (source >= 5)
            return "呼吸问题可能是慢阻肺导致";
        throw Oops.Oh("未知错误");
    }

    private static int GetActivitySourceRiskAssessment(string isActivity)
    {
        // 强烈反对
        // 反对
        // 不确定
        // 同意
        // 非常同意
        switch (isActivity)
        {
            case "强烈反对":
                return 0;
            case "反对":
                return 1;
            case "不确定":
                return 2;
            case "同意":
                return 3;
            case "非常同意":
                return 4;
            default:
                return 0;
        }
    }

    private static int GetCoughSourceRiskAssessment(string isCough)
    {
        // 从未咳出
        // 是的，但仅在偶尔感冒或胸部感染时咳出。
        // 是的，每月都咳几天。
        // 是的，大多数日子都咳。
        // 是的，每天都咳。
        switch (isCough)
        {
            case "从未咳出":
                return 0;
            case "是的，但仅在偶尔感冒或胸部感染时咳出。":
                return 1;
            case "是的，每月都咳几天。":
                return 2;
            case "是的，大多数日子都咳。":
                return 3;
            case "是的，每天都咳。":
                return 4;
            default:
                return 0;
        }
    }

    private static int GetShortnessOfBreathSourceRiskAssessment(string isShortnessOfBreath)
    {
        // 从未感觉到
        // 很少感觉气短
        // 有时感到气短
        // 经常感觉气短
        // 总是感觉气短
        switch (isShortnessOfBreath)
        {
            case "从未感觉到":
                return 0;
            case "很少感觉气短":
                return 0;
            case "有时感到气短":
                return 1;
            case "经常感觉气短":
                return 2;
            case "总是感觉气短":
                return 2;
            default:
                return 0;
        }
    }

    private static int GetSmokingSourceRiskAssessment(string isSmoking)
    {
        // 否
        // 是
        switch (isSmoking)
        {
            case "否":
                return 0;
            case "是":
                return 2;
            case "不知道":
                return 0;
            default:
                return 0;
        }
    }

    private static int GetAgeSourceRiskAssessment(string age)
    {
        // 35~49 岁
        // 50~59 岁
        // 60~69 岁
        // ≥70 岁
        switch (age)
        {
            case "35~49 岁":
                return 0;
            case "50~59 岁":
                return 1;
            case "60~69 岁":
                return 2;
            case "≥70 岁":
                return 2;
            default:
                return 0;
        }
    }




    //TODO：需要添加缓存层，一次计算需要访问数据库上百次

    /// <summary>
    /// 获取脑卒中 code
    /// </summary>
    /// <param name="questionResults"></param>
    /// <returns></returns>
    private static int GetStrokeRiskAssessmentResultCode(List<HT_QuestionResult> questionResults)
    {
        //是否高血压
        var isHypertension = GetHypertensionResult(questionResults);
        //是否吸烟
        var isSmoking = GetSmokingResult(questionResults);
        //血脂异常或未知
        var isBloodLipidAbnormal = GetBloodLipidAbnormalResult(questionResults);
        //糖尿病
        var isDiabetes = GetDiabetesResult(questionResults);
        //房颤或瓣膜性心脏病
        var isAtrialFibrillation = GetAtrialFibrillationResult(questionResults);
        //缺乏运动
        var isLackOfExercise = GetLackOfExerciseResult(questionResults);
        //有家族史 
        var isFamilyHistory = GetFamilyHistoryResult(questionResults);
        //BMI
        var bmi = GetBMIResult(questionResults);
        //八项内容中有3项及以上极为高危
        var count = 0;
        if (isHypertension)
            count++;
        if (isSmoking)
            count++;
        if (isBloodLipidAbnormal)
            count++;
        if (isDiabetes)
            count++;
        if (isAtrialFibrillation)
            count++;
        if (isLackOfExercise)
            count++;
        if (isFamilyHistory)
            count++;
        if (bmi)
            count++;
        if (count >= 3)
            return 2;
        else
        {
            if (isHypertension || isDiabetes || isAtrialFibrillation)
                return 1;
            else if (!isHypertension && !isDiabetes && !isAtrialFibrillation)
                return 0;
        }
        return 500;
        //TODO 脑卒中并未完成
    }

    private static bool GetBMIResult(List<HT_QuestionResult> questionResults)
    {
        var bmi = 0m;
        var height = Convert.ToDecimal(GetAnswer("身高", questionResults));
        var weight = Convert.ToDecimal(GetAnswer("体重", questionResults));
        bmi = weight / (height * height);
        if (bmi > 26)
            return true;

        return false;
    }

    private static bool GetFamilyHistoryResult(List<HT_QuestionResult> questionResults)
    {
        var isFamilyHistory = false;
        var ischemicStroke = GetAnswer("您是否有卒中家族史", questionResults);
        if (ischemicStroke == "是")
        {
            isFamilyHistory = true;
        }
        return isFamilyHistory;
    }

    private static bool GetLackOfExerciseResult(List<HT_QuestionResult> questionResults)
    {
        var isLackOfExercise = false;
        var ischemicStroke = GetAnswer("您是否坚持体育锻炼（每周>3次，每次>30分钟）", questionResults);
        if (ischemicStroke == "是")
        {
            isLackOfExercise = true;
        }
        return isLackOfExercise;
    }

    private static bool GetAtrialFibrillationResult(List<HT_QuestionResult> questionResults)
    {
        var isAtrialFibrillation = false;
        var ischemicStroke = GetAnswer("您是否有房颤或瓣膜性心脏病", questionResults);
        if (ischemicStroke == "是")
        {
            isAtrialFibrillation = true;
        }
        return isAtrialFibrillation;
    }

    private static bool GetDiabetesResult(List<HT_QuestionResult> questionResults)
    {
        var isDiabetes = false;
        var ischemicStroke = GetAnswer("您是否有糖尿病", questionResults);
        if (ischemicStroke == "是")
        {
            isDiabetes = true;
        }
        return isDiabetes;
    }

    /// <summary>
    /// 获取血脂异常或未知
    /// </summary>
    /// <param name="questionResults"></param>
    /// <returns></returns>
    private static bool GetBloodLipidAbnormalResult(List<HT_QuestionResult> questionResults)
    {
        var isBloodLipidAbnormal = false;
        var ischemicStroke = GetAnswer("您是否血脂异常或不了解自己血脂情况", questionResults);
        if (ischemicStroke == "是")
        {
            isBloodLipidAbnormal = true;
        }
        return isBloodLipidAbnormal;

    }
    
    /// <summary>
    /// 获取是否吸烟
    /// </summary>
    /// <param name="questionResults"></param>
    /// <returns></returns>
    private static bool GetSmokingResult(List<HT_QuestionResult> questionResults)
    {
        var isSmoking = false;
        var ischemicStroke = GetAnswer("您是否吸烟", questionResults);
        if (ischemicStroke == "是")
        {
            isSmoking = true;
        }
        return isSmoking;
    }

    /// <summary>
    /// 获取是否高血压
    /// </summary>
    /// <param name="questionResults"></param>
    /// <returns></returns>
    private static bool GetHypertensionResult(List<HT_QuestionResult> questionResults)
    {
        var isHypertension = false;
        //收缩压
        var systolicPressure = GetAnswer("收缩压", questionResults);
        //舒张压
        var diastolicPressure = GetAnswer("舒张压", questionResults);
        //您是否接受降压治疗
        var isReceiveTreatment = GetAnswer("您是否接受降压治疗", questionResults);
        if (systolicPressure != null && diastolicPressure != null)
        {
            if (int.Parse(systolicPressure) >= 140 || int.Parse(diastolicPressure) >= 90 || isReceiveTreatment == "是")
            {
                isHypertension = true;
            }
        }
        return isHypertension;
    }

    private static string GetCardiovascularRiskAssessmentResultCode(List<HT_QuestionResult> questionResults)
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
        var useAntihypertensiveDrugs = GetUseAntihypertensiveDrugs(questionResults);//使用降压药  
        return GetResultCode(age, isASCVD, isDiabetes, bloodLipidLevel, remainingLifeRiskFactor, riskFactor, useAntihypertensiveDrugs).ToString();
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
    /// <param name="useAntihypertensiveDrugs">使用降压药</param>
    /// <returns></returns>
    private static List<string> GetHealthAdvice(int age, bool isASCVD, bool isDiabetes, int bloodLipidLevel, int remainingLifeRiskFactor, int riskFactor, bool useAntihypertensiveDrugs)
    {
        var result = new List<string>();
        result.Add("LDL-C治疗达标值:" + GetStrokeRiskAssessmentHealthAdvice(age, isASCVD, isDiabetes, bloodLipidLevel, remainingLifeRiskFactor, riskFactor, useAntihypertensiveDrugs));
        return result;
    }

    private static string GetStrokeRiskAssessmentHealthAdvice(int age, bool isASCVD, bool isDiabetes, int bloodLipidLevel, int remainingLifeRiskFactor, int riskFactor, bool useAntihypertensiveDrugs)
    {
        var resultCode = GetResultCode(age, isASCVD, isDiabetes, bloodLipidLevel, remainingLifeRiskFactor, riskFactor, useAntihypertensiveDrugs);
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



    private static string GetStrokeRiskAssessmentResult(List<HT_QuestionResult> questionResults)
    {
        //十年卒中风险率
        var tenYearStrokeRiskRate = GetTenYearStrokeRiskRate(questionResults);

        switch (GetStrokeRiskAssessmentResultCode(questionResults))
        {
            case 0:
                return "低危";
            case 1:
                return "中危";
            case 2:
                return "高危";
            default:
                return "未知";
        }
    }

    private static decimal GetTenYearStrokeRiskRate(List<HT_QuestionResult> questionResults)
    {
        var archivesCode = HT_QuestionnaireResultRepositoryExtensions.GetQuestionPatientBasicArchivesCode(questionResults.First().QuestionnaireResultId);
        var patient = HT_PatientBasicInfoRepositoryExtensions.GetByArchivesCode(archivesCode);
        //年龄
        var age = ProfileInformationDetailTool.GetAgeFromIdCard(patient.PBI_ICard);
        var gender = patient.PBI_Gender == "1";
        //是否接受过降压治疗
        var isHypotensor = GetIsHypotensor(questionResults);
        //收缩压
        var systolicPressure = GetSystolicPressure(questionResults);
        //降压治疗后收缩压
        var systolicPressureAfterHypotensor = isHypotensor ? systolicPressure : 0;
        //是否有糖尿病
        var isDiabetes = GetDiabetesResult(questionResults);
        //您是否吸烟
        var isSmoking = GetSmokingResult(questionResults);
        //心血管疾病
        var isCardiovascularDisease = GetCardiovascularDiseaseResult(questionResults);
        //是否有房颤或瓣膜性心脏病 //TODO 不确定
        var isAtrialFibrillation = GetAtrialFibrillationResult(questionResults);
        //是否有左心室肥厚
        var isLeftVentricularHypertrophy = GetLeftVentricularHypertrophyResult(questionResults);

        //计算卒中风险
        var source = 0;
        var strokeRisRate = 0;
        if (gender)
        {
            //年龄
            source += GetAgeSourceMan(age);
            //未治疗收缩压
            source += GetSystolicPressureSourceMan(systolicPressure);
            //治疗后搜索压
            source += GetSystolicPressureAfterHypotensorSourceMan(systolicPressureAfterHypotensor);
            //是否有糖尿病
            source += GetDiabetesSourceMan(isDiabetes);
            //是否吸烟
            source += GetSmokingSourceMan(isSmoking);
            //是否有心血管疾病
            source += GetCardiovascularDiseaseSourceMan(isCardiovascularDisease);
            //是否有房颤或瓣膜性心脏病
            source += GetAtrialFibrillationSourceMan(isAtrialFibrillation);
            //是否有左心室肥厚
            source += GetLeftVentricularHypertrophySourceMan(isLeftVentricularHypertrophy);
            strokeRisRate = GetStrokeRiskRateMan(source);
        }
        else
        {
            //年龄
            source += GetAgeSourceWoman(age);
            //未治疗收缩压
            source += GetSystolicPressureSourceWoman(systolicPressure);
            //治疗后搜索压
            source += GetSystolicPressureAfterHypotensorSourceWoman(systolicPressureAfterHypotensor);
            //是否有糖尿病
            source += GetDiabetesSourceWoman(isDiabetes);
            //是否吸烟
            source += GetSmokingSourceWoman(isSmoking);
            //是否有心血管疾病
            source += GetCardiovascularDiseaseSourceWoman(isCardiovascularDisease);
            //是否有房颤或瓣膜性心脏病
            source += GetAtrialFibrillationSourceWoman(isAtrialFibrillation);
            //是否有左心室肥厚
            source += GetLeftVentricularHypertrophySourceWoman(isLeftVentricularHypertrophy);
            strokeRisRate = GetStrokeRiskRateWoman(source);
        }
        return strokeRisRate;
    }

    private static int GetStrokeRiskRateWoman(int source)
    {
        if  (source <= 0)
        {
            return 0;
        }
        switch (source)
        {
            case 1:
                return 1;
            case 2:
                return 1;
            case 3:
                return 2;
            case 4:
                return 2;
            case 5:
                return 2;
            case 6:
                return 3;
            case 7:
                return 4;
            case 8:
                return 4;
            case 9:
                return 5;
            case 10:
                return 6;
            case 11:
                return 8;
            case 12:
                return 9;
            case 13:
                return 11;
            case 14:
                return 13;
            case 15:
                return 16;
            case 16:
                return 19;
            case 17:
                return 23;
            case 18:
                return 27;
            case 19:
                return 32;
            case 20:
                return 37;
            case 21:
                return 43;
            case 22:
                return 50;
            case 23:
                return 57;
            case 24:
                return 64;
            case 25:
                return 71;
            case 26:
                return 78;
            case 27:
                return 84;
            default:
                return 88;
        }

    }

    private static int GetStrokeRiskRateMan(int source)
    {
        if  (source <= 0)
        {
            return 0;
        }
        switch (source)
        {
            case 1:
                return 3;
            case 2:
                return 3;
            case 3:
                return 4;
            case 4:
                return 4;
            case 5:
                return 5;
            case 6:
                return 5;
            case 7:
                return 6;
            case 8:
                return 7;
            case 9:
                return 8;
            case 10:
                return 10;
            case 11:
                return 11;
            case 12:
                return 13;
            case 13:
                return 15;
            case 14:
                return 17;
            case 15:
                return 20;
            case 16:
                return 22;
            case 17:
                return 26;
            case 18:
                return 29;
            case 19:
                return 33;
            case 20:
                return 37;
            case 21:
                return 42;
            case 22:
                return 47;
            case 23:
                return 52;
            case 24:
                return 57;
            case 25:
                return 63;
            case 26:
                return 68;
            case 27:
                return 74;
            case 28:
                return 79;
            case 29:
                return 84;
            case 30:
                return 88;
            default:
                return 88;
        }
    }

    private static int GetLeftVentricularHypertrophySourceWoman(bool isLeftVentricularHypertrophy)
    {
        if (isLeftVentricularHypertrophy)
            return 4;
        return 0;
    }

    private static int GetAtrialFibrillationSourceWoman(bool isAtrialFibrillation)
    {
        if (isAtrialFibrillation)
            return 6;
        return 0;
    }

    private static int GetCardiovascularDiseaseSourceWoman(bool isCardiovascularDisease)
    {
        if (isCardiovascularDisease)
            return 2;
        return 0;
    }

    private static int GetSmokingSourceWoman(bool isSmoking)
    {
        if (isSmoking)
            return 3;
        return 0;
    }


    private static int GetDiabetesSourceWoman(bool isDiabetes)
    {
        if (isDiabetes)
            return 3;
        return 0;
    }

    private static int GetSystolicPressureAfterHypotensorSourceWoman(decimal systolicPressureAfterHypotensor)
    {
        //95-106	107-113	114-119	120-125	126-131	132-139	140-148	149-160	161-204	205-216
        if (systolicPressureAfterHypotensor >= 95 && systolicPressureAfterHypotensor <= 106)
            return 1;
        if (systolicPressureAfterHypotensor >= 107 && systolicPressureAfterHypotensor <= 113)
            return 2;
        if (systolicPressureAfterHypotensor >= 114 && systolicPressureAfterHypotensor <= 119)
            return 3;
        if (systolicPressureAfterHypotensor >= 120 && systolicPressureAfterHypotensor <= 125)
            return 4;
        if (systolicPressureAfterHypotensor >= 126 && systolicPressureAfterHypotensor <= 131)
            return 5;
        if (systolicPressureAfterHypotensor >= 132 && systolicPressureAfterHypotensor <= 139)
            return 6;
        if (systolicPressureAfterHypotensor >= 140 && systolicPressureAfterHypotensor <= 148)
            return 7;
        if (systolicPressureAfterHypotensor >= 149 && systolicPressureAfterHypotensor <= 160)
            return 8;
        if (systolicPressureAfterHypotensor >= 161 && systolicPressureAfterHypotensor <= 204)
            return 9;
        if (systolicPressureAfterHypotensor >= 205 && systolicPressureAfterHypotensor <= 216)
            return 10;
        return 0;
    }

    private static int GetSystolicPressureSourceWoman(decimal systolicPressure)
    {
        //95-106	107-118	119-130	131-143	144-155	156-167	168-180	181-192	193-204	205-216
        if (systolicPressure >= 95 && systolicPressure <= 106)
            return 1;
        if (systolicPressure >= 107 && systolicPressure <= 118)
            return 2;
        if (systolicPressure >= 119 && systolicPressure <= 130)
            return 3;
        if (systolicPressure >= 131 && systolicPressure <= 143)
            return 4;
        if (systolicPressure >= 144 && systolicPressure <= 155)
            return 5;
        if (systolicPressure >= 156 && systolicPressure <= 167)
            return 6;
        if (systolicPressure >= 168 && systolicPressure <= 180)
            return 7;
        if (systolicPressure >= 181 && systolicPressure <= 192)
            return 8;
        if (systolicPressure >= 193 && systolicPressure <= 204)
            return 9;
        if (systolicPressure >= 205 && systolicPressure <= 216)
            return 10;

        return 0;

    }

    private static int GetAgeSourceWoman(int age)
    {
        //54-56	57-59	60-62	63-64	65-67	68-70	71-73	74-76	77-78	79-81	82-84
        if (age >= 54 && age <= 56)
            return 0;
        if (age >= 57 && age <= 59)
            return 1;
        if (age >= 60 && age <= 62)
            return 2;
        if (age >= 63 && age <= 64)
            return 3;
        if (age >= 65 && age <= 67)
            return 4;
        if (age >= 68 && age <= 70)
            return 5;
        if (age >= 71 && age <= 73)
            return 6;
        if (age >= 74 && age <= 76)
            return 7;
        if (age >= 77 && age <= 78)
            return 8;
        if (age >= 79 && age <= 81)
            return 9;
        if (age >= 82 && age <= 84)
            return 10;
        return 0;
    }

    private static int GetDiabetesSourceMan(bool isDiabetes)
    {
        if (isDiabetes)
            return 2;
        return 0;
    }

    private static int GetLeftVentricularHypertrophySourceMan(bool isLeftVentricularHypertrophy)
    {
        if (isLeftVentricularHypertrophy)
            return 5;
        return 0;
    }

    /// <summary>
    /// 获取治疗后的收缩压分熟
    /// </summary>
    /// <param name="systolicPressureAfterHypotensor"></param>
    /// <returns></returns>
    private static int GetSystolicPressureAfterHypotensorSourceMan(decimal systolicPressureAfterHypotensor)
    {
        //97-105	106-112	113-117	118-123	124-129	130-135	136-142	143-150	151-161	162-176	177-205
        if (systolicPressureAfterHypotensor >= 97 && systolicPressureAfterHypotensor <= 105)
            return 0;
        if (systolicPressureAfterHypotensor >= 106 && systolicPressureAfterHypotensor <= 112)
            return 1;
        if (systolicPressureAfterHypotensor >= 113 && systolicPressureAfterHypotensor <= 117)
            return 2;
        if (systolicPressureAfterHypotensor >= 118 && systolicPressureAfterHypotensor <= 123)
            return 3;
        if (systolicPressureAfterHypotensor >= 124 && systolicPressureAfterHypotensor <= 129)
            return 4;
        if (systolicPressureAfterHypotensor >= 130 && systolicPressureAfterHypotensor <= 135)
            return 5;
        if (systolicPressureAfterHypotensor >= 136 && systolicPressureAfterHypotensor <= 142)
            return 6;
        if (systolicPressureAfterHypotensor >= 143 && systolicPressureAfterHypotensor <= 150)
            return 7;
        if (systolicPressureAfterHypotensor >= 151 && systolicPressureAfterHypotensor <= 161)
            return 8;
        if (systolicPressureAfterHypotensor >= 162 && systolicPressureAfterHypotensor <= 176)
            return 9;
        if (systolicPressureAfterHypotensor >= 177 && systolicPressureAfterHypotensor <= 205)
            return 10;

        return 0;
    }

    /// <summary>
    /// 房颤或瓣膜性心脏病
    /// </summary>
    /// <param name="isAtrialFibrillation"></param>
    /// <returns></returns>
    private static int GetAtrialFibrillationSourceMan(bool isAtrialFibrillation)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 获取心血管疾病分数
    /// </summary>
    /// <param name="isCardiovascularDisease"></param>
    /// <returns></returns>
    private static int GetCardiovascularDiseaseSourceMan(bool isCardiovascularDisease)
    {
        if (isCardiovascularDisease)
            return 4;
        return 0;
    }

    /// <summary>
    /// 获取吸烟分数
    /// </summary>
    /// <param name="isSmoking"></param>
    /// <returns></returns>
    private static int GetSmokingSourceMan(bool isSmoking)
    {
        if (isSmoking)
            return 3;
        return 0;
    }

    /// <summary>
    /// 收缩压
    /// </summary>
    /// <param name="systolicPressure"></param>
    /// <returns></returns>
    private static int GetSystolicPressureSourceMan(decimal systolicPressure)
    {
        //97-105	106-115	116-125	126-135	136-145	146-155	156-165	166-175	176-185	186-195	196-205
        if (systolicPressure >= 97 && systolicPressure <= 105)
            return 0;
        if (systolicPressure >= 106 && systolicPressure <= 115)
            return 1;
        if (systolicPressure >= 116 && systolicPressure <= 125)
            return 2;
        if (systolicPressure >= 126 && systolicPressure <= 135)
            return 3;
        if (systolicPressure >= 136 && systolicPressure <= 145)
            return 4;
        if (systolicPressure >= 146 && systolicPressure <= 155)
            return 5;
        if (systolicPressure >= 156 && systolicPressure <= 165)
            return 6;
        if (systolicPressure >= 166 && systolicPressure <= 175)
            return 7;
        if (systolicPressure >= 176 && systolicPressure <= 185)
            return 8;
        if (systolicPressure >= 186 && systolicPressure <= 195)
            return 9;
        if (systolicPressure >= 196 && systolicPressure <= 205)
            return 10;

        return 0;
    }



    /// <summary>
    /// 获取年龄分数,男
    /// </summary>
    private static int GetAgeSourceMan(int age)
    {
        //年龄
        if (age < 0)
            throw Oops.Oh("年龄不能小于0");
        if (age < 45)
            return 0;
        //54-56
        if (age >= 54 && age <= 56)
            return 0;
        //57-59
        if (age >= 57 && age <= 59)
            return 1;
        //60-62
        if (age >= 60 && age <= 62)
            return 2;
        //63-65
        if (age >= 63 && age <= 65)
            return 3;
        //66-68
        if (age >= 66 && age <= 68)
            return 4;
        //69-72
        if (age >= 69 && age <= 72)
            return 5;
        //73-75
        if (age >= 73 && age <= 75)
            return 6;
        //76-78
        if (age >= 76 && age <= 78)
            return 7;
        //79-81
        if (age >= 79 && age <= 81)
            return 8;
        //82-84
        if (age >= 82 && age <= 84)
            return 9;
        //85
        if (age >= 85)
            return 10;

        return 0;
    }

    private static bool GetLeftVentricularHypertrophyResult(List<HT_QuestionResult> questionResults)
    {
        //是否有左心室肥厚
        var isLeftVentricularHypertrophy = GetAnswer("您是否有左心室肥厚", questionResults);
        if (isLeftVentricularHypertrophy == "是")
        {
            return true;
        }
        return false;
    }

    private static bool GetCardiovascularDiseaseResult(List<HT_QuestionResult> questionResults)
    {
        //您是否有心血管疾病
        var isCardiovascularDisease = GetAnswer("您是否有心血管疾病", questionResults);
        if (isCardiovascularDisease == "是")
        {
            return true;
        }
        return false;
    }

    private static decimal GetSystolicPressure(List<HT_QuestionResult> questionResults)
    {
        var systolicPressure = 0;
        systolicPressure = Convert.ToInt32(GetAnswer("收缩压", questionResults));
        return systolicPressure;
    }

    private static bool GetIsHypotensor(List<HT_QuestionResult> questionResults)
    {
        var isHypotensor = false;
        var ischemicStroke = GetAnswer("您是否接受降压治疗", questionResults);
        if (ischemicStroke == "是")
        {
            isHypotensor = true;
        }
        return isHypotensor;
    }

    private static string GetCardiovascularRiskAssessmentResult(List<HT_QuestionResult> questionResults)
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
        var useAntihypertensiveDrugs = GetUseAntihypertensiveDrugs(questionResults);//使用降压药  
        return GetResult(age, isASCVD, isDiabetes, bloodLipidLevel, remainingLifeRiskFactor, riskFactor, useAntihypertensiveDrugs);
    }

    private static bool GetUseAntihypertensiveDrugs(List<HT_QuestionResult> questionResults)
    {
        var useAntihypertensiveDrugs = GetAnswer("使用降压药", questionResults);
        if (useAntihypertensiveDrugs == "是")
            return true;
        return false;
    }

    private static int GetResultCode(int age, bool isASCVD, bool isDiabetes, int bloodLipidLevel, int remainingLifeRiskFactor, int riskFactor, bool useAntihypertensiveDrugs)
    {
        //是否使用降压药
        if (isASCVD)
            return 3;// highRisk + "极高危";
        //是否使用降压药
        if (useAntihypertensiveDrugs)
        {
            if (bloodLipidLevel == 4
                || (isDiabetes && age > 40)
                || (bloodLipidLevel >= 1 && bloodLipidLevel <= 3 && riskFactor == 3)
                || (bloodLipidLevel == 2 || bloodLipidLevel == 3 && riskFactor >= 2 && riskFactor <= 3))
                return 2;// highRisk + "高危";
            if ((bloodLipidLevel == 1 && riskFactor == 2)
                || (bloodLipidLevel == 2 || bloodLipidLevel == 3 && riskFactor == 1))
                return 1;
            //低危：危险因素0；血脂水平1且危险因素1
            if (bloodLipidLevel == 1 && riskFactor == 1)
                return 0;
        }
        else
        {
            if (bloodLipidLevel == 4
            || (isDiabetes && age > 40))
                return 2;// highRisk + "高危";
            //中危：血脂水平2且危险因素3；血脂水平3且危险因素2~3。
            if ((bloodLipidLevel == 2 && riskFactor == 3)
                || (bloodLipidLevel == 3 && riskFactor >= 2 && riskFactor <= 3))
                return 1;
            //低危：血脂水平1；血脂水平2且危险因素0~2；血脂水平3且危险因素0~1
            if ((bloodLipidLevel == 1)
                || (bloodLipidLevel == 2 && riskFactor >= 0 && riskFactor <= 2)
                || (bloodLipidLevel == 3 && riskFactor >= 0 && riskFactor <= 1))
                return 0;
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
    /// <param name="useAntihypertensiveDrugs">是否使用降压药</param>
    /// <returns></returns>
    private static string GetResult(int age, bool isASCVD, bool isDiabetes, int bloodLipidLevel, int remainingLifeRiskFactor, int riskFactor, bool useAntihypertensiveDrugs)
    {
        // 分层为极高危和单纯高危时，ASCVD10年危险评估替换为总体心血管危险评估:总体心血管危险评估：高危 or  总体心血管危险评估：极高危 
        //高危及以上返回值
        var highRisk = "ASCVD10年危险评估：";
        //中危及以下返回值
        var lowRisk = "总体心血管危险评估：";
        var resultLevel = GetResultCode(age, isASCVD, isDiabetes, bloodLipidLevel, remainingLifeRiskFactor, riskFactor, useAntihypertensiveDrugs);
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
        var hdlc = GetAnswer("HDL-C", questionResult);
        if (hdlc == "≥1.0mmol/L")
        {
            riskFactor++;
        }
        var smoking = GetAnswer("吸烟或被动吸烟", questionResult);
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
        var height = int.Parse(GetAnswer("身高", questionResult));
        var weight = int.Parse(GetAnswer("体重", questionResult));

        var bmi = GetBMI(height, weight);
        if (bmi >= 28)
            remainingLifeRiskFactor++;

        //吸烟或被动吸烟“是”	危险因素	+1，余生危险因素	+1
        var smoking = GetAnswer("吸烟或被动吸烟", questionResult);
        if (smoking == "是")
            remainingLifeRiskFactor++;

        //血压 2级以上血压	余生危险因素	+1
        //修改为血压_收缩压，血压_舒张压
        //血压_收缩压
        var systolicBloodPressure = GetAnswer("血压_收缩压", questionResult);
        //血压_舒张压
        var diastolicBloodPressure = GetAnswer("血压_舒张压", questionResult);
        //如何判断是否是二级高血压 二级   160-179 || 100-109 source:兵兵
        if (int.Parse(systolicBloodPressure) >= 160 || int.Parse(diastolicBloodPressure) >= 100)
            remainingLifeRiskFactor++;

        //HDL-C <1.0mmol/L<1.0mmol/L危险因素+1，余生危险因素+1   ≥1.01.0mmol/L
        var hdlc = GetAnswer("HDL-C", questionResult);
        if (hdlc == "<1.0mmol/L")
        {
            remainingLifeRiskFactor++;
        }

        //非-HDL-C ≥ 5.25.2  mmol/L 余生危险因素+1
        var nonHdlc = GetAnswer("非-HDL-C", questionResult);
        if (nonHdlc == "≥5.2mmol/L")
            remainingLifeRiskFactor++;
        return remainingLifeRiskFactor;
    }

    /// <summary>
    /// 获取是否有糖尿病
    /// </summary>
    /// <param name="questionResult"></param>
    /// <returns></returns>
    private static bool GetDiabetesState(List<HT_QuestionResult> questionResult)
    {
        var isDiabetes = false;
        //使用降糖药物选“是	”糖尿病	;选蓝色中任意一个	糖尿病  ，满足任意条件即使糖尿病//TODO: 还没写
        var useAntidiabeticDrugs = GetAnswer("使用降糖药物", questionResult);
        //空腹血糖  ≥≥7.0mmol/L7.0mmol/L    糖尿病
        var fastingBloodGlucose = GetAnswer("空腹血糖", questionResult);
        //餐后2小时血糖 ≥≥11.1mmol/L11.1mmol/L   糖尿病
        var postprandialBloodGlucose = GetAnswer("餐后2小时血糖", questionResult);
        if (useAntidiabeticDrugs == "是")
            isDiabetes = true;
        else if (fastingBloodGlucose == "是")
            isDiabetes = true;
        else if (postprandialBloodGlucose == "是")
            isDiabetes = true;
        //糖尿病 有 糖尿病
        var diabetes = GetAnswer("糖尿病", questionResult);
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
        var tc = GetAnswer("TC", questionResult);
        var ldlc = GetAnswer("LDL-C", questionResult);
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
        var ischemicStroke = GetAnswer("缺血性脑卒中", questionResult);
        //短暂性脑缺血发作 有 ASCVD
        var transientIschemicAttack = GetAnswer("短暂性脑缺血发作", questionResult);
        //心肌梗死史 有 ASCVD
        var myocardialInfarction = GetAnswer("心肌梗死史", questionResult);
        //心绞痛 有 ASCVD
        var anginaPectoris = GetAnswer("心绞痛", questionResult);
        //冠状动脉血运重建 有 ASCVD
        var coronaryArteryBypassGrafting = GetAnswer("冠状动脉血运重建", questionResult);
        //外周血管疾病 有 ASCVD
        var peripheralVascularDisease = GetAnswer("外周血管疾病", questionResult);

        if (ischemicStroke == "有" || transientIschemicAttack == "有" || myocardialInfarction == "有" || anginaPectoris == "有" || coronaryArteryBypassGrafting == "有" || peripheralVascularDisease == "有")
            isASCVD = true;
        return isASCVD;
    }

    private static string GetAnswer(string title, List<HT_QuestionResult> questionResult)
    {
        //查询问卷题目
        var questionnaireResult = HT_QuestionnaireResultRepositoryExtensions.GetQuestionnaireIdByIdAsync(questionResult.FirstOrDefault().QuestionnaireResultId);
        var questions = HT_QuestionnaireRepositoryExtensions.GetQuestion(questionnaireResult);
        var answerQuestionId = questions.Where(x => x.Title == title).FirstOrDefault().Id;
        var answer = questionResult.Where(x => x.QuestionId == answerQuestionId).FirstOrDefault().Answer;

        return answer;
    }

    public static decimal GetBMI(decimal height, decimal weight)
    {
        return weight / (height * height);
    }
}