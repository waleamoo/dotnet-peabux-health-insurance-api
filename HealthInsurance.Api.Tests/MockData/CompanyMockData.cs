using HealthInsurance.DataAccess.Dtos;

namespace HealthInsurance.Api.Tests.MockData
{
    public class CompanyMockData
    {

        public static CompanyAddDto GetCompanyAddDto()
        {
            return new CompanyAddDto
            {
                CompanyName = "PeaBux",
                CompanyAddress = "Lagos Nigeria"
            };
        }
        
        public static CompanyAddDto GetCompanyIncompleteDto()
        {
            return new CompanyAddDto
            {
                CompanyName = "PeaBux",
            };
        }


        public static MessageDto GetMessageDto() => new MessageDto { Message = "Company added", Ok = true, Record = null };
    }
}
