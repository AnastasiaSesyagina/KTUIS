// <copyright file="OrderMap.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

namespace DataAccessLayer.ORM
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс отображения Заказа.
    /// </summary>
    internal class OrderMap : ClassMap<Order>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="OrderMap"/>.
        /// </summary>
        public OrderMap()
        {
            this.Table("Orders");

            this.Id(x => x.Id);

            this.Map(x => x.Address)
                .Length(50)
                .Not
                .Nullable();

            this.References(x => x.Customer);

            this.Map(x => x.GetTime)
                .Not
                .Nullable();

            this.Map(x => x.DeliveryTime)
                .Not
                .Nullable();

            this.HasMany(x => x.ListItems)
                .Not
                .Inverse();
        }
    }
}