using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.HttpLogic.Services.Interfaces
{
    /// <summary>
    /// Функционал для HTTP-соединения
    /// </summary>
    public interface IHttpConnectionService
    {
        /// <summary>
        /// Создание клиента для HTTP-подключения
        /// </summary>
        /// <exception cref="HttpConnectionException"></exception>
        HttpClient CreateHttpClient(HttpConnectionData httpConnectionData);

        /// <summary>
        /// Отправляет HTTP-запрос.
        /// </summary>
        /// <param name="httpRequestMessage">HTTP-запрос для отправки.</param>
        /// <param name="httpClient">HTTP-клиент для использования при отправке запроса.</param>
        /// <param name="cancellationToken">Токен отмены для отмены операции.</param>
        /// <param name="httpCompletionOption">Опция завершения HTTP-запроса.</param>
        /// <returns>Ответ на HTTP-запрос.</returns>
        /// <exception cref="HttpConnectionException">Исключение, возникающее при проблемах с HTTP-соединением.</exception>
        Task<HttpResponseMessage> SendRequestAsync(
            HttpRequestMessage httpRequestMessage,
            HttpClient httpClient,
            CancellationToken cancellationToken,
            HttpCompletionOption httpCompletionOption = HttpCompletionOption.ResponseContentRead);
    }
}
