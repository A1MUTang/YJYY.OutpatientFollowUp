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
        public int Pulse { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}