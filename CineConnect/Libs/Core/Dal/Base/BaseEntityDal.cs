using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dal.Base
{
    /// <summary>
    /// Базовая сущность для работы с сущностями в бд
    /// </summary>
    /// <typeparam name="T">тип идентификатор</typeparam>
    public record BaseEntityDal<T>
    {
        /// <summary>
        /// уникальный идентфиикатор сущности
        /// </summary>
        public T Id { get; init; }
    }
}
