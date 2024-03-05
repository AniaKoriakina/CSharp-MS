using Dal.Users.Interfaces;
using Dal.Users.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Dal.Users
{
    internal class UserRepository : IUserRepository
    {
        private static readonly ConcurrentDictionary<Guid, UserDal> Store = new();

        /// <inheritdoc />
        public async Task<string> GetUserNameAsync(Guid userId)
        {
            if (Store.TryGetValue(userId, out var user))
            {
                return user.UserName;
            }

            throw new Exception("Имя пользователя не найдено");
        }

        /// <inheritdoc />
        public async Task<Guid> CreateUserAsync(UserDal user)
        {
            if (user.UserId == Guid.Empty)
            {
                user = user with { UserId = Guid.NewGuid() };
            }

            if (Store.TryAdd(user.UserId, user))
            {
                return user.UserId;
            }

            throw new Exception("Ошибка добавления пользователя");
        }

        /// <inheritdoc />
        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            return Store.TryRemove(userId, out _);
        }

        /// <inheritdoc />
        public async Task<UserDal> GetUserByIdAsync(Guid userId)
        {
            if (Store.TryGetValue(userId, out var user))
            {
                return user;
            }
            throw new Exception("Пользователь не найден");
        }

        /// <inheritdoc />
        public async Task<bool> UpdateUserAsync(UserDal user)
        {
            if (Store.ContainsKey(user.UserId))
            {
                Store[user.UserId] = user;
                return true;
            }
            throw new Exception("Ошибка удаления пользователя");
        }
    }
}
