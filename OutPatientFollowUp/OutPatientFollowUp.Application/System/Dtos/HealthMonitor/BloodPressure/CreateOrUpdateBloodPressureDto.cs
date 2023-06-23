namespace OutPatientFollowUp
{
    public class CreateOrUpdateBloodPressureDto : IValidatableObject
    {

        /// <summary>
        /// 设备号
        /// </summary>
        public string MacID { get; set; }

        /// <summary>
        /// 收缩压
        /// </summary>
        public int Systolic { get; set; }

        /// <summary>
        /// 舒张压
        /// </summary>
        public int Diastolic { get; set; }

        /// <summary>
        /// 脉搏
        /// </summary>
        public int HeartRate { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Systolic < 0 || Systolic > 300)
            {
                yield return new ValidationResult("收缩压必须在0-300之间");
            }
            if (Diastolic < 0 || Diastolic > 300)
            {
                yield return new ValidationResult("舒张压必须在0-300之间");
            }
            if (HeartRate < 0 || HeartRate > 300)
            {
                yield return new ValidationResult("脉搏必须在0-300之间");
            }
        }
    }
}