using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsurance.DataAccess.Dtos
{
    public class MessageDto
    {
        public bool Ok { get; set; }
        public string Message { get; set; } 
        public dynamic? Record { get; set; }

        public MessageDto()
        {
            
        }

        public MessageDto(int result, string successMessage, string errorMessage)
        {
            Ok = result > 0;
            Message = Ok ? successMessage : errorMessage;
            Record = string.Empty;
        }

        public MessageDto(bool success, string successMessage, string errorMessage, dynamic? record = null)
        {
            Ok = success;
            Message = Ok ? successMessage : errorMessage;
            Record = record;
        }

    }

    
}
