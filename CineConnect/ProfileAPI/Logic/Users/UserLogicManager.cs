using Dal.Users.Interfaces;
using Dal.Users.Models;
using Logic.Users.Interfaces;
using Logic.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Semaphore;

namespace Logic.Users
{
    /// <inheritdoc />
    internal class UserLogicManager : IUserLogicManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IDistributedSemaphore _semaphore;
        private const string SemaphoreKey = "profile_creation";
        private static readonly TimeSpan SemaphoreTimeout = TimeSpan.FromSeconds(30);

        public UserLogicManager(IUserRepository userRepository, IDistributedSemaphore semaphore)
        {
            _userRepository = userRepository;
            _semaphore = semaphore;
        }

        /// <inheritdoc />
        public async Task<string> GetUserNameAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return user?.UserName;
        }

        public async Task<Guid> CreateUserAsync(UserLogic user)
        {
            if (!await _semaphore.WaitAsync(SemaphoreKey, SemaphoreTimeout))
            {
                try
                {
                    var userDal = new UserDal
                    {
                        Login = user.Login,
                        UserName = user.UserName,
                        Email = user.Email
                    };
                    return await _userRepository.CreateUserAsync(userDal);
                }
                finally
                {
                    await _semaphore.ReleaseAsync(SemaphoreKey);
                }
            }
            else
            {
                throw new Exception($"Timeout {SemaphoreKey}");
            }
        }

        /// <inheritdoc />
        public async Task<bool> UpdateUserAsync(Guid userId, UserLogic user)
        {
            var userDal = new UserDal
            {
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
