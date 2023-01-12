﻿// <copyright file="Product.cs" company="ActiVia">
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
        /// <param name="listItem"> Запись блюда в заказе. </param>
        /// <exception cref="ArgumentNullException"></exception>
        public Product(string menuName, decimal price, ListItem listItem)
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
            this.ListItem = listItem ?? throw new ArgumentNullException(nameof(listItem));
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Название блюда.
        /// </summary>
        public string MenuName { get; protected set; }

        /// <summary>
        /// Цена блюда.
        /// </summary>
        public decimal Price { get; protected set; }

        /// <summary>
        /// Запись блюда в заказе.
        /// </summary>
        public ListItem ListItem { get; set; }

        /// <inheritdoc/>
        public override string ToString()
            => this.MenuName + ", " + this.Price;

        /// <inheritdoc/>
        public bool Equals(Product? other)
        {
            return Equals(this.Id, other?.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
            => this.Id.GetHashCode();
    }
}
