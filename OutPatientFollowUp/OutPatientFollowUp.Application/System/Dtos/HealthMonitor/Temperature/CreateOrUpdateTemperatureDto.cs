namespace OutPatientFollowUp
{
    public class CreateOrUpdateTemperatureDto : IValidatableObject
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
            if (Temperature <= 0)
            {
                yield return new ValidationResult("体温必须大于0", new[] { nameof(Temperature) });
            }
        }
    }
}