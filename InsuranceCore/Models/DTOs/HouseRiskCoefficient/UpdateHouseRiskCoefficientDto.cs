namespace InsuranceCore.Models.DTOs.HouseRiskCoefficient
{
    public class UpdateHouseRiskCoefficientDto : ADto, IHouseRiskCoefficientDto
    {
        public string Name { get; set; }
        public float Value { get; set; }
        public int Status { get; set; }
    }
}
