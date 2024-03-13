using AutoMapper;
using HealthInsurance.Api.Controllers;
using HealthInsurance.Api.Tests.MockData;
using HealthInsurance.DataAccess.Dtos;
using HealthInsurance.DataAccess.Repository;
using HealthInsurance.Service.Helpers;
using Moq;
using Xunit;

namespace HealthInsurance.Api.Tests.ControllerTests
{
    public class CompanyControllerTests
    {
        private readonly Mock<IUnitOfWork> unitOfWork = new();
        private readonly Mock<IMapper> mapper = new();
        private readonly CompanyController companyController;

        public CompanyControllerTests()
        {
            companyController = new(unitOfWork.Object, mapper.Object);
        }

        [Fact]
        public async Task AddCompany_ReturnsMessageDto_WhenResouceParameterValid()
        {
            // Arrange
            var companyController = new Mock<CompanyController>();
            companyController.Setup(c => c.AddCompany(CompanyMockData.GetCompanyAddDto())).ReturnsAsync(CompanyMockData.GetMessageDto());
            // Act
            var obj = new CompanyController(unitOfWork.Object, mapper.Object);
            var result = await obj.AddCompany(CompanyMockData.GetCompanyAddDto());
            // Assert 
            Assert.NotNull(result);
            Assert.IsType<MessageDto>(result);
        }

        [Fact]
        public async Task AddCompany_ReturnsException_WhenResouceParameterNotValid()
        {
            // Arrange
            var companyController = new Mock<CompanyController>();
            companyController.Setup(c => c.AddCompany(CompanyMockData.GetCompanyAddDto())).ThrowsAsync(new HealthInsuranceException(""));
            // Act & Assert 
            var obj = new CompanyController(unitOfWork.Object, mapper.Object);
            await Assert.ThrowsAsync<HealthInsuranceException>(async () => await obj.AddCompany(CompanyMockData.GetCompanyIncompleteDto()));
        }
    }
}
