using System.ComponentModel.DataAnnotations;

namespace ProfileAPI.Controllers.User.Responses
{
    public class ErrorResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
