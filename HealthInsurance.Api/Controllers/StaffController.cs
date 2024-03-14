using AutoMapper;
using HealthInsurance.DataAccess.Constants;
using HealthInsurance.DataAccess.Dtos;
using HealthInsurance.DataAccess.Models;
using HealthInsurance.DataAccess.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [Authorize]
        [HttpGet("role-types")]
        public async Task<ActionResult<List<StaffRoleType>>> GetStaffRoleTypes()
        {
            return Ok(await unitOfWork.StaffRepository.GetStaffRoleTypes());
        }

        [HttpGet("{staffGuid:guid}")]
        public async Task<ActionResult<StaffGetDto>> GetStaff(Guid staffGuid, int? companyId)
        {
            // confirm if company exist 
            return Ok(await unitOfWork.StaffRepository.GetStaff(staffGuid, companyId));
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddStaff(StaffAddDto staffDto)
        {
            if (await unitOfWork.UserRepository.StaffAlreadyExists(staffDto.StaffEmail))
                return BadRequest(Constants.StaffAlreadyExist);

            // confirm if company exist 
            var company = await unitOfWork.CompanyRepository.GetCompany(staffDto.CompanyId);
            if (company is null)
                return BadRequest(Constants.CompanyNotFound);
            // add the staff and the role of the staff
            await unitOfWork.UserRepository.RegisterStaff(staffDto);
            await unitOfWork.SaveAsync();
            return StatusCode(201, Constants.StaffAdded);
        }

        // TODO: Login staff 
        [HttpPost("login")]
        public async Task<IActionResult> StaffLogin(StaffLoginDto staffDto)
        {
            Staff staff = await unitOfWork.UserRepository.AuthenticateStaff(staffDto.StaffEmail, staffDto.StaffPassword);
            if (staff is null)
                return Unauthorized();
            StaffLoginResponseDto staffLoginRes = new();
            staffLoginRes.StaffEmail = staff.StaffEmail ?? "";
            staffLoginRes.StaffToken = unitOfWork.UserRepository.CreatJWT(staff);
            return Ok(staffLoginRes);
        }


        // TODO: Logout staff 

        // TODO: Approve claim 

        // TODO: Cancel claim 


    }
}
