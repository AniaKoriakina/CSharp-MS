using System.ComponentModel.DataAnnotations;

namespace ProfileAPI.Controllers.User.Responses
{
    public class CreateUserResponse
    {
        [Required]
        public Guid UserId { get; init; }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
