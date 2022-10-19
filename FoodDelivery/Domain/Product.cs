// <copyright file="Product.cs" company="Дюдя, Капанин, Паньков & Сесягина">
// Copyright (c) Дюдя В. А., Капанин А. А., Паньков Р. В., Сесягина А. А. 2022.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Блюдо.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Product"/>.
        /// </summary>
        /// <param name="menuName"> Название блюда.</param>
        /// <param name="price"> Цена блюда.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Product(string menuName, double price)
        {
            this.MenuName = menuName ?? throw new ArgumentNullException(nameof(menuName));
            this.Price = price;
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Название блюда.
        /// </summary>
        public string MenuName { get; }

        /// <summary>
        /// Цена блюда.
        /// </summary>
        public double Price { get; }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is not Product)
            {
                return false;
            }

            return Equals((obj as Product)?.Id, this.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
            => this.Id.GetHashCode();
    }
}
