// <copyright file="CustomerMap.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

namespace DataAccessLayer.ORM
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс отображения Покупателя.
    /// </summary>
    internal class CustomerMap : ClassMap<Customer>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CustomerMap"/>.
        /// </summary>
        public CustomerMap()
        {
            this.Table("Customers");

            this.Id(x => x.Id);

            this.Map(x => x.LastName)
                .Length(50)
                .Not
                .Nullable();

            this.Map(x => x.FirstName)
                .Length(50)
                .Not
                .Nullable();

            this.Map(x => x.PhoneNumber)
                .Length(11)
                .Not
                .Nullable();

            this.HasMany(x => x.Orders)
                .Not.Inverse();
        }
    }
}