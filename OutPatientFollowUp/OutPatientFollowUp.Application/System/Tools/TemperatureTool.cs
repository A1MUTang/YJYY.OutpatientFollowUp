using OutPatientFollowUp.Core;

namespace OutPatientFollowUp.Application
{
    public static class TemperatureTool
    {
        public static TemperatureResult GetTemperatureResult(decimal bodyTemperature)
        {
            if (bodyTemperature <= 35)
            {
                return TemperatureResult.BelowNormal;
            }
            else if (bodyTemperature > 35 && bodyTemperature < 37.3m)
            {
                return TemperatureResult.Normal;
            }
            else if (bodyTemperature >= 37.3m && bodyTemperature < 38.5m)
            {
                return TemperatureResult.MildAbnormality;
            }
            else
            {
                return TemperatureResult.SevereAbnormality;
            }
        }
    }


}