namespace Insurance.Domain.Dtos
{
    public class InsuranceDto
    {
        public InsuranceDto(double insuranceValue)
        {
            InsuranceValue = insuranceValue;
        }

        public double InsuranceValue { get; private set; }
    }
}
