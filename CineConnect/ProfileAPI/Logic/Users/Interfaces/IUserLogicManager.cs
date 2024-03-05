using Logic.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Users.Interfaces
{
    /// <summary>
    /// Работа с пользователем
    /// </summary>
    public interface IUserLogicManager
    {
        /// <summary>
        /// Получить имя пользователю по его уникальному идентификатору
        /// </summary>
        Task<string> GetUserNameAsync(Guid userId);

        /// <summary>
        /// Создать пользователя 
        /// </summary>
        Task<Guid> CreateUserAsync(UserLogic user);

        /// <summary>
        /// Обновить информацию о пользователе.
        /// </summary>
        Task<bool> UpdateUserAsync(Guid userId, UserLogic user);

        /// <summary>
        /// Удалить пользователя по его уникальному идентификатору.
        /// </summary>
        Task<bool> DeleteUserAsync(Guid userId);
    }
}
