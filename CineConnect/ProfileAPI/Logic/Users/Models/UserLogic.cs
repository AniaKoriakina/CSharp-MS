using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Users.Models
{
    /// <summary>
    /// Модель пользователя для слоя Logic 
    /// </summary>
    public class UserLogic
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
