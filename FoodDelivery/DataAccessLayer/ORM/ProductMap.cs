// <copyright file="ProductMap.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

namespace DataAccessLayer.ORM
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс отображения Блюда.
    /// </summary>
    internal class ProductMap : ClassMap<Product>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ProductMap"/>.
        /// </summary>
        public ProductMap()
        {
            this.Table("Product");

            this.Id(x => x.Id);

            this.Map(x => x.MenuName)
                .Length(50)
                .Not
                .Nullable();

            this.Map(x => x.Price)
                .Length(10)
                .Not
                .Nullable();

            this.References(x => x.ListItem)
                .Not
                .Nullable();
        }
    }
}