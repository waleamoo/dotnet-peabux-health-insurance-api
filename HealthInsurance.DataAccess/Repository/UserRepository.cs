using AutoMapper;
using HealthInsurance.DataAccess.Dtos;
using HealthInsurance.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Claim = System.Security.Claims.Claim;

namespace HealthInsurance.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HealthInsuranceContext context;
        private readonly IMapper mapper;
        private readonly IConfiguration config;

        public UserRepository(HealthInsuranceContext context, IMapper mapper, IConfiguration config)
        {
            this.context = context;
            this.mapper = mapper;
            this.config = config;
        }

        public async Task<Staff> AuthenticateStaff(string staffEmail, string passwordText)
        {
            Staff staff = await context.Staff.FirstOrDefaultAsync(x => x.StaffEmail == staffEmail);
            if (staff == null || staff.PasswordKey == null)
                return null;
            if (!MatchPasswordHash(passwordText, staff.Password, staff.PasswordKey))
                return null;
            return staff;
        }

        private bool MatchPasswordHash(string passwordText, byte[]? password, byte[] passwordKey)
        {
            using (var hmac = new HMACSHA512(passwordKey))
            {
                var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordText));
                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHash[i] != password[i])
                        return false;
                }
                return true;
            }
        }

        public async Task RegisterStaff(StaffAddDto staffAddDto)
        {
            byte[] passwordHash, passwordKey;
            using (var hmac = new HMACSHA512())
            {
                passwordKey = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(staffAddDto.Password));
            }

            Staff staff = mapper.Map<Staff>(staffAddDto);

            staff.Password = passwordHash;
            staff.PasswordKey = passwordKey;
            staff.StaffGuid = Guid.NewGuid();
            staff.CreatedDate = DateTime.UtcNow;
            staff.ModifiedDate = DateTime.UtcNow;
            await context.Staff.AddAsync(staff);
            await AddStaffRole(staffAddDto.StaffRole, staff.StaffGuid); // add staff to the specified role 
        }

        public async Task AddStaff(Staff staff)
        {
            await context.Staff.AddAsync(staff);
        }

        private async Task AddStaffRole(int staffRoleTypeId, Guid staffGuid)
        {
            StaffRole staffRole = new StaffRole
            {
                StaffRoleTypeId = staffRoleTypeId,
                StaffGuid = staffGuid,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };
            await context.StaffRoles.AddAsync(staffRole);
        }

        public async Task<bool> StaffAlreadyExists(string staffEmail)
        {
            return await context.Staff.AnyAsync(x => x.StaffEmail ==  staffEmail);
        }

        public string CreatJWT(Staff staff)
        {
            // authentication key 
            // symmetric encryption - one key can be used for both encrypting and decrypting the token 
            // assymeteric encryption - one key for encrypting (public key) and another key for decrypting (private key - only shared by the key initiator)
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["AppSettings:Key"] ?? string.Empty));

            // Get the role of the staff 
            int? roleId = context.StaffRoles.Where(x => x.StaffGuid == staff.StaffGuid).Select(x => x.StaffRoleTypeId).First(); // role can be many - but 1 for now
            string roleName = context.StaffRoleTypes.First(x => x.StaffRoleTypeId == roleId).StaffRoleTitle.ToString();

            // pieces of information about the user
            var claims = new Claim[]
            {
            new Claim(ClaimTypes.Name, staff.StaffEmail),
            new Claim(ClaimTypes.NameIdentifier, staff.StaffGuid.ToString()),
            new Claim(ClaimTypes.Role, roleName) // We will authorize with attriute [Authorize(Roles = "Admin")]
            };

            // define the secret key and security algorithm
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = signingCredentials
            };
            // token handler responsible for creating JWT 
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
