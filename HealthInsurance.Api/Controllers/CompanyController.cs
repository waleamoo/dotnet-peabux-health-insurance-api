using AutoMapper;
using HealthInsurance.DataAccess.Dtos;
using HealthInsurance.DataAccess.Models;
using HealthInsurance.DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthInsurance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CompanyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<MessageDto> AddCompany(CompanyAddDto companyDto)
        {
            Company company = mapper.Map<Company>(companyDto);
            company.CreatedDate = DateTime.UtcNow;
            company.ModifiedDate = DateTime.UtcNow;
            unitOfWork.CompanyRepository.AddCompany(company);
            await unitOfWork.SaveAsync();
            return new MessageDto { Message = "Company Added", Ok = true, Record = null };
        }
    }
}
