// <copyright file="Order.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

using System;

namespace Domain
{
    /// <summary>
    /// Заказ.
    /// </summary>
    public class Order : IEquatable<Order>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Order"/>.
        /// </summary>
        /// <param name="address"> Адрес доставки. </param>
        /// <param name="customer"> Покупатель. </param>
        /// <param name="getTime"> Время получения заказа. </param>
        /// <param name="deliveryTime"> Время доставки заказа. </param>
        /// <exception cref="ArgumentNullException">Выброс ошибки.</exception>

        public Order(string address, Customer customer, DateTime getTime, DateTime deliveryTime)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentNullException(nameof(address));
            }

            this.Id = Guid.NewGuid();
            this.Address = address;
            this.Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            this.GetTime = getTime;
            this.DeliveryTime = deliveryTime;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Order"/>.
        /// Пустой конструктор для работы с ORM.
        /// </summary>
        [Obsolete("For ORM", true)]
        protected Order()
        {
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Адрес доставки заказа.
        /// </summary>
        public virtual string Address { get; protected set; }

        /// <summary>
        /// Время получения заказа.
        /// </summary>
        public virtual DateTime GetTime { get; protected set; }

        /// <summary>
        /// Время доставки заказа.
        /// </summary>
        public virtual DateTime DeliveryTime { get; protected set; }

        /// <summary>
        /// Покупатель.
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Записи блюд в заказе.
        /// </summary>
        public virtual ISet<ListItem> ListItems { get; set; } = new HashSet<ListItem>();

        /// <summary>
        /// Добавление записи блюда в заказ.
        /// </summary>
        /// <param name="listItem"> Запись блюда в заказе. </param>
        public virtual void AddListItemToOrder(ListItem listItem)
        {
            this.ListItems.Add(listItem);
            listItem.Order = this;
        }

        /// <inheritdoc/>
        public virtual bool Equals(Order? other)
        {
            return Equals(this.Id, other?.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
            => this.Id.GetHashCode();
    }
}
