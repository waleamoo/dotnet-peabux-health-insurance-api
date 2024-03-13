using AutoMapper;
using HealthInsurance.DataAccess.Constants;
using HealthInsurance.DataAccess.Dtos;
using HealthInsurance.DataAccess.Models;
using HealthInsurance.DataAccess.Repository;
using HealthInsurance.Service.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HealthInsurance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StaffController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<MessageDto> AddStaff(StaffAddDto staffDto)
        {
            // confirm if company exist 
            var company = await unitOfWork.CompanyRepository.GetCompany(staffDto.CompanyId);
            if (company is null)
                throw new HealthInsuranceException(Constants.CompanyNotFound, HttpStatusCode.NotFound);

            Staff staff = mapper.Map<Staff>(staffDto);

            staff.StaffGuid = Guid.NewGuid();
            staff.CreatedDate = DateTime.UtcNow;
            staff.ModifiedDate = DateTime.UtcNow;
            // add the staff and the role of the staff
            await unitOfWork.StaffRepository.AddStaff(staff);
            await unitOfWork.StaffRepository.AddStaffRole(staffDto.StaffRole, staff.StaffGuid);

            await unitOfWork.SaveAsync();
            return new MessageDto { Message = Constants.StaffAdded, Ok = true, Record = null };
        }
    }
}
