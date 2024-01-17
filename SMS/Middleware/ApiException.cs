using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace BusinessLayer.Middleware
{
    public class ApiException : Exception
    {
        public ApiException(int status, string message, dynamic? details = null)
        {
            Status = status;
            Message = message;
            Details = details;
        }

        public int Status { get; set; }
        public new string Message { get; set; }
        public dynamic? Details { get; set; }
    }
}
