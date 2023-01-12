﻿// <copyright file="Customer.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Покупатель.
    /// </summary>
    public class Customer : IEquatable<Customer>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Customer"/>.
        /// </summary>
        /// <param name="lastName"> Фамилия. </param>
        /// <param name="firstName"> Имя. </param>
        /// <param name="middleName"> Отчество. </param>
        /// <param name="phoneNumber"> Номер телефона. </param>
        public Customer(string lastName, string firstName, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            this.Id = Guid.NewGuid();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.FullName =
                string.Concat(this.LastName, " ", this.FirstName);
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string FirstName { get; protected set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string LastName { get; protected set; }

        /// <summary>
        /// Полное имя.
        /// </summary>
        public string FullName { get; protected set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string PhoneNumber { get; protected set; }

        /// <summary>
        /// Заказы.
        /// </summary>
        public ISet<Order> Orders { get; set; } = new HashSet<Order>();

        /// <summary>
        /// Добавление заказов покупателю.
        /// </summary>
        /// <param name="order"> Заказ. </param>
        public void AddOrderToCustomer(Order order)
        {
            this.Orders.Add(order);
            order.Customer = this;
        }

        /// <inheritdoc/>
        public override string ToString()
            => this.FullName;

        /// <inheritdoc/>
        public bool Equals(Customer? other)
        {
            return Equals(this.Id, other?.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
            => this.Id.GetHashCode();
    }
}