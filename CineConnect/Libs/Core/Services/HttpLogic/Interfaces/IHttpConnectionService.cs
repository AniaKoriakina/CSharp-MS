﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.HttpLogic.Interfaces
{
    public interface IHttpConnectionService
    {
        /// <summary>
        /// Создание клиента для HTTP-подключения
        /// </summary>
        /// <exception cref="HttpConnectionException"></exception>
        HttpClient CreateHttpClient(HttpConnectionData httpConnectionData);

        /// <summary>
        /// Отправть HTTP-запрос
        /// </summary>
        /// <exception cref="HttpConnectionException"></exception>
        Task<HttpResponseMessage> SendRequestAsync(
            HttpRequestMessage httpRequestMessage,
            HttpClient httpClient,
            CancellationToken cancellationToken,
            HttpCompletionOption httpCompletionOption = HttpCompletionOption.ResponseContentRead);
    }
}
