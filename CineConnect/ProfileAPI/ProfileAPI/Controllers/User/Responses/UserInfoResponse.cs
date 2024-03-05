using System.ComponentModel.DataAnnotations;

namespace ProfileAPI.Controllers.User.Responses
{
    public record UserInfoResponse
    {
        [Required]
        public required Guid UserId { get; init; }

        [Required]
        public string Login { get; init; }

        [Required]
        public string UserName { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }
    }
}
