// <copyright file="Order.cs" company="Дюдя, Капанин, Паньков & Сесягина">
// Copyright (c) Дюдя В. А., Капанин А. А., Паньков Р. В., Сесягина А. А. 2022.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Заказ.
    /// </summary>
    public class Order
    {
        private string getTime;
        private string deliveryTime;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Order"/>.
        /// </summary>
        /// <param name="adress"> Адрес доставки заказа.</param>
        /// <param name="getHours"> Час поступления заказа.</param>
        /// <param name="getMinutes"> Минута поступления заказа.</param>
        /// <param name="getSeconds"> Секунда поступления заказа.</param>
        /// <param name="deliveryHours"> Час доставки заказа.</param>
        /// <param name="deliveryMinutes"> Минута доставки заказа.</param>
        /// <param name="deliverySeconds"> Секунда доставки заказа.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Order(string adress, uint getHours, uint getMinutes, uint getSeconds, uint deliveryHours, uint deliveryMinutes, uint deliverySeconds)
        {
            this.Adress = adress ?? throw new ArgumentNullException(nameof(adress));
            this.GetHours = getHours;
            this.GetMinutes = getMinutes;
            this.GetSeconds = getSeconds;
            this.getTime = this.GetTime;
            this.DeliveryHours = deliveryHours;
            this.DeliveryMinutes = deliveryMinutes;
            this.DeliverySeconds = deliverySeconds;
            this.deliveryTime = this.DeliveryTime;
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Адрес доставки заказа.
        /// </summary>
        public string Adress { get; }

        /// <summary>
        /// Час поступления заказа.
        /// </summary>
        public uint GetHours { get; }

        /// <summary>
        /// Минута поступления заказа.
        /// </summary>
        public uint GetMinutes { get; }

        /// <summary>
        /// Секунда поступления заказа.
        /// </summary>
        public uint GetSeconds { get; }

        /// <summary>
        /// Час доставки заказа.
        /// </summary>
        public uint DeliveryHours { get; }

        /// <summary>
        /// Минута доставки заказа.
        /// </summary>
        public uint DeliveryMinutes { get; }

        /// <summary>
        /// Секунда доставки заказа.
        /// </summary>
        public uint DeliverySeconds { get; }

        /// <summary>
        /// Время поступления заказа.
        /// </summary>
        public string GetTime
        {
            get => this.getTime;
            set
            {
                if (this.GetHours < 24 && this.GetMinutes < 60 && this.GetSeconds < 60)
                {
                    this.getTime = string.Concat(this.GetHours, ":", this.GetMinutes, ":", this.GetSeconds);
                }
                else
                {
                    throw new ArgumentNullException("Invalid get-time specified");
                }
            }
        }

        /// <summary>
        /// Время доставки заказа.
        /// </summary>
        public string DeliveryTime
        {
            get => this.deliveryTime;
            set
            {
                if (this.DeliveryHours < 24 && this.DeliveryMinutes < 60 && this.DeliverySeconds < 60)
                {
                    this.deliveryTime = string.Concat(this.DeliveryHours, ":", this.DeliveryMinutes, ":", this.DeliverySeconds);
                }
                else
                {
                    throw new ArgumentNullException("Invalid delivery-time specified");
                }
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is not Order)
            {
                return false;
            }

            return Equals((obj as Order)?.Id, this.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
            => this.Id.GetHashCode();

        // !!!Еще должны быть ссылки на Person (CustomerID и CourierID)
    }
}
