namespace OutPatientFollowUp
{
    public class CreateOrUpdateTemperature : IValidatableObject
    {
        /// <summary>
        /// 设备号
        /// </summary>
        public string MacID { get; set; }

        /// <summary>
        /// 体温
        /// </summary>
        public decimal Temperature { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}