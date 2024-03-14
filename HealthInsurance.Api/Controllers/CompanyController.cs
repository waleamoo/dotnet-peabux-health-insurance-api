using AutoMapper;
using HealthInsurance.DataAccess.Constants;
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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCompany(int id)
        {
            Company? company = await unitOfWork.CompanyRepository.GetCompany(id);
            if (company == null)
                return BadRequest(Constants.CompanyNotFound);
            return Ok(company);
        }

        [HttpPost("add")]
        public async Task<MessageDto> AddCompany(CompanyAddDto companyDto)
        {
            Company company = mapper.Map<Company>(companyDto);
            await unitOfWork.CompanyRepository.AddCompany(company);
            await unitOfWork.SaveAsync();
            return new MessageDto { Message = Constants.CompanyAdded, Ok = true, Record = null };
        }
    }
}
