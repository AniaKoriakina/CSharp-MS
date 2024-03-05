using System.ComponentModel.DataAnnotations;

namespace ProfileAPI.Controllers.User.Requests
{
    public record CreateUserRequest
    {
        [Required]
        public string Login {  get; init; }

        [Required]
        public string UserName { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }
    }
}
