using Core.Sagas.Events;
using Logic.Users.Interfaces;
using Logic.Users.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ProfileAPI.Controllers.User.Requests;
using ProfileAPI.Controllers.User.Responses;

namespace ProfileAPI.Controllers.User
{
    /// <summary>
    /// Контроллер для управления пользователями.
    /// </summary>
    [Route("public/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserLogicManager _userLogicManager;
        private readonly IBus _bus;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserLogicManager userLogicManager, IBus bus, ILogger<UserController> logger)
        {
            _userLogicManager = userLogicManager;
            _bus = bus;
            _logger = logger;
        }

        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="request">Данные запроса для создания пользователя.</param>
        /// <returns>Результат операции и информация о созданном пользователе.</returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(CreateUserResponse), 200)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequest request)
        {
            try
            {
                // Преобразование данных запроса в объект UserLogic
                var userLogic = new UserLogic
                {
                    Login = request.Login,
                    UserName = request.UserName,
                    Email = request.Email
                };

                // Вызов сервиса для создания пользователя
                var userId = await _userLogicManager.CreateUserAsync(userLogic);

                var response = new CreateUserResponse
                {
                    UserId = userId,
                    Success = true,
                    Message = "Пользователь успешно создан"
                };

                var userCreated = new UserCreated
                {
                    UserId = userId,
                    UserName = request.UserName,
                    Email = request.Email
                };
                
                await _bus.Publish(response);
                
                _logger.LogInformation($"Пользователь {userCreated.UserId} с именем {userCreated.UserName} создан + {userCreated.Email}");
                
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Success = false,
                    Message = $"Ошибка создания пользователя: {ex.Message}"
                };

                return BadRequest(errorResponse);
            }
        }

        /// <summary>
        /// Получение информации о пользователе по его идентификатору.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Результат операции и информация о пользователе.</returns>
        [HttpGet("get/{userId}")]
        [ProducesResponseType<UserInfoResponse>(200)]
        public async Task<IActionResult> GetUserAsync(Guid userId)
        {
            try
            {
                var userName = await _userLogicManager.GetUserNameAsync(userId);

                if (userName != null)
                {
                    var response = new
                    {
                        UserId = userId,
                        UserName = userName,
                        Success = true,
                        Message = "Пользователь получен успешно"
                    };

                    return Ok(response);
                }
                else
                {
                    var errorResponse = new ErrorResponse
                    {
                        Success = false,
                        Message = "Пользователь не найден"
                    };

                    return NotFound(errorResponse);
                }
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Success = false, 
                    Message = $"Ошибка получения информации о пользователе {ex.Message}",
                };

                return BadRequest(errorResponse);
            }
        }

        /// <summary>
        /// Удаление пользователя по его идентификатору.
        /// </summary>

        [HttpDelete("delete/{userId}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> DeleteUserAsync(Guid userId)
        {
            try
            {
                var success = await _userLogicManager.DeleteUserAsync(userId);

                if (success)
                {
                    return Ok(true);
                }
                else
                {
                    var errorResponse = new ErrorResponse
                    {
                        Success = false,
                        Message = "Пользователь не найден"
                    };

                    return NotFound(errorResponse);
                }
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Success = false,
                    Message = $"Ошибка удаления пользователя {ex.Message}",
                };

                return BadRequest(errorResponse);
            }
        }

        [HttpPut("update/{userId}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> UpdateUserAsync(Guid userId, [FromBody] CreateUserRequest request)
        {
            try
            {
                var userLogic = new UserLogic
                {
                    Login = request.Login,
                    UserName = request.UserName,
                    Email = request.Email
                };

                var success = await _userLogicManager.UpdateUserAsync(userId, userLogic);

                if (success)
                {
                    return Ok(true);
                }
                else
                {
                    var errorResponse = new ErrorResponse
                    {
                        Success = false,
                        Message = "Пользователь не найден"
                    };

                    return NotFound(errorResponse);
                }
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Success = false,
                    Message = $"Ошибка изменения данных пользователя {ex.Message}",
                };

                return BadRequest(errorResponse);
            }
        }
    }
}
