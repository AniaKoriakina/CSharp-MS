using Core.Dal.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Users.Models
{
    public record UserDal : BaseEntityDal<Guid>
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required]
        public string Login { get; init; }

        /// <summary>
        /// Никнейм пользователя
        /// </summary>
        [Required]
        public string UserName { get; init; }

        /// <summary>
        /// Электронная почта пользователя
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; init; }
    }
}
