using Dal.Users.Interfaces;
using Dal.Users.Models;
using Logic.Users.Interfaces;
using Logic.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Users
{
    /// <inheritdoc />
    internal class UserLogicManager : IUserLogicManager
    {
        private readonly IUserRepository _userRepository;

        public UserLogicManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc />
        public async Task<string> GetUserNameAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return user?.UserName;
        }

        public async Task<Guid> CreateUserAsync(UserLogic user)
        {
            var userDal = new UserDal
            {
                Login = user.Login,
                UserName = user.UserName,
                Email = user.Email
            };

            return await _userRepository.CreateUserAsync(userDal);
        }

        /// <inheritdoc />
        public async Task<bool> UpdateUserAsync(Guid userId, UserLogic user)
        {
            var userDal = new UserDal
            {
                UserId = userId,
                Login = user.Login,
                UserName = user.UserName,
                Email = user.Email
            };

            return await _userRepository.UpdateUserAsync(userDal);
        }

        /// <inheritdoc />
        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            return await _userRepository.DeleteUserAsync(userId);
        }
    }
}
