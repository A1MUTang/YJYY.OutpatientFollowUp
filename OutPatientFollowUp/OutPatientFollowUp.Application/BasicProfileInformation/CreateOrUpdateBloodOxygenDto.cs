namespace OutPatientFollowUp.Application.HealthMonitor
{
    public class CreateOrUpdateBloodOxygenDto:IValidatableObject
    {
        /// <summary>
        /// 血氧值
        /// </summary>
        /// <remarks>单位：%</remarks>
        /// <value></value>
        public int BloodOxygenValue { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (BloodOxygenValue < 0 || BloodOxygenValue > 100)
            {
                yield return new ValidationResult("血氧值必须在0-100之间");
            }
        }
    }
}