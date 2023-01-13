// <copyright file="Product.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Блюдо.
    /// </summary>
    public class Product : IEquatable<Product>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Product"/>.
        /// </summary>
        /// <param name="menuName"> Название блюда. </param>
        /// <param name="price"> Цена блюда. </param>
        /// <exception cref="ArgumentNullException"></exception>
        public Product(string menuName, decimal price)
        {
            if (string.IsNullOrWhiteSpace(menuName))
            {
                throw new ArgumentNullException(nameof(menuName));
            }

            if (price <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price));
            }

            this.Id = Guid.NewGuid();
            this.MenuName = menuName;
            this.Price = price;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Product"/>.
        /// Пустой конструктор для работы с ORM.
        /// </summary>
        [Obsolete("For ORM", true)]
        protected Product()
        {
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Название блюда.
        /// </summary>
        public virtual string MenuName { get; protected set; }

        /// <summary>
        /// Цена блюда.
        /// </summary>
        public virtual decimal Price { get; protected set; }

        /// <summary>
        /// Запись блюда в заказе.
        /// </summary>
        public virtual ListItem ListItem { get; set; }

        /// <inheritdoc/>
        public override string ToString()
            => this.MenuName + ", " + this.Price;

        /// <inheritdoc/>
        public virtual bool Equals(Product? other)
        {
            return Equals(this.Id, other?.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
            => this.Id.GetHashCode();
    }
}
