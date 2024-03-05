using Dal.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Users.Interfaces
{
    /// <summary>
    /// Хранение пользователя
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Получить пользователя по его уникальному идентификатору.
        /// </summary>
        /// <param name="userId">Уникальный идентификатор пользователя.</param>
        /// <returns>Объект, представляющий пользователя.</returns>
        Task<UserDal> GetUserByIdAsync(Guid userId);

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="user">Объект, представляющий данные нового пользователя.</param>
        /// <returns>Уникальный идентификатор созданного пользователя.</returns>
        Task<Guid> CreateUserAsync(UserDal user);

        /// <summary>
        /// Обновить информацию о пользователе.
        /// </summary>
        /// <param name="user">Объект, представляющий обновленные данные пользователя.</param>
        /// <returns>True, если обновление успешно, в противном случае - false.</returns>
        Task<bool> UpdateUserAsync(UserDal user);

        /// <summary>
        /// Удалить пользователя по его уникальному идентификатору.
        /// </summary>
        /// <param name="userId">Уникальный идентификатор пользователя.</param>
        /// <returns>True, если удаление успешно, в противном случае - false.</returns>
        Task<bool> DeleteUserAsync(Guid userId);
    }
}
