using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsurance.Service.Helpers
{
    public class HealthInsuranceException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public HealthInsuranceException(string? message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public HealthInsuranceException(string? message) : base(message) 
        {
        }
    }
}
