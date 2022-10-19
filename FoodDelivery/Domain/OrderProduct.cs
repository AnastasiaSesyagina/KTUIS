// <copyright file="OrderProduct.cs" company="Дюдя, Капанин, Паньков & Сесягина">
// Copyright (c) Дюдя В. А., Капанин А. А., Паньков Р. В., Сесягина А. А. 2022.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Продукты в заказе.
    /// </summary>
    public class OrderProduct
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        // !!!Еще должны быть ссылки на Order(ID) и Product(ID)
    }
}
